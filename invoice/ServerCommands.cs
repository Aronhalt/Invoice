using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace invoice
{
    class ServerCommands
    {
        
        public static SqlConnection connectDB()
        {
            string connectionString = null;
            SqlConnection cnn;
            connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            cnn = new SqlConnection(connectionString);
            try
            {
                cnn.Open();
                MessageBox.Show("Connection Successful");
            }catch
            {
                DialogResult result = MessageBox.Show("Connection Error", "Connection Error", MessageBoxButtons.RetryCancel);
                if (DialogResult.Retry == result)
                {
                    connectDB();
                }
                else
                {
                    return null;
                }
            }
            return cnn;
        }
        public static void closeDB(SqlConnection cnn)
        {
            cnn.Close();
        }
    }
}
