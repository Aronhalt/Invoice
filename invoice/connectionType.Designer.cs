namespace invoice
{
    partial class connectionType
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
            this.LocalButton = new System.Windows.Forms.Button();
            this.ServerButton = new System.Windows.Forms.Button();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.usernameTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LocalButton
            // 
            this.LocalButton.Location = new System.Drawing.Point(12, 12);
            this.LocalButton.Name = "LocalButton";
            this.LocalButton.Size = new System.Drawing.Size(243, 106);
            this.LocalButton.TabIndex = 0;
            this.LocalButton.Text = "Local";
            this.LocalButton.UseVisualStyleBackColor = true;
            // 
            // ServerButton
            // 
            this.ServerButton.Location = new System.Drawing.Point(262, 12);
            this.ServerButton.Name = "ServerButton";
            this.ServerButton.Size = new System.Drawing.Size(243, 106);
            this.ServerButton.TabIndex = 1;
            this.ServerButton.Text = "Server";
            this.ServerButton.UseVisualStyleBackColor = true;
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(13, 125);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(74, 16);
            this.userNameLabel.TabIndex = 2;
            this.userNameLabel.Text = "UserName";
            // 
            // usernameTxt
            // 
            this.usernameTxt.Location = new System.Drawing.Point(93, 125);
            this.usernameTxt.Name = "usernameTxt";
            this.usernameTxt.Size = new System.Drawing.Size(412, 22);
            this.usernameTxt.TabIndex = 3;
            // 
            // connectionType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 153);
            this.Controls.Add(this.usernameTxt);
            this.Controls.Add(this.userNameLabel);
            this.Controls.Add(this.ServerButton);
            this.Controls.Add(this.LocalButton);
            this.Name = "connectionType";
            this.Text = "connectionType";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LocalButton;
        private System.Windows.Forms.Button ServerButton;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.TextBox usernameTxt;
    }
}