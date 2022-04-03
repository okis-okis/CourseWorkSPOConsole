//Author:   Kiselnik Oleg
//Group:    SCS-19
//Project:  Simple interpreter of C language
//Purpose:  Spend syntax analysis and
//          return Abstract-Synax Tree (AST)

//Using library
using System;
using System.Collections.Generic;

namespace Onyx
{
    //Parser class
    class Parser
    {
        //Using variables
        //Position for step by tokens check
        private int tokenPos = 0;
        //Save token list
        private Token[] tokens;
        //Generate variable table
        private List<String[]> varDeclaration;
        //Value of variables and strings
        private String[] values;

        //Constructor
        public Parser(Token[] tokens, String[] values)
        {
            this.tokens = tokens;
            varDeclaration = new List<String[]>();
            this.values = values;
        }

        //Private function for program exit
        //Using if find critical error
        private void Error(String error)
        {
            Console.Error.WriteLine("Error! "+error);
            Environment.Exit(2);
        }

        //Private function for form node of
        //plus, minus, variable, number or
        //delimiter factor
        private Node factor()
        {
            //factor : PLUS factor
            //         | MINUS factor
            //         | INTEGER
            //         | REAL
            //         | LPAREN expr RPAREN
            //         | variable

            Token token = currentToken();

            if (new TokenDeclaration().isNumber(token.getToken()))
            {
                return new Node(token);
            }
            else if (token.getTokenType() == TokenTypes.delimiter)
            {
                if (token.getToken().Length == 1)
                {
                    if (token.getToken()[0] == '(')
                    {
                        getNextToken();
                        Node n = expr();
                        if (nextToken() == null)
                        {
                            Error("Not found RPAREN in factor.");
                        }
                        if (getNextToken().getToken().Length == 1 && currentToken().getToken()[0] == ')')
                        {
                            return n;
                        }
                    }
                }
            }
            else if (token.getTokenType() == TokenTypes.minus)
            {
                if (nextToken() == null)
                {
                    Error("In unary operation not found factor");
                }

                getNextToken();
                Node nextFactor = factor();

                return new Node(new Node(new Token("0")),
                                new Node(new Token("-")),
                                nextFactor
                                );
            }
            else if (token.getTokenType() == TokenTypes.plus)
            {
                if (nextToken() == null)
                {
                    Error("In unary operation not found factor");
                }
                getNextToken();
                return factor();
            }
            else if (token.getTokenType() == TokenTypes.var)
            {
                return new Node(token);
            }
            //If not found need factor - anounse error
            Error("Not found factor.");
            return null;
        }

        //term : factor((MUL | DIV) factor)
        private Node term()
        {
            Node result = factor();

            while (nextToken() != null &&
                 (nextToken().getTokenType() == TokenTypes.mul ||
                  nextToken().getTokenType() == TokenTypes.div))
            {
                step();
                result = new Node(result, new Node(currentToken()), new Node());
                step();
                result.setRight(factor());
            }
            return result;
        }

        //expr : term((PLUS | MINUS) term)
        private Node expr()
        {
            Node result = term();

            while (nextToken() != null &&
                  (nextToken().getTokenType() == TokenTypes.plus ||
                  nextToken().getTokenType() == TokenTypes.minus))
            {
                step();
                result = new Node(result, new Node(currentToken()), new Node());
                step();
                result.setRight(term());
            }
            return result;
        }

        //Private function for result data type token
        private Node dataType()
        {
            Token token = currentToken();
            if (token.getTokenType() == TokenTypes.sysWord)
            {
                if (new TokenDeclaration().isDataType(token.getToken()))
                {
                    return new Node(token);
                }
                else
                {
                    Error("Token is not data type.");
                }
            }
            return null;
        }

