using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Robot_Control.ArduinoConnection
{
    public class MessageEventArgs : EventArgs
    {
        public readonly string Text;

        public MessageEventArgs(string s)
        {
            Text = s;
        }
    }


    public class arduinoSerial
    {
        private SerialPort serialRead;
        private SerialPort serialWrite;
        private bool shared = true;

        public List<string> BaudRates = new List<string>
                    { "300", "600", "1200", "2400", "4800", "9600", "14400", "19200",
                    "28800", "38400", "57600", "115200" };

        public event EventHandler OpenEvent;
        public event EventHandler CloseEvent;
        public event EventHandler<MessageEventArgs> DropEvent;
        public event EventHandler<MessageEventArgs> ReceiveEvent;

        protected virtual void OnOpenEvent()
        {
            OpenEvent?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnCloseEvent()
        {
            CloseEvent?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnDropEvent(MessageEventArgs e)
        {
            DropEvent?.Invoke(this, e);
        }

        protected virtual void OnReceiveEvent(MessageEventArgs e)
        {
            ReceiveEvent?.Invoke(this, e);
        }

        public arduinoSerial()
        {
            serialRead = new SerialPort();
            serialWrite = new SerialPort();
            serialRead.ReadTimeout = 500;
            serialWrite.ReadTimeout = 500;
            serialWrite.WriteTimeout = 500;
            serialRead.DataReceived += DataReceived;
            serialWrite.DataReceived += DataReceived;
            loadSettings();
        }

        private void loadSettings()
        {
            Shared = Properties.Settings.Default.Shared;
            Leonardo = Properties.Settings.Default.Leonardo;
            Baud = Properties.Settings.Default.BaudRate;
            ReadPortName = Properties.Settings.Default.ReadPortName;
            WritePortName = Properties.Settings.Default.WritePortName;
        }

        public bool Shared
        {
            get
            {
                return shared;
            }
            set
            {
                shared = value;
                Properties.Settings.Default.Shared = value;
            }
        }

        public bool Leonardo
        {
            get
            {
                return serialRead.DtrEnable;
            }
            set
            {
                serialRead.DtrEnable = value;
                serialWrite.DtrEnable = value;
                Properties.Settings.Default.Leonardo = value;
            }
        }

        public int Baud
        {
            get
            {
                return serialRead.BaudRate;
            }
            set
            {
                serialRead.BaudRate = value;
                serialWrite.BaudRate = value;
                Properties.Settings.Default.BaudRate = value;
            }
        }

        public string ReadPortName
        {
            get
            {
                return serialRead.PortName;
            }
            set
            {
                serialRead.PortName = value;
                Properties.Settings.Default.ReadPortName = value;
            }
        }

        public string WritePortName
        {
            get
            {
                return serialWrite.PortName;
            }
            set
            {
                serialWrite.PortName = value;
                Properties.Settings.Default.WritePortName = value;
            }
        }

        public void Open()
        {
            try
            {
                serialWrite.Open();
                if (!shared)
                    serialRead.Open();
                Properties.Settings.Default.Save();
                OnOpenEvent();
            }
            catch
            {
                OnDropEvent(new MessageEventArgs("Failed to open serial port."));
                Close();
            }
        }

        public void Close()
        {
            if (serialWrite.IsOpen)
                serialWrite.Close();
            if (serialRead.IsOpen)
                serialRead.Close();
            OnCloseEvent();
        }

        public void Write(string s)
        {
            try
            {
                serialWrite.Write(s);
            }
            catch
            {
                OnDropEvent(new MessageEventArgs("Connection dropped."));
                Close();
            }
        }

        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string inData = sp.ReadExisting();
            OnReceiveEvent(new MessageEventArgs(inData));
        }

        public bool isConnected
        {
            get
            {
                return serialWrite.IsOpen;
            }
        }

        public string[] availablePorts
        {
            get
            {
                return SerialPort.GetPortNames().Distinct().OrderBy(s => s).ToArray();
            }
        }
    }
}
