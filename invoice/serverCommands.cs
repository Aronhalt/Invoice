using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace invoice
{
    class serverCommands
    {
        public static SqlConnection connectDB()
        {
            string connectionString = null;
            SqlConnection cnn;
            connectionString = "Data Source=DESKTOP-JSJ8LPG;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
            cnn = new SqlConnection(connectionString);
            try
            {
                cnn.Open();
                MessageBox.Show("Connection successful!", "Connection Status", MessageBoxButtons.OK);
                return cnn;
            }
            catch
            {
                DialogResult result = MessageBox.Show("Connection Failed!", "Connection Status", MessageBoxButtons.RetryCancel);
                if (result == DialogResult.Retry)
                {
                    return connectDB();
                }
                else
                {
                    //show serveroptions
                    return null;
                }
            }
        }
    }
}
