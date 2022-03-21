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
        private String[] usedStrings;
        private Int16 stage;
        private Int16 absoluteStage;
        private bool ifCon;

        public Interpreter(Node node, String[] usedString)
        {
            this.node = node;
            this.usedStrings = usedString;
            stage = 0;
            absoluteStage = 0;
            ifCon = false;
            codeAdd("BITS 32");
        }

        private void codeAdd(String command)
        {
            code += command + "\n";
        }

        public async void varDeclaration(String[][] vars)
        {
            codeAdd("");
            codeAdd("section .data");
            codeAdd("ns: db \"\", 10, 0");
            codeAdd("negative: db \"-%d\", 0");
            codeAdd("positiv: db \"%d\", 0");

            for(int i=0;i<usedStrings.Length;i++){
                codeAdd("DAT"+i+": db "+usedStrings[i]+", 0");
            }

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
            codeAdd("");
            codeAdd("section .text");
            codeAdd("global main");
            codeAdd("extern printf");
            codeAdd("extern scanf");
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
            else if(n.getValue() == ";")
            {
                return "eax";
            }
            else if (n.isNode())
            {
                interpretCode(n);
            }
            return n.getValue();
        }

        private void endl(){
            codeAdd("push dword ns");
            codeAdd("call printf");
            codeAdd("add esp, 4");
            codeAdd("");
        }

        private void outputVal(){
            codeAdd("mov ebx, 1000000000000000000000000000000b");
            codeAdd("cmp eax, ebx");
            codeAdd("jl pos"+stage);
            codeAdd("");
            codeAdd("xor eax, ebx");
            codeAdd("push eax");
            codeAdd("push dword negative");
            codeAdd("call printf");
            codeAdd("add esp, 8");
            codeAdd("jmp con"+stage);
            codeAdd("");
            codeAdd("pos"+stage+":");
            codeAdd("push eax");
            codeAdd("push dword positiv");
            codeAdd("call printf");
            codeAdd("add esp, 8");
            codeAdd("");
            codeAdd("con"+stage+":");
            stage++;
        }

        public void interpretCode(Node node)
        {
            if (node.isCompound())
            {
                if (node.getNodes().Length >= 1 && node.getNodes()[0].isNode() && node.getNodes()[0].getOp().getValue() == "if")
                {
                    foreach (Node n in node.getNodes()){
                        interpretCode(n);
                    }
                    codeAdd("cnt" + absoluteStage + ":");
                    absoluteStage++;
                }
                else
                {

                    foreach (Node n in node.getNodes())
                    {
                        interpretCode(n);
                    }
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
                            //codeAdd("push eax");
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
                        codeAdd("push eax");

                        string sr = getVal(node.getRight());

                        if (sr != null)
                        {
                            codeAdd("mov ebx, " + sr);
                            //codeAdd("mov ebx, eax");
                        }
                        else{
                            codeAdd("mov ebx, eax");
                        }
                        //codeAdd("push ebx");
                        codeAdd("pop eax");
                        /*if (sr == null)
                        {
                            codeAdd("pop ebx");
                        }
                        if (sl == null)
                        {
                            codeAdd("pop eax");
                        }*/

                        

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
                    else if(node.getOp().getValue() == "printf"){
                        /*
                        if(node.getRight() != null){
                            codeAdd("mov eax, "+outputVal(getVal(node.getRight())));
                            codeAdd("push eax");
                        }
                        for(int i=0;i<usedStrings.Length;i++){
                            if(usedStrings[i] == node.getLeft().getValue()){
                                codeAdd("push dword DAT"+i);
                            }
                        }
                        codeAdd("call printf");
                        if(node.getRight()!= null){
                            codeAdd("add esp, 8");
                        }
                        else{
                            codeAdd("add esp, 4");
                        }*/

                        for(int i=0;i<usedStrings.Length;i++){
                            Console.WriteLine(node.getLeft().getValue());
                            if(usedStrings[i] == node.getLeft().getValue()){
                                codeAdd("push dword DAT"+i);
                            }
                        }
                        codeAdd("call printf");
                        codeAdd("add esp, 4");
                        codeAdd("");

                        if(node.getRight() != null){
                            codeAdd("mov eax, "+getVal(node.getRight()));
                            outputVal();
                        }

                        endl();
                    }
                    else if(node.getOp().getValue() == "scanf"){
                        codeAdd("push "+node.getRight().getValue());
                        for(int i=0;i<usedStrings.Length;i++){
                            if(usedStrings[i] == node.getLeft().getValue()){
                                codeAdd("push dword DAT"+i);
                            }
                        }
                        codeAdd("call scanf");
                        codeAdd("add esp, 8");
                        codeAdd("");
                    }
                    else if (node.getOp().getValue() == "if")
                    {
                        Node subNode = node.getLeft();
                        if (subNode.getRight() != null)
                        {
                            String val = getVal(subNode.getRight());
                            if (val != null) {
                                codeAdd("mov eax, " + val);
                            }
                            codeAdd("mov ebx, eax");
                            codeAdd("push ebx");
                            codeAdd("");
                        }

                        if (subNode.getLeft() != null)
                        {
                            String val = getVal(subNode.getLeft());
                            if (val != null)
                            {
                                codeAdd("mov eax, " + val);
                            }
                            codeAdd("pop ebx");
                            codeAdd("");
                        }
                        codeAdd("cmp eax, ebx");
                        String bp = "";

                        switch (subNode.getOp().getValue())
                        {
                            case "<":
                                bp = "cjl" + stage;
                                codeAdd("jl " + bp);
                                break;
                            case ">":
                                bp = "cgl" + stage;
                                codeAdd("jg " + bp);
                                break;
                            case "<=":
                                bp = "cjle" + stage;
                                codeAdd("jle " + bp);
                                break;
                            case ">=":
                                bp = "cjge" + stage;
                                codeAdd("jge " + bp);
                                break;
                            case "==":
                                bp = "cje" + stage;
                                codeAdd("je " + bp);
                                break;
                            case "!=":
                                bp = "cjne" + stage;
                                codeAdd("jne ");
                                break;
                        }

                        codeAdd("jmp con" + stage);
                        codeAdd("");
                        codeAdd(bp + ":");
                        interpretCode(node.getRight());
                        codeAdd("jmp cnt" + absoluteStage);
                        codeAdd("");

                        codeAdd("con" + stage + ":");
                        stage++;

                    }
                    else if(node.getOp().getValue() == "else")
                    {
                        getVal(node.getRight());
                        //ifCon = false;
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

                Console.WriteLine("================\n\nExecute program:");
                ExecuteCommand("nasm -f elf -g interpreter.asm && gcc -m32 interpreter.o -o interpreter && ./interpreter");

                //Console.WriteLine(Directory.GetCurrentDirectory());

                /*Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = "/bin/bash";
                startInfo.WorkingDirectory = @Directory.GetCurrentDirectory();
                startInfo.Arguments = "echo 'Work'";
                process.StartInfo = startInfo;
                process.Start();*/
                
                /*var p = new Process
                {
                    StartInfo =
                 {
                     FileName = "cmd.exe",
                     WorkingDirectory = @Directory.GetCurrentDirectory(),
                     Arguments = "/C nasm -f elf -g interpreter.asm && gcc -m32 interpreter.o -o interpreter && interpreter"
                 }
                }.Start();
                */
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

        public static void ExecuteCommand(string command)
        {
            Process proc = new System.Diagnostics.Process ();
            proc.StartInfo.FileName = "/bin/bash";
            proc.StartInfo.Arguments = "-c \" " + command + " \"";
            proc.StartInfo.UseShellExecute = false; 
            proc.StartInfo.RedirectStandardOutput = true;
            proc.Start ();

            while (!proc.StandardOutput.EndOfStream) {
                Console.WriteLine (proc.StandardOutput.ReadLine ());
            }
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
