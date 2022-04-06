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
        private List<String> points;

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
            points = new List<String>();

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
                "return",
                //Logical value
                "true",
                "false"
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
            inputText = prepareText(input);
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
                if (inputText[i] == ' ' || 
                    inputText[i] == '\r' || 
                    inputText[i] == '\n')
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

            findValues(tokens.ToArray());

            findPoints(tokens.ToArray());

            return tokens.ToArray();
        }

        public void findPoints(Token[] tokens)
        {
            foreach (Token token in tokens)
            {
                if(token.getTokenType() == TokenTypes.point)
                {
                    points.Add(token.getToken().Substring(0, token.getToken().Length-1));
                }
            }

            foreach (Token token in tokens)
            {
                if (token.getTokenType() == TokenTypes.NOP)
                {
                    foreach(String point in points)
                    {
                        if(point == token.getToken())
                        {
                            token.setTokenType(TokenTypes.point);
                        }
                    }
                }
            }
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

        //Function find strings in code and add to string list
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

        //Function for code prepare (delete superfluous, new lines and comments)
        private string prepareText(String input)
        {
            return deleteSuperfluousSpaces(deleteNewLineChar(deleteComments(input)));
        }

        //Function for delete new lines from source code
        private string deleteNewLineChar(String input)
        {
            String result = "";
            foreach(char c in input)
            {
                if(c == '\n' || c == '\t')
                {
                    result += ' ';
                    continue;
                }
                result += c;
            }
            return result;
        }

        //Function for delete superfluous spaces from source code
        private String deleteSuperfluousSpaces(String input)
        {
            String result = "";
            int count = 0;
            foreach (Char c in input)
            {
                if (c == ' ')
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

        //Function for delete comments from source code
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

        //Function return sorted by length array. Need for
        //need for exact string finding
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

        //Function for define values from source code
        private void findValues(Token[] tokens)
        {
            foreach (Token token in tokens)
            {
                if (new TokenDeclaration().isNumber(token.getToken()))
                {
                    bool found = false;
                    foreach (String val in getValues())
                    {
                        if (val.Equals(token.getToken()))
                        {
                            found = true; break;
                        }
                    }
                    if (!found)
                    {
                        addValue(token.getToken());
                    }
                }
                else if (token.getTokenType() == TokenTypes.var)
                {
                    bool found = false;
                    foreach (Char var in getUsedVarNames())
                    {
                        if (var == token.getToken()[0])
                        {
                            found = true; break;
                        }
                    }
                    if (!found)
                    {
                        addVarName(token.getToken()[0]);
                    }
                }
            }
        }
    }
}
