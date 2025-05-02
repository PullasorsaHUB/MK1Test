using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MyMK1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text;

            if (username.Length == 0 || password.Length == 0)
            {
                MessageBox.Show("Täytä molemmat kentät.");
                return;
            }

            string hashedPassword = Security.HashPassword(password);

            string[] existingUsers = File.Exists("users.txt") ? File.ReadAllLines("users.txt") : new string[0];

            foreach (var line in existingUsers)
            {
                if (line.StartsWith(username + ":"))
                {
                    MessageBox.Show("Käyttäjänimi on jo olemassa.");
                    return;
                }
            }

            File.AppendAllText("users.txt", $"{username}:{hashedPassword}{Environment.NewLine}");
            MessageBox.Show("Käyttäjä luotu!");
            this.Close(); // Sulje rekisteröintilomake
        }
    }
}
