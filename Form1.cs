using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Onyx
{
    public partial class Form : System.Windows.Forms.Form
    {
        String path;

        public Form()
        {
            InitializeComponent();
            path = null;
        }

        private void interpretCodeButton_Click(object sender, EventArgs e)
        {
            interpretOperation();
        }

        private void interpretOperation()
        {
            try
            {
                progressBar.Value = 0;

                if (path == null)
                {
                    MessageBox.Show("You should save file!");
                    saveFileOperation();
                    if (path == null)
                    {
                        MessageBox.Show("Error!");
                        return;
                    }
                }

                //Read source code from test.c file
                String input = codeRichTextBox.Text;
                progressBar.PerformStep();  //1

                //Lexical analysis
                Lexer lex = new Lexer(input);
                Token[] tokenList = lex.scan();
                progressBar.PerformStep();  //2
                progressBar.PerformStep();  //3

                //Output result of lexical analysis
                lexRichTextBox.Text = getLexicalAnalysisResult(tokenList);
                String[] tempArr = lexRichTextBox.Text.ToString().Split('\n');
                String lexRaport = tempArr[tempArr.Length-1];
                progressBar.PerformStep();  //4

                if (lexRaport != "Lexical analysis did successful")
                {
                    MessageBox.Show(lexRaport);
                    return;
                }

                //Syntax analysis
                Parser parser = new Parser(tokenList, lex.getValues());
                Node AST = parser.parse();
                progressBar.PerformStep();  //5

                String[] parserErrors = parser.getErrors();
                String parse = "";
                if (parserErrors.Length != 0)
                {
                    foreach (string error in parserErrors)
                        parse += error + "\n";

                    MessageBox.Show(lexRaport + "\n" + parse);
                    return;
                }
                progressBar.PerformStep();  //6
                String parserRaport = parser.returnVar();
                parserRaport += parser.returnValues();
                syntaxRichTextBox.Text = parserRaport;
                progressBar.PerformStep();  //7

                rpnRichTextBox.Text = RPN.getPOLYZ(AST);
                progressBar.PerformStep();  //8

                //Interpret code
                Interpreter interpreter = new Interpreter(AST,
                                                          parser.getStrings(),
                                                          parser.getFloats(),
                                                          parser.getVarArray()
                                                          );
                interpreter.interpret();

                progressBar.PerformStep();  //9

                parserErrors = interpreter.getErrors();
                if (parserErrors != null && parserErrors.Length != 0)
                {
                    String errors = "";
                    foreach (string error in parserErrors)
                        errors += error + "\n";

                    MessageBox.Show(lexRaport + "\n" + parse + "\n" + errors);
                    return;
                }
                interpretRichTextBox.Text = interpreter.getCode();
                progressBar.PerformStep();  //10
                MessageBox.Show("Интерпретация была выполнена");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: "+e.Message);
            }
        }

        static String getLexicalAnalysisResult(Token[] tokenList)
        {
            List<Token> errorToken = new List<Token>();
            int error = 0;

            String result = "";
            foreach (Token token in tokenList)
            {
                result += token.getTokenInfo();

                if (token.getTokenType() == TokenTypes.NOP)
                {
                    error++;
                    errorToken.Add(token);
                }

                result += "\n";
            }

            if (error != 0)
            {
                result += "\n==========================\n";
                result += "Error count: " + error + "\n";
                foreach (Token token in errorToken)
                {
                    result += token.getTokenInfo();
                }
                result += "\nLexical analysis have error(-s)";
                return result;
            }
            result += "\nLexical analysis did successful";
            return result;
        }

        private void Form_Load(object sender, EventArgs e)
        {

        }

        private void закрытьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeFileOperation();
        }

        private void closeFileOperation()
        {
            path = null;
            openedFileName.Text = "None";
        }

        private void сохранитьВФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileOperation();
        }

        private void saveFileOperation()
        {
            try
            {
                if (path == null)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "C file|*.c";
                    saveFileDialog1.Title = "C file";
                    saveFileDialog1.ShowDialog();

                    // If the file name is not an empty string open it for saving.
                    if (saveFileDialog1.FileName != "")
                    {
                        path = saveFileDialog1.FileName;
                        openedFileName.Text = path;
                    }
                }
                
                File.WriteAllText(path, codeRichTextBox.Text);
                MessageBox.Show("File is saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, when write to file: " + ex.Message);
            }
        }

        private void интерпретироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            interpretOperation();
        }

        private void тестовыеПримерыToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void пример4циклыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openTestFile("test4.c");
        }

        private void example1_Click(object sender, EventArgs e)
        {
            openTestFile("test1.c");
        }

        private void openTestFile(String fileName)
        {
            if(path != null)
            {
                MessageBox.Show("You should close opened file!");
                return;
            }
            try
            {
                path = "tests/" + fileName;
                openedFileName.Text = path;
                codeRichTextBox.Text = File.ReadAllText(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't open file. Error: "+ex.Message);
            }
        }

        private void example2_Click(object sender, EventArgs e)
        {
            openTestFile("test2.c");
        }

        private void example3_Click(object sender, EventArgs e)
        {
            openTestFile("test3.c");
        }

        private void example5_Click(object sender, EventArgs e)
        {
            openTestFile("test5.c");
        }

        private void пример7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openTestFile("test7.c");
        }

        private void пример6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openTestFile("test6.c");
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private string openFileDialog()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Choose file",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "c",
                Filter = "c files (*.c)|*.c",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog1.FileName;
            }
            return null;
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            openFileOperation();
        }

        private void openFileOperation()
        {
            if(path != null)
            {
                MessageBox.Show("You already edit file. Save it and close.");
                return;
            }

            path = openFileDialog();
            openedFileName.Text = path;

            try
            {
                codeRichTextBox.Text = File.ReadAllText(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't open file. Error: " + ex.Message);
            }
        }

        public void openFile(String fileName)
        {
            path = fileName;
            openedFileName.Text = fileName;
            try
            {
                codeRichTextBox.Text = File.ReadAllText(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't open file. Error: " + ex.Message);
            }
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void interpretTB_Click(object sender, EventArgs e)
        {
            interpretOperation();
        }

        private void openTB_Click(object sender, EventArgs e)
        {
            openFileOperation();
        }

        private void saveTB_Click(object sender, EventArgs e)
        {
            saveFileOperation();
        }

        private void closeTB_Click(object sender, EventArgs e)
        {
            closeFileOperation();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            
        }

        private void документацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            openTestFile("test1.c");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            openTestFile("test2.c");
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            openTestFile("test3.c");
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            openTestFile("test4.c");
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            openTestFile("test5.c");
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            openTestFile("test6.c");
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            openTestFile("test7.c");
        }

        private void codeRichTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void codeSplitContainer_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void codeSplitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            interpretOperation();
        }
    }
}
