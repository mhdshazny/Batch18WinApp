using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Batch18WinApp
{
    class EmployeeCRUD
    {
        SqlConnection con = DbCon.connection;
        SqlCommand com;
        DataTable dt;
        SqlDataAdapter da;
        SqlDataReader dr;


        public EmployeeEntity Employee { get; set; }

        public List<EmployeeEntity> GetList()
        {
            try
            {
                string query = "Select * from Tbl_Employee";
                da = new SqlDataAdapter(query, con);                
                dt = new DataTable();
                da.Fill(dt);

                List<EmployeeEntity> employeeEntities = new List<EmployeeEntity>();


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var data = dt.Rows[i].ItemArray;
                    employeeEntities.Add(new EmployeeEntity()
                    {

                        ID = int.Parse(data[0].ToString()),
                        Name = data[1].ToString(),
                        NIC = data[2].ToString(),
                        Email = data[3].ToString(),
                        ContactNo = data[4].ToString(),
                        Address = data[5].ToString(),
                        Status = data[6].ToString()
                    });
                };

                return employeeEntities;
            }
            catch (Exception er)
            {
                MessageBox.Show("Error Occured"  + er.Message);
                return new List<EmployeeEntity>();
                con.Close();
            }


        }

        internal bool InsertRecord()
        {
            try
            {
                string query = "Insert into Tbl_Employee (Name,NIC,Address,ContactNo,Status,Email) Values('" + Employee.Name+ "','" + Employee.NIC + "','" + Employee.Address + "','"+Employee.ContactNo+ "','" + Employee.Status + "','" + Employee.Email + "')";
                string query2 = "Insert into Tbl_Employee (Name,NIC,Address,ContactNo,Status,Email) Values('{0}','{1}','{2}','{3}','{4}','{5}')";
                string FinalQuery = string.Format(query2,Employee.Name,Employee.NIC,Employee.Address,Employee.ContactNo,Employee.Status,Employee.Email);

                //string FinalQuery2 = string.Concat(FinalQuery, FinalQuery2);
                com = new SqlCommand(FinalQuery, con);

                con.Open();
                int updatedRecords = com.ExecuteNonQuery();
                if (updatedRecords > 0) return true; else return false;

            }
            catch (Exception er)
            {
                MessageBox.Show("Error Occured" + er.Message);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        internal object GetEmployee(string text)
        {
            try
            {
                string query = "Select * from Tbl_Employee where Name Like '%" + text+ "%'";
                da = new SqlDataAdapter(query, con);
                dt = new DataTable();
                da.Fill(dt);

                List<EmployeeEntity> employeeEntities = new List<EmployeeEntity>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var data = dt.Rows[i].ItemArray;
                    employeeEntities.Add(new EmployeeEntity()
                    {

                        ID = int.Parse(data[0].ToString()),
                        Name = data[1].ToString(),
                        NIC = data[2].ToString(),
                        Email = data[3].ToString(),
                        ContactNo = data[4].ToString(),
                        Address = data[5].ToString(),
                        Status = data[6].ToString()
                    });
                };

                return employeeEntities;
            }
            catch (Exception er)
            {
                MessageBox.Show("Error Occured" + er.Message);
                return new List<EmployeeEntity>();
            }
        }

        internal bool UpdateEmployee()
        {
            string query = "Update Tbl_Employee Set Name='"+Employee.Name+"',NIC='"+Employee.NIC+"', Email='"+Employee.Email+"',ContactNo='"+Employee.ContactNo+"',Address='"+Employee.Address+"',Status='"+Employee.Status+"' where ID='"+Employee.ID+"'";
            com = new SqlCommand(query, con);

            con.Open();
            int updatedRecords = com.ExecuteNonQuery();
            if (updatedRecords > 0) return true; else return false;

        }

        internal bool DeleteEmployee()
        {
            string query = "Delete Tbl_Employee where ID='" + Employee.ID + "'";
            com = new SqlCommand(query, con);

            con.Open();
            int updatedRecords = com.ExecuteNonQuery();
            if (updatedRecords > 0) return true; else return false;
        }
    }
    class EmployeeEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NIC { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
    }
}
