namespace Day_12
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            noteTXT = new RichTextBox();
            openBTN = new Button();
            saveBTN = new Button();
            closeBTN = new Button();
            fontBTN = new Button();
            colorBTN = new Button();
            customBTN = new Button();
            fontDialog1 = new FontDialog();
            colorDialog1 = new ColorDialog();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            SuspendLayout();
            // 
            // noteTXT
            // 
            noteTXT.Location = new Point(13, 47);
            noteTXT.Name = "noteTXT";
            noteTXT.Size = new Size(930, 438);
            noteTXT.TabIndex = 0;
            noteTXT.Text = "";
            // 
            // openBTN
            // 
            openBTN.BackColor = Color.FromArgb(39, 45, 194);
            openBTN.Cursor = Cursors.Hand;
            openBTN.FlatAppearance.BorderSize = 0;
            openBTN.FlatStyle = FlatStyle.Flat;
            openBTN.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            openBTN.ForeColor = SystemColors.Control;
            openBTN.Location = new Point(13, 12);
            openBTN.Name = "openBTN";
            openBTN.Size = new Size(310, 29);
            openBTN.TabIndex = 1;
            openBTN.Text = "Open";
            openBTN.UseVisualStyleBackColor = false;
            openBTN.Click += openBTN_Click;
            // 
            // saveBTN
            // 
            saveBTN.BackColor = Color.FromArgb(39, 194, 45);
            saveBTN.Cursor = Cursors.Hand;
            saveBTN.FlatAppearance.BorderSize = 0;
            saveBTN.FlatStyle = FlatStyle.Flat;
            saveBTN.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            saveBTN.ForeColor = SystemColors.Control;
            saveBTN.Location = new Point(323, 12);
            saveBTN.Name = "saveBTN";
            saveBTN.Size = new Size(310, 29);
            saveBTN.TabIndex = 2;
            saveBTN.Text = "Save";
            saveBTN.UseVisualStyleBackColor = false;
            saveBTN.Click += saveBTN_Click;
            // 
            // closeBTN
            // 
            closeBTN.BackColor = Color.FromArgb(194, 39, 45);
            closeBTN.Cursor = Cursors.Hand;
            closeBTN.FlatAppearance.BorderSize = 0;
            closeBTN.FlatStyle = FlatStyle.Flat;
            closeBTN.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            closeBTN.ForeColor = SystemColors.Control;
            closeBTN.Location = new Point(633, 12);
            closeBTN.Name = "closeBTN";
            closeBTN.Size = new Size(310, 29);
            closeBTN.TabIndex = 3;
            closeBTN.Text = "Close";
            closeBTN.UseVisualStyleBackColor = false;
            closeBTN.Click += closeBTN_Click;
            // 
            // fontBTN
            // 
            fontBTN.BackColor = Color.FromArgb(117, 42, 120);
            fontBTN.Cursor = Cursors.Hand;
            fontBTN.FlatAppearance.BorderSize = 0;
            fontBTN.FlatStyle = FlatStyle.Flat;
            fontBTN.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            fontBTN.ForeColor = SystemColors.Control;
            fontBTN.Location = new Point(13, 491);
            fontBTN.Name = "fontBTN";
            fontBTN.Size = new Size(310, 29);
            fontBTN.TabIndex = 4;
            fontBTN.Text = "Font";
            fontBTN.UseVisualStyleBackColor = false;
            fontBTN.Click += fontBTN_Click;
            // 
            // colorBTN
            // 
            colorBTN.BackColor = Color.FromArgb(39, 120, 120);
            colorBTN.Cursor = Cursors.Hand;
            colorBTN.FlatAppearance.BorderSize = 0;
            colorBTN.FlatStyle = FlatStyle.Flat;
            colorBTN.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            colorBTN.ForeColor = SystemColors.Control;
            colorBTN.Location = new Point(323, 491);
            colorBTN.Name = "colorBTN";
            colorBTN.Size = new Size(310, 29);
            colorBTN.TabIndex = 5;
            colorBTN.Text = "Color";
            colorBTN.UseVisualStyleBackColor = false;
            colorBTN.Click += colorBTN_Click;
            // 
            // customBTN
            // 
            customBTN.BackColor = Color.FromArgb(194, 120, 39);
            customBTN.Cursor = Cursors.Hand;
            customBTN.FlatAppearance.BorderSize = 0;
            customBTN.FlatStyle = FlatStyle.Flat;
            customBTN.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            customBTN.ForeColor = SystemColors.Control;
            customBTN.Location = new Point(633, 491);
            customBTN.Name = "customBTN";
            customBTN.Size = new Size(310, 29);
            customBTN.TabIndex = 6;
            customBTN.Text = "Custom";
            customBTN.UseVisualStyleBackColor = false;
            customBTN.Click += customBTN_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(956, 532);
            Controls.Add(noteTXT);
            Controls.Add(customBTN);
            Controls.Add(colorBTN);
            Controls.Add(fontBTN);
            Controls.Add(closeBTN);
            Controls.Add(saveBTN);
            Controls.Add(openBTN);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Text Editor";
            FormClosing += Form1_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox noteTXT;
        private Button openBTN;
        private Button saveBTN;
        private Button closeBTN;
        private Button fontBTN;
        private Button colorBTN;
        private Button customBTN;
        private FontDialog fontDialog1;
        private ColorDialog colorDialog1;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
    }
}
