using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robot_Control.Robots;

namespace Robot_Control.Input
{
    class AnalogGamepad : GamepadBase
    {
        public AnalogGamepad(GamepadXBox g)
        {
            gamepad = g;
            setDefault();
        }

        public void Update(object sender, EventArgs e)
        {
            if (gamepad.IsConnected())
            {
                gamepad.Update();
                if (gamepad.StartPressed)
                    OnStartEvent();
                if (gamepad.BackPressed)
                    OnStopEvent();
            }
        }

        private bool _boost = false;

        private double boost
        {
            get 
            {
                if (_boost && !gamepad.APressed)
                {
                    return 0.5;
                }
                else
                {
                    return 1;
                }
            }
        }

        private bool _exponential = true;

        public Option option
        {
            set
            {
                if (value == Option.BoostOff)
                    _boost = false;
                else if (value == Option.BoostOn)
                    _boost = true;
                else if (value == Option.ExpOff)
                    _exponential = false;
                else if (value == Option.ExpOn)
                    _exponential = true;
            }
        }

        private double scale (double X)
        {
            double x = boost * X;
            if (_exponential)
            {
                double s = 1.0;
                if (x < 0)
                    s = -1.0;
                return (s * (Math.Exp(4 * Math.Abs(x)) - 1) / (Math.Exp(4) - 1));
            }
            else
            {
                return x;
            }
        }

        private Mode _mode;

        public Mode mode 
        {
            get
            {
                return _mode;
            }

            set
            {
                _mode = value;
                switch (value)
                {
                    case Mode.Halo:
                        x = Axis.RightThumbX;
                        y = Axis.LeftThumbY;
                        break;
                    case Mode.Tank:
                        break;
                    case Mode.Mario:
                    case Mode.MarioPlus:
                        x = Axis.LeftThumbX;
                        y = Axis.Triggers;
                        break;
                    case Mode.Default:
                    default:
                        _mode = Mode.Default;
                        x = Axis.LeftThumbX;
                        y = Axis.LeftThumbY;
                        break;
                }
            }
        }

        public double Left
        {
            get
            {
                //System.Diagnostics.Debug.WriteLine(Radius + ", " + Theta + ", " + Quadrant);
                if (IsConnected())
                {
                    if (mode == Mode.Tank)
                        return scale(gamepad.LeftThumbY);
                    else if (mode == Mode.MarioPlus)
                    {
                        if (Y > 0)
                        {
                            if (X >= 0)
                                return scale(Y);
                            else
                                return scale((1 + X) * Y);
                        }
                        else if (Y < 0)
                        {
                            if (X >= 0)
                                return scale((1-X)*Y);
                            else
                                return scale(Y);
                        }
                        else
                            return 0;
                    }
                    else 
                    {
                        if (Quadrant == 1 || Quadrant == 3)
                            return scale(SignedRadius);
                        else
                            return scale(SignedRadius * reduceFactor);
                    }
                }
                else
                    return 0;
            }
        }

