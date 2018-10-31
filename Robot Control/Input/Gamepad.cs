using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robot_Control.Robots;
using System.Windows.Forms;

namespace Robot_Control.Input
{
    class GamepadInterface
    {
        private AnalogGamepad analog;
        private Robot robot;
        private GamepadXBox gamepad;
        private bool enabled;
        private Timer timer;
        private GamepadStatusStrip gamepadStatusStrip;
        private GamepadMenu gamepadMenu;
        private bool digital;

        public GamepadInterface(Robot r)
        {
            robot = r;
            gamepad = new GamepadXBox();
            analog = new AnalogGamepad(gamepad);
            timer = new Timer();
            timer.Interval = 100;
            timer.Enabled = true;
            enabled = false;
            timer.Tick += analog.Update;
            analog.StartEvent += Connect;
            analog.StopEvent += Disconnect;
        }

        private void changeMode(object sender, ModeEventArgs e)
        {
            analog.mode = e.mode;
        }

        private void toggleConnect(object sender, EventArgs a)
        {
            enabled = !enabled;
            if (enabled)
                timer.Tick += update;
            else
                timer.Tick -= update;
        }

        private void Connect(object sender, EventArgs e)
        {
            if (!enabled)
            {
                enabled = true;
                timer.Tick += update;
            }

        }

        private void Disconnect(object sender, EventArgs e)
        {
            if (enabled)
            {
                enabled = false;
                timer.Tick -= update;
            }
        }

        private void update(object sender, EventArgs e)
        {
            if (digital)
                robot.ChangeDirection(Direction[analog.Digital5]);
            else
                robot.Motors(analog.Left, analog.Right);
            if (analog.Fire)
                robot.SendString("x");
        }

        private Dictionary<digital5, string> Direction = new Dictionary<digital5, string>()
        {
            {digital5.Fwd,"fwd" },
            {digital5.Back,"back" },
            {digital5.Left,"left" },
            {digital5.Right,"right" },
            {digital5.Stop,"stop" }
        };

        private void setDigital(Object sender, AnalogDigitalEventArgs e)
        {
            digital = e.digital;
        }

        public void addMenu(ToolStripMenuItem m)
        {
            gamepadMenu = new GamepadMenu(gamepad, m);
            gamepadMenu.ToggleConnectionEvent += toggleConnect;
            gamepadMenu.ChangeModeEvent += changeMode;
            gamepadMenu.DigitalEvent += setDigital;
        }

        public void addStatusStrip(ToolStripStatusLabel gp1, ToolStripStatusLabel gp2,
            ToolStripStatusLabel gp3, ToolStripStatusLabel gp4)
        {
            gamepadStatusStrip = new GamepadStatusStrip();
            gamepadStatusStrip.attachStatusStrip(gp1, gp2, gp3, gp4);
            timer.Tick += UpdateStatusStrip;
        }

        private void UpdateStatusStrip(Object sender, EventArgs e)
        {
            gamepadStatusStrip.Update(gamepad.status(),enabled);
        }
    }

    class GamepadStatusStrip
    {
        private ToolStripStatusLabel[] icons = new ToolStripStatusLabel[4];

        public void attachStatusStrip(ToolStripStatusLabel gp1, ToolStripStatusLabel gp2,
            ToolStripStatusLabel gp3, ToolStripStatusLabel gp4)
        {
            icons[0] = gp1;
            icons[1] = gp2;
            icons[2] = gp3;
            icons[3] = gp4;
            foreach (var icon in icons)
                icon.Text = "";
        }

        public void Update(Status[] status, bool enabled)
        {
            for (int i = 0; i < 4; i++)
            {
                if (status[i] == Status.ready && enabled)
                    icons[i].Image = Properties.Resources.enabled_joystick_16;
                else if (status[i] == Status.ready)
                    icons[i].Image = Properties.Resources.selected_connected_joystick_16;
                else if (status[i] == Status.selected)
                    icons[i].Image = Properties.Resources.selected_joystick_16;
                else if (status[i] == Status.connected)
                    icons[i].Image = Properties.Resources.connected_joystick_16;
                else
                    icons[i].Image = Properties.Resources.disconnected_Joystick_16;
            }
        }
    }

    enum AnalogDigital { Analog, Digital };

    class AnalogDigitalEventArgs : EventArgs
    {
        public bool digital;
        public bool analog;

        public AnalogDigitalEventArgs(AnalogDigital ad)
        {
            if (ad == AnalogDigital.Digital)
            {
                digital = true;
                analog = false;
            }
            else
            {
                digital = false;
                analog = true;
            }            
        }
    }

    class GamepadMenu
    {
        public event EventHandler ToggleConnectionEvent;
        public event EventHandler<ModeEventArgs> ChangeModeEvent;
        public event EventHandler<AnalogDigitalEventArgs> DigitalEvent;
        private GamepadXBox gamepad;
        private bool enabled;

        private ToolStripMenuItem _menu;
        private ToolStripMenuItem _gamepad;
        private ToolStripMenuItem[] _gamepads = new ToolStripMenuItem[4];
        private ToolStripMenuItem _gamepad1;
        private ToolStripMenuItem _gamepad2;
        private ToolStripMenuItem _gamepad3;
        private ToolStripMenuItem _gamepad4;
        private ToolStripMenuItem _mode;
        private ToolStripMenuItem _default;
        private ToolStripMenuItem _marioKart;
        private ToolStripMenuItem _marioPlus;
        private ToolStripMenuItem _halo;
        private ToolStripMenuItem _tank;
        private ToolStripMenuItem _digital;
        private ToolStripMenuItem _enable;

