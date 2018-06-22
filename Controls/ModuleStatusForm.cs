using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionPlanner.Controls
{
    public partial class ModuleStatusForm: Form
    {
        private int NumberParam = 3;
        private Timer timer1;
        private IContainer components;
        private Label ModuleNumber;
        private List<Label> Param;

        public ModuleStatusForm()
        {
            InitializeComponent();
            Utilities.ThemeManager.ApplyThemeTo(this);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.SuspendLayout();
            ModuleStatus modulestatus = HUD.CurentModuleStatus;

            ModuleNumber.Text = "Module : " + modulestatus.ModuleNumber;
            if (Param != null)
            {
                foreach (var lab in Param)
                {
                    this.Controls.Remove(lab);
                }
            }

            Param = new List<Label>();
            int i = 0;
            if (modulestatus.Param != null)
            {
                foreach (var param in modulestatus.Param)
                {
                    Param.Add(new Label());
                    Param[i].AutoSize = true;
                    Param[i].Location = new System.Drawing.Point(71, 25 + 25 * (i + 1));
                    Param[i].Name = $"Param {i + 1}";
                    Param[i].Size = new System.Drawing.Size(66, 17);
                    Param[i].TabIndex = 0;
                    Param[i].Text = $"Param {i + 1} : {param}";
                    this.Controls.Add(Param[i]);

                    i++;
                }
            }

            // restore colours
            Utilities.ThemeManager.ApplyThemeTo(this);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ModuleNumber = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ModuleNumber
            // 
            this.ModuleNumber.AutoSize = true;
            this.ModuleNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModuleNumber.Location = new System.Drawing.Point(71, 25);
            this.ModuleNumber.Name = "ModuleNumber";
            this.ModuleNumber.Size = new System.Drawing.Size(87, 20);
            this.ModuleNumber.TabIndex = 0;
            this.ModuleNumber.Text = "Module : ";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ModuleStatusForm
            // 
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.ModuleNumber);
            this.Name = "ModuleStatusForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