        //variable : VAR
        private Node variable()
        {
            if (new TokenDeclaration().isDataType(currentToken().getToken()))
            {
                //Variable declaration;
                String type = currentToken().getToken();
                step();
                if (currentToken().getTokenType() == TokenTypes.var)
                {
                    String id = currentToken().getToken();
                    foreach (String[] str in varDeclaration.ToArray())
                    {
                        if (str[1] == id)
                        {
                            Error("You already declarated variable "+id);
                        }
                    }
                    varDeclaration.Add(new String[] { type, id });
                }
                else
                {
                    Error("Variable input expected");
                }
            }

            Token token = currentToken();

            if (token.getTokenType() == TokenTypes.var)
            {
                return new Node(token);
            }
            Error("Token is not var");
            return null;
        }

        //assignState: variable ASSIGN expr
        private Node assignState()
        {
            Node left = variable();
            Node op = null;
            step();
            if (currentToken().getTokenType() == TokenTypes.delimiter &&
                currentToken().getToken().Length == 1 &&
                currentToken().getToken()[0] == '=')
            {
                op = new Node(currentToken());
            }
            else if (currentToken().getTokenType() == TokenTypes.delimiter &&
                    currentToken().getToken() == ";")
            {
                return left;
            }
            else
            {
                Error("Expected symbol equal or semicolon.");
            }
            step();
            return new Node(left, op, expr());
        }

        //empty : ;
        private Node empty()
        {
            return new Node(new Token(";"));
        }

        //Private function for input/output operation
        //inout : printf ( str ) 
        //       | printf ( str , var )
        //       | scanf ( str , var )
        private Node inout()
        {
            Node left = null, right = null, op = null;
            op = new Node(currentToken());
            step();

            if (currentToken().getToken() == "(")
            {
                step();
            }
            else
            {
                Error("Expected symbol LPAREN");
            }

            //if printf
            if (op.getValue() == "printf")
            {
                String procStr = "";
                for (int i = 0; i < values.Length; i++)
                {
                    if (currentToken().getToken() == values[i])
                    {
                        bool con = false;
                        foreach (Char c in values[i])
                        {
                            if (c == '%')
                            {
                                con = !con;
                                continue;
                            }
                            if (con)
                            {
                                con = !con;
                                continue;
                            }
                            procStr += c;
                        }
                    }
                }
                left = new Node(new Token(procStr));
            }
            else
            {
                left = new Node(currentToken());
            }
            step();

            if (currentToken().getToken() == ",")
            {
                step();
            }
            else if (currentToken().getToken() == ")")
            {
                step();
                return new Node(left, op, null);
            }
            else
            {
                Error("Expected symbol RPAREN or comma.");
            }

            right = new Node(currentToken());
            step();

            if (currentToken().getToken() == ")")
            {
                step();
            }
            else
            {
                Error("Expected symbol RPAREN.");
            }
            return new Node(left, op, right);
        }

        //Public function return string array
        public String[] getStrings()
        {
            List<String> list = new List<String>();
            foreach (String s in values)
            {
                if (s.Length > 1 && s[0] == '"')
                {
                    list.Add(s);
                }
            }
            return list.ToArray();
        }

        //Public function return floats values from
        //values array/list
        public String[] getFloats()
        {
            List<String> list = new List<String>();
            foreach (String s in values)
            {
                if (new Token(s).getTokenType() == TokenTypes.real)
                {
                    list.Add(s);
                }
            }
            return list.ToArray();
        }

        //condition = if ( expr equalSymbol expr ) compound
        //           | if ( expr equalSymbol expr ) compund else condition
        //           | if compound else compound
        private Node condition()
        {
            List<Node> list = new List<Node>();
            while (currentToken().getTokenType() == TokenTypes.sysWord &&
                    (currentToken().getToken() == "if" ||
                    currentToken().getToken() == "else"))
            {

                if (currentToken().getToken() == "else" && nextToken().getToken() == "if")
                {
                    step();
                }

                Node op, left = null;
                op = new Node(currentToken());
                step();
                Node lp = null, opc = null, rp = null;
                if (op.getValue() != "else")
                {
                    if (currentToken().getTokenType() == TokenTypes.delimiter && 
                        currentToken().getToken() == "(")
                    {
                        step();
                    }
                    else
                    {
                        Error("Expected symbol LPAREN.");
                    }

                    lp = expr();

                    step();

                    opc = equalSymbol();

                    rp = expr();
                    step();
                    left = new Node(lp, opc, rp);


                    if (currentToken().getTokenType() == TokenTypes.delimiter && 
                        currentToken().getToken() == ")")
                    {
                        step();
                    }
                    else
                    {
                        Error("Expected symbol RPAREN.");
                    }
                }
                list.Add(new Node(left, op, compound()));
            }

            return new Node(list.ToArray());
        }

