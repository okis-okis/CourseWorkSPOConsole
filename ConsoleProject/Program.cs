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
            String input = File.ReadAllText("test.c");
            Console.WriteLine(input);

            lexer = new Lexer(input);
            Token[] tokens = lexer.lex();

            findValues(tokens);

            List<Token> errorToken = new List<Token>();
            int error = 0;

            foreach(Token token in tokens)
            {
                printTokenInfo(token);

                if(token.getTokenID() == new TokenTypes().NOP)
                {
                    error++;
                    errorToken.Add(token);
                }

                Console.WriteLine();
            }

            if (error==0)
            {
                Console.WriteLine("Ошибки не найдены");
            }
            else
            {
                Console.WriteLine("==========================");
                Console.WriteLine("Количество ошибок: "+error);
                foreach(Token token in errorToken)
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

            foreach(Token token in tokens)
            {
                if (token.getTokenID() == new TokenTypes().Num)
                {
                    bool found = false;
                    foreach(String val in lexer.getValues())
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
                else if(token.getTokenID() == new TokenTypes().Id)
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

    interface ILexer
    {
        public Token[] lex();
        public String[] getDelimiter();
        public String getVarNames();
        public String[] getSystemWords();

        public Char[] getUsedVarNames();
    }

    class Lexer: ILexer
    {
        public String inputText;

        private List <String> values;
        private List <Char> varNames;

        private String[] delimiter;
        private String id;
        private String[] systemWord;

        public Lexer()
        {
            values = new List<String>();
            varNames = new List<Char>();

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

        public Lexer(String input):this()
        {
            inputText = deleteSuperfluousSpaces(deleteComments(input));
        }

        public Token[] lex()
        {
            //1 Определить значение
            //Определение токенов
            findString(inputText);
            //findNumbers(inputText);
            //findId(inputText);

            List<String> cpValues = sortByLength(new List<String>(values));
            
            //2 Получение токенов

            List<Token> tokens = new List<Token>();

            String temp = "";
            for(int i = 0; i < inputText.Length; i++)
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
                foreach(String del in delimiter)
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


            /*for (int i = 0; i < inputText.Length; i++)
            {
                if(inputText[i] == 32 || inputText[i] == '\r')
                {
                    continue;
                }
                Boolean cont = false;
                //Check system words
                for (int j = 0; j < systemWord.Length; j++)
                {
                    if (i + systemWord[j].Length <= inputText.Length)
                    {
                        if (inputText.Substring(i, systemWord[j].Length).Contains(systemWord[j]))
                        {
                            tokens.Add(new Token(systemWord[j]));
                            i += systemWord[j].Length - 1;
                            cont = true;
                            break;
                        }
                    }
                }

                //if find needed word - continue
                if (cont)
                {
                    continue;
                }

                //Check delimiters
                for (int j = 0; j < delimiter.Length; j++)
                {

                    if (i + delimiter[j].Length <= inputText.Length)
                    {
                        if (inputText.Substring(i, delimiter[j].Length).Contains(delimiter[j]))
                        {
                            tokens.Add(new Token(delimiter[j]));
                            i += delimiter[j].Length - 1;
                            cont = true;
                            break;
                        }
                    }
                }

                if (cont)
                {
                    continue;
                }

                //Check value
                for (int j = 0; j < cpValues.Count; j++)
                {
                    if (i + cpValues[j].Length <= inputText.Length)
                    {
                        if (inputText.Substring(i, cpValues[j].Length).Contains(cpValues[j]))
                        {
                            for (int d = 0; d < values.Count; d++)
                            {
                                String test1 = cpValues[j];
                                String test2 = values[d];
                                //if (cpValues[j].Equals(values[d]))
                                if(test1==test2)
                                {
                                    tokens.Add(new Token(cpValues[j]));
                                    break;
                                }
                            }
                            i += cpValues[j].Length - 1;
                            cont = true;
                            break;
                        }
                    }
                }

                if (cont)
                {
                    continue;
                }

                //Check var names
                for (int j = 0; j < varNames.Count; j++)
                {
                    if (inputText[i] == varNames[j])
                    {
                        tokens.Add(new Token(Convert.ToString(varNames[j])));
                        cont = true;
                        break;
                    }
                }

                if (cont)
                {
                    continue;
                }

                tokens.Add(new Token(Convert.ToString(inputText[i])));
            }*/

            return tokens.ToArray();
        }

        public void addValue(String val)
        {
            values.Add(val);
        }

        public void addVarName(Char var)
        {
            varNames.Add(var);
        }

        public String[] getValues()
        {
            return values.ToArray();
        }

        public String[] getDelimiter()
        {
            return delimiter;
        }

        public String getVarNames()
        {
            return id;
        }

        public String[] getSystemWords()
        {
            return systemWord;
        }

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
                foreach(String val in values)
                {
                    if(('\"' + arr[i] + '\"') == val)
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
                    }
                    result += line[i];
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

    class TokenTypes
    {
        //Operators
        public byte Plus
        {
            get { return 0; }
        }
        public byte Minus
        {
            get { return 1; }
        }
        public byte Mul
        {
            get { return 2; }
        }
        public byte Div
        {
            get { return 3; }
        }
        //DataType
        public byte Logical
        {
            get { return 4; }
        }
        public byte Num
        {
            get { return 5; }
        }
        public byte String
        {
            get { return 6; }
        }
        //Variable Name
        public byte Id
        {
            get { return 7; }
        }
        //Block
        public byte Block
        {
            get { return 8; }
        }
        //SystemWord
        public byte SysWord
        {
            get { return 9; }
        }
        //Delimiters
        public byte Delimiter
        {
            get { return 10; }
        }
        //NOP
        public byte NOP
        {
            get { return 11; }
        }

        public Boolean isOperator(String s)
        {
            if(s == null || s == "")
            {
                return false;
            }
            if (isPlus(s[0]))
            {
                return true;
            }
            else if (isMinus(s[0]))
            {
                return true;
            }
            else if (isMul(s[0]))
            {
                return true;
            }
            else if (isDiv(s[0]))
            {
                return true;
            }
            return false;
        }

        public Boolean isNumber(String s)
        {
            try
            {
                if (Convert.ToString(
                    Convert.ToInt32(s)
                    ) == s)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return false;
        }

        public Boolean isSystemWord(String s)
        {
            foreach (String word in new Lexer().getSystemWords())
            {
                if (s == word)
                {
                    return true;
                }
            }
            return false;
        }

        public Boolean isVarName(String s)
        {
            if (s.Length == 1)
            {
                foreach (Char name in new Lexer().getVarNames())
                {
                    if(s[0] == name)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public Boolean isDelimiter(String s)
        {
            foreach(String del in new Lexer().getDelimiter())
            {
                if(s == del)
                {
                    return true;
                }
            }

            return false;
        }

        public Boolean isString(String s)
        {
            if (s.Length > 1)
            {
                if (s[0] == '"' && s[s.Length - 1] == '"')
                {
                    return true;
                }
            }
            return false;
        }

        public byte getOperator(String s)
        {
            if (isPlus(s[0]))
            {
                return Plus;
            }
            else if (isMinus(s[0]))
            {
                return Minus;
            }
            else if (isMul(s[0]))
            {
                return Mul;
            }
            else if (isDiv(s[0]))
            {
                return Div;
            }
            return 0;
        }

        public String getTokenType(byte tokenID)
        {
            if (tokenID == Plus)
            {
                return "PLUS";
            }
            else if (tokenID == Minus)
            {
                return "MINUS";
            }
            else if (tokenID == Div)
            {
                return "DIVISION";
            }
            else if(tokenID == Mul)
            {
                return "MULTIPLICATE";
            }
            else if(tokenID == Logical)
            {
                return "LOGICAL";
            }
            else if(tokenID == Num)
            {
                return "NUMBER";
            }
            else if(tokenID == Block)
            {
                return "BLOCK";
            }
            else if(tokenID == Id)
            {
                return "VARNAME";
            }
            else if(tokenID == SysWord)
            {
                return "SYSTEM WORD";
            }
            else if(tokenID == Delimiter)
            {
                return "DELIMITER";
            }
            else if(tokenID == String)
            {
                return "STRING";
            }
            else
            {
                return "NOP";
            }
        }

        public Boolean isPlus(char input)
        {
            return input == '+' ?  true : false;
        }

        public Boolean isMinus(char input)
        {
            return input == '-' ? true : false;
        }

        public Boolean isMul(char input)
        {
            return input == '*' ? true : false;
        }

        public Boolean isDiv(char input)
        {
            return input == '/' ? true : false;
        }
    }

    class Token
    {
        private String token;
        public byte tokenId;

        public Token(String token)
        {
            this.token = token;
            TokenTypes tokenTypes = new TokenTypes();
            if(tokenTypes.isOperator(this.token))
            {
                this.tokenId = tokenTypes.getOperator(this.token);
            }
            else if (tokenTypes.isNumber(this.token))
            {
                this.tokenId = tokenTypes.Num;
            }
            else if (tokenTypes.isSystemWord(this.token)){
                this.tokenId = tokenTypes.SysWord;
            }
            else if (tokenTypes.isVarName(this.token))
            {
                this.tokenId = tokenTypes.Id;
            }
            else if (tokenTypes.isDelimiter(this.token))
            {
                this.tokenId = tokenTypes.Delimiter;
            }
            else if (tokenTypes.isString(this.token))
            {
                this.tokenId = tokenTypes.String;
            }
            else
            {
                this.tokenId = tokenTypes.NOP;
            }
        }

        public byte getTokenID()
        {
            return tokenId;
        }

        public String getToken()
        {
            return this.token;
        }


    }
}
