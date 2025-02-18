namespace Day_12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void closeBTN_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openBTN_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Rich File Text|*.rft|Text File|*.txt";
            openFileDialog1.InitialDirectory = Application.StartupPath.Split(@"\bin")[0];
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                noteTXT.LoadFile(openFileDialog1.FileName, (RichTextBoxStreamType)openFileDialog1.FilterIndex - 1);
            }
        }

        private void saveBTN_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Rich File Text|*.rft|Text File|*.txt";
            saveFileDialog1.InitialDirectory = Application.StartupPath.Split(@"\bin")[0];
            saveFileDialog1.FileName = "";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                noteTXT.SaveFile(saveFileDialog1.FileName, (RichTextBoxStreamType)saveFileDialog1.FilterIndex - 1);
            }
        }

        private void fontBTN_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = noteTXT.SelectionFont ?? fontDialog1.Font;

            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                noteTXT.SelectionFont = fontDialog1.Font;
            }
        }

        private void colorBTN_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = noteTXT.SelectionColor;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                noteTXT.SelectionColor = colorDialog1.Color;
            }
        }
        InsertLine form = new();
        private void customBTN_Click(object sender, EventArgs e)
        {
            form.TextboxContent = "";
            if (form.ShowDialog() == DialogResult.OK)
                noteTXT.AppendText(form.TextboxContent.ToUpper());
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close this form ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
