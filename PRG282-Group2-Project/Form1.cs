using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG282_Group2_Project
{
    public partial class StudentForm : Form
    {
        // Create DataHandler instance.
        DataHandler dataHandler = new DataHandler();

        // Declare variables.
        string name, surname, Gender, Phone, Address, image, DoB;
        int number, module;

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Declare search variable and assign value.
            int searchNumber = int.Parse(txtSearch.Text);

            // Call delete method.
            dataHandler.deleteStudent(searchNumber);

            // Update data grid view.
            dgvStudents.DataSource = dataHandler.displayStudents().Tables[0];
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Declare search variable and assign value.
            int searchNumber = int.Parse(txtSearch.Text);

            // Call search method and update data grid view.
            dgvStudents.DataSource = dataHandler.searchStudent(searchNumber).Tables[0];
        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void StudentForm_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Assign values to variables
                number = int.Parse(txtNumber.Text);
                name = txtName.Text;
                surname = txtSurname.Text;
                DoB = dtpDOB.Value.ToString("yyyyMMdd");
                Gender = txtGender.Text;
                Phone = txtPhone.Text;
                Address = txtAddress.Text;
                module = int.Parse(txtModuleCodes.Text);
                image = ptbImage.Image.ToString();

                // Call update method.
                dataHandler.updateStudent(number, name, surname, image, DoB, Address, Gender, Phone, module);

                // Update data grid view.
                dgvStudents.DataSource = dataHandler.displayStudents().Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        public StudentForm()
        {
            InitializeComponent();

            // Set data grid view to students table on form load.
            dgvStudents.DataSource = dataHandler.displayStudents().Tables[0];

            // Set size of columns.
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            // Declare variable to hold file path.
            string imgLocation = "";
            try
            {
                // Create open file dialog instance, and set the filter to only open images.
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    // If OK is pressed on dialog, set variable to filename of image.
                    imgLocation = openFile.FileName;
                    ptbImage.ImageLocation = imgLocation;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured", ex.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnViewModules_Click(object sender, EventArgs e)
        {
            // Hide this form and show Module form.
            this.Hide();
            ModuleForm moduleForm = new ModuleForm();
            moduleForm.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Assign values to variables
                number = int.Parse(txtNumber.Text);
                name = txtName.Text;
                surname = txtSurname.Text;
                DoB = dtpDOB.Value.ToString("yyyyMMdd");
                Gender = txtGender.Text;
                Phone = txtPhone.Text;
                Address = txtAddress.Text;
                module = int.Parse(txtModuleCodes.Text);
                image = ptbImage.Image.ToString();

                // Call insert method.
                dataHandler.insertStudent(number, name, surname, image, DoB, Phone, Gender, Address, module);

                // Update data grid view
                dgvStudents.DataSource = dataHandler.displayStudents().Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
