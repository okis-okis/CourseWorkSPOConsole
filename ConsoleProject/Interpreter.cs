using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

//nasm -f elf32 interpreter.asm && gcc -m32 interpreter.o -o interpreter && ./interpreter

namespace ConsoleProject
{
    class Interpreter
    {
        Node node;
        private String code;
        public Interpreter(Node node)
        {
            this.node = node;
            codeAdd("BITS 32");
        }

        private void codeAdd(String command)
        {
            code += command + "\n";
        }

        public void varDeclaration(String[][] vars)
        {
            codeAdd("section .data");
            codeAdd("DAT1: db \"%i\", 10, 0");

            foreach (String[] var in vars)
            {
                if (var[0] == "int")
                {
                    codeAdd(var[1] + ": dq 0");
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
            codeAdd("global main");
            codeAdd("extern printf");
            codeAdd("main:");
            codeAdd("");
            codeAdd("xor eax, eax");
            codeAdd("xor ebx, ebx");
            codeAdd("xor ecx, ecx");
            codeAdd("xor edx, edx");
            codeAdd("");
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
            codeAdd("ret 0");
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
                            codeAdd("mov eax, " + sr);
                            //codeAdd("mov " + getVal(node.getLeft()) + ", " + sr);
                        }
                        codeAdd("mov " + getVal(node.getLeft()) + ", eax");
                        codeAdd("");
                    }
                    else if (node.getOp().getValue() == "+" ||
                            node.getOp().getValue() == "-"||
                            node.getOp().getValue() == "*"||
                            node.getOp().getValue() == "/")
                    {
                        string sl = getVal(node.getLeft());

                        if (sl != null)
                        {
                            codeAdd("mov eax, " + sl);
                        }
                        else
                        {
                            codeAdd("push eax");
                        }

                        string sr = getVal(node.getRight());

                        if (sr != null)
                        {
                            codeAdd("mov ebx, " + sr);
                        }
                        else
                        {
                            codeAdd("mov ebx, eax");
                            codeAdd("push ebx");
                        }

                        if (sr == null)
                        {
                            codeAdd("pop ebx");
                        }
                        if (sl == null)
                        {
                            codeAdd("pop eax");
                        }

                        if (node.getOp().getValue() == "+")
                        {
                            codeAdd("add eax, ebx");
                        }
                        else if (node.getOp().getValue() == "*")
                        {
                            codeAdd("mul ebx");
                        }
                        else if (node.getOp().getValue() == "/")
                        {
                            codeAdd("mov edx, 0");
                            codeAdd("mov ecx, ebx");
                            codeAdd("div ecx");
                        }
                        else
                        {
                            codeAdd("sub eax, ebx");
                        }
                        codeAdd("");
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
                    codeAdd("push eax");
                    codeAdd("push dword DAT1");
                    codeAdd("call printf ");
                    codeAdd("add esp, 8");

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
                using (FileStream fs = File.Create("interpreter.asm"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(code);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                // Open the stream and read it back.
                using (StreamReader sr = File.OpenText("interpreter.asm"))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }

                //Console.WriteLine(Directory.GetCurrentDirectory());

                /*Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.WorkingDirectory = @Directory.GetCurrentDirectory();
                startInfo.Arguments = "nasm -f elf -g interpreter.asm && gcc -m32 interpreter.o -o interpreter && interpreter";
                process.StartInfo = startInfo;
                process.Start()*/
                /*
                var p = new Process
                {
                    StartInfo =
                 {
                     FileName = "cmd.exe",
                     WorkingDirectory = @Directory.GetCurrentDirectory(),
                     Arguments = "/C nasm -f elf -g interpreter.asm && gcc -m32 interpreter.o -o interpreter && interpreter"
                 }
                }.Start();*/

                //Console.WriteLine(command);

                //Process.Start("CMD.exe", command);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Interpreter error!");
                Console.WriteLine(ex.ToString());
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
