using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Robot_Control.HTML
{
    public class HtmlConnection
    {
        public event EventHandler TimeoutEvent;

        protected virtual void onTimeoutEvent()
        {
            TimeoutEvent?.Invoke(this, EventArgs.Empty);
        }

        private string baseurl;
        public bool Enabled { get; set; }

        public string Baseurl
        {
            get
            {
                return baseurl;
            }
            set
            {
                // check for trailing / and http:// or https:// if not add
                baseurl = value;
            }
        }

        public void call(string s)
        {
            //Debug.Print(Baseurl + s+@"/");
            if (Baseurl != "" && Enabled)
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Baseurl + s + @"/");
                    request.Timeout = 50;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException e) when (e.Status == WebExceptionStatus.Timeout)
                {
                    Debug.Print("Timeout");
                }
                catch
                {
                    
                }
            }
        }

        public void ToggleConnect()
        {
            Enabled = !Enabled;
        }
    }
}
