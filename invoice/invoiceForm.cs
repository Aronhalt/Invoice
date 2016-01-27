using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace invoice
{

    public partial class InvoiceForm : Form
    {
        double total;
        string username;
        bool hasChanged;
        public InvoiceForm()
        {
            hasChanged = false;
            InitializeComponent();

            //variables
            DateTime currentDate = DateTime.Now;
            username = "SW";
            AuthorTextBox.Text = username;
            total = 0;
            TotalText.Text = total.ToString();
            CurrentDateTextBox.Text = currentDate.ToShortDateString();            
            InvoiceDatePicker.Value = currentDate;
            CompletionTimePicker.Value = currentDate;

            

            //formatting
            TasksListView.View = View.Details;
            TasksListView.GridLines = true;
            TasksListView.FullRowSelect = true;
            InvoiceDatePicker.Format = DateTimePickerFormat.Custom;
            CompletionTimePicker.Format = DateTimePickerFormat.Custom;
            InvoiceDatePicker.CustomFormat = "MM'/'dd'/'yyyy";



            //configure buttons
            AddButton.Click += new EventHandler(AddButton_click);
            EditButton.Click += new EventHandler(EditButton_click);
            RemoveButton.Click += new EventHandler(RemoveButton_click);
            SaveButton.Click += new EventHandler(SaveButton_click);
            TaskText.TextChanged += new EventHandler(invoiceChanged);
            TitleTextBox.TextChanged += new EventHandler(invoiceChanged);
            NotesTextBox.TextChanged += new EventHandler(invoiceChanged);
            CompletionTimePicker.ValueChanged += new EventHandler(invoiceChanged);
            this.FormClosing += new FormClosingEventHandler(invoiceForm_FormClosing);
        }
        //open invoice for editing
        public InvoiceForm(string invoice)
        {
            InitializeComponent();
            //variables
            string line;
            string[] invoiceInfo = new string[5];
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "invoice\\");
            ListViewItem item;
            System.IO.StreamReader fileReader;

            //formatting

            //datepicker
            InvoiceDatePicker.Format = DateTimePickerFormat.Custom;
            CompletionTimePicker.Format = DateTimePickerFormat.Custom;
            InvoiceDatePicker.CustomFormat = "MM'/'dd'/'yyyy";
            
            //listview
            TasksListView.View = View.Details;
            TasksListView.GridLines = true;
            TasksListView.FullRowSelect = true;
            //try: open the file and recreate invoice
            //catch: file not found error
            try
            {
                fileReader = new System.IO.StreamReader(filePath + invoice);
                line = fileReader.ReadLine();
                invoiceInfo = line.Split(',');

                /*first line in invoice has a format of
                Task
                Total
                Author
                Invoice creation date
                Completion Date
                Notes
                */
                TitleTextBox.Text = invoiceInfo[0];
                TotalText.Text = invoiceInfo[1];
                AuthorTextBox.Text = invoiceInfo[2];
                InvoiceDatePicker.Value = DateTime.Parse(invoiceInfo[3]);
                CompletionTimePicker.Value = DateTime.Parse(invoiceInfo[4]);
                NotesTextBox.Text = invoiceInfo[5];
                //retrieve tasks from file and add them to the listview
                while ((line = fileReader.ReadLine()) != null)
                {
                    item = new ListViewItem(line.Split(','));
                    TasksListView.Items.Add(item);
                }
               
       


                //set total variable
                total = double.Parse(TotalText.Text);

                /* string[] addList = new string[2];
                 addList[0] = "jump off a building";
                 addList[1] = "35";
                 ListViewItem addItem = new ListViewItem(addList);
                 TasksListView.Items.Add(addItem);
                 addList[0] = "spawn satan";
                 addList[1] = "666";
                 addItem = new ListViewItem(addList);
                 TasksListView.Items.Add(addItem);
                 */

            }
            catch
            {
                MessageBox.Show("error: file not found");
                this.Close();
            }




            //configure buttons
            AddButton.Click += new EventHandler(AddButton_click);
            EditButton.Click += new EventHandler(EditButton_click);
            RemoveButton.Click += new EventHandler(RemoveButton_click);
            SaveButton.Click += new EventHandler(SaveButton_click);
            TaskText.TextChanged += new EventHandler(invoiceChanged);
            TitleTextBox.TextChanged += new EventHandler(invoiceChanged);
            NotesTextBox.TextChanged += new EventHandler(invoiceChanged);
            CompletionTimePicker.ValueChanged += new EventHandler(invoiceChanged);
            this.FormClosing += new FormClosingEventHandler(invoiceForm_FormClosing);

        }

        private void AddButton_click(object sender, EventArgs e)
        {
            double price;
            if(TaskText.Text =="")
            {
                MessageBox.Show("Error: Task empty!");

            }
            if(PaymentText.Text == "")
            {
                MessageBox.Show("Error: Payment empty!");

            }
            else if (double.TryParse(PaymentText.Text,out price) && price >= 0.0)
            {

                string[] addList = new string[2];
                addList[0] = TaskText.Text;
                addList[1] = price.ToString();
                ListViewItem addItem = new ListViewItem(addList);
                TasksListView.Items.Add(addItem);
                TaskText.Clear();
                PaymentText.Clear();
                total += price;
                TotalText.Text = total.ToString();
            }else
            {
                string ss = "wtf";
                MessageBox.Show("\"" + PaymentText.Text + "\"is not a vaild payment");
            }
        }
        //to do: bring up text box
        //known issues: editing one task then editing another without readding it back will result in a lost task.
        //bandaid fix, dialog box to ask user if they want to discard task
        private void EditButton_click(object sender, EventArgs e)
        {
            bool oktoClear = false;
            if (!string.IsNullOrEmpty(TaskText.Text.Trim()))
            {
                oktoClear = taskTextCheck("task text");
            }
            if (oktoClear || string.IsNullOrEmpty(TaskText.Text.Trim()))
            {

                if (TasksListView.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Error: no entry selected!");
                    //do nothing
                }

                else if (TasksListView.SelectedItems.Count == 1)
                {


                    double price;
                    TaskText.Text = TasksListView.SelectedItems[0].SubItems[0].Text;
                    PaymentText.Text = TasksListView.SelectedItems[0].SubItems[1].Text;
                    TasksListView.SelectedItems[0].Remove();
                    price = double.Parse(PaymentText.Text);
                    total -= price;
                    TotalText.Text = total.ToString();
                    //MessageBox.Show(TasksListView.SelectedItems[0].SubItems[1].Text);

                }
                else
                {
                    MessageBox.Show("Error: can only edit one at a time!");

                }



            }
        }

    
        private void RemoveButton_click(object sender, EventArgs e)
        {            
            if(TasksListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Error: no tasks selected!");
            }
            else if (TasksListView.MultiSelect == true)
            {
                foreach (ListViewItem item in TasksListView.SelectedItems)
                {
                    
                    total -= double.Parse(item.SubItems[1].Text.ToString());
                    TasksListView.Items.Remove(item);

                }
            }
            else
            {
                total -= double.Parse(TasksListView.SelectedItems[1].ToString());
                TasksListView.SelectedItems[0].Remove();
            }
            TotalText.Text = total.ToString();
        }
        private void SaveButton_click(object sender, EventArgs e)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //check if all text boxes are filled out correctly
            if (TitleTextBox.Text.Length == 0)
            {
                //empty
                MessageBox.Show("Error: no title!");
            }
            else if (TasksListView.Items.Count == 0)
            {
                MessageBox.Show("Error: no tasks!");
                //empty
            }
            else if (CompletionTimePicker.Value < InvoiceDatePicker.Value)
            {
                //date incorrect
                MessageBox.Show("Error: date incorrect!");
            }
            else
            {
                //save
                System.IO.StreamWriter file = new System.IO.StreamWriter(filePath + "/invoice/" + TitleTextBox.Text.Trim() + ".invoice");
                /*first line in invoice has a format of
                   Task
                   Total
                   Author
                   Invoice creation date
                   Completion Date
                   Notes
                   */
                string invoice =
                    TitleTextBox.Text + "," + TotalText.Text + "," + AuthorTextBox.Text.Trim() + "," +
                    InvoiceDatePicker.Value + "," + CompletionTimePicker.Value + "," + NotesTextBox.Text.Trim();
                // lines after this are items in the list view
                // these items are each a line consisting of the task and payment seperated by a comma
                file.WriteLine(invoice);
                foreach (ListViewItem item in TasksListView.Items)
                {
                    file.WriteLine(item.SubItems[0].Text + "," + item.SubItems[1].Text);
                }
                file.Close();
                MessageBox.Show("Saved!" + invoice);
                
                this.Close();
            }
        }
        private bool taskTextCheck(string textBox)
        {
            DialogResult result = MessageBox.Show("Warning: "+ textBox + " has text in it. Do you want to discard current task?", "Dialog Title", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }
        private void invoiceChanged(object sender, EventArgs e)
        {
            hasChanged = true;
        }
        void invoiceForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason == CloseReason.UserClosing && hasChanged == true)
            {
                DialogResult result = MessageBox.Show("Do you want to save before exiting?", "Dialog Title", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    SaveButton_click(sender, e);
                    
                }
                else if(result == DialogResult.No)
                {
                    
                    return;
                }
                else
                {
                    e.Cancel = true;
                }
            }else if(hasChanged == false)
            {
               
                return;
            }
            else
            {
                e.Cancel = true;
            }
        }

        // textboxes
        // completion time is a valid date
        // payment is possitive

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


        private void CompletionDateTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CurrentDateTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void TitleTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void NotesTextBox_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void TasksListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PaymentTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
