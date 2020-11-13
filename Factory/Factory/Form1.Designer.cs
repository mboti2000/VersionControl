﻿namespace Factory
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
            this.components = new System.ComponentModel.Container();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.createTimer = new System.Windows.Forms.Timer(this.components);
            this.conveyorTimer = new System.Windows.Forms.Timer(this.components);
            this.BallButon = new System.Windows.Forms.Button();
            this.CarButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.presentButton = new System.Windows.Forms.Button();
            this.boxColor = new System.Windows.Forms.Button();
            this.ribbonColor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(3, 303);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1063, 236);
            this.mainPanel.TabIndex = 0;
            // 
            // createTimer
            // 
            this.createTimer.Enabled = true;
            this.createTimer.Interval = 3000;
            this.createTimer.Tick += new System.EventHandler(this.createTimer_Tick);
            // 
            // conveyorTimer
            // 
            this.conveyorTimer.Enabled = true;
            this.conveyorTimer.Interval = 10;
            this.conveyorTimer.Tick += new System.EventHandler(this.conveyorTimer_Tick);
            // 
            // BallButon
            // 
            this.BallButon.Location = new System.Drawing.Point(90, 53);
            this.BallButon.Name = "BallButon";
            this.BallButon.Size = new System.Drawing.Size(75, 23);
            this.BallButon.TabIndex = 1;
            this.BallButon.Text = "BALL";
            this.BallButon.UseVisualStyleBackColor = true;
            this.BallButon.Click += new System.EventHandler(this.BallButon_Click);
            // 
            // CarButton
            // 
            this.CarButton.Location = new System.Drawing.Point(212, 53);
            this.CarButton.Name = "CarButton";
            this.CarButton.Size = new System.Drawing.Size(75, 23);
            this.CarButton.TabIndex = 2;
            this.CarButton.Text = "CAR";
            this.CarButton.UseVisualStyleBackColor = true;
            this.CarButton.Click += new System.EventHandler(this.CarButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(460, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Coming next:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(90, 82);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // presentButton
            // 
            this.presentButton.Location = new System.Drawing.Point(322, 53);
            this.presentButton.Name = "presentButton";
            this.presentButton.Size = new System.Drawing.Size(82, 23);
            this.presentButton.TabIndex = 5;
            this.presentButton.Text = "PRESENT";
            this.presentButton.UseVisualStyleBackColor = true;
            this.presentButton.Click += new System.EventHandler(this.presentButton_Click);
            // 
            // boxColor
            // 
            this.boxColor.BackColor = System.Drawing.Color.Red;
            this.boxColor.Location = new System.Drawing.Point(329, 82);
            this.boxColor.Name = "boxColor";
            this.boxColor.Size = new System.Drawing.Size(75, 23);
            this.boxColor.TabIndex = 6;
            this.boxColor.UseVisualStyleBackColor = false;
            this.boxColor.Click += new System.EventHandler(this.button1_Click);
            // 
            // ribbonColor
            // 
            this.ribbonColor.BackColor = System.Drawing.Color.Red;
            this.ribbonColor.Location = new System.Drawing.Point(329, 111);
            this.ribbonColor.Name = "ribbonColor";
            this.ribbonColor.Size = new System.Drawing.Size(75, 23);
            this.ribbonColor.TabIndex = 7;
            this.ribbonColor.UseVisualStyleBackColor = false;
            this.ribbonColor.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.ribbonColor);
            this.Controls.Add(this.boxColor);
            this.Controls.Add(this.presentButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CarButton);
            this.Controls.Add(this.BallButon);
            this.Controls.Add(this.mainPanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Timer createTimer;
        private System.Windows.Forms.Timer conveyorTimer;
        private System.Windows.Forms.Button BallButon;
        private System.Windows.Forms.Button CarButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button presentButton;
        private System.Windows.Forms.Button boxColor;
        private System.Windows.Forms.Button ribbonColor;
    }
}

