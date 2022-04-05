//Author:   Kiselnik Oleg
//Group:    SCS-19
//Project:  Simple interpreter of C language
//Purpose:  Convert C code from AST to NASM
//          code and execute compilation

//Using command for NASM compiler (Linux):
//nasm -f elf32 interpreter.asm && gcc -m32 interpreter.o -o interpreter && ./interpreter

//Using library
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Onyx
{
    class Interpreter
    {
        //AST
        Node node;

        //Variable for store of generated code
        private String code;

        //Array of using strings
        private String[] usedStrings;

        //Array of using floats value
        private String[] usedFloats;

        //Array of using vars
        String[][] vars;

        //Stage for if jump
        private Int16 stage;

        //Stage for NOT jump
        private Int16 nStage;

        //Stage for loop jump
        private Int16 fStage;

        //Stage for printf jump
        private Int16 pStage;

        //Absolute stage for if jump (else)
        private Int16 absoluteStage;

        //Variable for check OS
        //If program execute on OS Windows
        //Variable like true
        private bool Win;

        //Constructor
        public Interpreter(Node node, String[] usedString, String[] usedFloats, String[][] vars)
        {
            this.node = node;
            this.usedFloats = usedFloats;
            this.vars = vars;

            List<String> list = new List<String>();

            //Delete %d and %f from string for output
            //positiv and negativ number
            for (int i = 0; i < usedString.Length; i++)
            {
                String procStr = "";
                bool con = false;
                foreach (Char c in usedString[i])
                {
                    if (c == '%')
                    {
                        con = !con;
                        continue;
                    }
                    if (con)
                    {
                        con = !con;
                        continue;
                    }
                    procStr += c;
                }
                list.Add(procStr);
            }

            this.usedStrings = list.ToArray();

            Win = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            stage = 0;
            nStage = 0;
            fStage = 0;
            pStage = 0;
            absoluteStage = 0;
            codeAdd("BITS 32");
        }

        //Function for add code
        private void codeAdd(String command)
        {
            code += command + "\n";
        }

        //Declaration var and value for real number
        private void varDeclaration()
        {
            codeAdd("");
            codeAdd("section .data");
            codeAdd("ns: db \"\", 10, 0");
            codeAdd("negative: db \"-%d\", 0");
            codeAdd("positiv: db \"%d\", 0");
            codeAdd("fltOutput: db \"%f\", 0");

            for (int i = 0; i < usedStrings.Length; i++)
            {
                codeAdd("DAT" + i + ": db " + usedStrings[i] + ", 0");
            }

            foreach (String[] var in this.vars)
            {
                if (var[0] == "int" || var[0] == "float")
                {
                    codeAdd(var[1] + ": dd 0");
                }
            }

            for (int i = 0; i < usedFloats.Length; i++)
            {
                codeAdd("flt" + i + " : dd " + usedFloats[i]);
            }

            codeAdd("");
            codeAdd("section .bss");
            foreach (String[] var in this.vars)
            {
                if (var[0] == "bool")
                {
                    codeAdd(var[1] + ": resd 1");
                }
            }
        }

        //Check Node as entry point
        private bool isMain(Node n)
        {
            if (n.isToken() && n.getValue() == "main")
            {
                return true;
            }
            return false;
        }

        //Add to code entry point
        private void addMain()
        {
            codeAdd("");
            codeAdd("section .text");
            if (Win)
            {
                codeAdd("global _main");
                codeAdd("extern _printf");
                codeAdd("extern _scanf");

                codeAdd("_main:");
            }
            else
            {
                codeAdd("global main");
                codeAdd("extern printf");
                codeAdd("extern scanf");

                codeAdd("main:");
            }
            codeAdd("finit");
            codeAdd("");
            //Clear registers
            codeAdd("xor eax, eax");
            codeAdd("xor ebx, ebx");
            codeAdd("xor ecx, ecx");
            codeAdd("xor edx, edx");
            codeAdd("");
        }

        //If node is return node, return true
        private bool isReturn(Node n)
        {
            if (n.isToken() && n.getValue() == "return")
            {
                return true;
            }
            return false;
        }

        //Add to code return command
        private void addReturn()
        {
            codeAdd("ret 0");
        }

        //Move to register eax value from Node
        public String getVal(Node n)
        {
            if (n.getValue() != null &&
                new Token(n.getValue()).getTokenType() == TokenTypes.var)
            {
                return "[" + n.getValue() + "]";
            }
            else if (new Token(n.getValue()).getTokenType() == TokenTypes.real)
            {
                for (int i = 0; i < usedFloats.Length; i++)
                {
                    if (usedFloats[i] == n.getValue())
                    {
                        return "[flt" + i + "]";
                    }
                }
            }
            else if (n.getValue() == ";")
            {
                return "eax";
            }
            else if (n.isNode())
            {
                interpretCode(n);
            }
            else if (n.isToken() && isLogical(n.getValue()))
            {
                if (n.getValue() == "true")
                {
                    return "1b";
                }
                else
                {
                    return "0b";
                }
            }
            return n.getValue();
        }

        //Print '\n' char (new line)
        private void endl()
        {
            codeAdd("push dword ns");
            if (Win)
            {
                codeAdd("call _printf");
            }
            else
            {
                codeAdd("call printf");
            }
            codeAdd("add esp, 4");
            codeAdd("");
        }

        //Output value from eax register
        //Check number is positiv or negativ
        private void outputVal()
        {
            codeAdd("mov ebx, 1000000000000000000000000000000b");
            codeAdd("cmp eax, ebx");
            codeAdd("jl pos" + pStage);
            codeAdd("");
            codeAdd("xor eax, ebx");
            codeAdd("push eax");
            codeAdd("push dword negative");
            if (Win)
            {
                codeAdd("call _printf");
            }
            else
            {
                codeAdd("call printf");
            }
            codeAdd("add esp, 8");
            codeAdd("jmp fcon" + pStage);
            codeAdd("");
            codeAdd("pos" + pStage + ":");
            codeAdd("push eax");
            codeAdd("push dword positiv");
            if (Win)
            {
                codeAdd("call _printf");
            }
            else
            {
                codeAdd("call printf");
            }
            codeAdd("add esp, 8");
            codeAdd("");
            codeAdd("fcon" + pStage + ":");
            pStage++;
        }

        private bool isFloatVar(String var)
        {
            foreach (String[] name in vars)
            {
                if (name[1] == var && name[0] == "float")
                {
                    return true;
                }
            }

            return false;
        }

        private bool isFloatNum(Node n)
        {
            if (n.isNode())
            {
                return isFloatNum(n.getLeft());
            }

            if (n.isToken())
            {
                return isFloatNum(n.getValue());
            }

            return false;
        }

        private bool isFloatNum(String val)
        {
            if (val == null)
            {
                return false;
            }

            foreach (String flt in usedFloats)
            {
                if (val == flt)
                {
                    return true;
                }
            }

            return false;
        }

        private bool isLogical(String val)
        {
            if (val != null && (val == "true" || val == "false"))
            {
                return true;
            }
            return false;
        }

        private void andOperation(Node n)
        {
            String sr = getVal(n.getRight());

            if (sr != null)
            {
                codeAdd("mov eax, " + sr);
            }
            codeAdd("mov ebx, eax");
            codeAdd("push ebx");

            String sl = getVal(n.getLeft());

            codeAdd("pop ebx");
            if (sl != null)
            {
                codeAdd("mov eax, " + sl);
            }

            codeAdd("AND eax, ebx");
        }

        private void orOperation(Node n)
        {
            String sr = getVal(n.getRight());

            if (sr != null)
            {
                codeAdd("mov eax, " + sr);
            }
            codeAdd("mov ebx, eax");
            codeAdd("push ebx");

            String sl = getVal(n.getLeft());

            codeAdd("pop ebx");
            if (sl != null)
            {
                codeAdd("mov eax, " + sl);
            }

            codeAdd("OR eax, ebx");
        }

        private void notOperation(Node n)
        {
            String sl = getVal(n.getLeft());
            if (sl != null) {
                codeAdd("mov eax, " + sl);
            }
            codeAdd("NOT eax");
            codeAdd("cmp eax, 1000000000000000000000000000000b");
            codeAdd("jl nStage" + nStage);
            codeAdd("");
            codeAdd("mov ebx, 2");
            codeAdd("sub eax, ebx");
            codeAdd("");
            codeAdd("nStage" + nStage + ":");
            codeAdd("mov ebx, 2");
            codeAdd("add eax, ebx");
            nStage++;
        }

        private void forOperation(Node n)
        {
            interpretCode(n.getLeft().getNodes()[0]);
            codeAdd("fStage"+fStage+":");

            Token pnt = new Token("fStage" + fStage);
            pnt.setTokenType(TokenTypes.point);
            Node gt = new Node(new Node(pnt), new Node(new Token("goto")), null);

            n.getLeft().getNodes()[1].getNodes()[0].getRight().getNodes()[2] = gt;

            interpretCode(n.getLeft().getNodes()[1]);
        }

        private void interpretCode(Node node)
        {
            if (node.isCompound())
            {
                if (node.getNodes().Length >= 1 && node.getNodes()[0].isNode() &&
                    node.getNodes()[0]!=null&&
                    node.getNodes()[0].getOp() != null &&
                    node.getNodes()[0].getOp().getValue() == "if")
                {
                    foreach (Node n in node.getNodes())
                    {
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
                if (node.getOp() != null)
                {
                    if (node.getOp().getValue() == "=")
                    {
                        string sr = getVal(node.getRight());
                        if (isFloatVar(node.getLeft().getValue()))
                        {
                            if (node.getRight().isToken())
                            {
                                codeAdd("fld dword " + sr);
                            }
                            codeAdd("fstp dword "+getVal(node.getLeft()));
                        }
                        else
                        {
                            if (sr != null)
                            {
                                codeAdd("mov eax, " + sr);
                            }
                            codeAdd("mov " + getVal(node.getLeft()) + ", eax");
                        }
                        codeAdd("");
                    }
                    else if (node.getOp().getValue() == "+" ||
                            node.getOp().getValue() == "-" ||
                            node.getOp().getValue() == "*" ||
                            node.getOp().getValue() == "/")
                    {

                        string sl = getVal(node.getLeft());

                        if (isFloatNum(node.getLeft()) ||
                            isFloatVar(node.getLeft().getValue())
                            )
                        {
                            if (sl != null)
                            {
                                codeAdd("fld dword " + sl);
                            }
                            string sr = getVal(node.getRight());

                            if(sr != null)
                            {
                                codeAdd("fld dword " + sr);
                            }

                            if (node.getOp().getValue() == "+")
                            {
                                codeAdd("fadd");
                            }
                            else if (node.getOp().getValue() == "*")
                            {
                                codeAdd("fmul");
                            }
                            else if (node.getOp().getValue() == "/")
                            {
                                codeAdd("fdiv");
                            }
                            else
                            {
                                codeAdd("fsub");
                            }
                        }
                        else
                        {

                            if (sl != null)
                            {
                                codeAdd("mov eax, " + sl);
                            }
                            codeAdd("push eax");

                            string sr = getVal(node.getRight());

                            if (sr != null)
                            {
                                codeAdd("mov ebx, " + sr);
                            }
                            else
                            {
                                codeAdd("mov ebx, eax");
                            }
                            codeAdd("pop eax");

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
                        }
                        codeAdd("");
                    }
                    else if (node.getOp().getValue() == "printf")
                    {

                        for (int i = 0; i < usedStrings.Length; i++)
                        {
                            if (usedStrings[i] == node.getLeft().getValue())
                            {
                                codeAdd("push dword DAT" + i);
                            }
                        }

                        if (Win)
                        {
                            codeAdd("call _printf");
                        }
                        else
                        {
                            codeAdd("call _printf");
                        }
                        codeAdd("add esp, 4");
                        codeAdd("");

                        if (node.getRight()!=null && 
                            isFloatVar(node.getRight().getValue()))
                        {
                            codeAdd("fld dword" + getVal(node.getRight()));
                            codeAdd("sub esp, 8");
                            codeAdd("fstp qword[esp]");
                            codeAdd("push fltOutput");
                            if (Win) {
                                codeAdd("call _printf");
                            }
                            else
                            {
                                codeAdd("call printf");
                            }
                            codeAdd("add esp, 12");
                        }
                        else
                        {
                            if (node.getRight() != null)
                            {
                                codeAdd("mov eax, " + getVal(node.getRight()));
                                outputVal();
                            }
                        }
                        codeAdd("");
                        endl();
                    }
                    else if (node.getOp().getValue() == "scanf")
                    {
                        codeAdd("push " + node.getRight().getValue());

                        if (isFloatVar(node.getRight().getValue()))
                        {
                            codeAdd("push fltOutput");
                        }
                        else
                        {
                            for (int i = 0; i < usedStrings.Length; i++)
                            {
                                if (usedStrings[i] == node.getLeft().getValue())
                                {
                                    codeAdd("push dword DAT" + i);
                                }
                            }
                        }
                        if (Win)
                        {
                            codeAdd("call _scanf");
                        }
                        else
                        {
                            codeAdd("call scanf");
                        }
                        codeAdd("add esp, 8");
                        codeAdd("");
                    }
                    else if (node.getOp().getValue() == "if")
                    {
                        Node subNode = node.getLeft();
                        if (subNode.getRight() != null)
                        {
                            String val = getVal(subNode.getRight());
                            if (val != null)
                            {
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
                    else if (node.getOp().getValue() == "else")
                    {
                        getVal(node.getRight());
                    }
                    else if (node.getOp().getValue() == "goto")
                    {
                        codeAdd("jmp "+node.getLeft().getValue());
                    }
                    else if (node.getOp().getValue() == "AND")
                    {
                        andOperation(node);
                    }
                    else if (node.getOp().getValue() == "OR")
                    {
                        orOperation(node);
                    }
                    else if (node.getOp().getValue() == "NOT")
                    {
                        notOperation(node);
                    }
                    else if (node.getOp().getValue() == "for")
                    {
                        forOperation(node);
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
                else if (new TokenDeclaration().isNumber(node.getValue()))
                {
                    codeAdd(node.getValue());
                }
                else if (new TokenDeclaration().isPoint(node.getValue()))
                {
                    codeAdd(node.getValue());
                }
            }
            else
            {

            }
        }

        //Main function for interpret code
        public void interpret()
        {
            //declaration variables
            varDeclaration();

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

                if (Win)
                {
                    var p = new Process
                    {
                        StartInfo =
                 {
                     FileName = "cmd.exe",
                     WorkingDirectory = @Directory.GetCurrentDirectory(),
                     Arguments = "/C nasm -f elf -g interpreter.asm && gcc -m32 interpreter.o -o interpreter && interpreter"
                 }
                    }.Start();
                }
                else
                {
                    executeCommand("nasm -f elf -g interpreter.asm && gcc -m32 interpreter.o -o interpreter && ./interpreter");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Interpreter error!");
                Console.WriteLine(ex.ToString());
                Environment.Exit(2);
            }
        }

        //Execute Linux command function
        private static void executeCommand(string command)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = "/bin/bash";
            proc.StartInfo.Arguments = "-c \" " + command + " \"";
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.Start();

            while (!proc.StandardOutput.EndOfStream)
            {
                Console.WriteLine(proc.StandardOutput.ReadLine());
            }
        }
    }
}

