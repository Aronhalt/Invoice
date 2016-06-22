using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace invoice
{
    public partial class fileBrowser : Form
    {
        string author;
        string filePath;
        DirectoryInfo d;
        List<string> fileList;
        public fileBrowser()
        {
            InitializeComponent();
            author = Globals.author;
            if (Globals.dataType == Globals.DataType.Local)
            { 
                
                string[] addList = new string[5];
                string line;
                fileList = new List<string>();
                                 
                filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "invoice\\");            
                System.IO.Directory.CreateDirectory(filePath);
                d = new DirectoryInfo(filePath);
                System.IO.StreamReader fileReader;
                ListViewItem addItem;

                    //populate the Listview with invoices
                    foreach (var file in d.GetFiles("*.invoice"))
                    {

                        fileReader = new System.IO.StreamReader(filePath + file);
                        //grab the first line of the file which is the info of the invoice
                        line = fileReader.ReadLine();
                        //MessageBox.Show(line);
                        /*first line in invoice has a format of
                            Task
                            Total
                            Author
                            Invoice creation date
                            Completion Date
                            Notes
                            */
                        //split the info line and parse the line for the important information
                        addList = line.Split(',');
                        addItem = new ListViewItem(addList);
                        FileBrowserListView.Items.Add(addItem);
                        fileReader.Close();
                        fileList.Add(file.ToString());
                }
                
                deleteButton.Click += new EventHandler(deleteButton_click_L);
                editButton.Click += new EventHandler(editButton_click_L);

            }
            else
            {
                update();
                deleteButton.Click += new EventHandler(deleteButton_click_S);
                editButton.Click += new EventHandler(editButton_click_S);
            }

            newButton.Click += new EventHandler(newButton_click);
            this.FormClosing += new FormClosingEventHandler(FormClosing_click);
        }
        void newButton_click(object sender, EventArgs e)
        {
            InvoiceForm newInvoice = new InvoiceForm();
            newInvoice.ShowDialog();
            update();
        }
       private void update()
       {
            if (Globals.dataType == Globals.DataType.Local)
            {

                string[] addList = new string[5];
                string line;
                System.IO.StreamReader fileReader;
                ListViewItem addItem;
                //get the list of files in the directory
                ListViewItem item;
                foreach (var file in d.GetFiles("*.invoice"))
                {
                    // item = FileBrowserListView.FindItemWithText(file.ToString().Replace(".invoice",""));
                    //check if the file has already been added to the listview.
                    //adding it to the listview if it hasn't
                    if (!(fileList.Contains(file.ToString())))
                    {
                        fileReader = new System.IO.StreamReader(filePath + file);
                        line = fileReader.ReadLine();
                        addList = line.Split(',');
                        addItem = new ListViewItem(addList);
                        FileBrowserListView.Items.Add(addItem);
                        fileReader.Close();
                    }
                }
            }else
            {
                //todo server-DB update
                FileBrowserListView.Items.Clear();
                SqlConnection cnn = ServerCommands.connectDB();
                SqlCommand sqlQuerry = new SqlCommand("SELECT * from invoice", cnn);
                using (SqlDataReader reader = sqlQuerry.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // MessageBox.Show((reader["task"] + " " + reader["Author"]
                        //   + " " + reader["Total"] + " " + reader["Creation_Date"] + " " + reader["Completion_Date"]));
                        //MessageBox.Show(taskline[0]);
                        String[] listItems = {
                            reader["task"].ToString(),  reader["Total"].ToString(),reader["Author"].ToString(), reader["Creation_Date"].ToString(), reader["Completion_Date"].ToString()
                            ,reader["taskID"].ToString()
                        };
                        ListViewItem addItem = new ListViewItem(listItems);
                        FileBrowserListView.Items.Add(addItem);
                    }
                }
                cnn.Close();
            }
       }
        //local version of delete
        private void deleteButton_click_L(object sender, EventArgs e)
        {
            if (FileBrowserListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Error: no files selected!");
            }
            else if (FileBrowserListView.MultiSelect == true)
            {
                foreach (ListViewItem item in FileBrowserListView.SelectedItems)
                {
                    FileBrowserListView.Items.Remove(item);
                    
                    File.Delete(filePath + item.SubItems[0].Text.ToString() + ".invoice");

                }
            }
            else
            {
                FileBrowserListView.SelectedItems[0].Remove();
            }
        }
        //local version of edit
        private void editButton_click_L(object sender, EventArgs e)
        {
            if (FileBrowserListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Error: no files selected!");
            }
            else if (FileBrowserListView.SelectedItems.Count == 1)
            {
                try {
                    
                    InvoiceForm newInvoice = new InvoiceForm(FileBrowserListView.SelectedItems[0].SubItems[0].Text.ToString() + ".invoice");
                    newInvoice.ShowDialog();
                    update();
                }
                catch
                {
                    //invoiceform not init correctly
                    MessageBox.Show("invoice error");
                }
            }
            else
            {
                MessageBox.Show("Error: Can only edit one invoice at a time!");
            }
        }
        void FormClosing_click(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("are you sure you want to exit?","Exit?", MessageBoxButtons.YesNo);
            if(DialogResult.Yes == result)
            {
                Environment.Exit(999);
                return;
            }else
            {
                e.Cancel = true;
            }
        }
        //server database version of delete
        private void deleteButton_click_S(object sender, EventArgs e)
        {
            if (FileBrowserListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Error: no files selected!");
            }
            else if (FileBrowserListView.MultiSelect == true)
            {
                foreach (ListViewItem item in FileBrowserListView.SelectedItems)
                {
                    FileBrowserListView.Items.Remove(item);
                    ServerCommands.deleteDB(item.SubItems[0].Text.ToString(), item.SubItems[5].Text.ToString());

                }
            }
            else
            {
                FileBrowserListView.SelectedItems[0].Remove();
                ServerCommands.deleteDB(FileBrowserListView.SelectedItems[0].SubItems[0].Text.ToString(), FileBrowserListView.SelectedItems[0].SubItems[5].Text.ToString());

            }
        }
        //server-database version of edit
        private void editButton_click_S(object sender, EventArgs e)
        {
            if (FileBrowserListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Error: no files selected!");
            }
            else if (FileBrowserListView.SelectedItems.Count == 1)
            {
                //to do delete old entry
                    //MessageBox.Show(FileBrowserListView.SelectedItems[0].SubItems[5].Text.ToString());
                    
                string[] invoiceInfo = ServerCommands.getInvoiceInfo(
                    FileBrowserListView.SelectedItems[0].SubItems[0].Text.ToString(), FileBrowserListView.SelectedItems[0].SubItems[5].Text.ToString());
                task task = ServerCommands.getTasks(FileBrowserListView.SelectedItems[0].SubItems[5].Text.ToString());
                            InvoiceForm newInvoice = new InvoiceForm(invoiceInfo,task.tasks,task.prices);
                    newInvoice.ShowDialog();
                    update();
                    
                
              
            }
            else
            {
                MessageBox.Show("Error: Can only edit one invoice at a time!");
            }
        }

    }
}
