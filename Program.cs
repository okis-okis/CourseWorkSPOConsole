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

            //Output result of lexical analysis
            outputLexicalAnalysisResult(tokenList);
        }

        static void outputLexicalAnalysisResult(Token[] tokenList)
        {
            List<Token> errorToken = new List<Token>();
            int error = 0;

            foreach (Token token in tokenList)
            {
                token.printTokenInfo();

                if (token.getTokenType() == TokenTypes.NOP)
                {
                    error++;
                    errorToken.Add(token);
                }

                Console.WriteLine();
            }

            if (error != 0)
            {
                Console.WriteLine("==========================");
                Console.WriteLine("Error count: " + error);
                foreach (Token token in errorToken)
                {
                    token.printTokenInfo();
                }

                Environment.Exit(1);
            }
            Console.WriteLine("Lexical analysis did successful");
        }
    }
}
