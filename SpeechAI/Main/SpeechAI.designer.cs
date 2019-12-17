namespace SpeechAI
{
    partial class SpeechAI
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CommandHistory = new System.Windows.Forms.TextBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.lblMediaFileName = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.lblTrackCount = new System.Windows.Forms.Label();
            this.pnlMediaControlPanel = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtCommand = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.pnlMediaControlPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CommandHistory
            // 
            this.CommandHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.CommandHistory.Font = new System.Drawing.Font("굴림", 8F);
            this.CommandHistory.Location = new System.Drawing.Point(3, 24);
            this.CommandHistory.Multiline = true;
            this.CommandHistory.Name = "CommandHistory";
            this.CommandHistory.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.CommandHistory.Size = new System.Drawing.Size(424, 91);
            this.CommandHistory.TabIndex = 2;
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.SystemColors.Control;
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trackBar1.Location = new System.Drawing.Point(0, 62);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(424, 45);
            this.trackBar1.TabIndex = 5;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar1_MouseUp);
            // 
            // lblMediaFileName
            // 
            this.lblMediaFileName.BackColor = System.Drawing.Color.LightGreen;
            this.lblMediaFileName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMediaFileName.Location = new System.Drawing.Point(0, 31);
            this.lblMediaFileName.Name = "lblMediaFileName";
            this.lblMediaFileName.Size = new System.Drawing.Size(424, 31);
            this.lblMediaFileName.TabIndex = 6;
            this.lblMediaFileName.Text = "음원파일명";
            this.lblMediaFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(195, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(90, 21);
            this.btnStop.TabIndex = 9;
            this.btnStop.Text = "■";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(99, 3);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(90, 21);
            this.btnPause.TabIndex = 8;
            this.btnPause.Text = "||";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(3, 3);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(90, 21);
            this.btnPlay.TabIndex = 7;
            this.btnPlay.Text = "▶";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(291, 3);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(127, 21);
            this.btnOpen.TabIndex = 10;
            this.btnOpen.Text = "Choose File...";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // lblTrackCount
            // 
            this.lblTrackCount.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblTrackCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTrackCount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTrackCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTrackCount.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTrackCount.Location = new System.Drawing.Point(0, 107);
            this.lblTrackCount.Name = "lblTrackCount";
            this.lblTrackCount.Size = new System.Drawing.Size(424, 31);
            this.lblTrackCount.TabIndex = 11;
            this.lblTrackCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlMediaControlPanel
            // 
            this.pnlMediaControlPanel.Controls.Add(this.flowLayoutPanel1);
            this.pnlMediaControlPanel.Controls.Add(this.lblMediaFileName);
            this.pnlMediaControlPanel.Controls.Add(this.trackBar1);
            this.pnlMediaControlPanel.Controls.Add(this.lblTrackCount);
            this.pnlMediaControlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMediaControlPanel.Location = new System.Drawing.Point(3, 115);
            this.pnlMediaControlPanel.Name = "pnlMediaControlPanel";
            this.pnlMediaControlPanel.Size = new System.Drawing.Size(424, 138);
            this.pnlMediaControlPanel.TabIndex = 12;
            this.pnlMediaControlPanel.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Info;
            this.flowLayoutPanel1.Controls.Add(this.btnPlay);
            this.flowLayoutPanel1.Controls.Add(this.btnPause);
            this.flowLayoutPanel1.Controls.Add(this.btnStop);
            this.flowLayoutPanel1.Controls.Add(this.btnOpen);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(424, 32);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // txtCommand
            // 
            this.txtCommand.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtCommand.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCommand.Location = new System.Drawing.Point(3, 3);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.ReadOnly = true;
            this.txtCommand.Size = new System.Drawing.Size(424, 21);
            this.txtCommand.TabIndex = 1;
            // 
            // SpeechAI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 257);
            this.Controls.Add(this.pnlMediaControlPanel);
            this.Controls.Add(this.CommandHistory);
            this.Controls.Add(this.txtCommand);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SpeechAI";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "AI MingMing";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.SpeechAI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.pnlMediaControlPanel.ResumeLayout(false);
            this.pnlMediaControlPanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CommandHistory;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lblMediaFileName;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label lblTrackCount;
        private System.Windows.Forms.Panel pnlMediaControlPanel;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

