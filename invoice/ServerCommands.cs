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
            connectionString = @"Data Source=DESKTOP-JSJ8LPG;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            cnn = new SqlConnection(connectionString);
            try
            {
                cnn.Open();
               
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
        public static void insertDB(string[] invoice, ListViewItem[] items)
        {
            /**invoice array**
            *task
            *author
            *creation date
            *completion date
            *total
            *notes
            */
            string unique = uniqueIdentifier();            
            SqlConnection cnn = connectDB();
            SqlCommand sqlQuerry = new SqlCommand("INSERT into [dbo].[invoice]([Task],[Author],[Creation_Date],[Completion_Date],[Total],[TaskID],[Notes])"
               + "Values(@task,@author,@Creation,@Completion,@Total,@unique,@Notes)", cnn);
            sqlQuerry.Parameters.AddWithValue("@task", invoice[0]);
            sqlQuerry.Parameters.AddWithValue("@author", invoice[1]);
            sqlQuerry.Parameters.AddWithValue("@Creation", invoice[2]);
            sqlQuerry.Parameters.AddWithValue("@Completion", invoice[3]);
            sqlQuerry.Parameters.AddWithValue("@unique", unique.ToString());
            sqlQuerry.Parameters.AddWithValue("@Total", float.Parse(invoice[4]));
            sqlQuerry.Parameters.AddWithValue("@Notes", invoice[5]);
            sqlQuerry.ExecuteNonQuery();
            foreach ( ListViewItem i in items)
            {
                sqlQuerry = new SqlCommand("insert into Task VALUES(@task,@unique,@price)",cnn);
                sqlQuerry.Parameters.AddWithValue("@task", i.SubItems[0].Text);
                sqlQuerry.Parameters.AddWithValue("@price", @i.SubItems[1].Text);
                sqlQuerry.Parameters.AddWithValue("@unique", unique);
                sqlQuerry.ExecuteNonQuery();
            }
            
            cnn.Close();
        }
        private static string uniqueIdentifier()
        {
            DateTime date = DateTime.Now;
            return String.Format("{0:00}{1:0000}{2:00}{3:00}{4:00}{5:00}{6:00}", Globals.author, date.Year, date.Month, date.Day, date.Hour, date.Minute,
                date.Second);

        }
        public static string[] getInvoiceInfo(string task, string taskID)
        {
            SqlConnection cnn = ServerCommands.connectDB();
            SqlCommand sqlQuerry = new SqlCommand("SELECT * from invoice WHERE invoice.task = @task AND invoice.TaskID = @taskID", cnn);
            sqlQuerry.Parameters.AddWithValue("@task", task);
            sqlQuerry.Parameters.AddWithValue("@taskID", taskID);
            string[] invoiceInfo = null;
            using (SqlDataReader reader = sqlQuerry.ExecuteReader())
                if (reader.Read())
                {
                    /*invoice format
                    Task
                    Total
                    Author
                    Invoice creation date
                    Completion Date
                    Notes
                    taskID
                    */
                    
                    invoiceInfo = new string[]{
                                reader["task"].ToString(),reader["Total"].ToString(), reader["Author"].ToString(),reader["Creation_Date"].ToString(),
                                reader["Completion_Date"].ToString(),reader["Notes"].ToString(),reader["TaskID"].ToString()
                            };
                    
                    return invoiceInfo;

                }else
                {
                    MessageBox.Show("error: no invoiceinfo found to delete");
                    return null;
                }
            
            
        }
        public static task getTasks(string taskID)
        {
            task task = new task();
            List<string> tasks = new List<string>();
            List<string> prices = new List<string>();
            SqlConnection cnn = ServerCommands.connectDB();
            SqlCommand sqlQuerry = new SqlCommand("SELECT * from task WHERE task.TaskID = @taskID", cnn);
            sqlQuerry.Parameters.AddWithValue("@taskID",taskID);
            using (SqlDataReader reader = sqlQuerry.ExecuteReader())
                while (reader.Read())
                {
                    //MessageBox.Show(reader["Task"].ToString() + " " + reader["Price"].ToString());
                    tasks.Add(reader["task"].ToString());
                    prices.Add((reader["Price"].ToString()));
                }
            task.tasks = tasks;
            task.prices = prices;
            return task;
        }

        public static void deleteDB(string task, string taskID)
        {
            SqlConnection cnn = ServerCommands.connectDB();
            SqlCommand sqlQuerry = new SqlCommand("DELETE invoice from invoice WHERE invoice.task = @task AND invoice.TaskID = @taskID", cnn);
            sqlQuerry.Parameters.AddWithValue("@task", task);
            sqlQuerry.Parameters.AddWithValue("@taskID", taskID);
           // try
           // {

                sqlQuerry.ExecuteNonQuery();
                
           // }
           // catch
           // {
           //     MessageBox.Show("error: delete db");
           // }

        }
        public static void editDB(string[] invoiceInfo, ListViewItem[] items)
        {
            /**invoice array**
             *task
             *author
             *creation date
             *completion date
             *total
             *notes
             */
            
            SqlConnection cnn = connectDB();
            SqlCommand sqlQuerry = new SqlCommand("UPDATE  [dbo].[invoice] SET [Task]= @newTask,[Creation_Date]= @Creation,"
                + " [Completion_Date]= @Completion,[Total]= @Total,[Notes]=@Notes"
                + " WHERE invoice.task = @task AND invoice.TaskID = @taskID ", cnn);
            sqlQuerry.Parameters.AddWithValue("@task", invoiceInfo[7]);
            sqlQuerry.Parameters.AddWithValue("@newTask", invoiceInfo[0]);
            sqlQuerry.Parameters.AddWithValue("@Creation", invoiceInfo[2]);
            sqlQuerry.Parameters.AddWithValue("@Completion", invoiceInfo[3]);
            sqlQuerry.Parameters.AddWithValue("@Total", float.Parse(invoiceInfo[4]));
            sqlQuerry.Parameters.AddWithValue("@Notes", invoiceInfo[5]);
            sqlQuerry.Parameters.AddWithValue("@taskID", invoiceInfo[6]);
            sqlQuerry.ExecuteNonQuery();
            sqlQuerry = new SqlCommand("DELETE task WHERE task.taskID = @taskID", cnn);
            sqlQuerry.Parameters.AddWithValue("@taskID", invoiceInfo[6]);
            sqlQuerry.ExecuteNonQuery();
            foreach (ListViewItem i in items)
            {                
                sqlQuerry = new SqlCommand("insert into Task VALUES(@task,@unique,@price)", cnn);
                sqlQuerry.Parameters.AddWithValue("@task", i.SubItems[0].Text);
                sqlQuerry.Parameters.AddWithValue("@price", @i.SubItems[1].Text);
                sqlQuerry.Parameters.AddWithValue("@unique", invoiceInfo[6]);
                sqlQuerry.ExecuteNonQuery();
            }

            cnn.Close();
        }
    }
    

    public class task
    {
        public List<string> tasks { get; set; }
        public List<string> prices { get; set; }
    }
}