        //equalSymbol = > | < | >= | <= | == | !=
        private Node equalSymbol()
        {
            if (currentToken().getTokenType() == TokenTypes.delimiter &&
                        (currentToken().getToken() == ">" ||
                        currentToken().getToken() == "<" ||
                        currentToken().getToken() == ">=" ||
                        currentToken().getToken() == "<=" ||
                        currentToken().getToken() == "==" ||
                        currentToken().getToken() == "!="))
            {
                Node result = new Node(currentToken());
                step();
                return result;
            }
            else
            {
                Error("Exprected entry symbol like '>', '<', '>=', '<=', '==' or '!='.");
                return null;
            }
        }

        //point = text:
        private Node point()
        {
            if(currentToken().getTokenType() == TokenTypes.point)
            {
                Node node = new Node(currentToken());
                return node;
            }
            Error("Token is not a point");
            return null;
        }

        private Node gotoStatement()
        {
            if (currentToken().getTokenType() == TokenTypes.sysWord &&
                currentToken().getToken() == "goto")
            {
                Node op = new Node(currentToken());
                step();
                Node left = new Node(currentToken());
                return new Node(left, op, null);
            }
            Error("Operation is not defined");
            return null;
        }

        //statement = compound
        //          | assignState
        //          | inout
        //          | condition
        //          | empty
        private Node statement()
        {
            if (new TokenDeclaration().isDataType(currentToken().getToken()) || 
                currentToken().getTokenType() == TokenTypes.var)
            {
                return assignState();
            }
            else if (currentToken().getTokenType() == TokenTypes.delimiter && 
                    currentToken().getToken() == "{")
            {
                return compound();
            }
            else if (currentToken().getTokenType() == TokenTypes.sysWord && 
                    (currentToken().getToken() == "printf" || 
                    currentToken().getToken() == "scanf"))
            {
                return inout();
            }
            else if (currentToken().getTokenType() == TokenTypes.sysWord && 
                    currentToken().getToken() == "if")
            {
                return condition();
            }
            else if (currentToken().getTokenType() == TokenTypes.point)
            {
                return point();
            }
            else if (currentToken().getTokenType() == TokenTypes.sysWord &&
                    currentToken().getToken() == "goto")
            {
                return gotoStatement();
            }
                return empty();
        }

        //Private function form list of statement
        //statementList = statement
        //              | statement statementList
        private Node[] statementList()
        {
            List<Node> list = new List<Node>();
            list.Add(statement());

            if (currentToken().getToken() == "}")
            {
                return list.ToArray();
            }

            if (previousToken().getTokenType() != TokenTypes.point && 
                currentToken().getToken() != "return" &&
                currentToken().getToken() != ";" &&
                currentToken().getToken() != "goto")
            {
                step();
            }

            while (currentToken().getToken() == ";" || 
                  (previousToken() != null && previousToken().getToken() == "}") ||
                  previousToken().getTokenType() == TokenTypes.point)
            {
                if (currentToken().getToken() == "return" || 
                    nextToken() == null || 
                    nextToken().getToken() == "}" || 
                    nextToken().getToken() == "return")
                {
                    break;
                }
                if (previousToken().getToken() != "}" &&
                    previousToken().getTokenType() != TokenTypes.point)
                {
                    step();
                }
                list.Add(statement());
                if (currentToken().getToken() != ";" && 
                    currentToken().getToken() != "return")
                {
                    step();
                }
            }

            return list.ToArray();
        }

        //compound = { statementList }
        private Node compound()
        {
            Node compound = null;

            if (currentToken() != null)
            {
                if (currentToken().getTokenType() == TokenTypes.delimiter && 
                    currentToken().getToken() == "{")
                {
                    step();
                }
                else
                {
                    return new Node(statementList());
                }

                compound = new Node(statementList());
                step();

                if (currentToken().getTokenType() == TokenTypes.delimiter && 
                    currentToken().getToken() == "}")
                {
                    step();
                }
            }
            else
            {
                Error("Compound: current token is null.");
            }

            return compound;
        }

