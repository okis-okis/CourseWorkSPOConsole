﻿//Author:   Kiselnik Oleg
//Group:    SCS-19
//Project:  Simple interpreter of C language
//Purpose:  Develop token class

using System;

namespace Onyx
{
    public class Token : IToken
    {
        //Token value and token type
        private String token;
        private TokenTypes tokenType;

        //Constructor
        public Token(String token)
        {
            this.token = token;
            tokenType = TokenDeclaration.getTokenType(token);
        }

        //Return token type
        public TokenTypes getTokenType()
        {
            return tokenType;
        }

        //Get token value
        public String getToken()
        {
            return this.token;
        }

        //Function for set token type
        public void setTokenType(TokenTypes type)
        {
            tokenType = type;
        }

        //Output to console information about token
        public void printTokenInfo()
        {
            Console.WriteLine(getTokenInfo());
        }

        //Return information about token in a string
        public string getTokenInfo()
        {
            return "Token:\nWords: " + getToken() + "\nToken id: " + getTokenType() + "\n";
        }
    }
}
