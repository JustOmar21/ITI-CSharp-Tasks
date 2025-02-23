namespace UAL
{
    partial class detailedView
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
            listBox1 = new ListBox();
            label1 = new Label();
            label2 = new Label();
            prodID = new NumericUpDown();
            nameTXT = new TextBox();
            label3 = new Label();
            catBOX = new ComboBox();
            label4 = new Label();
            supBOX = new ComboBox();
            commitBTN = new Button();
            addBTN = new Button();
            supADD = new ComboBox();
            label5 = new Label();
            catAdd = new ComboBox();
            label6 = new Label();
            nameAdd = new TextBox();
            label7 = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)prodID).BeginInit();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(12, 54);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(165, 384);
            listBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(183, 54);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 1;
            label1.Text = "Product ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(183, 126);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 2;
            label2.Text = "Name";
            // 
            // prodID
            // 
            prodID.Enabled = false;
            prodID.Location = new Point(183, 77);
            prodID.Name = "prodID";
            prodID.Size = new Size(222, 27);
            prodID.TabIndex = 3;
            prodID.ValueChanged += prodID_ValueChanged;
            // 
            // nameTXT
            // 
            nameTXT.Location = new Point(183, 149);
            nameTXT.Name = "nameTXT";
            nameTXT.Size = new Size(222, 27);
            nameTXT.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(183, 198);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 5;
            label3.Text = "Category";
            // 
            // catBOX
            // 
            catBOX.FormattingEnabled = true;
            catBOX.Location = new Point(183, 221);
            catBOX.Name = "catBOX";
            catBOX.Size = new Size(222, 28);
            catBOX.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(183, 271);
            label4.Name = "label4";
            label4.Size = new Size(64, 20);
            label4.TabIndex = 7;
            label4.Text = "Supplier";
            // 
            // supBOX
            // 
            supBOX.FormattingEnabled = true;
            supBOX.Location = new Point(183, 294);
            supBOX.Name = "supBOX";
            supBOX.Size = new Size(222, 28);
            supBOX.TabIndex = 8;
            // 
            // commitBTN
            // 
            commitBTN.Location = new Point(183, 409);
            commitBTN.Name = "commitBTN";
            commitBTN.Size = new Size(222, 29);
            commitBTN.TabIndex = 9;
            commitBTN.Text = "Commit";
            commitBTN.UseVisualStyleBackColor = true;
            commitBTN.Click += commitBTN_Click;
            // 
            // addBTN
            // 
            addBTN.Location = new Point(566, 409);
            addBTN.Name = "addBTN";
            addBTN.Size = new Size(222, 29);
            addBTN.TabIndex = 18;
            addBTN.Text = "Add";
            addBTN.UseVisualStyleBackColor = true;
            addBTN.Click += addBTN_Click;
            // 
            // supADD
            // 
            supADD.FormattingEnabled = true;
            supADD.Location = new Point(566, 294);
            supADD.Name = "supADD";
            supADD.Size = new Size(222, 28);
            supADD.TabIndex = 17;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(566, 271);
            label5.Name = "label5";
            label5.Size = new Size(64, 20);
            label5.TabIndex = 16;
            label5.Text = "Supplier";
            // 
            // catAdd
            // 
            catAdd.FormattingEnabled = true;
            catAdd.Location = new Point(566, 221);
            catAdd.Name = "catAdd";
            catAdd.Size = new Size(222, 28);
            catAdd.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(566, 198);
            label6.Name = "label6";
            label6.Size = new Size(69, 20);
            label6.TabIndex = 14;
            label6.Text = "Category";
            // 
            // nameAdd
            // 
            nameAdd.Location = new Point(566, 149);
            nameAdd.Name = "nameAdd";
            nameAdd.Size = new Size(222, 27);
            nameAdd.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(566, 126);
            label7.Name = "label7";
            label7.Size = new Size(49, 20);
            label7.TabIndex = 11;
            label7.Text = "Name";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(474, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(2, 426);
            panel1.TabIndex = 19;
            // 
            // detailedView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(addBTN);
            Controls.Add(supADD);
            Controls.Add(label5);
            Controls.Add(catAdd);
            Controls.Add(label6);
            Controls.Add(nameAdd);
            Controls.Add(label7);
            Controls.Add(commitBTN);
            Controls.Add(supBOX);
            Controls.Add(label4);
            Controls.Add(catBOX);
            Controls.Add(label3);
            Controls.Add(nameTXT);
            Controls.Add(prodID);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "detailedView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "detailedView";
            FormClosed += detailedView_FormClosed;
            ((System.ComponentModel.ISupportInitialize)prodID).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private Label label1;
        private Label label2;
        private NumericUpDown prodID;
        private TextBox nameTXT;
        private Label label3;
        private ComboBox catBOX;
        private Label label4;
        private ComboBox supBOX;
        private Button commitBTN;
        private Button addBTN;
        private ComboBox supADD;
        private Label label5;
        private ComboBox catAdd;
        private Label label6;
        private TextBox nameAdd;
        private Label label7;
        private Panel panel1;
    }
}