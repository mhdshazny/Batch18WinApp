using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Batch18WinApp
{
    public partial class EmployeeManage : Form
    {
        public EmployeeManage()
        {
            InitializeComponent();
        }

        private void EmployeeManage_Load(object sender, EventArgs e)
        {
            LoadData();
            InitMode();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            EmployeeCRUD employeeCRUD = new EmployeeCRUD();
            var data = employeeCRUD.GetEmployee(txtEmployeeName.Text);

            dataGridView1.DataSource = data;
        }

        private void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {
            EmployeeCRUD employeeCRUD = new EmployeeCRUD();
            var data = employeeCRUD.GetEmployee(txtEmployeeName.Text);

            dataGridView1.DataSource = data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeCRUD employeeCRUD = new EmployeeCRUD();

            employeeCRUD.Employee = new EmployeeEntity()
            {
                Address = txtAddress.Text,
                ContactNo = txtContact.Text,
                Email = txtEmail.Text,
                Name = txtName.Text,
                NIC = txtNIC.Text,
                Status = cmbStatus.Text
            };

            bool status =  employeeCRUD.InsertRecord();
            if (status)
                MessageBox.Show("Record Inserted");
            else
                MessageBox.Show("Record insertion failed.");

            LoadData();
            InitMode();
            
        }

        public void LoadData()
        {
            EmployeeCRUD employeeCRUD = new EmployeeCRUD();
            var data = employeeCRUD.GetList();

            dataGridView1.DataSource = data;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtNIC.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtContact.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            cmbStatus.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

            UpdateMode();

        }

        public void UpdateMode()
        {
            btnInsert.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }
        public void InitMode()
        {
            btnInsert.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            txtID.Clear();
            txtName.Clear();
            txtNIC.Clear();
            txtAddress.Clear();
            txtContact.Clear();
            txtEmail.Clear();
            cmbStatus.SelectedIndex = -1;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EmployeeCRUD employeeCRUD = new EmployeeCRUD();

            employeeCRUD.Employee = new EmployeeEntity()
            {
                ID = int.Parse(txtID.Text),
                Address = txtAddress.Text,
                ContactNo = txtContact.Text,
                Email = txtEmail.Text,
                Name = txtName.Text,
                NIC = txtNIC.Text,
                Status = cmbStatus.Text
            };

            bool status = employeeCRUD.UpdateEmployee();
            if (status)
                MessageBox.Show("Record Updated");
            else
                MessageBox.Show("Record Update failed.");

            LoadData();
            InitMode();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            EmployeeCRUD employeeCRUD = new EmployeeCRUD();

            employeeCRUD.Employee = new EmployeeEntity()
            {
                ID = int.Parse(txtID.Text)
            };

            bool status = employeeCRUD.DeleteEmployee();
            if (status)
                MessageBox.Show("Record Deleted");
            else
                MessageBox.Show("Record Deletion failed.");

            LoadData();
            InitMode();
        }
    }



}
