﻿using System;
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
                MessageBox.Show(line);
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
        }
        void newButton_click(object sender, EventArgs e)
        {
            InvoiceForm newInvoice = new InvoiceForm();
            newInvoice.ShowDialog();
            update();
        }
       public void update()
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

}
}
