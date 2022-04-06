//Author:   Kiselnik Oleg
//Group:    SCS-19
//Project:  Simple interpreter of C language
//Purpose:  Develop Reverse Polish Notation (RPN)
//          with postfix notation

//Using library
using System;

namespace Onyx
{
    class RPN
    {
        public RPN()
        {

        }

        //Function for output RPN to console in a line
        public void outputPOLYZ(Node AST)
        {
            Console.WriteLine(getPOLYZ(AST));
        }

        //Get string with RPN
        public string getPOLYZ(Node AST)
        {
            string result = "";
            if(AST == null)
            {
                return "";
            }

            if (AST.isCompound())
            {
                foreach (Node n in AST.getNodes())
                {
                    result += getPOLYZ(n)+"\n";
                }
            }
            else if (AST.isNode())
            {
                if (AST.getLeft() != null)
                {
                    result += getPOLYZ(AST.getLeft());
                }
                if (AST.getRight() != null)
                {
                    result += getPOLYZ(AST.getRight());
                }
                result += getPOLYZ(AST.getOp());
            }
            else if (AST.isToken())
            {
                return AST.getValue();
            }

            return result;
        }
    }
}
