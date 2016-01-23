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
        public fileBrowser()
        {
            InitializeComponent();
            author = "SW";
            filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);            
             System.IO.Directory.CreateDirectory(filePath + "/invoice/");
            DirectoryInfo d = new DirectoryInfo(filePath + "/invoice//");

             foreach (var file in d.GetFiles("*.invoice"))
             {
                 MessageBox.Show(file.ToString());
             }
            newButton.Click += new EventHandler(newButton_click);
        }
        void newButton_click(object sender, EventArgs e)
        {
            InvoiceForm newInvoice = new InvoiceForm();
            newInvoice.Show();  
        }
    }
}
