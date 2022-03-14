using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject
{
    class Token
    {
        private String token;
        public byte tokenId;

        public Token(String token)
        {
            this.token = token;
            TokenTypes tokenTypes = new TokenTypes();
            if (tokenTypes.isOperator(this.token))
            {
                this.tokenId = tokenTypes.getOperator(this.token);
            }
            else if (tokenTypes.isNumber(this.token))
            {
                this.tokenId = tokenTypes.Num;
            }
            else if (tokenTypes.isSystemWord(this.token))
            {
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

        public bool isOperator()
        {
            if (new TokenTypes().isOperator(this.token))
            {
                return true;
            }
            return false;
        }

        public bool isPlus()
        {
            if (this.token.Length > 1)
            {
                return false;
            }
            if (new TokenTypes().isPlus(this.token[0]))
            {
                return true;
            }
            return false;
        }

        public bool isMinus()
        {
            if (this.token.Length > 1)
            {
                return false;
            }
            if (new TokenTypes().isMinus(this.token[0]))
            {
                return true;
            }
            return false;
        }

        public bool isMul()
        {
            if (this.token.Length > 1)
            {
                return false;
            }
            if (new TokenTypes().isMul(this.token[0]))
            {
                return true;
            }
            return false;
        }

        public bool isDiv()
        {
            if (this.token.Length > 1)
            {
                return false;
            }
            if (new TokenTypes().isDiv(this.token[0]))
            {
                return true;
            }
            return false;
        }
    }
}
