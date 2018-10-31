using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Robot_Control.Robots;

namespace Robot_Control.Input
{
    class KeyPress
    {
        private Form form;
        private bool takeReading = true;
        private List<char> pressed = new List<char>();
        private Robot robot;

        private Dictionary<char, string> DirectionForKey = new Dictionary<char, string>()
        {
            {'W',"fwd" },
            {'S',"back" },
            {'A',"left" },
            {'D',"right" },
            {'L',"follow" }
        };

        public KeyPress(Form f, Robot r)
        {
            form = f;
            robot = r;
            form.KeyPreview = true;
            form.KeyDown += Form1_KeyDown;
            form.KeyUp += Form1_KeyUp;
        }

        ~KeyPress()
        {
            form.KeyDown -= Form1_KeyDown;
            form.KeyUp -= Form1_KeyUp;
        }

        private void processChar(char c)
        {
            if (c == ' ')
            {
                if (takeReading)
                {
                    robot.Reading();
                    takeReading = false;
                }
            }
            else if (DirectionForKey.ContainsKey(c))
            {
                robot.ChangeDirection(DirectionForKey[c]);
                if (!pressed.Contains(c))
                    pressed.Add(c);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            processChar(Convert.ToChar(e.KeyCode));
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            char c = Convert.ToChar(e.KeyCode);
            pressed.Remove(c);
            takeReading = c == ' ';
            if (pressed.Count > 0)
                processChar(pressed[0]);
            else if (DirectionForKey.ContainsKey(c))
                robot.ChangeDirection("stop");
        }
    }
}
