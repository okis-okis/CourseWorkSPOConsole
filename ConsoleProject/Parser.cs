using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject
{
    class Parser
    {
        private int tokenPos = 0;
        private Token[] tokens;
        private List<String[]> varDeclaration;
        private String[] values;

        public Parser(Token[] tokens, String[] values)
        {
            this.tokens = tokens;
            varDeclaration = new List<String[]>();
            this.values = values;
        }

        private void Error()
        {
            Console.Error.WriteLine("Error!");
            Environment.Exit(2);
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
            else if (token.getTokenID() == new TokenTypes().Id)
            {
                return new Node(token);
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

        private Node dataType()
        {
            Token token = currentToken();
            if (token.getTokenID() == new TokenTypes().SysWord)
            {
                if (token.isDataType())
                {
                    return new Node(token);
                }
                else{
                    Error();
                }
            }
            return null;
        }

        private Node variable()
        {
            if (currentToken().isDataType())
            {
                //Variable declaration;
                String type = currentToken().getToken();
                step();
                if(currentToken().getTokenID() == new TokenTypes().Id)
                {
                    String id = currentToken().getToken();
                    foreach (String[] str in varDeclaration.ToArray())
                    {
                        if(str[1] == id)
                        {
                            Error();
                        }
                    }
                    varDeclaration.Add(new String[] {type, id});
                }
                else
                {
                    Error();
                }
            }

            Token token = currentToken();

            if (token.getTokenID() == new TokenTypes().Id)
            {
                return new Node(token);
            }
            Error();
            return null;
        }

        private Node assignState()
        {
            Node left = variable();
            Node op = null;
            step();
            if (currentToken().getTokenID() == new TokenTypes().Delimiter &&
                currentToken().getToken().Length == 1 &&
                currentToken().getToken()[0] == '=')
            {
                op = new Node(currentToken());
            }
            else if (currentToken().getTokenID() == new TokenTypes().Delimiter &&
                    currentToken().getToken() == ";")
            {
                return left;
            }
            else
            {
                Error();
            }
            step();
            return new Node(left, op, expr());
        }

        private Node empty()
        {
            return new Node(new Token(";"));
        }

        private Node inout(){
            Node left = null, right=null, op=null;
            op = new Node(currentToken());
            step();

            if(currentToken().getToken() == "("){
                step();
            }
            else{
                Error();
            }

            //if printf
            if(op.getValue() == "printf"){
                String procStr = "";
                for(int i=0;i<values.Length;i++){
                    if(currentToken().getToken() == values[i]){
                        bool con = false;
                        foreach(Char c in values[i]){
                            if(c == '%'){
                                con = !con;
                                continue;
                            }
                            if(con){
                                con = !con;
                                continue;
                            }
                            procStr += c;
                        }
                        values[i] = procStr;
                    }
                }
                left = new Node(new Token(procStr));
            }
            else{
                left = new Node(currentToken());
            }
            step();

            if(currentToken().getToken() == ","){
                step();
            }
            else if(currentToken().getToken() == ")"){
                step();
                return new Node(left, op, null);
            }
            else{
                Error();
            }

            right = new Node(currentToken());
            step();

            if(currentToken().getToken() == ")"){
                step();
            }
            else{
                Error();
            }
            return new Node(left, op, right);
        }

        public String[] getValues(){
            List <String> list = new List<String>();
            foreach(String s in values){
                if(s.Length>1 && s[0] == '"'){
                    list.Add(s);
                }
            }
            return list.ToArray();
        }

        private Node condition(){
            List<Node> list = new List<Node>();
            while(currentToken().getTokenID() == new TokenTypes().SysWord && 
                    (currentToken().getToken() == "if" || 
                    currentToken().getToken() == "else")){
                
                if(currentToken().getToken() == "else" && nextToken().getToken() == "if")
                {
                    step();
                }

                Node op, left = null;
                op = new Node(currentToken());
                step();
                Node lp = null, opc = null, rp = null;
                if (op.getValue() != "else")
                {
                    if (currentToken().getTokenID() == new TokenTypes().Delimiter && currentToken().getToken() == "(")
                    {
                        step();
                    }
                    else
                    {
                        Error();
                    }

                    lp = expr();

                    step();
                    if (currentToken().getTokenID() == new TokenTypes().Delimiter &&
                        (currentToken().getToken() == ">" ||
                        currentToken().getToken() == "<" ||
                        currentToken().getToken() == ">=" ||
                        currentToken().getToken() == "<=" ||
                        currentToken().getToken() == "==" ||
                        currentToken().getToken() == "!="))
                    {
                        opc = new Node(currentToken());
                        step();
                    }
                    else
                    {
                        Error();
                    }

                    rp = expr();
                    step();
                    left = new Node(lp, opc, rp);


                    if (currentToken().getTokenID() == new TokenTypes().Delimiter && currentToken().getToken() == ")")
                    {
                        step();
                    }
                    else
                    {
                        Error();
                    }
                }
                list.Add(new Node(left, op, compound()));
            }

            return new Node(list.ToArray());
        }

        private Node statement()
        {
            if (currentToken().isDataType() || currentToken().getTokenID() == new TokenTypes().Id)
            {
                return assignState();
            }
            else if(currentToken().getTokenID()==new TokenTypes().Delimiter && currentToken().getToken() == "{")
            {
                return compound();
            }
            else if(currentToken().getTokenID() == new TokenTypes().SysWord && (currentToken().getToken() == "printf" || currentToken().getToken() == "scanf")){
                return inout();
            }
            else if(currentToken().getTokenID() == new TokenTypes().SysWord && currentToken().getToken() == "if"){
                return condition();
            }
            return empty();
        }

        private Node[] statementList()
        {
            List<Node> list = new List<Node> ();
            list.Add(statement());
            
            if(currentToken().getToken() == "}")
            {
                return list.ToArray();
            }

            if (currentToken().getToken() != "return" && currentToken().getToken() != ";")
            {
                step();
            }

            while (currentToken().getToken() == ";" || (previousToken() != null && previousToken().getToken() == "}"))
            {
                if (currentToken().getToken() == "return" || nextToken() == null || nextToken().getToken() == "}" || nextToken().getToken() == "return")
                {
                    break;
                }
                if (previousToken().getToken() != "}")
                {
                    step();
                }
                list.Add(statement());
                if (currentToken().getToken() != ";" && currentToken().getToken() != "return")
                {
                    step();
                }
            }

            return list.ToArray();
        }

        private Node compound()
        {
            Node compound = null;
            
            if (currentToken() != null)
            {
                if(currentToken().getTokenID() == new TokenTypes().Delimiter && currentToken().getToken() == "{")
                {
                    step();
                }
                else
                {
                    return new Node(statementList());
                }
                
                compound = new Node(statementList());
                step();

                if (currentToken().getTokenID() == new TokenTypes().Delimiter && currentToken().getToken() == "}")
                {
                    step();
                }
            }
            else
            {
                Error();
            }

            return compound;
        }

        private Node program()
        {
            List<Node> list = new List<Node>();
            if(currentToken() == null)
            {
                Error();
            }
            
            dataType();
            step();

            if(currentToken().getTokenID() == new TokenTypes().SysWord && currentToken().getToken() == "main")
            {
                list.Add(new Node(currentToken()));
                step();
            }
            else
            {
                Error();
            }

            if (currentToken().getTokenID() == new TokenTypes().Delimiter && currentToken().getToken() == "(")
            {
                step();
            }
            else
            {
                Error();
            }

            if (currentToken().getTokenID() == new TokenTypes().Delimiter && currentToken().getToken() == ")")
            {
                step();
            }
            else
            {
                Error();
            }

            if (currentToken().getTokenID() == new TokenTypes().Delimiter && currentToken().getToken() == "{")
            {
                step();
            }
            else
            {
                Error();
            }

            list.Add(compound());
            if (currentToken().getToken() != "return")
            {
                step();
            }

            if (currentToken().getTokenID() == new TokenTypes().SysWord && currentToken().getToken() == "return")
            {
                list.Add(new Node(currentToken()));
                step();
            }
            else
            {
                Error();
            }

            factor();
            step();

            if (currentToken().getTokenID() == new TokenTypes().Delimiter && currentToken().getToken() == ";")
            {
                step();
            }
            else
            {
                Error();
            }

            if (currentToken().getTokenID() == new TokenTypes().Delimiter && currentToken().getToken() == "}")
            {
            }
            else
            {
                Error();
            }

            return new Node(list.ToArray());
        }

        private Token nextToken()
        {
            if (tokenPos + 1 < tokens.Length)
            {
                return tokens[tokenPos + 1];
            }
            return null;
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

        public String[][] getVarArray()
        {
            return varDeclaration.ToArray();
        }

        private Token currentToken()
        {
            if (tokenPos < tokens.Length)
            {
                return tokens[tokenPos];
            }
            return null;
        }

        private Token previousToken()
        {
            if (tokenPos-1 > 0)
            {
                return tokens[tokenPos-1];
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

        private void step()
        {
            if (getNextToken() == null)
            {
                Error();
            }
        }

        public Node parse()
        {
            return program();
        }

        public void outputVar()
        {
            Console.WriteLine("Declaration var: ");
            foreach (String[] var in varDeclaration.ToArray())
            {
                Console.WriteLine("Var: "+var[0]+" "+var[1]);
            }
            
        }
    }
}
