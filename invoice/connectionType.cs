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
        }
        void LocalButton_click(object sender, EventArgs e)
        {
            fileBrowser FB = new fileBrowser();
            FB.Show();
            this.Hide();
        }
        void ServerButton_click(object sender, EventArgs e)
        {
            Globals.dataType = Globals.DataType.Server;
            //ping database to test connection
            ServerCommands.closeDB(ServerCommands.connectDB());
            fileBrowser FB = new fileBrowser();
            FB.Show();
            this.Hide();
        }
    }
}
