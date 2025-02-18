namespace Day_12
{
    partial class InsertLine
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            okBTN = new Button();
            cancelBTN = new Button();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(12, 31);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Type here";
            textBox1.Size = new Size(686, 20);
            textBox1.TabIndex = 0;
            // 
            // okBTN
            // 
            okBTN.BackColor = Color.FromArgb(39, 194, 45);
            okBTN.Cursor = Cursors.Hand;
            okBTN.DialogResult = DialogResult.OK;
            okBTN.FlatAppearance.BorderSize = 0;
            okBTN.FlatStyle = FlatStyle.Flat;
            okBTN.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            okBTN.ForeColor = SystemColors.Control;
            okBTN.Location = new Point(12, 82);
            okBTN.Name = "okBTN";
            okBTN.Size = new Size(343, 29);
            okBTN.TabIndex = 1;
            okBTN.Text = "Insert UPPERCASE";
            okBTN.UseVisualStyleBackColor = false;
            // 
            // cancelBTN
            // 
            cancelBTN.BackColor = Color.FromArgb(194, 39, 45);
            cancelBTN.Cursor = Cursors.Hand;
            cancelBTN.DialogResult = DialogResult.Cancel;
            cancelBTN.FlatAppearance.BorderSize = 0;
            cancelBTN.FlatStyle = FlatStyle.Flat;
            cancelBTN.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            cancelBTN.ForeColor = SystemColors.Control;
            cancelBTN.Location = new Point(355, 82);
            cancelBTN.Name = "cancelBTN";
            cancelBTN.Size = new Size(343, 29);
            cancelBTN.TabIndex = 2;
            cancelBTN.Text = "Cancel";
            cancelBTN.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Desktop;
            panel1.Location = new Point(12, 57);
            panel1.Name = "panel1";
            panel1.Size = new Size(686, 2);
            panel1.TabIndex = 3;
            // 
            // InsertLine
            // 
            AcceptButton = okBTN;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelBTN;
            ClientSize = new Size(710, 127);
            ControlBox = false;
            Controls.Add(panel1);
            Controls.Add(cancelBTN);
            Controls.Add(okBTN);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "InsertLine";
            StartPosition = FormStartPosition.CenterParent;
            Text = "InsertLine";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button okBTN;
        private Button cancelBTN;
        private Panel panel1;
    }
}