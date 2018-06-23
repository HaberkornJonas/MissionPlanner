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
        private Timer timer1;
        private IContainer components;
        private Label ModuleNumber;
        private Label MessageNumber;
        private List<Label> Param;
        private List<Label> Position;
        private int CounterNoNewMessage = 0;
        private int LastMessageNumber = -1;

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

            ModuleNumber.Text = ModuleStatus.GetModuleName(modulestatus.ModuleNumber);
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
                    Param[i].Location = new System.Drawing.Point(71, 25 + 25 * (i+1));
                    Param[i].Name = ModuleStatus.GetParameterName(modulestatus.ModuleNumber, i);
                    Param[i].Size = new System.Drawing.Size(66, 17);
                    Param[i].TabIndex = 0;
                    Param[i].Text = $"{ModuleStatus.GetParameterName(modulestatus.ModuleNumber, i)} : {param}";
                    this.Controls.Add(Param[i]);
                    i++;
                }
            }
            i++;
            for (int j = 0; j < ModuleStatus.PositionFieldsName.Length; j++)
            {
                Position[j].Location = new System.Drawing.Point(71, 25 + 25 * (i + 1));
                Position[j].Text = $"{((modulestatus.ModuleNumber == -1) ? ($"Last {ModuleStatus.PositionFieldsName[j].ToLower()}"): ModuleStatus.PositionFieldsName[j])} : {modulestatus.PositionFieldsValue[j]}";
                i++;
            }
            MessageNumber.Location = new System.Drawing.Point(71, 25 + 25 * (i + 1));
            MessageNumber.Text = $"Message emitted number :  {modulestatus.MessageNumber}";

            // restore colours
            Utilities.ThemeManager.ApplyThemeTo(this);
            this.ResumeLayout(false);
            this.PerformLayout();

            if (modulestatus.MessageNumber == LastMessageNumber)
            {
                CounterNoNewMessage++;
                if(CounterNoNewMessage>20) //after 2s with no new messages, set error or disconnected but keep position values
                {
                    modulestatus.ModuleNumber = -1;
                    modulestatus.Param = null;
                }
            }
            else
            {
                CounterNoNewMessage = 0;
                LastMessageNumber = modulestatus.MessageNumber;
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModuleStatusForm));
            this.ModuleNumber = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            int i = 0;
            // 
            // ModuleNumber
            // 
            this.ModuleNumber.AutoSize = true;
            this.ModuleNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModuleNumber.Location = new System.Drawing.Point(60, 25);
            this.ModuleNumber.Name = "ModuleNumber";
            this.ModuleNumber.Size = new System.Drawing.Size(87, 20);
            this.ModuleNumber.TabIndex = 0;
            this.ModuleNumber.Text = "Module : ";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 150;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ModuleStatusForm
            // 
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.ModuleNumber);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModuleStatusForm";
            this.Text = "Module status";
            this.ResumeLayout(false);
            this.PerformLayout();
            //
            // Position
            //
            Position = new List<Label>();
            for(; i<ModuleStatus.PositionFieldsName.Length; i++)
            {
                Position.Add(new Label());
                Position[i].AutoSize = true;
                Position[i].Location = new System.Drawing.Point(71, 25 + 25 * (i + 1));
                Position[i].Name = ModuleStatus.PositionFieldsName[i];
                Position[i].Size = new System.Drawing.Size(66, 17);
                Position[i].TabIndex = 0;
                Position[i].Text = $"{ModuleStatus.PositionFieldsName[i]} : ";
                this.Controls.Add(Position[i]);
            }
            //
            // Message number
            //
            MessageNumber = new Label();
            MessageNumber.AutoSize = true;
            MessageNumber.Location = new System.Drawing.Point(71, 25 + 25 * (i + 1));
            MessageNumber.Name = "Message number";
            MessageNumber.Size = new System.Drawing.Size(66, 17);
            MessageNumber.TabIndex = 0;
            MessageNumber.Text = "Message emitted number : ";
            this.Controls.Add(MessageNumber);
            i++;
        }
    }
}
