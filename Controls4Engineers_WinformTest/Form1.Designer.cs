namespace Controls4Engineers_WinformTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            gauge4Engineers2 = new Controls4Engineers.Gauge4Engineers();
            gauge4Engineers3 = new Controls4Engineers.Gauge4Engineers();
            timer1 = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            linkLabel1 = new LinkLabel();
            label4 = new Label();
            gauge4Engineers1 = new Controls4Engineers.Gauge4Engineers();
            gauge4Engineers4 = new Controls4Engineers.Gauge4Engineers();
            label5 = new Label();
            SuspendLayout();
            // 
            // gauge4Engineers2
            // 
            gauge4Engineers2.Feedback = 33F;
            gauge4Engineers2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gauge4Engineers2.Location = new Point(251, 48);
            gauge4Engineers2.Max = 100F;
            gauge4Engineers2.Mid = 50F;
            gauge4Engineers2.Min = 0F;
            gauge4Engineers2.MinimumSize = new Size(64, 50);
            gauge4Engineers2.Name = "gauge4Engineers2";
            gauge4Engineers2.Reference = 50F;
            gauge4Engineers2.ShowFeedback = true;
            gauge4Engineers2.ShowReference = false;
            gauge4Engineers2.Size = new Size(229, 180);
            gauge4Engineers2.Step = 1F;
            gauge4Engineers2.TabIndex = 1;
            gauge4Engineers2.Value = 0F;
            gauge4Engineers2.ValueChanged += gauge4Engineers2_ValueChanged;
            // 
            // gauge4Engineers3
            // 
            gauge4Engineers3.Feedback = 0F;
            gauge4Engineers3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gauge4Engineers3.Location = new Point(486, 48);
            gauge4Engineers3.Max = 100F;
            gauge4Engineers3.Mid = 50F;
            gauge4Engineers3.Min = 0F;
            gauge4Engineers3.MinimumSize = new Size(64, 50);
            gauge4Engineers3.Name = "gauge4Engineers3";
            gauge4Engineers3.Reference = 50F;
            gauge4Engineers3.ShowFeedback = false;
            gauge4Engineers3.ShowReference = true;
            gauge4Engineers3.Size = new Size(229, 180);
            gauge4Engineers3.Step = 1F;
            gauge4Engineers3.TabIndex = 2;
            gauge4Engineers3.Value = 0F;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 50;
            timer1.Tick += timer1_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(273, 240);
            label1.Name = "label1";
            label1.Size = new Size(191, 20);
            label1.TabIndex = 3;
            label1.Text = "with feedback signal shown";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(80, 240);
            label2.Name = "label2";
            label2.Size = new Size(106, 20);
            label2.TabIndex = 4;
            label2.Text = "Simple version";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(504, 240);
            label3.Name = "label3";
            label3.Size = new Size(192, 20);
            label3.TabIndex = 5;
            label3.Text = "with reference signal shown";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(12, 290);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(387, 20);
            linkLabel1.TabIndex = 6;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "https://www.linkedin.com/in/fabrizio-morlino-06b51128/";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 9);
            label4.Name = "label4";
            label4.Size = new Size(250, 20);
            label4.TabIndex = 7;
            label4.Text = "Use mouse click or wheel o set value";
            // 
            // gauge4Engineers1
            // 
            gauge4Engineers1.Feedback = 0F;
            gauge4Engineers1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gauge4Engineers1.Location = new Point(16, 48);
            gauge4Engineers1.Max = 100F;
            gauge4Engineers1.Mid = 50F;
            gauge4Engineers1.Min = 0F;
            gauge4Engineers1.MinimumSize = new Size(64, 50);
            gauge4Engineers1.Name = "gauge4Engineers1";
            gauge4Engineers1.Reference = 50F;
            gauge4Engineers1.ShowFeedback = false;
            gauge4Engineers1.ShowReference = false;
            gauge4Engineers1.Size = new Size(229, 180);
            gauge4Engineers1.Step = 1F;
            gauge4Engineers1.TabIndex = 8;
            gauge4Engineers1.Value = 0F;
            // 
            // gauge4Engineers4
            // 
            gauge4Engineers4.Feedback = 0F;
            gauge4Engineers4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gauge4Engineers4.Location = new Point(436, 290);
            gauge4Engineers4.Max = 100F;
            gauge4Engineers4.Mid = 50F;
            gauge4Engineers4.Min = 0F;
            gauge4Engineers4.MinimumSize = new Size(64, 50);
            gauge4Engineers4.Name = "gauge4Engineers4";
            gauge4Engineers4.Reference = 50F;
            gauge4Engineers4.ShowFeedback = false;
            gauge4Engineers4.ShowReference = false;
            gauge4Engineers4.Size = new Size(84, 66);
            gauge4Engineers4.Step = 1F;
            gauge4Engineers4.TabIndex = 9;
            gauge4Engineers4.Text = "gauge4Engineers4";
            gauge4Engineers4.Value = 0F;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 322);
            label5.Name = "label5";
            label5.Size = new Size(112, 20);
            label5.TabIndex = 10;
            label5.Text = "leave me an Hi!";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(732, 368);
            Controls.Add(label5);
            Controls.Add(gauge4Engineers4);
            Controls.Add(gauge4Engineers1);
            Controls.Add(label4);
            Controls.Add(linkLabel1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(gauge4Engineers3);
            Controls.Add(gauge4Engineers2);
            MinimumSize = new Size(750, 415);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Controls4Engineers testbench";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Controls4Engineers.Gauge4Engineers gauge4Engineers2;
        private Controls4Engineers.Gauge4Engineers gauge4Engineers3;
        private System.Windows.Forms.Timer timer1;
        private Label label1;
        private Label label2;
        private Label label3;
        private LinkLabel linkLabel1;
        private Label label4;
        private Controls4Engineers.Gauge4Engineers gauge4Engineers1;
        private Controls4Engineers.Gauge4Engineers gauge4Engineers4;
        private Label label5;
    }
}
