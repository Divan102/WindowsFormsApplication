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
    public partial class ModuleForm : Form
    {
        // Create DataHandler instance.
        DataHandler dataHandler = new DataHandler();

        // Declare variables.
        string  name, desc, link;
        int code;

        public ModuleForm()
        {
            InitializeComponent();

            // Fill data grid view with Module Table information on form load.
            dgvModule.DataSource = dataHandler.displayModule().Tables[0];

            // Set size of columns.
            dgvModule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnViewStudents_Click(object sender, EventArgs e)
        {
            // Hide this form and show Students form.
            this.Hide();
            StudentForm studentForm = new StudentForm();
            studentForm.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Assign values to variables
                code = int.Parse(txtCode.Text);
                name = txtName.Text;
                desc = txtDescription.Text;
                link = txtLinks.Text;

                // Call Update Module method
                dataHandler.updateModule(code,name,desc,link);

                // Update data grid view
                dgvModule.DataSource = dataHandler.displayModule().Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Declare search module and assign values.
            int searchModule = int.Parse(txtSearch.Text);

            // Call Delete method.
            dataHandler.deleteModule(searchModule);

            // Update data grid view.
            dgvModule.DataSource = dataHandler.displayModule().Tables[0];
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Declare search module and assign values.
            int searchModule = int.Parse(txtSearch.Text);

            // Call search method, and update data grid view.
            dgvModule.DataSource = dataHandler.searchModule(searchModule).Tables[0];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Assign values to variables
                code = int.Parse(txtCode.Text);
                name = txtName.Text;
                desc = txtDescription.Text;
                link = txtLinks.Text;

                // Call insert method.
                dataHandler.insertModule(code, name, desc, link);

                // Update data grid view
                dgvModule.DataSource = dataHandler.displayModule().Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ModuleForm_Load(object sender, EventArgs e)
        {

        }
    }
}
