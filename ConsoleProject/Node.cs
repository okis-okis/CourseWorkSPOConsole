using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject
{
    class Node
    {
        private bool end;
        private bool list;

        Node left, right, op;
        Node[] compound;


        private string value;

        public Node()
        {
            list = false;
        }

        public Node(Token token):this()
        {
            end = true;
            /*if(token.getTokenID() == new TokenTypes().NOP)
            {
                Error();
            }*/
            value = token.getToken();
        }

        public Node(Node[] nodes)
        {
            compound = nodes;
            list = true;
        }

        public Node(Node left, Node op, Node right)
        {
            end = false;
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
            return !end;
        }

        public bool isToken()
        {
            return end;
        }

        public bool isCompound()
        {
            return list;
        }

        public Node[] getNodes()
        {
            return compound;
        }

        private void Error()
        {
            Console.Error.WriteLine("Node Error!");
            Environment.Exit(2);
        }
    }
}