        protected virtual void onToggleConnectionEvent()
        {
            enabled = !enabled;
            ToggleConnectionEvent?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void onChangeModeEvent(Mode m)
        {
            ChangeModeEvent?.Invoke(this, new ModeEventArgs(m));
        }

        protected virtual void onDigitalEvent()
        {
            if (_digital.Checked)
                DigitalEvent?.Invoke(this, new AnalogDigitalEventArgs(AnalogDigital.Digital));
            else
                DigitalEvent?.Invoke(this, new AnalogDigitalEventArgs(AnalogDigital.Analog));
        }

        public GamepadMenu(GamepadXBox g, ToolStripMenuItem m)
        {
            gamepad = g;
            _menu = m;
            _mode = new ToolStripMenuItem("Mode", null, null, "mode");
            _gamepad = new ToolStripMenuItem("Gamepad", null, null, "gamepad");
            _gamepad1 = new ToolStripMenuItem("One", null, Choose, "gp0");
            _gamepad2 = new ToolStripMenuItem("Two", null, Choose, "gp1");
            _gamepad3 = new ToolStripMenuItem("Three", null, Choose, "gp2");
            _gamepad4 = new ToolStripMenuItem("Four", null, Choose, "gp3");
            _gamepads[0] = _gamepad1;
            _gamepads[1] = _gamepad2;
            _gamepads[2] = _gamepad3;
            _gamepads[3] = _gamepad4;
            _default = new ToolStripMenuItem("Default", null, modeDefault, "default");
            _marioKart = new ToolStripMenuItem("Mario Kart", null, modeMario, "mario");
            _marioPlus = new ToolStripMenuItem("Mario Kart +", null, modeMarioPlus, "mario+");
            _halo = new ToolStripMenuItem("Halo", null, modeHalo, "halo");
            _tank = new ToolStripMenuItem("Tank", null, modeTank, "tank");
            _digital = new ToolStripMenuItem("Digital", null, modeDigital, "digital");
            _enable = new ToolStripMenuItem("Connect", null, Enable, "enable");
            _menu.DropDownItems.Add(_gamepad);
            _gamepad.DropDownItems.Add(_gamepad1);
            _gamepad.DropDownItems.Add(_gamepad2);
            _gamepad.DropDownItems.Add(_gamepad3);
            _gamepad.DropDownItems.Add(_gamepad4);
            _menu.DropDownItems.Add(_mode);
            _mode.DropDownItems.Add(_default);
            _mode.DropDownItems.Add(_marioKart);
            _mode.DropDownItems.Add(_halo);
            _mode.DropDownItems.Add(_tank);
            _mode.DropDownItems.Add(_marioPlus);
            _menu.DropDownItems.Add(_digital);
            _menu.DropDownItems.Add(_enable);
            _default.Checked = true;
            _digital.Checked = false;
            _menu.DropDownOpened += updateMenus;
        }

        private void updateMenus(object sender, EventArgs e)
        {
            updateGamepad();
            updateConnect();
        }

        private void updateGamepad()
        {
            for (int i = 0; i < 4; i++)
            {
                if (gamepad.IsSelected(i))
                    _gamepads[i].Checked = true;
                else
                    _gamepads[i].Checked = false;
                if (gamepad.IsConnected(i))
                    _gamepads[i].Enabled = true;
                else
                    _gamepads[i].Enabled = false;
            }
        }

        private void updateConnect()
        {
            if (gamepad.IsConnected() && enabled)
                _enable.Text = "Disable";
            else
                _enable.Text = "Enable";
        }

        private void UncheckModes()
        {
            _default.Checked = false;
            _marioKart.Checked = false;
            _halo.Checked = false;
            _tank.Checked = false;
            _marioPlus.Checked = false;
        }

        private void Enable(object sender, EventArgs e)
        {
            onToggleConnectionEvent();
        }

        private void Choose(object sender, EventArgs e)
        {
            ToolStripMenuItem option = (ToolStripMenuItem)sender;
            int index = option.Name[option.Name.Length -1]-'0';
            gamepad.PadIndex = index;
        }

        private void modeDefault(object sender, EventArgs e)
        {
            UncheckModes();
            _default.Checked = true;
            onChangeModeEvent(Mode.Default);
        }

        private void modeMario(object sender, EventArgs e)
        {
            UncheckModes();
            _marioKart.Checked = true;
            onChangeModeEvent(Mode.Mario);
        }

        private void modeMarioPlus(object sender, EventArgs e)
        {
            UncheckModes();
            _marioPlus.Checked = true;
            onChangeModeEvent(Mode.MarioPlus);
        }

        private void modeHalo(object sender, EventArgs e)
        {
            UncheckModes();
            _halo.Checked = true;
            onChangeModeEvent(Mode.Halo);
        }

        private void modeTank(object sender, EventArgs e)
        {
            UncheckModes();
            _tank.Checked = true;
            onChangeModeEvent(Mode.Tank);
        }

        private void modeDigital(object sender, EventArgs e)
        {
            _digital.Checked = !_digital.Checked;
            onDigitalEvent();
        }
    }

    
}
