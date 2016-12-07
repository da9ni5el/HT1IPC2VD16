using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HT1IPC2VD16
{
    public partial class Form1 : Form
    {
        Postfijo pt = new Postfijo();

        string operacion = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            operacion = textBox1.Text + "+" + textBox2.Text;
            Console.WriteLine(operacion);
            Console.WriteLine(pt.post_fijo(operacion));
        }
    }
}
