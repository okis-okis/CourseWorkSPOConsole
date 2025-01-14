﻿//Author:   Kiselnik Oleg
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
using System.Windows.Forms;

namespace Onyx
{
    interface IInterpreter
    {
        string getCode();
        string[] getErrors();
        string getVal(Node n);
        void interpret();
    }

    class Interpreter : IInterpreter
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

        private List<String> errors;

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
            this.usedStrings = usedString;

            errors = new List<String>();

            Win = true;
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

        //Check if variable type is float, thet
        //return true. Else return false
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

        //Check if value data type is float
        //Get Node for check
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

        //Check if value data type is float
        //Get STRING for check
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

        //Check value type is logical
        private bool isLogical(String val)
        {
            if (val != null && (val == "true" || val == "false"))
            {
                return true;
            }
            return false;
        }

        //Interpret AND operation
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

        //Interpret OR operation
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

        //Interpret NOT operation
        private void notOperation(Node n)
        {
            String sl = getVal(n.getLeft());
            if (sl != null)
            {
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

        //Interpret loop FOR operation
        private void forOperation(Node n)
        {
            interpretCode(n.getLeft().getNodes()[0]);
            codeAdd("fStage" + fStage + ":");

            Token pnt = new Token("fStage" + fStage);
            pnt.setTokenType(TokenTypes.point);
            Node gt = new Node(new Node(pnt), new Node(new Token("goto")), null);
            fStage++;
            n.getLeft().getNodes()[1].getNodes()[0].getRight().getNodes()[2] = gt;

            interpretCode(n.getLeft().getNodes()[1]);
        }

        //Main function for interpret AST to
        //NASM code
        private void interpretCode(Node node)
        {
            if (node.isCompound())
            {
                if (node.getNodes().Length >= 1 && node.getNodes()[0].isNode() &&
                    node.getNodes()[0] != null &&
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
                            codeAdd("fstp dword " + getVal(node.getLeft()));
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

                            if (sr != null)
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

                        String val = null;
                        for (int i = 0; i < usedStrings.Length; i++)
                        {
                            if (usedStrings[i] == node.getLeft().getValue())
                            {
                                val = "DAT" + i;
                                break;
                            }
                        }
                        if(val == null)
                        {
                            errors.Add("Interpreter error! Not found string");
                            return;
                        }

                        //float
                        if (node.getRight() != null &&
                            isFloatVar(node.getRight().getValue()))
                        {
                            codeAdd("fld dword" + getVal(node.getRight()));
                            codeAdd("sub esp, 8");
                            codeAdd("fstp qword[esp]");
                            codeAdd("push "+val);
                            if (Win)
                            {
                                codeAdd("call _printf");
                            }
                            else
                            {
                                codeAdd("call printf");
                            }
                            codeAdd("add esp, 12");
                        }
                        //bool and int
                        else
                        {
                            if (node.getRight() != null)
                            {
                                codeAdd("mov eax, " + getVal(node.getRight()));
                                codeAdd("mov ebx, 1000000000000000000000000000000b");
                                codeAdd("cmp eax, ebx");
                                codeAdd("jl pos" + pStage);
                                codeAdd("");
                                codeAdd("not eax");
                                codeAdd("");
                                codeAdd("pos" + pStage + ":");
                                codeAdd("push eax");
                            }
                            codeAdd("push dword "+val);
                            if (Win)
                            {
                                codeAdd("call _printf");
                            }
                            else
                            {
                                codeAdd("call printf");
                            }

                            if (node.getRight() != null)
                            {
                                codeAdd("add esp, 8");
                            }
                            else
                            {
                                codeAdd("add esp, 4");
                            }
                            codeAdd("");
                            codeAdd("fcon" + pStage + ":");
                            pStage++;
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
                        String bp = "compare" + stage;

                        switch (subNode.getOp().getValue())
                        {
                            case "<":
                                codeAdd("jl " + bp);
                                break;
                            case ">":
                                codeAdd("jg " + bp);
                                break;
                            case "<=":
                                codeAdd("jle " + bp);
                                break;
                            case ">=":
                                codeAdd("jge " + bp);
                                break;
                            case "==":
                                codeAdd("je " + bp);
                                break;
                            case "!=":
                                codeAdd("jne ");
                                break;
                        }

                        codeAdd("jmp con" + stage);
                        codeAdd("");
                        codeAdd(bp + ":");
                        int temp = stage;
                        stage++;
                        interpretCode(node.getRight());
                        codeAdd("jmp cnt" + absoluteStage);
                        codeAdd("");

                        codeAdd("con" + temp + ":");

                    }
                    else if (node.getOp().getValue() == "else")
                    {
                        getVal(node.getRight());
                    }
                    else if (node.getOp().getValue() == "goto")
                    {
                        codeAdd("jmp " + node.getLeft().getValue());
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
                else if (TokenDeclaration.isNumber(node.getValue()))
                {
                    codeAdd(node.getValue());
                }
                else if (TokenDeclaration.isPoint(node.getValue()))
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
                String tempPath;

                // Create the file, or overwrite if the file exists.
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        tempPath = fbd.SelectedPath;
                    }
                    else
                    {
                        MessageBox.Show("You shood choose folder!");
                        return;
                    }
                }

                FileStream fs = File.Create(tempPath + "\\result.asm");
                byte[] info = new UTF8Encoding(true).GetBytes(code);
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
                fs.Close();

                if (Win)
                {

                    String command = "/C nasm -f elf -g " + tempPath + "\\result.asm -o " + tempPath + "\\result.o && gcc -m32 " + tempPath + "\\result.o -o " + tempPath + "\\result";
                    //MessageBox.Show(command);
                    var p = new Process
                    {
                        StartInfo =
                         {
                             FileName = "cmd.exe",
                             WorkingDirectory = @Directory.GetCurrentDirectory(),
                             Arguments = command// && interpreter"
                         }
                    }.Start();
                }
                else
                {
                    executeCommand("nasm -f elf -g interpreter.asm && gcc -m32 interpreter.o -o interpreter");// && ./interpreter");
                }
            }
            catch (Exception ex)
            {
                errors.Add("Interpreter error! " + ex.ToString());
            }
        }

        //Get NASM code
        public string getCode()
        {
            return code;
        }

        //Get list of errors
        public String[] getErrors()
        {
            if (errors == null)
            {
                return null;
            }
            return errors.ToArray();
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

