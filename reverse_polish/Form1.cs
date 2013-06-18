using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace reverse_polish
{

    public partial class Form1 : Form
    {
        ReversePolish rp = new ReversePolish();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                label1.Text = "" + rp.ExecutePolish(rp.GetPolishString(textBox1.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rp.Variables[textBox2.Text] = int.Parse(textBox3.Text);
            listBox1.Items.Add("変数セット：" + textBox2.Text + "=" + textBox3.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("変数内容：" + textBox2.Text + "=" + rp.Variables[textBox2.Text]);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = "" + rp.isVariable(textBox1.Text);
        }
    }
}
