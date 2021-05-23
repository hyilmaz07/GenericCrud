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
            Entity.Users entity = new Entity.Users();
            entity.Name = "Deneme";
            entity.BirthDate = new DateTime(1991, 06, 13);
            entity.DateCreated = DateTime.Now;
            entity.DateModifed = DateTime.Now.AddDays(-5);
            entity.UserIDCreated = -1;
            entity.UserIDModified = 5;

            Entity.Users cu = Helper.Object.Clone<Entity.Users>(entity);

            MessageBox.Show(new Business.UserManager().Add(entity).ToString());
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
