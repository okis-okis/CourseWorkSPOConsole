using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject
{
    class Parser
    {
        private int tokenPos = 0;
        private Token[] tokens;


        public Parser(Token[] tokens)
        {
            this.tokens = tokens;
        }

        private void Error()
        {
            Console.Error.WriteLine("Error!");
            Environment.Exit(2);
        }

        private Token eat(Token token, int type)
        {
            if (token.getTokenID() == type)
            {
                return token;
            }
            Error();
            return null;
        }

        private Token currentToken()
        {
            if (tokenPos < tokens.Length)
            {
                return tokens[tokenPos];
            }
            return null;
        }

        private Token getNextToken()
        {
            if (tokenPos + 1 < tokens.Length)
            {
                tokenPos++;
                return tokens[tokenPos];
            }
            return null;
        }

        private Node factor()
        {
            Token token = currentToken();

            if (token.getTokenID() == new TokenTypes().Num)
            {
                return new Node(token);
            }
            else if (token.getTokenID() == new TokenTypes().Delimiter)
            {
                if (token.getToken().Length == 1)
                {
                    if (token.getToken()[0] == '(')
                    {
                        getNextToken();
                        Node n = expr();
                        if (nextToken() == null)
                        {
                            Error();
                        }
                        if (getNextToken().getToken().Length == 1 && currentToken().getToken()[0] == ')')
                        {
                            return n;
                        }
                    }
                }
            }
            else if (token.getTokenID() == new TokenTypes().Minus)
            {
                if (nextToken() == null)
                {
                    Error();
                }
                
                getNextToken();
                Node nextFactor = factor();

                return new Node(new Node(new Token("0")), 
                       new Node(new Token("-")),
                       nextFactor);
            }
            else if (token.getTokenID() == new TokenTypes().Plus)
            {
                if (nextToken() == null)
                {
                    Error();
                }
                getNextToken();
                return factor();
            }
            
            Error();
            return null;
        }

        private Node term()
        {
            Node result = factor();

            while (nextToken() != null &&
                 (nextToken().getTokenID() == new TokenTypes().Mul ||
                  nextToken().getTokenID() == new TokenTypes().Div))
            {
                step();
                result = new Node(result, new Node(currentToken()), new Node());
                step();
                result.setRight(factor());
            }
            return result;
        }

        private Token nextToken()
        {
            if (tokenPos + 1 < tokens.Length)
            {
                return tokens[tokenPos + 1];
            }
            return null;
        }

        private Node expr()
        {
            Node result = term();

            while (nextToken() != null &&
                  (nextToken().getTokenID() == new TokenTypes().Plus ||
                  nextToken().getTokenID() == new TokenTypes().Minus))
            {
                step();
                result = new Node(result, new Node(currentToken()), new Node());
                step();
                result.setRight(term());
            }
            return result;
        }

        private void step()
        {
            if (getNextToken() == null)
            {
                Error();
            }
        }
        public Node parse()
        {
            return expr();
        }
    }
}
