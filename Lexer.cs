//Author:   Kiselnik Oleg
//Group:    SCS-19
//Project:  Simple interpreter of C language
//Purpose:  Spend lexical analysis

using System;
using System.Collections.Generic;

namespace Onyx
{
    //Interface of class for better module mobility
    interface ILexer
    {
        Token[] scan();
        String[] getDelimiter();
        String getVarNames();
        String[] getSystemWords();

        Char[] getUsedVarNames();
    }

    //Class of lexical analysis
    class Lexer : ILexer
    {
        //Using variables
        //Source code
        public String inputText;

        //Variables list
        private List<String> values;
        private List<Char> varNames;

        //Special symbols and words for tokenizer
        private String[] delimiter;
        private String id;
        private String[] systemWord;
        
        //If found skip symbols
        private bool skip;

        //Constructor
        public Lexer()
        {
            values = new List<String>();
            varNames = new List<Char>();
            skip = false;

            id = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            systemWord = new String[]{
                //Data types
                "int",
                "float",
                "bool",
                "double",
                "char",
                //Operators
                "for",
                "if",
                "else",
                "goto",
                "printf",
                "scanf",
                "OR",
                "AND",
                "NOT",
                //Enter point
                "main",
                "return"
            };
            delimiter = new String[]{
                ";", "==",">=",
                "<=", "!=", "=",
                ">", "<", "+",
                "-", "*", "/",
                "\n", "(", ")",
                ",", "{", "}",
                "[", "]"
            };
        }

        //Constructor with get source code
        public Lexer(String input) : this()
        {
            //Process of delete comments and superfluous
            inputText = deleteSuperfluousSpaces(deleteComments(input));
        }

        //Public function for scan code
        //As result will get token list
        public Token[] scan()
        {
            //Find using string
            findString(inputText);

            //Get sort list by string length
            List<String> cpValues = sortByLength(new List<String>(values));

            //Form token list
            List<Token> tokens = new List<Token>();

            String temp = "";
            //Find tokens loop
            for (int i = 0; i < inputText.Length; i++)
            {
                bool next = false;

                //Check if string

                for (int j = 0; j < cpValues.Count; j++)
                {
                    if (i + cpValues[j].Length <= inputText.Length)
                    {
                        if (inputText.Substring(i, cpValues[j].Length).Contains(cpValues[j]))
                        {
                            for (int d = 0; d < values.Count; d++)
                            {
                                if (cpValues[j].Equals(values[d]))
                                {
                                    tokens.Add(new Token(cpValues[j]));
                                    break;
                                }
                            }
                            i += cpValues[j].Length - 1;
                            next = true;
                            break;
                        }
                    }
                }

                //If found string, then continue
                if (next)
                {
                    continue;
                }

                //Check if end of token
                if (inputText[i] == ' ' || inputText[i] == '\r' || inputText[i] == '\n')
                {
                    if (temp != "" && temp != null)
                    {
                        tokens.Add(new Token(temp));
                        temp = "";
                    }
                    continue;
                }

                //Check if delimiter
                foreach (String del in delimiter)
                {
                    if (i + del.Length <= inputText.Length)
                    {
                        if (inputText.Substring(i, del.Length).Contains(del))
                        {
                            if (temp != "")
                            {
                                tokens.Add(new Token(temp));
                                temp = "";
                            }

                            tokens.Add(new Token(del));
                            i += del.Length - 1;

                            next = true;

                            break;
                        }
                    }
                }

                //If delimiter found, then continue
                if (next)
                {
                    continue;
                }

                //Formation of token word
                temp += inputText[i];
            }

            if (temp != null && temp != "")
            {
                tokens.Add(new Token(temp));
            }

            return tokens.ToArray();
        }

        //Private function for add value to table
        public void addValue(String val)
        {
            values.Add(val);
        }

        //Private function for add (declaration) of variable name
        public void addVarName(Char var)
        {
            varNames.Add(var);
        }

        //Get using values
        public String[] getValues()
        {
            return values.ToArray();
        }

        //Get lexer delimiters
        public String[] getDelimiter()
        {
            return delimiter;
        }

        //Get list of available variable names
        public String getVarNames()
        {
            return id;
        }

        public String[] getSystemWords()
        {
            return systemWord;
        }

        //Get list of used variables name
        public Char[] getUsedVarNames()
        {
            return varNames.ToArray();
        }

        private void findString(String input)
        {
            String[] arr = input.Split('\"');
            for (int i = 1; i < arr.Length; i += 2)
            {
                Boolean find = false;
                foreach (String val in values)
                {
                    if (('\"' + arr[i] + '\"') == val)
                    {
                        find = true;
                        break;
                    }
                }
                if (!find)
                {
                    values.Add('\"' + arr[i] + '\"');
                }
            }
        }

        private String deleteSuperfluousSpaces(String input)
        {
            String result = "";
            int count = 0;
            foreach (Char c in input)
            {
                if (c == '\t')
                {
                    continue;
                }
                else if (c == ' ')
                {
                    if (count == 0)
                    {
                        count++;
                        result += ' ';
                    }
                }
                else
                {
                    if (count != 0)
                    {
                        count = 0;
                    }
                    result += c;
                }
            }
            return result;
        }

        private String deleteComments(String input)
        {
            String result = "";

            foreach (String line in input.Split('\n'))
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '/' && i + 1 < line.Length)
                    {
                        if (line[i + 1] == '/')
                        {
                            break;
                        }
                        else if (line[i + 1] == '*')
                        {
                            skip = true;
                            i++;
                            continue;
                        }
                    }
                    else if (line[i] == '*' && i + 1 < line.Length)
                    {
                        if (line[i + 1] == '/' && skip)
                        {
                            skip = false;
                            i++;
                            continue;
                        }
                    }

                    if (!skip)
                    {
                        result += line[i];
                    }
                }
            }

            return result;
        }

        private List<String> sortByLength(List<String> arr)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = i; j < arr.Count; j++)
                {
                    if (arr[i].Length < arr[j].Length)
                    {
                        String temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

            return arr;
        }
    }
}
