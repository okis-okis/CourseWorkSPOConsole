namespace Onyx
{
    partial class Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.openedFileName = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.interpretTB = new System.Windows.Forms.ToolStripButton();
            this.openTB = new System.Windows.Forms.ToolStripButton();
            this.saveTB = new System.Windows.Forms.ToolStripButton();
            this.closeTB = new System.Windows.Forms.ToolStripButton();
            this.pages = new System.Windows.Forms.TabControl();
            this.codePage = new System.Windows.Forms.TabPage();
            this.codeSplitContainer = new System.Windows.Forms.SplitContainer();
            this.codeRichTextBox = new System.Windows.Forms.RichTextBox();
            this.interpretCodeButton = new System.Windows.Forms.Button();
            this.lexPage = new System.Windows.Forms.TabPage();
            this.lexRichTextBox = new System.Windows.Forms.RichTextBox();
            this.parserPage = new System.Windows.Forms.TabPage();
            this.syntaxRichTextBox = new System.Windows.Forms.RichTextBox();
            this.rpnPage = new System.Windows.Forms.TabPage();
            this.rpnRichTextBox = new System.Windows.Forms.RichTextBox();
            this.interpretPage = new System.Windows.Forms.TabPage();
            this.interpretRichTextBox = new System.Windows.Forms.RichTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.pages.SuspendLayout();
            this.codePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.codeSplitContainer)).BeginInit();
            this.codeSplitContainer.Panel1.SuspendLayout();
            this.codeSplitContainer.Panel2.SuspendLayout();
            this.codeSplitContainer.SuspendLayout();
            this.lexPage.SuspendLayout();
            this.parserPage.SuspendLayout();
            this.rpnPage.SuspendLayout();
            this.interpretPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.openedFileName,
            this.progressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 650);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1190, 42);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(145, 32);
            this.toolStripStatusLabel2.Text = "Opened file:";
            this.toolStripStatusLabel2.Click += new System.EventHandler(this.toolStripStatusLabel2_Click);
            // 
            // openedFileName
            // 
            this.openedFileName.Name = "openedFileName";
            this.openedFileName.Size = new System.Drawing.Size(73, 32);
            this.openedFileName.Text = "None";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 30);
            this.progressBar.ToolTipText = "Процесс выполнения интерпретации";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.interpretTB,
            this.openTB,
            this.saveTB,
            this.closeTB,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripButton7});
            this.toolStrip1.Location = new System.Drawing.Point(1144, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(46, 650);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // interpretTB
            // 
            this.interpretTB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.interpretTB.Image = global::Onyx.Properties.Resources.interpret;
            this.interpretTB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.interpretTB.Name = "interpretTB";
            this.interpretTB.Size = new System.Drawing.Size(45, 36);
            this.interpretTB.Text = "toolStripButton1";
            this.interpretTB.ToolTipText = "Интерпретировать";
            this.interpretTB.Click += new System.EventHandler(this.interpretTB_Click);
            // 
            // openTB
            // 
            this.openTB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openTB.Image = global::Onyx.Properties.Resources.open;
            this.openTB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openTB.Name = "openTB";
            this.openTB.Size = new System.Drawing.Size(45, 36);
            this.openTB.Text = "toolStripButton2";
            this.openTB.ToolTipText = "Открыть файл";
            this.openTB.Click += new System.EventHandler(this.openTB_Click);
            // 
            // saveTB
            // 
            this.saveTB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveTB.Image = global::Onyx.Properties.Resources.save;
            this.saveTB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveTB.Name = "saveTB";
            this.saveTB.Size = new System.Drawing.Size(45, 36);
            this.saveTB.Text = "toolStripButton3";
            this.saveTB.ToolTipText = "Сохранить файл";
            this.saveTB.Click += new System.EventHandler(this.saveTB_Click);
            // 
            // closeTB
            // 
            this.closeTB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.closeTB.Image = global::Onyx.Properties.Resources.close;
            this.closeTB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.closeTB.Name = "closeTB";
            this.closeTB.Size = new System.Drawing.Size(45, 36);
            this.closeTB.Text = "toolStripButton4";
            this.closeTB.ToolTipText = "Закрыть файл";
            this.closeTB.Click += new System.EventHandler(this.closeTB_Click);
            // 
            // pages
            // 
            this.pages.Controls.Add(this.codePage);
            this.pages.Controls.Add(this.lexPage);
            this.pages.Controls.Add(this.parserPage);
            this.pages.Controls.Add(this.rpnPage);
            this.pages.Controls.Add(this.interpretPage);
            this.pages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pages.Location = new System.Drawing.Point(0, 0);
            this.pages.Name = "pages";
            this.pages.SelectedIndex = 0;
            this.pages.Size = new System.Drawing.Size(1144, 650);
            this.pages.TabIndex = 3;
            // 
            // codePage
            // 
            this.codePage.Controls.Add(this.codeSplitContainer);
            this.codePage.Location = new System.Drawing.Point(8, 51);
            this.codePage.Name = "codePage";
            this.codePage.Padding = new System.Windows.Forms.Padding(3);
            this.codePage.Size = new System.Drawing.Size(1128, 591);
            this.codePage.TabIndex = 0;
            this.codePage.Text = "Исходный код";
            this.codePage.UseVisualStyleBackColor = true;
            // 
            // codeSplitContainer
            // 
            this.codeSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeSplitContainer.Location = new System.Drawing.Point(3, 3);
            this.codeSplitContainer.Name = "codeSplitContainer";
            this.codeSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // codeSplitContainer.Panel1
            // 
            this.codeSplitContainer.Panel1.Controls.Add(this.codeRichTextBox);
            // 
            // codeSplitContainer.Panel2
            // 
            this.codeSplitContainer.Panel2.Controls.Add(this.interpretCodeButton);
            this.codeSplitContainer.Size = new System.Drawing.Size(1122, 585);
            this.codeSplitContainer.SplitterDistance = 518;
            this.codeSplitContainer.SplitterWidth = 3;
            this.codeSplitContainer.TabIndex = 0;
            // 
            // codeRichTextBox
            // 
            this.codeRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.codeRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.codeRichTextBox.Name = "codeRichTextBox";
            this.codeRichTextBox.Size = new System.Drawing.Size(1122, 518);
            this.codeRichTextBox.TabIndex = 0;
            this.codeRichTextBox.Text = "int main(){\n//code\nreturn 0;\n}";
            // 
            // interpretCodeButton
            // 
            this.interpretCodeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.interpretCodeButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.interpretCodeButton.Location = new System.Drawing.Point(839, 0);
            this.interpretCodeButton.Name = "interpretCodeButton";
            this.interpretCodeButton.Size = new System.Drawing.Size(283, 64);
            this.interpretCodeButton.TabIndex = 0;
            this.interpretCodeButton.Text = "Интерпретировать код";
            this.interpretCodeButton.UseVisualStyleBackColor = true;
            this.interpretCodeButton.Click += new System.EventHandler(this.interpretCodeButton_Click);
            // 
            // lexPage
            // 
            this.lexPage.Controls.Add(this.lexRichTextBox);
            this.lexPage.Location = new System.Drawing.Point(8, 51);
            this.lexPage.Name = "lexPage";
            this.lexPage.Padding = new System.Windows.Forms.Padding(3);
            this.lexPage.Size = new System.Drawing.Size(1267, 711);
            this.lexPage.TabIndex = 1;
            this.lexPage.Text = "Лексический анализ";
            this.lexPage.UseVisualStyleBackColor = true;
            // 
            // lexRichTextBox
            // 
            this.lexRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lexRichTextBox.Location = new System.Drawing.Point(3, 3);
            this.lexRichTextBox.Name = "lexRichTextBox";
            this.lexRichTextBox.ReadOnly = true;
            this.lexRichTextBox.Size = new System.Drawing.Size(1261, 705);
            this.lexRichTextBox.TabIndex = 0;
            this.lexRichTextBox.Text = "";
            // 
            // parserPage
            // 
            this.parserPage.Controls.Add(this.syntaxRichTextBox);
            this.parserPage.Location = new System.Drawing.Point(8, 51);
            this.parserPage.Name = "parserPage";
            this.parserPage.Padding = new System.Windows.Forms.Padding(3);
            this.parserPage.Size = new System.Drawing.Size(1267, 711);
            this.parserPage.TabIndex = 2;
            this.parserPage.Text = "Синтаксический анализ";
            this.parserPage.UseVisualStyleBackColor = true;
            // 
            // syntaxRichTextBox
            // 
            this.syntaxRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.syntaxRichTextBox.Location = new System.Drawing.Point(3, 3);
            this.syntaxRichTextBox.Name = "syntaxRichTextBox";
            this.syntaxRichTextBox.ReadOnly = true;
            this.syntaxRichTextBox.Size = new System.Drawing.Size(1261, 705);
            this.syntaxRichTextBox.TabIndex = 1;
            this.syntaxRichTextBox.Text = "";
            // 
            // rpnPage
            // 
            this.rpnPage.Controls.Add(this.rpnRichTextBox);
            this.rpnPage.Location = new System.Drawing.Point(8, 51);
            this.rpnPage.Name = "rpnPage";
            this.rpnPage.Size = new System.Drawing.Size(1267, 711);
            this.rpnPage.TabIndex = 4;
            this.rpnPage.Text = "ПОЛИЗ";
            this.rpnPage.UseVisualStyleBackColor = true;
            // 
            // rpnRichTextBox
            // 
            this.rpnRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpnRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.rpnRichTextBox.Name = "rpnRichTextBox";
            this.rpnRichTextBox.ReadOnly = true;
            this.rpnRichTextBox.Size = new System.Drawing.Size(1267, 711);
            this.rpnRichTextBox.TabIndex = 1;
            this.rpnRichTextBox.Text = "";
            // 
            // interpretPage
            // 
            this.interpretPage.Controls.Add(this.interpretRichTextBox);
            this.interpretPage.Location = new System.Drawing.Point(8, 51);
            this.interpretPage.Name = "interpretPage";
            this.interpretPage.Size = new System.Drawing.Size(1267, 711);
            this.interpretPage.TabIndex = 3;
            this.interpretPage.Text = "Интерпретация";
            this.interpretPage.UseVisualStyleBackColor = true;
            // 
            // interpretRichTextBox
            // 
            this.interpretRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.interpretRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.interpretRichTextBox.Name = "interpretRichTextBox";
            this.interpretRichTextBox.ReadOnly = true;
            this.interpretRichTextBox.Size = new System.Drawing.Size(1267, 711);
            this.interpretRichTextBox.TabIndex = 2;
            this.interpretRichTextBox.Text = "";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(45, 6);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::Onyx.Properties.Resources.example1;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(45, 36);
            this.toolStripButton1.Text = "Пример 1(переменные)";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::Onyx.Properties.Resources.example2;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(45, 36);
            this.toolStripButton2.Text = "Пример 2 (целые числа)";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::Onyx.Properties.Resources.example3;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(45, 36);
            this.toolStripButton3.Text = "Пример 3 (дробные числа)";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::Onyx.Properties.Resources.example4;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(45, 36);
            this.toolStripButton4.Text = "Пример 4 (булевы значения)";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = global::Onyx.Properties.Resources.example5;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(45, 36);
            this.toolStripButton5.Text = "Пример 5 (условные переходы)";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = global::Onyx.Properties.Resources.example6;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(45, 36);
            this.toolStripButton6.Text = "Пример 6 (безусловные переходы)";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = global::Onyx.Properties.Resources.example7;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(45, 36);
            this.toolStripButton7.Text = "Пример 7 (циклы)";
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 692);
            this.Controls.Add(this.pages);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_FormClosed);
            this.Load += new System.EventHandler(this.Form_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pages.ResumeLayout(false);
            this.codePage.ResumeLayout(false);
            this.codeSplitContainer.Panel1.ResumeLayout(false);
            this.codeSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.codeSplitContainer)).EndInit();
            this.codeSplitContainer.ResumeLayout(false);
            this.lexPage.ResumeLayout(false);
            this.parserPage.ResumeLayout(false);
            this.rpnPage.ResumeLayout(false);
            this.interpretPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton interpretTB;
        private System.Windows.Forms.TabControl pages;
        private System.Windows.Forms.TabPage codePage;
        private System.Windows.Forms.SplitContainer codeSplitContainer;
        private System.Windows.Forms.RichTextBox codeRichTextBox;
        private System.Windows.Forms.Button interpretCodeButton;
        private System.Windows.Forms.TabPage lexPage;
        private System.Windows.Forms.RichTextBox lexRichTextBox;
        private System.Windows.Forms.TabPage parserPage;
        private System.Windows.Forms.TabPage interpretPage;
        private System.Windows.Forms.RichTextBox syntaxRichTextBox;
        private System.Windows.Forms.TabPage rpnPage;
        private System.Windows.Forms.RichTextBox rpnRichTextBox;
        private System.Windows.Forms.RichTextBox interpretRichTextBox;
        private System.Windows.Forms.ToolStripButton openTB;
        private System.Windows.Forms.ToolStripButton saveTB;
        private System.Windows.Forms.ToolStripButton closeTB;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel openedFileName;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
    }
}

