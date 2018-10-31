using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Robot_Control.ArduinoConnection;
using Robot_Control.Robots;
using Robot_Control.Input;
using Robot_Control.HTML;

namespace Robot_Control
{
    public partial class Form1 : Form
    {
        Arduino arduino;
        Html html;
        Robot robot;
        RobotArduino robotArduino;
        RobotHTML robotHTML;
        ReportDirection reportDirection;
        KeyPress keypress;
        Buttons buttons;
        GamepadInterface gamepad;

        public Form1()
        {
            InitializeComponent();
            menuStrip1.ImageScalingSize = new Size(16, 16);

            arduino = new Arduino();
            arduino.addMenu(connectionToolStripMenuItem);
            arduino.addStatusStrip(sslConnection, sslMessage);
            arduino.addReceivedRichText(richTextBox1,this);

            html = new Html();
            html.addMenu(htmlToolStripMenuItem);
            html.addStatusStrip(sslMessage);

            robot = new Robot();

            robotArduino = new RobotArduino(arduino, robot);
            reportDirection = new ReportDirection(label1, robot);
            robotHTML = new RobotHTML(html, robot);

            keypress = new KeyPress(this, robot);

            buttons = new Buttons(robot, btnFwd, btnBack, btnLeft, btnRight);
            buttons.addSensor(btnSensor);
            buttons.addSend(btnSend, txtBoxInstructions);

            gamepad = new GamepadInterface(robot);
            gamepad.addMenu(gamepadToolStripMenuItem);
            gamepad.addStatusStrip(SSLgp1, SSLgp2, SSLgp3, SSLgp4);

        }
    }
}
