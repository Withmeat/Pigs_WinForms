using System;
using System.Windows.Forms;
using FightPigs.Main.Model;

namespace FightPigs.Main.View
{
    public partial class sizeDialog : Form
    {
        public sizeDialog()
        {
            InitializeComponent();
            OK.Click += setSize;
        }

        public event EventHandler<sizeEventArgs> SendSize;
        private void setSize(object sender, EventArgs e)
        {
            size output = smallSize.Checked ? size.Small : mediumSize.Checked ? size.Medium : size.Big;

            SendSize(this, new sizeEventArgs(output));
        }
    }
}
