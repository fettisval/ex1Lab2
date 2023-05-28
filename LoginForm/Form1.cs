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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LoginForm
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string utilizator = txtUsername.Text;
            string parola = txtPassword.Text;
            bool autentificareReusita = false;

            using (StreamReader sr = new StreamReader("users.txt"))
            {
                string linie;
                while ((linie = sr.ReadLine()) != null)
                {
                    string[] campuri = linie.Split(':');
                    if (campuri[0] == utilizator && campuri[1] == parola)
                    {
                         autentificareReusita = true;
                         break;
                    }
                }
            }
            if (autentificareReusita)
            {
                this.Hide();
                Form2 form2 = new Form2();
                form2.SetUsername(utilizator);
                form2.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Numele de utilizator sau parola sunt incorecte!");                
            }
        }
    }
}
