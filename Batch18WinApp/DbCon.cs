using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch18WinApp
{
    internal class DbCon
    {
        public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["_Batch18DbConnectionString"].ConnectionString);
    
    }
}
