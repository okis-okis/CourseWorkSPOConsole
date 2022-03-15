using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleProject
{
    internal class Program
    {
        static Lexer lexer;

        static void Main(string[] args)
        {
            //Get code for processing
            String input = File.ReadAllText("test.c");
            Console.WriteLine(input);

            //Spend lexical analysis
            lexer = new Lexer(input);
            Token[] tokens = lexer.lex();

            findValues(tokens);

            //Output result of lexical analysis
            List<Token> errorToken = new List<Token>();
            int error = 0;
            
            foreach (Token token in tokens)
            {
                printTokenInfo(token);

                if (token.getTokenID() == new TokenTypes().NOP)
                {
                    error++;
                    errorToken.Add(token);
                }

                Console.WriteLine();
            }

            if (error == 0)
            {
                Console.WriteLine("Лексические ошибки не найдены");

                //PARSER
                Parser parser = new Parser(tokens);
                Node AST = parser.parse();
                parser.outputVar();

                //Interpreter interpreter = new Interpreter(AST);
                Console.WriteLine("Work!");
                //Spend syntax analysis

                Interpreter interpreter = new Interpreter(AST);
                interpreter.interpret(parser.getVarArray());

                //Console.WriteLine("Result is: " + interpreter.interpret());

            }
            else
            {
                Console.WriteLine("==========================");
                Console.WriteLine("Количество ошибок: " + error);
                foreach (Token token in errorToken)
                {
                    printTokenInfo(token);
                }
            }

        }

        static void printTokenInfo(Token token)
        {
            Console.WriteLine("Token:");
            Console.WriteLine("Words: " + token.getToken());
            Console.WriteLine("Token type: " +
                            new TokenTypes().getTokenType(token.getTokenID())
                            );
            Console.WriteLine("Token id: " + token.getTokenID());
        }

        static void findValues(Token[] tokens)
        {

            foreach (Token token in tokens)
            {
                if (token.getTokenID() == new TokenTypes().Num)
                {
                    bool found = false;
                    foreach (String val in lexer.getValues())
                    {
                        if (val.Equals(token.getToken()))
                        {
                            found = true; break;
                        }
                    }
                    if (!found)
                    {
                        lexer.addValue(token.getToken());
                    }
                }
                else if (token.getTokenID() == new TokenTypes().Id)
                {
                    bool found = false;
                    foreach (Char var in lexer.getUsedVarNames())
                    {
                        if (var == token.getToken()[0])
                        {
                            found = true; break;
                        }
                    }
                    if (!found)
                    {
                        lexer.addVarName(token.getToken()[0]);
                    }
                }
            }
        }
    }

    //###################################//
    //          INTEPRETER               //
    //###################################//

}
