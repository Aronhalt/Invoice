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
            // connectionType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 124);
            this.Controls.Add(this.ServerButton);
            this.Controls.Add(this.LocalButton);
            this.Name = "connectionType";
            this.Text = "connectionType";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LocalButton;
        private System.Windows.Forms.Button ServerButton;
    }
}