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
            author = "SW";
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
                addItem = new  ListViewItem(addList);
                FileBrowserListView.Items.Add(addItem);
                fileReader.Close();
                fileList.Add(file.ToString());
                
             }
            newButton.Click += new EventHandler(newButton_click);
            deleteButton.Click += new EventHandler(deleteButton_click);
            editButton.Click += new EventHandler(editButton_click);
        }
        void newButton_click(object sender, EventArgs e)
        {
            InvoiceForm newInvoice = new InvoiceForm();
            newInvoice.ShowDialog();
            update();
        }
       private void update()
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
       }
        private void deleteButton_click(object sender, EventArgs e)
        {
            //for each selected item
            //find file in file list
            //delete file
            //remove file from file list and listview
            d = new DirectoryInfo(filePath);
            if (FileBrowserListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Error: no files selected!");
            }
            else if (FileBrowserListView.MultiSelect == true)
            {
                foreach (ListViewItem item in FileBrowserListView.SelectedItems)
                {
                    try
                    {
                        DialogResult result = MessageBox.Show("Are you sure you want to delete \"" + item.SubItems[0].Text.ToString() + ".invoice\"","Delete confirmation", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            File.Delete(filePath + item.SubItems[0].Text.ToString() + ".invoice");
                            FileBrowserListView.Items.Remove(item);
                            fileList.Remove(item.SubItems[0].Text.ToString());
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error: "+ item.SubItems[0].Text.ToString() +" couldnt be deleted");
                    }
                    
                }
            }
            else
            {
                FileBrowserListView.SelectedItems[0].Remove();
            }
        }
        private void editButton_click(object sender, EventArgs e)
        {
            if (FileBrowserListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Error: no files selected!");
            }
            else if (FileBrowserListView.SelectedItems.Count == 1)
            {
                try {
                    //MessageBox.Show(filePath + " " + FileBrowserListView.SelectedItems[0].SubItems[0].Text.ToString() + ".invoice");
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

        private void fileBrowser_Load(object sender, EventArgs e)
        {

        }
    }
}
