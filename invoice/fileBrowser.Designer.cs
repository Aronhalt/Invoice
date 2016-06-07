namespace invoice
{
    partial class fileBrowser
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
            this.newButton = new System.Windows.Forms.Button();
            this.FileBrowserListView = new System.Windows.Forms.ListView();
            this.Task = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Total = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.User = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CreationDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CompletionDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(842, 536);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(198, 41);
            this.newButton.TabIndex = 0;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            // 
            // FileBrowserListView
            // 
            this.FileBrowserListView.AutoArrange = false;
            this.FileBrowserListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Task,
            this.Total,
            this.User,
            this.CreationDate,
            this.CompletionDate});
            this.FileBrowserListView.Location = new System.Drawing.Point(13, 27);
            this.FileBrowserListView.Name = "FileBrowserListView";
            this.FileBrowserListView.Size = new System.Drawing.Size(1027, 498);
            this.FileBrowserListView.TabIndex = 1;
            this.FileBrowserListView.UseCompatibleStateImageBehavior = false;
            this.FileBrowserListView.View = System.Windows.Forms.View.Details;
            // 
            // Task
            // 
            this.Task.Text = "Task";
            this.Task.Width = 355;
            // 
            // Total
            // 
            this.Total.Text = "Total";
            this.Total.Width = 75;
            // 
            // User
            // 
            this.User.Text = "User";
            this.User.Width = 104;
            // 
            // CreationDate
            // 
            this.CreationDate.Text = "CreationDate";
            this.CreationDate.Width = 99;
            // 
            // CompletionDate
            // 
            this.CompletionDate.Text = "CompletionDate";
            this.CompletionDate.Width = 110;
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(13, 532);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(155, 45);
            this.editButton.TabIndex = 2;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(426, 531);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(132, 45);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // fileBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1052, 589);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.FileBrowserListView);
            this.Controls.Add(this.newButton);
            this.Name = "fileBrowser";
            this.Text = "Invoice File Browser";
            this.Load += new System.EventHandler(this.fileBrowser_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.ListView FileBrowserListView;
        private System.Windows.Forms.ColumnHeader Task;
        private System.Windows.Forms.ColumnHeader Total;
        private System.Windows.Forms.ColumnHeader User;
        private System.Windows.Forms.ColumnHeader CreationDate;
        private System.Windows.Forms.ColumnHeader CompletionDate;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
    }
}