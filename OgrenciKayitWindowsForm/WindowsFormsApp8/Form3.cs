using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        Form2 form2 = new Form2();
        public Form3(int index, string borc, string taksit)
        {
            InitializeComponent();
            label1.Text = index + ". Taksit, " + taksit + " TL Karsiliginda Odenmistir";
            label2.Text = "Kalan borc = " + borc;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
        }
    }
}
