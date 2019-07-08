using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robot_Control.ArduinoConnection;

namespace Robot_Control.Robots
{
    public class RobotArduino
    {
        private Arduino arduino;

        private Dictionary<string, string> direction = new Dictionary<string, string>()
        {
            {"fwd","f" },
            {"back","b" },
            {"left","l" },
            {"right","r" },
            {"stop", "s" },
            {"follow", "F" },
            {"callibrate","C" }
        };

        private Dictionary<string, string> direction9 = new Dictionary<string, string>()
        {
            {"fwd","f" },
            {"back","b" },
            {"left","L" },
            {"right","R" },
            {"stop", "s" },
            {"fwdLeft","l" },
            {"fwdRight","r" },
            {"backLeft","k" },
            {"backRight","t" },
            {"follow","F" },
            {"callibrate","C" }
        };

        public RobotArduino(Arduino a, Robot robot)
        {
            arduino = a;
            robot.DirectionChange += ChangeDirection;
            robot.TakeReading += TakeReading;
            robot.StringSent += SendString;
            robot.MotorChange += ChangeMotors;
            robot.Fire += shoot;
        }

        private void TakeReading(object sender, EventArgs e)
        {
            arduino.write("#");
        }

        private void ChangeDirection(object sender, StringEventArgs e)
        {
            string d = e.Direction;
            if (direction.ContainsKey(d))
                arduino.write(direction[d]);
        }

        private void SendString(object sender, StringEventArgs e)
        {
            arduino.write(e.Direction);
        }

        private void ChangeMotors(object sender, MotorEventArgs e)
        {
            arduino.write("m" +
                ((int)(e.left * 255)).ToString() + "," +
                ((int)(e.right * 255)).ToString() + ";");
            System.Diagnostics.Debug.WriteLine("m" +
                ((int)(e.left * 255)).ToString() + "," +
                ((int)(e.right * 255)).ToString() + ";");
            //System.Diagnostics.Debug.WriteLine(Math.Round(192 - (64 * e.left)) + "," + Math.Round(64 - (63 * e.right)));
            /*
            char c = (char)((byte)(e.left < 0 ? 0x1 : 0x0) | (byte)(e.right < 0 ? 0x2 : 0x0));
            char left = (char)((byte)(e.left * 255));
            char right = (char)((byte)(e.right * 255));
            string s = c.ToString() + left.ToString() + right.ToString(); 
            arduino.write(s);
            */
        }

        private void shoot(object sender, EventArgs e)
        {
            arduino.write("x");
        }
    }
}
