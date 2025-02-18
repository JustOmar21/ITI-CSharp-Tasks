using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Day_12
{
    public partial class InsertLine : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string TextboxContent { get => textBox1.Text; set => textBox1.Text = value; }
        public InsertLine()
        {
            InitializeComponent();
        }
    }
}
