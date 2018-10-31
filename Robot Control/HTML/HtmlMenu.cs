using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Robot_Control.HTML
{
    public class Html
    {
        private HtmlConnection html;

        private ToolStripMenuItem menu;
        private ToolStripMenuItem address;
        private ToolStripMenuItem connect;
        private ToolStripStatusLabel message;

        public Html()
        {
            html = new HtmlConnection();
        }

        public void addMenu(ToolStripMenuItem m)
        {
            menu = m;
            address = new ToolStripMenuItem("Set IP Address", null, SetIP, "IPAddress");
            connect = new ToolStripMenuItem("Connect", null, ToggleConnect, "HtmlConnect");
            menu.DropDownItems.Add(address);
            menu.DropDownItems.Add(connect);
            menu.DropDownOpening += MenuUpdate;
        }

        public void addStatusStrip(ToolStripStatusLabel sslMessage)
        {
            message = sslMessage;
            html.TimeoutEvent += Timeout;
        }

        public void Timeout (object sender, EventArgs a)
        {
            message.Text = "Timeout";
        }

        public void call(string s)
        {
            html.call(s);
        }

        private void MenuUpdate(object sender, EventArgs e)
        {
            if (html.Enabled)
                connect.Text = "Disconnect";
            else
                connect.Text = "Connect";
        }

        private void ToggleConnect(object sender, EventArgs e)
        {
            html.ToggleConnect();
        }

        private void SetIP(object sender, EventArgs e)
        {
            GetIPForm getform = new GetIPForm();
            getform.ShowDialog();
            html.Baseurl = getform.address;
        }
    }
}
