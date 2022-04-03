//Author:   Kiselnik Oleg
//Group:    SCS-19
//Project:  Simple interpreter of C language
//Purpose:  Develop token type class

using System;

namespace Onyx
{ 
    //List of token types
    public enum TokenTypes{
        plus = 0,
        minus = 1,
        mul = 2,
        div = 3,
        boolean = 4,
        integer = 5,
        real = 6,
        str = 7,
        var = 8,
        sysWord = 9,
        delimiter = 10,
        point = 11,
        NOP = 12
    }

    //Class token declaration consist function for token for define
    //token type and other
    class TokenDeclaration
    {
        public TokenTypes getTokenType(String tokenValue)
        {
            //Define token type
            if (isOperator(tokenValue))
            {
                return getOperator(tokenValue);
            }
            else if (isNumber(tokenValue))
            {
                return getNumber(tokenValue);
            }
            else if (isSystemWord(tokenValue))
            {
                return TokenTypes.sysWord;
            }
            else if (isVarName(tokenValue))
            {
                return TokenTypes.var;
            }
            else if (isDelimiter(tokenValue))
            {
                return TokenTypes.delimiter;
            }
            else if (isString(tokenValue))
            {
                return TokenTypes.str;
            }
            else if (isPoint(tokenValue))
            {
                return TokenTypes.point;
            }
            else
            {
                return TokenTypes.NOP;
            }
        }

        public bool isPoint(String token)
        {
            if(token==null||token.Length <= 1)
            {
                return false;
            }
            else if (token[token.Length-1]==':')
            {
                token = token.Substring(0, token.Length - 1);
                int c = 'a';
                int d = 'z';
                if ((token[0] >= 'a' && token[0] <= 'z') ||
                    (token[0] >= 'A' && token[0] <= 'Z'))
                {
                    return true;
                }
            }
            return false;
        }

        public bool isDataType(String token)
        {
            if (token == "int" ||
            token == "float" ||
            token == "bool" ||
            token == "double")
            {
                return true;
            }
            return false;
        }

        public bool isPlus(String token)
        {
            return token == "+" ? true : false;
        }

        public bool isMinus(String token)
        {
            return token == "-" ? true : false;
        }

        public bool isMul(String token)
        {
            return token == "*" ? true : false;
        }

        public bool isDiv(String token)
        {
            return token == "/" ? true : false;
        }

        public bool isOperator(String s)
        {
            if (s == null || s == "" || s.Length > 1)
            {
                return false;
            }
            if (isPlus(s))
            {
                return true;
            }
            else if (isMinus(s))
            {
                return true;
            }
            else if (isMul(s))
            {
                return true;
            }
            else if (isDiv(s))
            {
                return true;
            }
            return false;
        }

        public bool isNumber(String s)
        {
            if (isInt(s) || isFloat(s))
            {
                return true;
            }
            return false;
        }

        public TokenTypes getNumber(String s)
        {
            if (isNumber(s))
            {
                if (isInt(s))
                {
                    return TokenTypes.integer;
                }
                else
                {
                    return TokenTypes.real;
                }
            }
            return TokenTypes.NOP;
        }

        public Boolean isInt(String s)
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
            }
            return false;
        }

        public Boolean isFloat(String s)
        {
            if(s == null)
            {
                return false;
            }

            float f;

            String temp = "";
            foreach (char c in s)
            {
                temp += c == '.' ? ',' : c;
            }

            return float.TryParse(temp, out f);
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
            if (s != null && s.Length == 1)
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
            if (s!= null && s.Length > 1)
            {
                if (s[0] == '"' && s[s.Length - 1] == '"')
                {
                    return true;
                }
            }
            return false;
        }

        public TokenTypes getOperator(String s)
        {
            if (isPlus(s))
            {
                return TokenTypes.plus;
            }
            else if (isMinus(s))
            {
                return TokenTypes.minus;
            }
            else if (isMul(s))
            {
                return TokenTypes.mul;
            }
            else if (isDiv(s))
            {
                return TokenTypes.div;
            }
            return 0;
        }

        public String getTokenType(TokenTypes tokenType)
        {
            if (tokenType == TokenTypes.plus)
            {
                return "PLUS";
            }
            else if (tokenType == TokenTypes.minus)
            {
                return "MINUS";
            }
            else if (tokenType == TokenTypes.div)
            {
                return "DIVISION";
            }
            else if (tokenType == TokenTypes.mul)
            {
                return "MULTIPLICATE";
            }
            else if (tokenType == TokenTypes.boolean)
            {
                return "BOOLEAN";
            }
            else if (tokenType == TokenTypes.integer)
            {
                return "INTEGER";
            }
            else if(tokenType == TokenTypes.real)
            {
                return "REAL";
            }
            else if(tokenType == TokenTypes.str)
            {
                return "STRING";
            }
            else if (tokenType == TokenTypes.var)
            {
                return "VARNAME";
            }
            else if (tokenType == TokenTypes.sysWord)
            {
                return "SYSTEM WORD";
            }
            else if (tokenType == TokenTypes.delimiter)
            {
                return "DELIMITER";
            }
            else
            {
                return "NOP";
            }
        }
    }
}
