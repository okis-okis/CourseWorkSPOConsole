//Author:   Kiselnik Oleg
//Group:    SCS-19
//Project:  Simple interpreter of C language
//Purpose:  Read source code and convert it to NASM code
//          After this execute compile

//===================================//
//                                   //
//              ONYX                 //
//                                   //
//===================================//


//Using library
using System;
using System.Collections.Generic;
using System.IO;

namespace Onyx
{
    internal class Program
    {
        static Lexer lex;

        static void Main(string[] args)
        {
            //Read source code from test.c file
            String input = File.ReadAllText("test.c");

            lex = new Lexer(input);
            Token[] tokenList = lex.scan();

            findValues(tokenList);

            //Output result of lexical analysis
            List<Token> errorToken = new List<Token>();
            int error = 0;

            foreach (Token token in tokenList)
            {
                printTokenInfo(token);

                if (token.getTokenType() == TokenTypes.NOP)
                {
                    error++;
                    errorToken.Add(token);
                }

                Console.WriteLine();
            }
        }

        static void printTokenInfo(Token token)
        {
            Console.WriteLine("Token:");
            Console.WriteLine("Words: " + token.getToken());
            Console.WriteLine("Token id: " + token.getTokenType());
        }

        static void findValues(Token[] tokens)
        {
            foreach (Token token in tokens)
            {
                if (new TokenDeclaration().isNumber(token.getToken()))
                {
                    bool found = false;
                    foreach (String val in lex.getValues())
                    {
                        if (val.Equals(token.getToken()))
                        {
                            found = true; break;
                        }
                    }
                    if (!found)
                    {
                        lex.addValue(token.getToken());
                    }
                }
                else if (token.getTokenType() == TokenTypes.var)
                {
                    bool found = false;
                    foreach (Char var in lex.getUsedVarNames())
                    {
                        if (var == token.getToken()[0])
                        {
                            found = true; break;
                        }
                    }
                    if (!found)
                    {
                        lex.addVarName(token.getToken()[0]);
                    }
                }
            }
        }
    }
}
