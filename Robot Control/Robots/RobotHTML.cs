using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robot_Control.HTML;

namespace Robot_Control.Robots
{
    class RobotHTML
    {
        Html html;

        public bool Enabled { get; set; }

        private Dictionary<string, string> direction = new Dictionary<string, string>()
        {
            {"fwd","fwd" },
            {"back","back" },
            {"left","left" },
            {"right","right" },
            {"stop", "stop" }
        };

        public RobotHTML(Html h, Robot robot)
        {
            html = h;
            robot.DirectionChange += ChangeDirection;
            robot.TakeReading += TakeReading;
            robot.StringSent += SendString;
            robot.MotorChange += ChangeMotors;
            robot.Fire += fire;
        }

        private void TakeReading(object sender, EventArgs e)
        {
            html.call("sensor");
        }

        private void ChangeDirection(object sender, StringEventArgs e)
        {
            string d = e.Direction;
            if (direction.ContainsKey(d))
                html.call(direction[e.Direction]);
        }

        private void SendString(object sender, StringEventArgs e)
        {
            html.call(@"string/" + e.Direction);
        }

        private void ChangeMotors(object sender, MotorEventArgs e)
        {
            html.call(@"ml/" + e.left + @"/mr/" + e.right);
        }

        private void fire(object sender, EventArgs e)
        {
            html.call(@"fire/");
        }
    }
}
