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
            this.timeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.openedFileName = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.openFile = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.interpret = new System.Windows.Forms.ToolStripMenuItem();
            this.closeFile = new System.Windows.Forms.ToolStripMenuItem();
            this.examplesButton = new System.Windows.Forms.ToolStripMenuItem();
            this.example1 = new System.Windows.Forms.ToolStripMenuItem();
            this.example2 = new System.Windows.Forms.ToolStripMenuItem();
            this.example3 = new System.Windows.Forms.ToolStripMenuItem();
            this.example4 = new System.Windows.Forms.ToolStripMenuItem();
            this.example5 = new System.Windows.Forms.ToolStripMenuItem();
            this.пример6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пример7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.документацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.interpretTB = new System.Windows.Forms.ToolStripButton();
            this.openTB = new System.Windows.Forms.ToolStripButton();
            this.saveTB = new System.Windows.Forms.ToolStripButton();
            this.closeTB = new System.Windows.Forms.ToolStripButton();
            this.referenceTB = new System.Windows.Forms.ToolStripButton();
            this.aboutTB = new System.Windows.Forms.ToolStripButton();
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
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
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
            this.timeLabel,
            this.toolStripStatusLabel2,
            this.openedFileName,
            this.progressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 853);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1352, 42);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // timeLabel
            // 
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(223, 32);
            this.timeLabel.Text = "00:00:00 12.04.2022";
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
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileButton,
            this.examplesButton,
            this.документацияToolStripMenuItem,
            this.aboutButton});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1352, 48);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileButton
            // 
            this.fileButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFile,
            this.saveFile,
            this.interpret,
            this.closeFile});
            this.fileButton.Name = "fileButton";
            this.fileButton.Size = new System.Drawing.Size(90, 44);
            this.fileButton.Text = "Файл";
            // 
            // openFile
            // 
            this.openFile.Image = global::Onyx.Properties.Resources.open;
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(356, 44);
            this.openFile.Text = "Открыть файл";
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // saveFile
            // 
            this.saveFile.Image = global::Onyx.Properties.Resources.save;
            this.saveFile.Name = "saveFile";
            this.saveFile.Size = new System.Drawing.Size(356, 44);
            this.saveFile.Text = "Сохранить в файл";
            this.saveFile.Click += new System.EventHandler(this.сохранитьВФайлToolStripMenuItem_Click);
            // 
            // interpret
            // 
            this.interpret.Image = global::Onyx.Properties.Resources.interpret;
            this.interpret.Name = "interpret";
            this.interpret.Size = new System.Drawing.Size(356, 44);
            this.interpret.Text = "Интерпретировать";
            this.interpret.Click += new System.EventHandler(this.интерпретироватьToolStripMenuItem_Click);
            // 
            // closeFile
            // 
            this.closeFile.Image = global::Onyx.Properties.Resources.close;
            this.closeFile.Name = "closeFile";
            this.closeFile.Size = new System.Drawing.Size(356, 44);
            this.closeFile.Text = "Закрыть файл";
            this.closeFile.Click += new System.EventHandler(this.закрытьФайлToolStripMenuItem_Click);
            // 
            // examplesButton
            // 
            this.examplesButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.example1,
            this.example2,
            this.example3,
            this.example4,
            this.example5,
            this.пример6ToolStripMenuItem,
            this.пример7ToolStripMenuItem});
            this.examplesButton.Name = "examplesButton";
            this.examplesButton.Size = new System.Drawing.Size(248, 44);
            this.examplesButton.Text = "Тестовые примеры";
            this.examplesButton.Click += new System.EventHandler(this.тестовыеПримерыToolStripMenuItem_Click);
            // 
            // example1
            // 
            this.example1.Image = global::Onyx.Properties.Resources.example1;
            this.example1.Name = "example1";
            this.example1.Size = new System.Drawing.Size(538, 44);
            this.example1.Text = "Пример 1 (переменные)";
            this.example1.Click += new System.EventHandler(this.example1_Click);
            // 
            // example2
            // 
            this.example2.Image = global::Onyx.Properties.Resources.example2;
            this.example2.Name = "example2";
            this.example2.Size = new System.Drawing.Size(538, 44);
            this.example2.Text = "Пример 2 (целые числа)";
            this.example2.Click += new System.EventHandler(this.example2_Click);
            // 
            // example3
            // 
            this.example3.Image = global::Onyx.Properties.Resources.example3;
            this.example3.Name = "example3";
            this.example3.Size = new System.Drawing.Size(538, 44);
            this.example3.Text = "Пример 3 (дробные числа)";
            this.example3.Click += new System.EventHandler(this.example3_Click);
            // 
            // example4
            // 
            this.example4.Image = global::Onyx.Properties.Resources.example4;
            this.example4.Name = "example4";
            this.example4.Size = new System.Drawing.Size(538, 44);
            this.example4.Text = "Пример 4 (булевы значения)";
            this.example4.Click += new System.EventHandler(this.пример4циклыToolStripMenuItem_Click);
            // 
            // example5
            // 
            this.example5.Image = global::Onyx.Properties.Resources.example5;
            this.example5.Name = "example5";
            this.example5.Size = new System.Drawing.Size(538, 44);
            this.example5.Text = "Пример 5 (условные переходы)";
            this.example5.Click += new System.EventHandler(this.example5_Click);
            // 
            // пример6ToolStripMenuItem
            // 
            this.пример6ToolStripMenuItem.Image = global::Onyx.Properties.Resources.example6;
            this.пример6ToolStripMenuItem.Name = "пример6ToolStripMenuItem";
            this.пример6ToolStripMenuItem.Size = new System.Drawing.Size(538, 44);
            this.пример6ToolStripMenuItem.Text = "Пример 6 (безусловные переходы)";
            this.пример6ToolStripMenuItem.Click += new System.EventHandler(this.пример6ToolStripMenuItem_Click);
            // 
            // пример7ToolStripMenuItem
            // 
            this.пример7ToolStripMenuItem.Image = global::Onyx.Properties.Resources.example7;
            this.пример7ToolStripMenuItem.Name = "пример7ToolStripMenuItem";
            this.пример7ToolStripMenuItem.Size = new System.Drawing.Size(538, 44);
            this.пример7ToolStripMenuItem.Text = "Пример 7 (циклы)";
            this.пример7ToolStripMenuItem.Click += new System.EventHandler(this.пример7ToolStripMenuItem_Click);
            // 
            // документацияToolStripMenuItem
            // 
            this.документацияToolStripMenuItem.Name = "документацияToolStripMenuItem";
            this.документацияToolStripMenuItem.Size = new System.Drawing.Size(195, 44);
            this.документацияToolStripMenuItem.Text = "Документация";
            this.документацияToolStripMenuItem.Click += new System.EventHandler(this.документацияToolStripMenuItem_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(183, 44);
            this.aboutButton.Text = "О программе";
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
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
            this.referenceTB,
            this.aboutTB});
            this.toolStrip1.Location = new System.Drawing.Point(1306, 48);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(46, 805);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
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
            // referenceTB
            // 
            this.referenceTB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.referenceTB.Image = global::Onyx.Properties.Resources.reference;
            this.referenceTB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.referenceTB.Name = "referenceTB";
            this.referenceTB.Size = new System.Drawing.Size(45, 36);
            this.referenceTB.Text = "toolStripButton1";
            this.referenceTB.ToolTipText = "Документация";
            this.referenceTB.Click += new System.EventHandler(this.referenceTB_Click);
            // 
            // aboutTB
            // 
            this.aboutTB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.aboutTB.Image = global::Onyx.Properties.Resources.about;
            this.aboutTB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aboutTB.Name = "aboutTB";
            this.aboutTB.Size = new System.Drawing.Size(45, 36);
            this.aboutTB.Text = "toolStripButton5";
            this.aboutTB.ToolTipText = "О программе";
            this.aboutTB.Click += new System.EventHandler(this.aboutTB_Click);
            // 
            // pages
            // 
            this.pages.Controls.Add(this.codePage);
            this.pages.Controls.Add(this.lexPage);
            this.pages.Controls.Add(this.parserPage);
            this.pages.Controls.Add(this.rpnPage);
            this.pages.Controls.Add(this.interpretPage);
            this.pages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pages.Location = new System.Drawing.Point(0, 48);
            this.pages.Name = "pages";
            this.pages.SelectedIndex = 0;
            this.pages.Size = new System.Drawing.Size(1306, 805);
            this.pages.TabIndex = 3;
            // 
            // codePage
            // 
            this.codePage.Controls.Add(this.codeSplitContainer);
            this.codePage.Location = new System.Drawing.Point(8, 51);
            this.codePage.Name = "codePage";
            this.codePage.Padding = new System.Windows.Forms.Padding(3);
            this.codePage.Size = new System.Drawing.Size(1290, 746);
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
            this.codeSplitContainer.Size = new System.Drawing.Size(1284, 740);
            this.codeSplitContainer.SplitterDistance = 659;
            this.codeSplitContainer.SplitterWidth = 3;
            this.codeSplitContainer.TabIndex = 0;
            // 
            // codeRichTextBox
            // 
            this.codeRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.codeRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.codeRichTextBox.Name = "codeRichTextBox";
            this.codeRichTextBox.Size = new System.Drawing.Size(1284, 659);
            this.codeRichTextBox.TabIndex = 0;
            this.codeRichTextBox.Text = "int main(){\n//code\nreturn 0;\n}";
            // 
            // interpretCodeButton
            // 
            this.interpretCodeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.interpretCodeButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.interpretCodeButton.Location = new System.Drawing.Point(1001, 0);
            this.interpretCodeButton.Name = "interpretCodeButton";
            this.interpretCodeButton.Size = new System.Drawing.Size(283, 78);
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
            this.lexPage.Size = new System.Drawing.Size(1290, 754);
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
            this.lexRichTextBox.Size = new System.Drawing.Size(1284, 748);
            this.lexRichTextBox.TabIndex = 0;
            this.lexRichTextBox.Text = "";
            // 
            // parserPage
            // 
            this.parserPage.Controls.Add(this.syntaxRichTextBox);
            this.parserPage.Location = new System.Drawing.Point(8, 51);
            this.parserPage.Name = "parserPage";
            this.parserPage.Padding = new System.Windows.Forms.Padding(3);
            this.parserPage.Size = new System.Drawing.Size(1290, 754);
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
            this.syntaxRichTextBox.Size = new System.Drawing.Size(1284, 748);
            this.syntaxRichTextBox.TabIndex = 1;
            this.syntaxRichTextBox.Text = "";
            // 
            // rpnPage
            // 
            this.rpnPage.Controls.Add(this.rpnRichTextBox);
            this.rpnPage.Location = new System.Drawing.Point(8, 51);
            this.rpnPage.Name = "rpnPage";
            this.rpnPage.Size = new System.Drawing.Size(1290, 754);
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
            this.rpnRichTextBox.Size = new System.Drawing.Size(1290, 754);
            this.rpnRichTextBox.TabIndex = 1;
            this.rpnRichTextBox.Text = "";
            // 
            // interpretPage
            // 
            this.interpretPage.Controls.Add(this.interpretRichTextBox);
            this.interpretPage.Location = new System.Drawing.Point(8, 51);
            this.interpretPage.Name = "interpretPage";
            this.interpretPage.Size = new System.Drawing.Size(1290, 754);
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
            this.interpretRichTextBox.Size = new System.Drawing.Size(1290, 754);
            this.interpretRichTextBox.TabIndex = 2;
            this.interpretRichTextBox.Text = "";
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 895);
            this.Controls.Add(this.pages);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Onyx";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_FormClosed);
            this.Load += new System.EventHandler(this.Form_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileButton;
        private System.Windows.Forms.ToolStripMenuItem openFile;
        private System.Windows.Forms.ToolStripMenuItem closeFile;
        private System.Windows.Forms.ToolStripMenuItem saveFile;
        private System.Windows.Forms.ToolStripMenuItem aboutButton;
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
        private System.Windows.Forms.ToolStripStatusLabel timeLabel;
        private System.Windows.Forms.ToolStripMenuItem interpret;
        private System.Windows.Forms.ToolStripMenuItem examplesButton;
        private System.Windows.Forms.ToolStripMenuItem example1;
        private System.Windows.Forms.ToolStripMenuItem example2;
        private System.Windows.Forms.ToolStripMenuItem example3;
        private System.Windows.Forms.ToolStripMenuItem example4;
        private System.Windows.Forms.ToolStripMenuItem example5;
        private System.Windows.Forms.ToolStripButton openTB;
        private System.Windows.Forms.ToolStripButton saveTB;
        private System.Windows.Forms.ToolStripButton closeTB;
        private System.Windows.Forms.ToolStripButton aboutTB;
        private System.Windows.Forms.ToolStripMenuItem пример6ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пример7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel openedFileName;
        private System.Windows.Forms.ToolStripMenuItem документацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton referenceTB;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
    }
}