        //program = dataType main ( ) { compound return factor }
        private Node program()
        {
            List<Node> list = new List<Node>();
            if (currentToken() == null)
            {
                Error("Program: current token is null.");
            }

            dataType();
            step();

            if (currentToken().getTokenType() == TokenTypes.sysWord && 
                currentToken().getToken() == "main")
            {
                list.Add(new Node(currentToken()));
                step();
            }
            else
            {
                Error("Not found entry point.");
            }

            if (currentToken().getTokenType() == TokenTypes.delimiter && 
                currentToken().getToken() == "(")
            {
                step();
            }
            else
            {
                Error("Program: expected symbol LPAREN.");
            }

            if (currentToken().getTokenType() == TokenTypes.delimiter && 
                currentToken().getToken() == ")")
            {
                step();
            }
            else
            {
                Error("Program: expected symbol RPAREN.");
            }

            if (currentToken().getTokenType() == TokenTypes.delimiter && 
                currentToken().getToken() == "{")
            {
                step();
            }
            else
            {
                Error("Program: expected symbol LBrace.");
            }

            list.Add(compound());
            if (currentToken().getToken() != "return")
            {
                step();
            }

            if (currentToken().getTokenType() == TokenTypes.sysWord && 
                currentToken().getToken() == "return")
            {
                list.Add(new Node(currentToken()));
                step();
            }
            else
            {
                Error("Program: not found return opeartion.");
            }

            factor();
            step();

            if (currentToken().getTokenType() == TokenTypes.delimiter && 
                currentToken().getToken() == ";")
            {
                step();
            }
            else
            {
                Error("Program: expected symbol semicolon.");
            }

            if (currentToken().getTokenType() == TokenTypes.delimiter && 
                currentToken().getToken() == "}")
            {
            }
            else
            {
                Error("Program: expected symbol RBrace.");
            }

            return new Node(list.ToArray());
        }

        //Private function for step by token list
        //Return next token from token list
        private Token nextToken()
        {
            if (tokenPos + 1 < tokens.Length)
            {
                return tokens[tokenPos + 1];
            }
            return null;
        }

        //Public function return array of var
        //table type:
        /* /-------------------------------\
         * |   DATA TYPE   |   VAR NAME    |
         * |---------------+---------------|
         * |     INT       |      i        |
         * |---------------+---------------|
         * |    FLOAT      |      f        |
         * |---------------+---------------|
         * |     ...       |     ...       |
         * \-------------------------------/
         */
        public String[][] getVarArray()
        {
            return varDeclaration.ToArray();
        }

        //Private function return current token
        //from token list
        private Token currentToken()
        {
            if (tokenPos < tokens.Length)
            {
                return tokens[tokenPos];
            }
            return null;
        }

        //Private function return previous token
        private Token previousToken()
        {
            if (tokenPos - 1 > 0)
            {
                return tokens[tokenPos - 1];
            }
            return null;
        }

        //Get next token from token array/list
        private Token getNextToken()
        {
            if (tokenPos + 1 < tokens.Length)
            {
                tokenPos++;
                return tokens[tokenPos];
            }
            return null;
        }

        //step by token list
        private void step()
        {
            if (getNextToken() == null)
            {
                Error("Next token is null.");
            }
        }

        //Generate AST
        public Node parse()
        {
            return program();
        }

        //Public function for print in console
        //variable list
        //example of print:
        //Declaration var:
        //Var: float f
        public void outputVar()
        {
            Console.WriteLine("Declaration var: ");
            foreach (String[] var in varDeclaration.ToArray())
            {
                Console.WriteLine("Var: " + var[0] + " " + var[1]);
            }

        }

        public void outputValues()
        {
            Console.WriteLine("Declaration value: ");
            foreach (String value in values)
            {
                Console.WriteLine(value);
            }
        }
    }
}
