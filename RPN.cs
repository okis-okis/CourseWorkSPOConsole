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
            if(AST == null)
            {
                return;
            }

            if (AST.isCompound())
            {
                foreach (Node n in AST.getNodes())
                {
                    outputPOLYZ(n);
                }
            }
            else if (AST.isNode())
            {
                if (AST.getLeft() != null)
                {
                    outputPOLYZ(AST.getLeft());
                }
                if (AST.getRight() != null)
                {
                    outputPOLYZ(AST.getRight());
                }
                outputPOLYZ(AST.getOp());
            }
            else if (AST.isToken())
            {
                Console.Write(AST.getValue());
            }
        }
    }
}
