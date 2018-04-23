using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MissionPlanner.Controls
{
    //added for the Thesis
    public class ModuleStatus : Form
    {
        public ModuleStatus()
        {
            InitializeComponent();

            Utilities.ThemeManager.ApplyThemeTo(this);

            timer1.Start();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*ekfvel.Value = (int) (MainV2.comPort.MAV.cs.ekfvelv*100);
            ekfposh.Value = (int) (MainV2.comPort.MAV.cs.ekfposhor*100);
            ekfposv.Value = (int) (MainV2.comPort.MAV.cs.ekfposvert*100);
            ekfcompass.Value = (int) (MainV2.comPort.MAV.cs.ekfcompv*100);
            ekfterrain.Value = (int) (MainV2.comPort.MAV.cs.ekfteralt*100);

            // restore colours
            Utilities.ThemeManager.ApplyThemeTo(this);

            foreach (var item in new VerticalProgressBar2[] {ekfvel, ekfposh, ekfposv, ekfcompass, ekfterrain})
            {
                if (item.Value > 50)
                    item.ValueColor = Color.Orange;

                if (item.Value > 80)
                    item.ValueColor = Color.Red;
            }

            label7.Text = "";

            for (int a = 1; a <= (int) MAVLink.EKF_STATUS_FLAGS.EKF_PRED_POS_HORIZ_ABS; a = a << 1)
            {
                int currentbit = (MainV2.comPort.MAV.cs.ekfflags & a);

                var currentflag = (MAVLink.EKF_STATUS_FLAGS) Enum.Parse(typeof (MAVLink.EKF_STATUS_FLAGS), a.ToString());

                label7.Text += currentflag.ToString().Replace("EKF_", "").ToLower() + " " +
                               (currentbit > 0 ? "On " : "Off") + "\r\n";
            }*/
        }





        #region Design region

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
            this.ekfvel = new MissionPlanner.Controls.VerticalProgressBar2();
            this.ekfposv = new MissionPlanner.Controls.VerticalProgressBar2();
            this.ekfposh = new MissionPlanner.Controls.VerticalProgressBar2();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ekfcompass = new MissionPlanner.Controls.VerticalProgressBar2();
            this.ekfterrain = new MissionPlanner.Controls.VerticalProgressBar2();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ekfvel
            // 
            this.ekfvel.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(255)))));
            this.ekfvel.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.ekfvel.DisplayScale = 0.01F;
            this.ekfvel.DrawLabel = false;
            this.ekfvel.Label = null;
            this.ekfvel.Location = new System.Drawing.Point(23, 23);
            this.ekfvel.Maximum = 100;
            this.ekfvel.maxline = 80;
            this.ekfvel.Minimum = 0;
            this.ekfvel.minline = 50;
            this.ekfvel.Name = "ekfvel";
            this.tableLayoutPanel1.SetRowSpan(this.ekfvel, 4);
            this.ekfvel.Size = new System.Drawing.Size(14, 23);
            this.ekfvel.TabIndex = 2;
            this.ekfvel.Value = 10;
            this.ekfvel.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            // 
            // ekfposv
            // 
            this.ekfposv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(255)))));
            this.ekfposv.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.ekfposv.DisplayScale = 0.01F;
            this.ekfposv.DrawLabel = false;
            this.ekfposv.Label = null;
            this.ekfposv.Location = new System.Drawing.Point(63, 23);
            this.ekfposv.Maximum = 100;
            this.ekfposv.maxline = 80;
            this.ekfposv.Minimum = 0;
            this.ekfposv.minline = 50;
            this.ekfposv.Name = "ekfposv";
            this.tableLayoutPanel1.SetRowSpan(this.ekfposv, 4);
            this.ekfposv.Size = new System.Drawing.Size(14, 23);
            this.ekfposv.TabIndex = 0;
            this.ekfposv.Value = 10;
            this.ekfposv.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            // 
            // ekfposh
            // 
            this.ekfposh.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(255)))));
            this.ekfposh.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.ekfposh.DisplayScale = 0.01F;
            this.ekfposh.DrawLabel = false;
            this.ekfposh.Label = null;
            this.ekfposh.Location = new System.Drawing.Point(43, 23);
            this.ekfposh.Maximum = 100;
            this.ekfposh.maxline = 80;
            this.ekfposh.Minimum = 0;
            this.ekfposh.minline = 50;
            this.ekfposh.Name = "ekfposh";
            this.tableLayoutPanel1.SetRowSpan(this.ekfposh, 4);
            this.ekfposh.Size = new System.Drawing.Size(14, 23);
            this.ekfposh.TabIndex = 1;
            this.ekfposh.Value = 10;
            this.ekfposh.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.ekfposh, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.ekfvel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.ekfcompass, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.ekfterrain, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.label5, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.label6, 5, 5);
            this.tableLayoutPanel1.Controls.Add(this.label7, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.ekfposv, 3, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 50);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(278, 147);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // label1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 5);
            this.label1.Location = new System.Drawing.Point(23, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 3;
            //this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label8
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.label8, 2);
            this.label8.Location = new System.Drawing.Point(123, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 20);
            this.label8.TabIndex = 4;
            // 
            // ekfcompass
            // 
            this.ekfcompass.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(255)))));
            this.ekfcompass.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.ekfcompass.DisplayScale = 0.01F;
            this.ekfcompass.DrawLabel = false;
            this.ekfcompass.Label = null;
            this.ekfcompass.Location = new System.Drawing.Point(83, 23);
            this.ekfcompass.Maximum = 100;
            this.ekfcompass.maxline = 80;
            this.ekfcompass.Minimum = 0;
            this.ekfcompass.minline = 50;
            this.ekfcompass.Name = "ekfcompass";
            this.tableLayoutPanel1.SetRowSpan(this.ekfcompass, 4);
            this.ekfcompass.Size = new System.Drawing.Size(14, 23);
            this.ekfcompass.TabIndex = 5;
            this.ekfcompass.Value = 10;
            this.ekfcompass.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            // 
            // ekfterrain
            // 
            this.ekfterrain.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(255)))));
            this.ekfterrain.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.ekfterrain.DisplayScale = 0.01F;
            this.ekfterrain.DrawLabel = false;
            this.ekfterrain.Label = null;
            this.ekfterrain.Location = new System.Drawing.Point(103, 23);
            this.ekfterrain.Maximum = 100;
            this.ekfterrain.maxline = 80;
            this.ekfterrain.Minimum = 0;
            this.ekfterrain.minline = 50;
            this.ekfterrain.Name = "ekfterrain";
            this.tableLayoutPanel1.SetRowSpan(this.ekfterrain, 4);
            this.ekfterrain.Size = new System.Drawing.Size(14, 23);
            this.ekfterrain.TabIndex = 6;
            this.ekfterrain.Value = 10;
            this.ekfterrain.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(23, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 20);
            this.label2.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(43, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 20);
            this.label3.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(63, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 20);
            this.label4.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(83, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 20);
            this.label5.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(103, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 20);
            this.label6.TabIndex = 11;
            // 
            // label7
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.label7, 2);
            this.label7.Location = new System.Drawing.Point(123, 40);
            this.label7.Name = "label7";
            this.tableLayoutPanel1.SetRowSpan(this.label7, 3);
            this.label7.Size = new System.Drawing.Size(74, 23);
            this.label7.TabIndex = 12;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ModuleStatus
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ModuleStatus";
            this.ShowIcon = false;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private VerticalProgressBar2 ekfvel;
        private VerticalProgressBar2 ekfposv;
        private VerticalProgressBar2 ekfposh;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer timer1;
        private VerticalProgressBar2 ekfcompass;
        private VerticalProgressBar2 ekfterrain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;

        #endregion


    }
}