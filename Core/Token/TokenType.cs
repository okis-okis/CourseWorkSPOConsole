//Author:   Kiselnik Oleg
//Group:    SCS-19
//Project:  Simple interpreter of C language
//Purpose:  Develop token type class

using System;

namespace Onyx
{ 
    //List of token types
    public enum TokenTypes{
        plus    =   0,
        minus   =   1,
        mul     =   2,
        div     =   3,
        boolean =   4,
        integer =   5,
        real    =   6,
        str     =   7,
        var     =   8,
        sysWord =   9,
        delimiter = 10,
        point   =   11,
        NOP     =   12
    }

    //Class token declaration consist function for token for define
    //token type and other
    static public class TokenDeclaration
    {
        //Function for define type of token
        static public TokenTypes getTokenType(String tokenValue)
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

        //Check token value is point
        static public bool isPoint(String token)
        {
            if(token==null||token.Length <= 1)
            {
                return false;
            }
            else if (token[token.Length-1]==':')
            {
                token = token.Substring(0, token.Length - 1);
                if ((token[0] >= 'a' && token[0] <= 'z') ||
                    (token[0] >= 'A' && token[0] <= 'Z'))
                {
                    return true;
                }
            }
            return false;
        }

        //Check token value is data type
        //Data types: int, float, bool
        static public bool isDataType(String token)
        {
            if (token == "int" ||
            token == "float" ||
            token == "bool")
            {
                return true;
            }
            return false;
        }

        //Check token value is + operation
        static public bool isPlus(String token)
        {
            return token == "+" ? true : false;
        }

        //Check token value is - operation
        static public bool isMinus(String token)
        {
            return token == "-" ? true : false;
        }

        //Check token value is mul(*) operation
        static public bool isMul(String token)
        {
            return token == "*" ? true : false;
        }

        //Check token value is div(/) operation
        static public bool isDiv(String token)
        {
            return token == "/" ? true : false;
        }

        //Check token value is operator
        //Operators: +, -, *, /
        static public bool isOperator(String s)
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

        //Check token value is float or int number
        static public bool isNumber(String s)
        {
            if (isInt(s) || isFloat(s))
            {
                return true;
            }
            return false;
        }

        //Return type of token if token value is
        //integer or float number
        static public TokenTypes getNumber(String s)
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

        //Check token value is integer
        static public Boolean isInt(String s)
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

        //Check token value is float
        static public Boolean isFloat(String s)
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

        //Check token value is system word
        static public Boolean isSystemWord(String s)
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

        //Check token value is var name
        static public Boolean isVarName(String s)
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

        //Check token value is delimiter
        static public Boolean isDelimiter(String s)
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

        //Check token value is string
        static public Boolean isString(String s)
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

        //Return type of token if token value is
        //operator
        static public TokenTypes getOperator(String s)
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

        //Return string with token type
        //Used for output token type to console/terminal
        static public String getTokenType(TokenTypes tokenType)
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
