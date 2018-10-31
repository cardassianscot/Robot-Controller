using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.XInput;

namespace Robot_Control.Input
{
    enum Axis
    {
        LeftThumbX,
        LeftThumbY,
        RightThumbX,
        RightThumbY,
        LeftTrigger,
        RightTrigger,
        Triggers
    };

    enum Status
    {
        nothing,
        connected,
        selected,
        ready,
        enabled
    }

    class GamepadXBox
    {
        private Controller[] gamepads = new Controller[4];
        private Controller gamepad;
        private int padIndex;
        private int DeadZone { get; set; }
        private int OuterDeadZone { get; set; }
        private State gamepadState;

        public int PadIndex
        {
            get
            {
                return padIndex;
            }
            set
            {
                padIndex = value;
                gamepad = gamepads[padIndex];
            }
        }

        public GamepadXBox()
        {
            gamepads[0] = new Controller(UserIndex.One);
            gamepads[1] = new Controller(UserIndex.Two);
            gamepads[2] = new Controller(UserIndex.Three);
            gamepads[3] = new Controller(UserIndex.Four);
            PadIndex = 0;
            DeadZone = Gamepad.LeftThumbDeadZone;
            OuterDeadZone = 30000;
        }

        public bool IsConnected()
        {
            return gamepad.IsConnected;
        }

        public bool IsConnected(int i)
        {
            return gamepads[i].IsConnected;
        }

        public bool IsSelected(int i)
        {
            return i == padIndex;
        }

        public Status[] status()
        {
            Status[] s = new Status[4];
            for (int i = 0; i < 4; i++)
            {
                if (i == padIndex && gamepads[i].IsConnected)
                    s[i] = Status.ready;
                else if (gamepads[i].IsConnected)
                    s[i] = Status.connected;
                else if (i == padIndex)
                    s[i] = Status.selected;
                else
                    s[i] = Status.nothing;
            }
            return s;
        }

        public double AxisValue(Axis a)
        {
            switch (a)
            {
                case Axis.LeftThumbX:
                    return LeftThumbX;
                case Axis.LeftThumbY:
                    return LeftThumbY;
                case Axis.RightThumbX:
                    return RightThumbX;
                case Axis.LeftTrigger:
                    return LeftTrigger;
                case Axis.RightTrigger:
                    return RightTrigger;
                case Axis.Triggers:
                    return Triggers;
                default:
                    return 0;
            }
        }

        public void Update()
        {
            gamepadState = gamepad.GetState();
        }

        private double normalisePad(double d)
        {
            return Maths.Map(Math.Abs(d), DeadZone, OuterDeadZone, 0, 1) * Maths.Sign(d);
        }

        public double LeftThumbX
        {
            get { return normalisePad(gamepadState.Gamepad.LeftThumbX); }
        }

        public double LeftThumbY
        {
            get { return normalisePad(gamepadState.Gamepad.LeftThumbY); }
        }

        public double RightThumbX
        {
            get { return normalisePad(gamepadState.Gamepad.RightThumbX); }
        }

        public double RightThumbY
        {
            get { return normalisePad(gamepadState.Gamepad.RightThumbY); }
        }

        public double LeftTrigger
        {
            get { return Maths.Map(gamepadState.Gamepad.LeftTrigger, 0, 255, 0, 1); }

        }

        public double RightTrigger
        {
            get { return Maths.Map(gamepadState.Gamepad.RightTrigger, 0, 255, 0, 1); }
        }

        public double Triggers
        {
            get { return RightTrigger > LeftTrigger ? RightTrigger : -LeftTrigger; }
        }

        public bool StartPressed
        {
            get { return (gamepadState.Gamepad.Buttons & GamepadButtonFlags.Start) != 0; }
        }

        public bool BackPressed
        {
            get { return (gamepadState.Gamepad.Buttons & GamepadButtonFlags.Back) != 0; }
        }

        public bool APressed
        {
            get { return (gamepadState.Gamepad.Buttons & GamepadButtonFlags.A) != 0; }
        }

        public bool XPressed
        {
            get { return (gamepadState.Gamepad.Buttons & GamepadButtonFlags.X) != 0; }
        }

        public bool BPressed
        {
            get { return (gamepadState.Gamepad.Buttons & GamepadButtonFlags.B) != 0; }
        }

        public bool YPressed
        {
            get { return (gamepadState.Gamepad.Buttons & GamepadButtonFlags.Y) != 0; }
        }
    }

    class Maths
    {
        static public double Map(double x, double FromMin, double FromMax, double ToMin, double ToMax)
        {
            double X = Constrain(x, FromMin, FromMax);
            return (X - FromMin) / (FromMax - FromMin) * (ToMax - ToMin) + ToMin;
        }

        static public double Constrain(double x, double min, double max)
        {
            return Math.Min(Math.Max(x, min), max);
        }

        static public double Sign(double x)
        {
            if (x == 0)
                return 1;
            else
                return Math.Sign(x);
        }
    }
}
