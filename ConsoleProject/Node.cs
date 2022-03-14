using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject
{
    class Node
    {
        private bool num;
        Node left, right, op;
        private string value;

        public Node()
        {

        }

        public Node(Token token)
        {
            num = true;
            if (token.getTokenID() == new TokenTypes().Num ||
               new TokenTypes().isOperator(token.getToken()))
            {
                value = token.getToken();
            }
            else
            {
                Error();
            }
        }

        public Node(Node left, Node op, Node right)
        {
            num = false;
            this.left = left;
            this.right = right;
            this.op = op;
        }

        public Node getLeft()
        {
            return left;
        }

        public Node getOp()
        {
            return op;
        }

        public Node getRight()
        {
            return right;
        }

        public String getValue()
        {
            return value;
        }

        public void setRight(Node right)
        {
            this.right = right;
        }

        public bool isNode()
        {
            return !num;
        }

        public bool isToken()
        {
            return num;
        }

        private void Error()
        {
            Console.Error.WriteLine("Node Error!");
            Environment.Exit(2);
        }
    }
}
