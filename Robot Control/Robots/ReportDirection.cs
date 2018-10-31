using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Robot_Control.Robots
{
    public class ReportDirection
    {
        Label label;

        private Dictionary<string, string> direction = new Dictionary<string, string>()
        {
            {"fwd","Forward" },
            {"back","Back" },
            {"left","Left" },
            {"right","Right" },
            {"stop", "Stop" },
            {"follow", "Follow" }
        };

        public ReportDirection(Label l, Robot robot)
        {
            label = l;
            label.Text = direction["stop"];
            robot.DirectionChange += UpdateLabel;
        }

        private void UpdateLabel(object sender, StringEventArgs e)
        {
            if (direction.ContainsKey(e.Direction))
                label.Text = direction[e.Direction];
        }
    }
}
