using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleProject
{
    class Interpreter
    {
        Node node;
        private String code;
        public Interpreter(Node node)
        {
            this.node = node;
            codeAdd("%include \"io64.inc\"");
        }

        private void codeAdd(String command)
        {
            code += command + "\n";
        }

        public void varDeclaration(String[][] vars)
        {
            codeAdd("section .data");
            foreach (String[] var in vars)
            {
                if (var[0] == "int")
                {
                    codeAdd(var[1] + ": dw 0");
                }
            }
        }

        private bool isMain(Node n)
        {
            if(n.isToken() && n.getValue() == "main")
            {
                return true;
            }
            return false;
        }

        private void addMain()
        {
            codeAdd("section .text");
            codeAdd("global CMAIN");
            codeAdd("CMAIN:");
        }

        private bool isReturn(Node n)
        {
            if (n.isToken() && n.getValue() == "return")
            {
                return true;
            }
            return false;
        }

        private void addReturn()
        {
            codeAdd("ret");
        }

        public String getVal(Node n)
        {
            if(n.getValue() != null && 
                new Token(n.getValue()).getTokenID() == new TokenTypes().Id)
            {
                return "["+ n.getValue() + "]";
            }
            else if (n.isNode())
            {
                interpretCode(n);
            }
            return n.getValue();
        }

        public void interpretCode(Node node)
        {
            if (node.isCompound())
            {
                foreach(Node n in node.getNodes()){
                    interpretCode(n);
                }
            }
            else if (node.isNode())
            {
                if(node.getOp()!= null)
                {
                    if(node.getOp().getValue() == "=")
                    {
                        string sr = getVal(node.getRight());
                        if(sr != null)
                        {
                            codeAdd("mov " + getVal(node.getLeft()) + ", " + sr);
                        }
                        else
                        {
                            codeAdd("mov " + getVal(node.getLeft()) + ", eax");
                        }
                    }
                    else if (node.getOp().getValue() == "+" ||
                            node.getOp().getValue() == "-")
                    {
                        string sr = getVal(node.getRight());
                        string sl = getVal(node.getLeft());
                        if (sr != null)
                        {
                            codeAdd("mov ebx, " + sr);
                        }
                        if (sl != null)
                        {
                            codeAdd("mov eax, " + sl);
                        }
                        if (node.getOp().getValue() == "+")
                        {
                            codeAdd("add eax, ebx");
                        }
                        else
                        {
                            codeAdd("sub eax, ebx");
                        }
                    }
                }
            }
            else if (node.isToken())
            {
                if (isMain(node))
                {
                    addMain();
                }
                else if (isReturn(node))
                {
                    addReturn();
                }
                else if(new Token(node.getValue()).getTokenID() == new TokenTypes().Num)
                {
                    codeAdd(node.getValue());
                }
            }
            else
            {

            }
        }

        public void interpret(String[][] vars)
        {
            //declaration variables
            varDeclaration(vars);

            //code description
            interpretCode(node);

            try
            {
                // Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create("interpteter.asm"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(code);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                // Open the stream and read it back.
                using (StreamReader sr = File.OpenText("interpteter.asm"))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Interpreter error!");
                Environment.Exit(2);
            }
        }

        private void visit(Node node)
        {

        }

        /*private int visit(Node node)
        {
            if (node.isToken())
            {
                return Convert.ToInt32(node.getValue());
            }

            if (node.getOp().getValue() == "+")
            {
                return visit(node.getLeft()) + visit(node.getRight());
            }
            else if (node.getOp().getValue() == "-")
            {
                return visit(node.getLeft()) - visit(node.getRight());
            }
            else if (node.getOp().getValue() == "*")
            {
                return visit(node.getLeft()) * visit(node.getRight());
            }
            else if (node.getOp().getValue() == "/")
            {
                return visit(node.getLeft()) / visit(node.getRight());
            }
            else
            {
                return 0;
            }
        }*/
    }
}
