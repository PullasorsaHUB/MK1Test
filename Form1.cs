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
    public partial class Form1 : BaseForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Username
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Password
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Username Textbox
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            // Password Textbox
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Login
            string username = textBox1.Text.Trim();
            string password = txtPassword.Text;

            if (!File.Exists("users.txt"))
            {
                MessageBox.Show("Käyttäjätiedostoa ei ole.");
                return;
            }

            string hashedInput = Security.HashPassword(password);
            string[] lines = File.ReadAllLines("users.txt");

            foreach (string line in lines)
            {
                string[] parts = line.Split(':');
                if (parts.Length == 2 && parts[0] == username && parts[1] == hashedInput)
                {
                    // Kirjautuminen onnistui
                    Form2 mainForm = new Form2();
                    mainForm.FormClosed += (s, args) => this.Close();
                    mainForm.Show();
                    this.Hide();
                    return;
                }
            }

            MessageBox.Show("Väärä käyttäjänimi tai salasana.");
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Form3 registerForm = new Form3();
            registerForm.ShowDialog();
        }
    }
}
