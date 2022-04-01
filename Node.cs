//Author:   Kiselnik Oleg
//Group:    SCS-19
//Project:  Simple interpreter of C language
//Purpose:  Develop Node class

//Using library
using System;

namespace Onyx
{
    class Node
    {
        //End = true if this node if token,
        //else - false
        private bool end;
        //If this Node is token list, than
        //list = true
        private bool list;

        Node left, right, op;
        Node[] compound;
        
        //Node value if this Node is Token
        private string value;

        //Empty constructor
        public Node()
        {
            list = false;
        }

        //Node is Token
        public Node(Token token) : this()
        {
            end = true;
            value = token.getToken();
        }

        //Node is Node list
        public Node(Node[] nodes)
        {
            compound = nodes;
            list = true;
        }

        //Statement node
        //----------------
        //For example: i = 5. Node op = '=', left = i
        //right = 5. Tree for this example:
        //      =
        //    /   \
        //   i     5
        //Example 2: i = 5+2*2. Tree for this example:
        //          =
        //        /   \
        //       i     +
        //           /   \
        //          5     *
        //              /   \
        //             2     2
        public Node(Node left, Node op, Node right)
        {
            end = false;
            this.left = left;
            this.right = right;
            this.op = op;
        }

        //Public function return left part of Node
        public Node getLeft()
        {
            return left;
        }

        //Public function return operation part of Node
        public Node getOp()
        {
            return op;
        }

        //Public function return right part of Node
        public Node getRight()
        {
            return right;
        }

        //Public function return value of Node
        public String getValue()
        {
            return value;
        }

        //Set right part of Node
        //Using for operation create
        public void setRight(Node right)
        {
            this.right = right;
        }

        //Return true if end = false
        //P.S. this Node not last of Node list
        public bool isNode()
        {
            return !end;
        }

        //Return true if end = true
        //This Node is Token
        public bool isToken()
        {
            return end;
        }

        //Return this if this Node
        //is Node list
        public bool isCompound()
        {
            return list;
        }

        //Return Node list
        public Node[] getNodes()
        {
            return compound;
        }

        //Output error and exit of program
        private void Error()
        {
            Console.Error.WriteLine("Node Error!");
            Environment.Exit(2);
        }
    }
}
