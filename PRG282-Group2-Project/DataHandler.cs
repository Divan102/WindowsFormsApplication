using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Threading;

namespace PRG282_Group2_Project
{
    class DataHandler
    {
        //string con = @"Server=YANDRELAPTOP//SQLEXPRESS;Initial Catalog=MainDB;Integrated Security=True";
        //string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\panda\Documents\Belgium Campus\Year 2\PRG\PRG282\Assignments\Project\PRG282-Group2-Project\MainDB.mdf;Integrated Security=True";
        string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MainDB.mdf;Integrated Security=True";
        string query;

        SqlDataAdapter adapter;
        SqlConnection connection;
        SqlCommand cmd;

        public DataHandler()
        {
            connection = new SqlConnection(con);
        }

        public DataSet displayStudents()
        {
            connection = new SqlConnection(con); 

            query = @"SELECT * FROM StudentTable";
            adapter = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();
            adapter.Fill(ds);

            return ds;
        }

        public DataSet displayModule()
        {
            connection = new SqlConnection(con);

            query = @"SELECT * FROM ModuleTable";
            adapter = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();
            adapter.Fill(ds);

            return ds;
        }

        public void insertStudent(int Number, string Name, string Surname, string Image, string DateOfBirth, string Gender, string Phone, string Address, int ModuleCode)
        {
            connection = new SqlConnection(con);

            try
            {
                connection.Open();
            }
            catch
            {
                MessageBox.Show("Could not connect database.");
            }

            query = @"INSERT INTO StudentTable (Number, Name, Surname, Image, DateOfBirth, Gender, Phone, Address, ModuleCode) VALUES ('" + Number + "', '" + Name + "', '" + Surname + "', '" + Image + "', '" + DateOfBirth + "', '" + Gender + "', '" + Phone + "', '" + Address + "', " + ModuleCode + ")";
            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Student has been added successfully.");
            connection.Close();
        }

        public void insertModule(int code, string name, string desc, string link)
        {
            connection = new SqlConnection(con);

            try
            {
                connection.Open();
            }
            catch
            {
                MessageBox.Show("Could not connect database.");
            }

            query = @"INSERT INTO ModuleTable (ModuleCode, ModuleName, ModuleDescription, ModuleLinks) VALUES ('" + code + "', '" + name + "', '" + desc + "', '" + link + "')";
            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Module has been added successfully.");
            connection.Close();
        }

        public void updateStudent(int Number, string Name, string Surname, string Image, string DateOfBirth, string Gender, string Phone, string Address, int ModuleCode)
        {
            connection = new SqlConnection(con);

            try
            {
                connection.Open();
            }
            catch
            {
                MessageBox.Show("Could not connect database.");
            }

            query = @"UPDATE StudentTable SET Name = '" + Name + "', Surname = '" + Surname + "', Image = '" + Image + "', DateOfBirth = '" + DateOfBirth + "', Gender = '" + Gender + "', Phone = '" + Phone + "', Address = '" + Address + "', ModuleCode = " + ModuleCode + " WHERE Number = " + Number;
            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Student has been updated successfully.");
            connection.Close();
        }

        public void updateModule(int code, string name, string desc, string link)
        {
            connection = new SqlConnection(con);

            try
            {
                connection.Open();
            }
            catch
            {
                MessageBox.Show("Could not connect database.");
            }

            query = @"UPDATE ModuleTable SET ModuleCode = '" + code + "', ModuleName = '" + name + "', ModuleDescription = '" + desc + "', ModuleLink = " + link + "'";
            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Module has been updated successfully.");
            connection.Close();
        }

        public void deleteStudent(int number)
        {
            connection = new SqlConnection(con);

            query = @"DELETE FROM StudentTable WHERE Number = " + number;
            cmd = new SqlCommand(query, connection);

            connection.Open();
            cmd.BeginExecuteNonQuery();

            MessageBox.Show("Student successfully deleted.");

            connection.Close();
        }

        public void deleteModule(int code)
        {
            connection = new SqlConnection(con);

            query = @"DELETE FROM ModuleTable WHERE ModuleCode = " + code;
            cmd = new SqlCommand(query, connection);

            connection.Open();
            cmd.BeginExecuteNonQuery();

            MessageBox.Show("Module successfully deleted.");

            connection.Close();
        }

        public DataSet searchStudent(int number)
        {
            connection = new SqlConnection(con);

            query = @"SELECT * FROM StudentTable WHERE Number = " + number;
            adapter = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();
            adapter.Fill(ds);

            return ds;
        }

        public DataSet searchModule(int code)
        {
            connection = new SqlConnection(con);

            query = @"SELECT * FROM ModuleTable WHERE ModuleCode = " + code;
            adapter = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();
            adapter.Fill(ds);

            return ds;
        }
    }
}
