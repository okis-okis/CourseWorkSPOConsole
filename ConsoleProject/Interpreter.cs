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

        public void interpretCode()
        {

        }

        public void interpret(String[][] vars)
        {
            //declaration variables
            varDeclaration(vars);

            //code description
            interpretCode();

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
