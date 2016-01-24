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

namespace invoice
{
    public partial class InvoiceForm : Form
    {
        double total;
        public InvoiceForm()
        {
            InitializeComponent();
            DateTime currentDate = DateTime.Now;
            CurrentDateTextBox.Text = currentDate.ToShortDateString();
            InvoiceDatePicker.Format = DateTimePickerFormat.Custom;
            CompletionTimePicker.Format = DateTimePickerFormat.Custom;
            InvoiceDatePicker.Value = currentDate;
            CompletionTimePicker.Value = currentDate;

            InvoiceDatePicker.CustomFormat = "MM'/'dd'/'yyyy";

            //dateTimePicker2.Value = currentDate;
            TasksListView.View = View.Details;
            TasksListView.GridLines = true;
            TasksListView.FullRowSelect = true;
            total = 0;
            TotalText.Text = total.ToString();
            AddButton.Click += new EventHandler(AddButton_click);
            EditButton.Click += new EventHandler(EditButton_click);
            RemoveButton.Click += new EventHandler(RemoveButton_click);
            SaveButton.Click += new EventHandler(SaveButton_click);
        }
        public InvoiceForm(string test)
        {
            InitializeComponent();
            DateTime currentDate = DateTime.Now;
            DateTime date = DateTime.Parse("12/3/2015");
            CurrentDateTextBox.Text = currentDate.ToShortDateString();
            InvoiceDatePicker.Format = DateTimePickerFormat.Custom;
            CompletionTimePicker.Format = DateTimePickerFormat.Custom;
            InvoiceDatePicker.CustomFormat = "MM'/'dd'/'yyyy";
            CompletionTimePicker.Value = date;

            TasksListView.View = View.Details;
            TasksListView.GridLines = true;
            TasksListView.FullRowSelect = true;
            total = 110;
            TotalText.Text = total.ToString();

            string[] addList = new string[2];
            addList[0] = "jump off a building";
            addList[1] = "35";
            ListViewItem addItem = new ListViewItem(addList);
            TasksListView.Items.Add(addItem);
            addList[0] = "spawn satan";
            addList[1] = "666";
            addItem = new ListViewItem(addList);
            TasksListView.Items.Add(addItem);




            AddButton.Click += new EventHandler(AddButton_click);
            EditButton.Click += new EventHandler(EditButton_click);
            RemoveButton.Click += new EventHandler(RemoveButton_click);
            SaveButton.Click += new EventHandler(SaveButton_click);
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
        private void EditButton_click(object sender, EventArgs e)
        {
            if(TasksListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Error: no entry selected!");
                //do nothing
            }
            else if (TasksListView.MultiSelect == true)
            {
                MessageBox.Show("Error: can only edit one at a time!");
                foreach( ListViewItem item in TasksListView.SelectedItems)
                {
                    //do nothing
                }
            }
            else
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
                    TasksListView.Items.Remove(item);

                }
            }
            else
            {
                TasksListView.SelectedItems[0].Remove();
            }
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
