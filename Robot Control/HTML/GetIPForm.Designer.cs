namespace Robot_Control.HTML
{
    partial class GetIPForm
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
            this.tbIP0 = new System.Windows.Forms.TextBox();
            this.tbIP1 = new System.Windows.Forms.TextBox();
            this.tbIP3 = new System.Windows.Forms.TextBox();
            this.tbIP2 = new System.Windows.Forms.TextBox();
            this.cbHttp = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbIP0
            // 
            this.tbIP0.Location = new System.Drawing.Point(142, 54);
            this.tbIP0.Name = "tbIP0";
            this.tbIP0.Size = new System.Drawing.Size(40, 26);
            this.tbIP0.TabIndex = 1;
            this.tbIP0.Text = "0";
            this.tbIP0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbIP0.TextChanged += new System.EventHandler(this.tbIP_TextChanged);
            // 
            // tbIP1
            // 
            this.tbIP1.Location = new System.Drawing.Point(207, 54);
            this.tbIP1.Name = "tbIP1";
            this.tbIP1.Size = new System.Drawing.Size(40, 26);
            this.tbIP1.TabIndex = 2;
            this.tbIP1.Text = "0";
            this.tbIP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbIP3
            // 
            this.tbIP3.Location = new System.Drawing.Point(337, 54);
            this.tbIP3.Name = "tbIP3";
            this.tbIP3.Size = new System.Drawing.Size(40, 26);
            this.tbIP3.TabIndex = 4;
            this.tbIP3.Text = "0";
            this.tbIP3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbIP2
            // 
            this.tbIP2.Location = new System.Drawing.Point(272, 54);
            this.tbIP2.Name = "tbIP2";
            this.tbIP2.Size = new System.Drawing.Size(40, 26);
            this.tbIP2.TabIndex = 3;
            this.tbIP2.Text = "0";
            this.tbIP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbHttp
            // 
            this.cbHttp.FormattingEnabled = true;
            this.cbHttp.Items.AddRange(new object[] {
            "http",
            "https"});
            this.cbHttp.Location = new System.Drawing.Point(24, 54);
            this.cbHttp.Name = "cbHttp";
            this.cbHttp.Size = new System.Drawing.Size(72, 28);
            this.cbHttp.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "://";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = ".";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(253, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = ".";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(318, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = ".";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(172, 142);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 36);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(286, 142);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 36);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // GetIPForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 220);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbHttp);
            this.Controls.Add(this.tbIP2);
            this.Controls.Add(this.tbIP3);
            this.Controls.Add(this.tbIP1);
            this.Controls.Add(this.tbIP0);
            this.Name = "GetIPForm";
            this.Text = "3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbIP0;
        private System.Windows.Forms.TextBox tbIP1;
        private System.Windows.Forms.TextBox tbIP3;
        private System.Windows.Forms.TextBox tbIP2;
        private System.Windows.Forms.ComboBox cbHttp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}