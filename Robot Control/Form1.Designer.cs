namespace Robot_Control
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnFwd = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxInstructions = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnSensor = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sslConnection = new System.Windows.Forms.ToolStripStatusLabel();
            this.SSLgp1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.SSLgp2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.SSLgp3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.SSLgp4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.htmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gamepadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnFollow = new System.Windows.Forms.Button();
            this.btnCallibrate = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.btnFwd, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnRight, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnBack, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnLeft, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(46, 69);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(455, 388);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnFwd
            // 
            this.btnFwd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFwd.Location = new System.Drawing.Point(157, 4);
            this.btnFwd.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnFwd.Name = "btnFwd";
            this.btnFwd.Size = new System.Drawing.Size(139, 121);
            this.btnFwd.TabIndex = 0;
            this.btnFwd.Text = "↑";
            this.btnFwd.UseVisualStyleBackColor = true;
            // 
            // btnRight
            // 
            this.btnRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRight.Location = new System.Drawing.Point(308, 133);
            this.btnRight.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(141, 121);
            this.btnRight.TabIndex = 1;
            this.btnRight.Text = "→";
            this.btnRight.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(157, 262);
            this.btnBack.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(139, 122);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "↓";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // btnLeft
            // 
            this.btnLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeft.Location = new System.Drawing.Point(6, 133);
            this.btnLeft.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(139, 121);
            this.btnLeft.TabIndex = 3;
            this.btnLeft.Text = "←";
            this.btnLeft.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(157, 129);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 129);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBoxInstructions
            // 
            this.txtBoxInstructions.Location = new System.Drawing.Point(46, 490);
            this.txtBoxInstructions.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txtBoxInstructions.Multiline = true;
            this.txtBoxInstructions.Name = "txtBoxInstructions";
            this.txtBoxInstructions.Size = new System.Drawing.Size(702, 124);
            this.txtBoxInstructions.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(782, 516);
            this.btnSend.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(158, 65);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // btnSensor
            // 
            this.btnSensor.Location = new System.Drawing.Point(677, 299);
            this.btnSensor.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnSensor.Name = "btnSensor";
            this.btnSensor.Size = new System.Drawing.Size(125, 66);
            this.btnSensor.TabIndex = 6;
            this.btnSensor.Text = "Sensor";
            this.btnSensor.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslConnection,
            this.SSLgp1,
            this.SSLgp2,
            this.SSLgp3,
            this.SSLgp4,
            this.sslMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 652);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 25, 0);
            this.statusStrip1.Size = new System.Drawing.Size(985, 54);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sslConnection
            // 
            this.sslConnection.Name = "sslConnection";
            this.sslConnection.Size = new System.Drawing.Size(186, 41);
            this.sslConnection.Text = "ConnectIcon";
            // 
            // SSLgp1
            // 
            this.SSLgp1.Name = "SSLgp1";
            this.SSLgp1.Size = new System.Drawing.Size(70, 41);
            this.SSLgp1.Text = "gp1";
            // 
            // SSLgp2
            // 
            this.SSLgp2.Name = "SSLgp2";
            this.SSLgp2.Size = new System.Drawing.Size(70, 41);
            this.SSLgp2.Text = "gp2";
            // 
            // SSLgp3
            // 
            this.SSLgp3.Name = "SSLgp3";
            this.SSLgp3.Size = new System.Drawing.Size(70, 41);
            this.SSLgp3.Text = "gp3";
            // 
            // SSLgp4
            // 
            this.SSLgp4.Name = "SSLgp4";
            this.SSLgp4.Size = new System.Drawing.Size(70, 41);
            this.SSLgp4.Text = "gp4";
            // 
            // sslMessage
            // 
            this.sslMessage.Name = "sslMessage";
            this.sslMessage.Size = new System.Drawing.Size(136, 41);
            this.sslMessage.Text = "Message";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionToolStripMenuItem,
            this.htmlToolStripMenuItem,
            this.gamepadToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(10, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(985, 51);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(148, 45);
            this.connectionToolStripMenuItem.Text = "Arduino";
            // 
            // htmlToolStripMenuItem
            // 
            this.htmlToolStripMenuItem.Name = "htmlToolStripMenuItem";
            this.htmlToolStripMenuItem.Size = new System.Drawing.Size(106, 45);
            this.htmlToolStripMenuItem.Text = "Html";
            // 
            // gamepadToolStripMenuItem
            // 
            this.gamepadToolStripMenuItem.Name = "gamepadToolStripMenuItem";
            this.gamepadToolStripMenuItem.Size = new System.Drawing.Size(171, 45);
            this.gamepadToolStripMenuItem.Text = "Gamepad";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(541, 69);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(397, 210);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            // 
            // btnFollow
            // 
            this.btnFollow.Location = new System.Drawing.Point(552, 391);
            this.btnFollow.Name = "btnFollow";
            this.btnFollow.Size = new System.Drawing.Size(171, 66);
            this.btnFollow.TabIndex = 10;
            this.btnFollow.Text = "Follow";
            this.btnFollow.UseVisualStyleBackColor = true;
            // 
            // btnCallibrate
            // 
            this.btnCallibrate.Location = new System.Drawing.Point(765, 391);
            this.btnCallibrate.Name = "btnCallibrate";
            this.btnCallibrate.Size = new System.Drawing.Size(173, 66);
            this.btnCallibrate.TabIndex = 11;
            this.btnCallibrate.Text = "Callibrate";
            this.btnCallibrate.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 706);
            this.Controls.Add(this.btnCallibrate);
            this.Controls.Add(this.btnFollow);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnSensor);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtBoxInstructions);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.Name = "Form1";
            this.Text = "Robot Control";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnFwd;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxInstructions;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnSensor;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sslConnection;
        private System.Windows.Forms.ToolStripStatusLabel sslMessage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripMenuItem gamepadToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel SSLgp1;
        private System.Windows.Forms.ToolStripStatusLabel SSLgp2;
        private System.Windows.Forms.ToolStripStatusLabel SSLgp3;
        private System.Windows.Forms.ToolStripStatusLabel SSLgp4;
        private System.Windows.Forms.ToolStripMenuItem htmlToolStripMenuItem;
        private System.Windows.Forms.Button btnFollow;
        private System.Windows.Forms.Button btnCallibrate;
    }
}

