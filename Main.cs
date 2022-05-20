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
    public partial class Main
    {
        List<Form> listForms;

        public Main()
        {
            InitializeComponent();

            listForms = new List<Form>();
        }

        public Main(String fileName):this()
        {
            //MessageBox.Show(fileName);
            Form newMDIChild = new Form();
            listForms.Add(newMDIChild);
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
            newMDIChild.openFile(fileName);
        }

        private void окнаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void документацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openReference();
        }

        private void openReference()
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://okis-okis.github.io/OnyxDocs/",
                UseShellExecute = true
            });
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutProgram();
        }

        private void aboutProgram()
        {
            MessageBox.Show("Курсовая работа\nПредмет: СПО\nАвтор:Кисельник", "О программе");
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            openReference();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            aboutProgram();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form newMDIChild = new Form();
            listForms.Add(newMDIChild);
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void удалитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(Form frm in listForms)
                frm.Close();
            listForms.Clear();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Form newMDIChild = new Form();
            listForms.Add(newMDIChild);
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            foreach (Form frm in listForms)
                frm.Close();
            listForms.Clear();
        }

        private void timeLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
