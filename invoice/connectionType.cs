using System;
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
    public partial class connectionType : Form
    {
        public connectionType()
        {
            InitializeComponent();
            LocalButton.Click += new EventHandler(LocalButton_click);
            ServerButton.Click += new EventHandler(ServerButton_click);
            FormClosing += new FormClosingEventHandler(form_closing);
        }
        void LocalButton_click(object sender, EventArgs e)
        {
            if (validUser())
            {
                Globals.author = usernameTxt.Text;
                fileBrowser FB = new fileBrowser();
                FB.Show();
                this.Hide();
            }
            else
            {
                
                
                MessageBox.Show("Invalid Username");
            }
        }
        void ServerButton_click(object sender, EventArgs e)
        {
            if (validUser())
            {

                Globals.author = usernameTxt.Text;
                Globals.dataType = Globals.DataType.Server;
                //ping database to test connection
                ServerCommands.closeDB(ServerCommands.connectDB());
                MessageBox.Show("Connection Successful");
                fileBrowser FB = new fileBrowser();
                FB.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username");
            }

        }
        Boolean validUser()
        {
            if (!usernameTxt.Text.Equals("") && usernameTxt.Text.Length <= 20)
            {
                return true;
            }
            return false;
        }
        void form_closing(Object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
