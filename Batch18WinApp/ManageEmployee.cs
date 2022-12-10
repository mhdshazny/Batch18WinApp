using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Batch18WinApp
{
    public partial class ManageEmployee : Form
    {
        public ManageEmployee()
        {
            InitializeComponent();
        }

        private void ManageEmployee_Load(object sender, EventArgs e)
        {
            string constring = "Data Source=MHD-SHAZNY;Initial Catalog=_Batch18Db;Integrated Security=True";
            SqlConnection con = new SqlConnection(constring);

            con.Open();

            con.Close();

        }
    }
}
