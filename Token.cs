//Author:   Kiselnik Oleg
//Group:    SCS-19
//Project:  Simple interpreter of C language
//Purpose:  Develop token class

using System;

namespace Onyx
{
    class Token
    {
        //Token value and token type
        private String token;
        public TokenTypes tokenType;

        //Constructor
        public Token(String token)
        {
            this.token = token;
            tokenType = new TokenDeclaration().getTokenType(token);
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
    }
}
