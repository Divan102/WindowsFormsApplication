using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PRG282_Group2_Project
{
    public partial class LoginForm : Form
    {
        FileHandler fileHandler = new FileHandler();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Entry fields cant be empty!");
            }
            else
            {
                try
                {
                    string username = txtUsername.Text;
                    string password = txtPassword.Text;
                    int i = 1;

                    if (fileHandler.Read(username, password) == true)
                    {
                        MessageBox.Show("Welcome " + username);
                        this.Hide();
                        StudentForm studentForm = new StudentForm();
                        studentForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect details. Try again");
                        txtUsername.Clear();
                        txtPassword.Clear();
                        txtUsername.Focus();                       
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("The was and error:" + ex.ToString());
                }
            } 
        }
    }
}
