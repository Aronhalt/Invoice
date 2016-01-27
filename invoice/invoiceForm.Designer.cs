namespace invoice
{
    partial class InvoiceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.NotesTextBox = new System.Windows.Forms.RichTextBox();
            this.CurrentDateTextBox = new System.Windows.Forms.TextBox();
            this.AuthorTextBox = new System.Windows.Forms.TextBox();
            this.TotalText = new System.Windows.Forms.TextBox();
            this.TotalLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TasksListView = new System.Windows.Forms.ListView();
            this.Task = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Payment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label7 = new System.Windows.Forms.Label();
            this.TaskText = new System.Windows.Forms.TextBox();
            this.PaymentText = new System.Windows.Forms.TextBox();
            this.TaskLabel = new System.Windows.Forms.Label();
            this.PaymentLabel = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.CompletionTimePicker = new System.Windows.Forms.DateTimePicker();
            this.InvoiceDatePicker = new System.Windows.Forms.DateTimePicker();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(22, 34);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(750, 22);
            this.TitleTextBox.TabIndex = 1;
            this.TitleTextBox.TextChanged += new System.EventHandler(this.TitleTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(800, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "invoice date";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Subject";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 402);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Author";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // NotesTextBox
            // 
            this.NotesTextBox.Location = new System.Drawing.Point(22, 355);
            this.NotesTextBox.Name = "NotesTextBox";
            this.NotesTextBox.Size = new System.Drawing.Size(862, 43);
            this.NotesTextBox.TabIndex = 5;
            this.NotesTextBox.Text = "";
            this.NotesTextBox.TextChanged += new System.EventHandler(this.NotesTextBox_TextChanged);
            // 
            // CurrentDateTextBox
            // 
            this.CurrentDateTextBox.Cursor = System.Windows.Forms.Cursors.No;
            this.CurrentDateTextBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CurrentDateTextBox.Location = new System.Drawing.Point(803, 33);
            this.CurrentDateTextBox.Name = "CurrentDateTextBox";
            this.CurrentDateTextBox.ReadOnly = true;
            this.CurrentDateTextBox.Size = new System.Drawing.Size(116, 22);
            this.CurrentDateTextBox.TabIndex = 6;
            this.CurrentDateTextBox.TextChanged += new System.EventHandler(this.CurrentDateTextBox_TextChanged);
            // 
            // AuthorTextBox
            // 
            this.AuthorTextBox.Location = new System.Drawing.Point(22, 422);
            this.AuthorTextBox.Name = "AuthorTextBox";
            this.AuthorTextBox.Size = new System.Drawing.Size(181, 22);
            this.AuthorTextBox.TabIndex = 7;
            this.AuthorTextBox.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // TotalText
            // 
            this.TotalText.Location = new System.Drawing.Point(803, 263);
            this.TotalText.Name = "TotalText";
            this.TotalText.Size = new System.Drawing.Size(116, 22);
            this.TotalText.TabIndex = 8;
            this.TotalText.TextChanged += new System.EventHandler(this.PaymentTextBox_TextChanged);
            // 
            // TotalLabel
            // 
            this.TotalLabel.AutoSize = true;
            this.TotalLabel.Location = new System.Drawing.Point(803, 243);
            this.TotalLabel.Name = "TotalLabel";
            this.TotalLabel.Size = new System.Drawing.Size(40, 17);
            this.TotalLabel.TabIndex = 9;
            this.TotalLabel.Text = "Total";
            this.TotalLabel.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(803, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Complete by date";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // TasksListView
            // 
            this.TasksListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Task,
            this.Payment});
            this.TasksListView.FullRowSelect = true;
            this.TasksListView.HideSelection = false;
            this.TasksListView.ImeMode = System.Windows.Forms.ImeMode.On;
            this.TasksListView.Location = new System.Drawing.Point(22, 87);
            this.TasksListView.Name = "TasksListView";
            this.TasksListView.Size = new System.Drawing.Size(775, 198);
            this.TasksListView.TabIndex = 12;
            this.TasksListView.UseCompatibleStateImageBehavior = false;
            this.TasksListView.View = System.Windows.Forms.View.Details;
            this.TasksListView.SelectedIndexChanged += new System.EventHandler(this.TasksListView_SelectedIndexChanged);
            // 
            // Task
            // 
            this.Task.Text = "Task";
            this.Task.Width = 500;
            // 
            // Payment
            // 
            this.Payment.Text = "Payment";
            this.Payment.Width = 120;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 332);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Notes:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // TaskText
            // 
            this.TaskText.Location = new System.Drawing.Point(25, 307);
            this.TaskText.Name = "TaskText";
            this.TaskText.Size = new System.Drawing.Size(606, 22);
            this.TaskText.TabIndex = 14;
            // 
            // PaymentText
            // 
            this.PaymentText.Location = new System.Drawing.Point(637, 308);
            this.PaymentText.Name = "PaymentText";
            this.PaymentText.Size = new System.Drawing.Size(140, 22);
            this.PaymentText.TabIndex = 15;
            // 
            // TaskLabel
            // 
            this.TaskLabel.AutoSize = true;
            this.TaskLabel.Location = new System.Drawing.Point(25, 289);
            this.TaskLabel.Name = "TaskLabel";
            this.TaskLabel.Size = new System.Drawing.Size(39, 17);
            this.TaskLabel.TabIndex = 16;
            this.TaskLabel.Text = "Task";
            // 
            // PaymentLabel
            // 
            this.PaymentLabel.AutoSize = true;
            this.PaymentLabel.Location = new System.Drawing.Point(637, 289);
            this.PaymentLabel.Name = "PaymentLabel";
            this.PaymentLabel.Size = new System.Drawing.Size(63, 17);
            this.PaymentLabel.TabIndex = 17;
            this.PaymentLabel.Text = "Payment";
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(783, 308);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 18;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(803, 113);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(116, 23);
            this.EditButton.TabIndex = 19;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(806, 143);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(113, 23);
            this.RemoveButton.TabIndex = 20;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            // 
            // CompletionTimePicker
            // 
            this.CompletionTimePicker.CustomFormat = "MM\'/\'dd\'/\'yyyy";
            this.CompletionTimePicker.Location = new System.Drawing.Point(803, 218);
            this.CompletionTimePicker.Name = "CompletionTimePicker";
            this.CompletionTimePicker.Size = new System.Drawing.Size(136, 22);
            this.CompletionTimePicker.TabIndex = 21;
            this.CompletionTimePicker.Value = new System.DateTime(2015, 12, 3, 0, 0, 0, 0);
            this.CompletionTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // InvoiceDatePicker
            // 
            this.InvoiceDatePicker.CustomFormat = "";
            this.InvoiceDatePicker.Enabled = false;
            this.InvoiceDatePicker.Location = new System.Drawing.Point(806, 62);
            this.InvoiceDatePicker.Name = "InvoiceDatePicker";
            this.InvoiceDatePicker.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.InvoiceDatePicker.Size = new System.Drawing.Size(113, 22);
            this.InvoiceDatePicker.TabIndex = 22;
            this.InvoiceDatePicker.Value = new System.DateTime(2015, 12, 19, 0, 0, 0, 0);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(754, 404);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(165, 49);
            this.SaveButton.TabIndex = 23;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // InvoiceForm
            // 
            this.AcceptButton = this.AddButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(931, 461);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.InvoiceDatePicker);
            this.Controls.Add(this.CompletionTimePicker);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.PaymentLabel);
            this.Controls.Add(this.TaskLabel);
            this.Controls.Add(this.PaymentText);
            this.Controls.Add(this.TaskText);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TasksListView);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TotalLabel);
            this.Controls.Add(this.TotalText);
            this.Controls.Add(this.AuthorTextBox);
            this.Controls.Add(this.CurrentDateTextBox);
            this.Controls.Add(this.NotesTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.label1);
            this.Name = "InvoiceForm";
            this.Text = "invoice";
            this.Load += new System.EventHandler(this.InvoiceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox NotesTextBox;
        private System.Windows.Forms.TextBox CurrentDateTextBox;
        private System.Windows.Forms.TextBox AuthorTextBox;
        private System.Windows.Forms.TextBox TotalText;
        private System.Windows.Forms.Label TotalLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView TasksListView;
        private System.Windows.Forms.ColumnHeader Task;
        private System.Windows.Forms.ColumnHeader Payment;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TaskText;
        private System.Windows.Forms.TextBox PaymentText;
        private System.Windows.Forms.Label TaskLabel;
        private System.Windows.Forms.Label PaymentLabel;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.DateTimePicker CompletionTimePicker;
        private System.Windows.Forms.DateTimePicker InvoiceDatePicker;
        private System.Windows.Forms.Button SaveButton;
    }
}

