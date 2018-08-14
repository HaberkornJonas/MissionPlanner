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
        private Label MessageNumberAPM;
        private Label MessageNumberController;
        private Label TimeElapsedSinceAPMStart;
        private List<Label> Parameters;
        private List<Label> Position;
        private int CounterNoNewMessage = 0;
        private int LastMessageNumberAPM = -1;
        private const int SIZE_X_WINDOW = 350; //282
        private const int SIZE_Y_WINDOW = 330; //253
        private const int TABULATION_TITLE = 30;
        private const int TABULATION_DATA = TABULATION_TITLE + 11;

        public ModuleStatusForm()
        {
            InitializeComponent();
            Utilities.ThemeManager.ApplyThemeTo(this);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ModuleStatus modulestatus = HUD.CurentModuleStatus;
            if (modulestatus.MessageNumberAPM == -1)
                return;
            this.SuspendLayout();

            ModuleNumber.Text = ModuleStatus.GetModuleName(modulestatus.ModuleNumber);
            if (Parameters != null)
            {
                foreach (var lab in Parameters)
                {
                    this.Controls.Remove(lab);
                }
            }

            Parameters = new List<Label>();
            int i = 0;
            if (modulestatus.Parameters != null)
            {
                foreach (var parameter in modulestatus.Parameters)
                {
                    Parameters.Add(new Label());
                    Parameters[i].AutoSize = true;
                    Parameters[i].Location = new System.Drawing.Point(TABULATION_DATA, 25 + 25 * (i+1));
                    Parameters[i].Name = ModuleStatus.GetParameterName(modulestatus.ModuleNumber, i);
                    Parameters[i].Size = new Size(66, 17);
                    Parameters[i].TabIndex = 0;
                    Parameters[i].Text = $"{ModuleStatus.GetParameterName(modulestatus.ModuleNumber, i)} : {parameter}";
                    this.Controls.Add(Parameters[i]);
                    i++;
                }
            }
            i++;
            for (int j = 0; j < ModuleStatus.PositionFieldsName.Length; j++)
            {
                Position[j].Location = new System.Drawing.Point(TABULATION_DATA, 25 + 25 * (i + 1));
                Position[j].Text = $"{((modulestatus.ModuleNumber == -1) ? ($"Last {ModuleStatus.PositionFieldsName[j].ToLower()}"): ModuleStatus.PositionFieldsName[j])} : {modulestatus.PositionFieldsValue[j]}";
                i++;
            }
            MessageNumberAPM.Location = new System.Drawing.Point(TABULATION_DATA, 25 + 25 * (i + 1));
            MessageNumberAPM.Text = $"{((modulestatus.MessageNumberAPM == -1) ? "APM - Last message emitted number" : "APM - Message emitted number")} : {modulestatus.MessageNumberAPM}";
            i++;
            MessageNumberController.Location = new System.Drawing.Point(TABULATION_DATA, 25 + 25 * (i + 1));
            MessageNumberController.Text = $"{((modulestatus.MessageNumberController == -1) ? "Module - Last message emitted number" : "Module - Message emitted number")} : {modulestatus.MessageNumberController}";
            i++;
            TimeElapsedSinceAPMStart.Location = new System.Drawing.Point(TABULATION_DATA, 25 + 25 * (i + 1));
            TimeElapsedSinceAPMStart.Text = $"Time elapsed since APM's start : {((int)(modulestatus.MillisecondsSinceAPMStart / 1000 / 60 / 60) % 24).ToString().PadLeft(2, '0')}:{((int)(modulestatus.MillisecondsSinceAPMStart / 1000 / 60) % 60).ToString().PadLeft(2, '0')}:{((int)(modulestatus.MillisecondsSinceAPMStart/1000)%60).ToString().PadLeft(2, '0')}s {(modulestatus.MillisecondsSinceAPMStart % 1000).ToString().PadLeft(3, '0')}ms";

            // restore colours
            Utilities.ThemeManager.ApplyThemeTo(this);
            this.ResumeLayout(false);
            this.PerformLayout();

            if (modulestatus.MessageNumberAPM == LastMessageNumberAPM)
            {
                CounterNoNewMessage++;
                if(CounterNoNewMessage>27) //after 2.7s with no new messages, set error or disconnected but keep position values
                {
                    modulestatus.ModuleNumber = -1;
                    modulestatus.Parameters = null;
                }
            }
            else
            {
                CounterNoNewMessage = 0;
                LastMessageNumberAPM = modulestatus.MessageNumberAPM;
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
            this.ModuleNumber.Location = new System.Drawing.Point(TABULATION_TITLE, 25);
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
            this.ClientSize = new System.Drawing.Size(SIZE_X_WINDOW, SIZE_Y_WINDOW);
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
                Position[i].Location = new System.Drawing.Point(TABULATION_DATA, 25 + 25 * (i + 1));
                Position[i].Name = ModuleStatus.PositionFieldsName[i];
                Position[i].Size = new System.Drawing.Size(66, 17);
                Position[i].TabIndex = 0;
                Position[i].Text = $"{ModuleStatus.PositionFieldsName[i]} : ";
                this.Controls.Add(Position[i]);
            }
            //
            // Message number APM
            //
            MessageNumberAPM = new Label();
            MessageNumberAPM.AutoSize = true;
            MessageNumberAPM.Location = new System.Drawing.Point(TABULATION_DATA, 25 + 25 * (i + 1));
            MessageNumberAPM.Name = "APM - Message number";
            MessageNumberAPM.Size = new System.Drawing.Size(66, 17);
            MessageNumberAPM.TabIndex = 0;
            MessageNumberAPM.Text = "APM - Message emitted number : ";
            this.Controls.Add(MessageNumberAPM);
            i++;
            //
            // Message number Module
            //
            MessageNumberController = new Label();
            MessageNumberController.AutoSize = true;
            MessageNumberController.Location = new System.Drawing.Point(TABULATION_DATA, 25 + 25 * (i + 1));
            MessageNumberController.Name = "Module - Message number Module";
            MessageNumberController.Size = new System.Drawing.Size(66, 17);
            MessageNumberController.TabIndex = 0;
            MessageNumberController.Text = "Module - Message emitted number : ";
            this.Controls.Add(MessageNumberController);
            i++;
            //
            // Milliseconds since APM start
            //
            TimeElapsedSinceAPMStart = new Label();
            TimeElapsedSinceAPMStart.AutoSize = true;
            TimeElapsedSinceAPMStart.Location = new System.Drawing.Point(TABULATION_DATA, 25 + 25 * (i + 1));
            TimeElapsedSinceAPMStart.Name = "Time elapsed since APM's start";
            TimeElapsedSinceAPMStart.Size = new System.Drawing.Size(66, 17);
            TimeElapsedSinceAPMStart.TabIndex = 0;
            TimeElapsedSinceAPMStart.Text = "Time elapsed since APM's start : ";
            this.Controls.Add(TimeElapsedSinceAPMStart);
            i++;
        }
    }
}
