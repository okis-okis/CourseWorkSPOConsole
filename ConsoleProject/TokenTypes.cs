using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject
{
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
            if (s == null || s == "" || s.Length > 1)
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
                    if (s[0] == name)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public Boolean isDelimiter(String s)
        {
            foreach (String del in new Lexer().getDelimiter())
            {
                if (s == del)
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
            else if (tokenID == Mul)
            {
                return "MULTIPLICATE";
            }
            else if (tokenID == Logical)
            {
                return "LOGICAL";
            }
            else if (tokenID == Num)
            {
                return "NUMBER";
            }
            else if (tokenID == Block)
            {
                return "BLOCK";
            }
            else if (tokenID == Id)
            {
                return "VARNAME";
            }
            else if (tokenID == SysWord)
            {
                return "SYSTEM WORD";
            }
            else if (tokenID == Delimiter)
            {
                return "DELIMITER";
            }
            else if (tokenID == String)
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
            return input == '+' ? true : false;
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
}
