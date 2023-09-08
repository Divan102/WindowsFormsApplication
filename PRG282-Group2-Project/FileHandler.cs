using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace PRG282_Group2_Project
{
    internal class FileHandler
    {
        public bool Read(string username, string password)
        {
            string line;
            int index = 0;
            string[] arrSplit;

            FileStream fs = new FileStream("users.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            
            while ((line = sr.ReadLine())!= null)
            {
                arrSplit = line.Split(',');
                if (username.Equals(arrSplit[0]))
                {
                    if (password.Equals(arrSplit[1]))
                    {
                        return true;
                        sr.Close();
                        fs.Close();
                    }
                }
            }
            sr.Close();
            fs.Close();
            return false;
        }

        public void Write(string username, string password)
        {
            try
            {
                using (StreamWriter sw = File.AppendText("users.txt"))
                {
                    sw.WriteLine(username + "," + password);
                    MessageBox.Show("User successfully created. Please login.");
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong. Error: " + ex.ToString());
            }
        }
    }
}
