using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_Control.Robots
{
    public class StringEventArgs : EventArgs
    {
        public readonly string Direction;

        public StringEventArgs(string s)
        {
            Direction = s;
        }
    }

    public class MotorEventArgs : EventArgs
    {
        public readonly double left;
        public readonly double right;

        public MotorEventArgs(double l, double r)
        {
            left = l;
            right = r;
        }
    }

    public class Robot
    {
        public event EventHandler<StringEventArgs> DirectionChange;
        public event EventHandler<StringEventArgs> StringSent;
        public event EventHandler TakeReading;
        public event EventHandler<MotorEventArgs> MotorChange;
        public event EventHandler Fire;

        string direction = "";

        protected virtual void OnDirectionChange()
        {
            DirectionChange?.Invoke(this, new StringEventArgs(direction));
        }

        protected virtual void OnTakeReading()
        {
            TakeReading?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnStringSent(string s)
        {
            StringSent?.Invoke(this, new StringEventArgs(s));
        }

        protected virtual void OnMotorChange(double l, double r)
        {
            MotorChange?.Invoke(this, new MotorEventArgs(l, r));
        }

        protected virtual void onFire()
        {
            Fire?.Invoke(this, EventArgs.Empty);
        }

        public void ChangeDirection(string d)
        {
            if (direction != d)
            {
                direction = d;
                OnDirectionChange();
            }
        }

        public void Reading()
        {
            OnTakeReading();
        }

        public void SendString(string s)
        {
            OnStringSent(s);
        }

        public void Motors(double left, double right)
        {
            OnMotorChange(left, right);
        }

        public void Shoot()
        {
            onFire();
        }
    }
}
