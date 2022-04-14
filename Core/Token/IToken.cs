//Author:   Kiselnik Oleg
//Group:    SCS-19
//Project:  Simple interpreter of C language
//Purpose:  Develop token class

namespace Onyx
{
    public interface IToken
    {
        string getToken();
        string getTokenInfo();
        TokenTypes getTokenType();
        void printTokenInfo();
        void setTokenType(TokenTypes type);
    }
}