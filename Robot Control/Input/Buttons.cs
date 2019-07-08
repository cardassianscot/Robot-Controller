using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Robot_Control.Robots;
using System.Drawing;

namespace Robot_Control.Input
{
    public class Buttons
    {
        Dictionary<string, string> direction = new Dictionary<string, string>();

        private Robot robot;

        public Buttons(Robot r, Button fwd, Button back, Button left, Button right)
        {
            robot = r;
            direction[fwd.Name] = "fwd";
            direction[back.Name] = "back";
            direction[left.Name] = "left";
            direction[right.Name] = "right";

            fwd.MouseDown += MouseDown;
            fwd.MouseUp += MouseUp;
            back.MouseDown += MouseDown;
            back.MouseUp += MouseUp;
            left.MouseDown += MouseDown;
            left.MouseUp += MouseUp;
            right.MouseDown += MouseDown;
            right.MouseUp += MouseUp;
        }

        public void addSensor(Button button)
        {
            button.MouseClick += Sensor;
        }

        public void addSend(Button button, TextBox textBox)
        {
            button.MouseClick += (sender, e) => { robot.SendString(textBox.Text); };
        }

        private void MouseDown(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (direction.ContainsKey(button.Name))
                robot.ChangeDirection(direction[button.Name]);
        }

        private void MouseUp(object sender, EventArgs e)
        {
            robot.ChangeDirection("stop");
        }

        private void Sensor(object sender,EventArgs e)
        {
            robot.Reading();
        }

        public void addFollow(Button follow, Button callibrate)
        {
            callibrate.Click += (sender, e) => { robot.SendString("C"); };
            follow.Click += Follow;
        }

        private void Follow(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Text == "Follow")
            {
                b.BackColor = SystemColors.ControlDark;
                b.Text = "Stop";
                robot.ChangeDirection("follow");
            } 
            else
            {
                b.BackColor = SystemColors.Control;
                b.Text = "Follow";
                robot.ChangeDirection("stop");
            }
        }

    }
}
