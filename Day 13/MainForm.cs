namespace Day_13
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GridForm form = new(this);
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            detailedView form = new detailedView(this);
            form.Show();
            this.Hide();
        }
    }
}
