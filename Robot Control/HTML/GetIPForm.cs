using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Robot_Control.HTML
{
    public partial class GetIPForm : Form
    {
        public string address;
        private int[] ips = new int[4];

        public GetIPForm()
        {
            InitializeComponent();
            cbHttp.SelectedIndex = 0;
            address = "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            address = cbHttp.GetItemText(cbHttp.SelectedItem) + "://" + tbIP0.Text + "." + tbIP1.Text + "." + tbIP2.Text + "." + tbIP3.Text + "/";
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbIP_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            int i = tb.Name[tb.Name.Length - 1]-'0';
            int ip;
            if (tb.Text == "")
                tb.Text = "0";
            else if (Int32.TryParse(tb.Text, out ip) && ip > -1 && ip < 256)
                ips[i] = ip;
            else
                tb.Text = ips[i].ToString();
            tb.SelectionStart = tb.Text.Length;
        }
    }
}