        public double Right
        {
            get
            {
                if (IsConnected())
                {
                    if (mode == Mode.Tank)
                        return scale(gamepad.RightThumbY);
                    else if (mode == Mode.MarioPlus)
                    {
                        if (Y > 0)
                        {
                            if (X >= 0)
                                return scale((1 - X)*Y);
                            else
                                return scale(Y);
                        }
                        else if (Y < 0)
                        {
                            if (X <= 0)
                                return scale((1+X)*Y);
                            else
                                return scale(Y);
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    else
                    {
                        if (Quadrant == 1 || Quadrant == 3)
                            return scale(SignedRadius * reduceFactor);
                        else
                            return scale(SignedRadius);
                    }
                }
                else
                    return 0;
            }
        }

        public digital5 Digital5
        {
            get
            {
                if (mode == Mode.Tank)
                {
                    if (gamepad.RightThumbY > 0 && gamepad.LeftThumbY > 0)
                        return digital5.Fwd;
                    else if (gamepad.RightThumbY < 0 && gamepad.LeftThumbY < 0)
                        return digital5.Back;
                    else if (gamepad.LeftThumbY > 0 || gamepad.RightThumbY < 0)
                        return digital5.Right;
                    else if (gamepad.LeftThumbY < 0 || gamepad.RightThumbY > 0)
                        return digital5.Left;
                    else
                        return digital5.Stop;
                }
                else
                {
                    if (Y > 0)
                        return digital5.Fwd;
                    else if (Y < 0)
                        return digital5.Back;
                    else if (X < 0)
                        return digital5.Left;
                    else if (X > 0)
                        return digital5.Right;
                    else
                        return digital5.Stop;
                }
            }
        }

        public digital9 Digital9
        {
            get
            {
                if (mode == Mode.Tank)
                {
                    if (gamepad.RightThumbY > 0 && gamepad.LeftThumbY > 0)
                        return digital9.Fwd;
                    else if (gamepad.RightThumbY > 0 && gamepad.LeftThumbY == 0)
                        return digital9.FwdLeft;
                    else if (gamepad.RightThumbY == 0 && gamepad.LeftThumbY > 0)
                        return digital9.FwdRight;
                    else if (gamepad.RightThumbY < 0 && gamepad.LeftThumbY < 0)
                        return digital9.Back;
                    else if (gamepad.RightThumbY < 0 && gamepad.LeftThumbY == 0)
                        return digital9.BackLeft;
                    else if (gamepad.RightThumbY == 0 && gamepad.LeftThumbY < 0)
                        return digital9.BackRight;
                    else if (gamepad.LeftThumbY > 0 || gamepad.RightThumbY < 0)
                        return digital9.Right;
                    else if (gamepad.LeftThumbY < 0 || gamepad.RightThumbY > 0)
                        return digital9.Left;
                    else
                        return digital9.Stop;
                }
                else
                {
                    if (Y > 0 && X == 0)
                        return digital9.Fwd;
                    else if (Y > 0 && X < 0)
                        return digital9.FwdLeft;
                    else if (Y > 0 && X > 0)
                        return digital9.FwdRight;
                    else if (Y < 0 && X == 0)
                        return digital9.Back;
                    else if (Y < 0 && X < 0)
                        return digital9.BackLeft;
                    else if (Y < 0 && X > 0)
                        return digital9.BackRight;
                    else if (X < 0)
                        return digital9.Left;
                    else if (X > 0)
                        return digital9.Right;
                    else
                        return digital9.Stop;
                }
            }
        }

        private bool _fireTriggered=false;

        public bool Fire
        {
            get
            {
                if (gamepad.XPressed && !_fireTriggered)
                {
                    _fireTriggered = false;
                    return true;
                }
                else
                {
                    _fireTriggered = gamepad.XPressed;
                    return false;
                } 
            }
        }

        private Axis x;
        private Axis y;

        private double X
        {
            get { return gamepad.AxisValue(x); }
        }

        private double Y
        {
            get { return gamepad.AxisValue(y); }
        }

        private void setDefault()
        {
            x = Axis.LeftThumbX;
            y = Axis.LeftThumbY;
        }

        private double Radius
        {
            get { return Math.Min(1, Math.Sqrt(X * X + Y * Y)); }
        }

        private double SignedRadius
        {
            get { return Radius * Maths.Sign(Theta); }
        }

        private double Theta
        {
            get
            {
                double theta = 0;
                if (Radius != 0)
                    theta = Math.Atan2(Y, X);
                return theta * 180 / Math.PI;
            }
        }

        private int Quadrant
        {
            get
            {
                if (0 <= Theta && Theta < 90)
                    return 1;
                else if (Theta >= 90)
                    return 2;
                else if (-90 > Theta)
                    return 3;
                else
                    return 4;
            }

        }

        private double reduceFactor
        {
            get { return (45 - Math.Abs(Math.Abs(Theta) - 90)) / 45; }
        }
    }

    enum digital5 { Left, Right, Fwd, Back, Stop };
    enum digital9 { Left, Right, Fwd, Back, Stop, FwdLeft, FwdRight, BackLeft, BackRight};

    enum Mode { Default, Mario, Halo, Tank, MarioPlus};
    enum Option { BoostOn, BoostOff, ExpOn, ExpOff};

    class ModeEventArgs : EventArgs
    {
        public Mode mode;

        public ModeEventArgs(Mode m)
        {
            mode = m;
        }
    }

    class OptionEventArgs : EventArgs
    {
        public Option option;

        public OptionEventArgs(Option o)
        {
            option = o;
        }
    }

    public class GamepadConnectEventArgs : EventArgs
    {
        public readonly int index;

        public GamepadConnectEventArgs(int i)
        {
            index = i;
        }
    }

    class GamepadBase
    {
        public event EventHandler<GamepadConnectEventArgs> ConnectEvent;
        public event EventHandler<GamepadConnectEventArgs> DisconnectEvent;
        public event EventHandler StartEvent;
        public event EventHandler StopEvent;

        private bool connected;
        protected GamepadXBox gamepad;

        protected bool IsConnected()
        {
            if (connected && !gamepad.IsConnected())
                OnDisconnectEvent(gamepad.PadIndex);
            else if (!connected && gamepad.IsConnected())
                OnConnectEvent(gamepad.PadIndex);
            connected = gamepad.IsConnected();
            return connected;
        }

        protected virtual void OnConnectEvent(int i)
        {
            ConnectEvent?.Invoke(this, new GamepadConnectEventArgs(i));
        }

        protected virtual void OnDisconnectEvent(int i)
        {
            DisconnectEvent?.Invoke(this, new GamepadConnectEventArgs(i));
        }

        protected virtual void OnStartEvent()
        {
            StartEvent?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnStopEvent()
        {
            StopEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
