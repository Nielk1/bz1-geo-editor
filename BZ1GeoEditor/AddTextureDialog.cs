using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BZ1GeoEditor
{
    public partial class AddTextureDialog : Form
    {
        public string Value { get; private set; }
        
        public AddTextureDialog()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Value = textBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
