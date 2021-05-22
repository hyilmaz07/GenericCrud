using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenericCrud.Winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(new Business.UserManager().Add(new Entity.Users()).ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Business.UserManager().Update(new Entity.Users());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show(new Business.UserManager().CustomMethod().ToString());
        }
    }
}
