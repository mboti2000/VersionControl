using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();

            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";

            label1.Text = Resource2.FullName;
            button1.Text = Resource2.Add;
            button2.Text = Resource2.WriteToFile;
            button3.Text = Resource2.Delete;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u = new User();
         
            u.FullName = textBox1.Text;
            
            users.Add(u);
            textBox1.Text = "";
        }

   
        private void button2_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() != DialogResult.OK) return;

            using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
            {

                foreach (var u in users)
                {
                    sw.Write(u.ID);
                    sw.Write(";");
                    sw.Write(u.FullName);
                    sw.Write(";");
                    sw.WriteLine();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           var deleteItem =  (User)listBox1.SelectedItem;
           users.Remove(deleteItem);
        }
    }
}
