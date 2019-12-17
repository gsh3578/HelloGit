namespace SpeechAI.MediaPlayer
{
    partial class Notepad
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenu_File = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenu_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenu_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenu_Print = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenu_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenu_Style = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenu_Font = new System.Windows.Forms.ToolStripMenuItem();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(776, 522);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 522);
            this.panel1.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenu_File,
            this.ToolStripMenu_Style});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(94, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenu_File
            // 
            this.ToolStripMenu_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenu_Open,
            this.ToolStripMenu_Save,
            this.ToolStripMenu_Print,
            this.ToolStripMenu_Exit});
            this.ToolStripMenu_File.Name = "ToolStripMenu_File";
            this.ToolStripMenu_File.Size = new System.Drawing.Size(43, 20);
            this.ToolStripMenu_File.Text = "파일";
            // 
            // ToolStripMenu_Open
            // 
            this.ToolStripMenu_Open.Name = "ToolStripMenu_Open";
            this.ToolStripMenu_Open.Size = new System.Drawing.Size(98, 22);
            this.ToolStripMenu_Open.Text = "열기";
            this.ToolStripMenu_Open.Click += new System.EventHandler(this.ToolStripMenu_Open_Click);
            // 
            // ToolStripMenu_Save
            // 
            this.ToolStripMenu_Save.Name = "ToolStripMenu_Save";
            this.ToolStripMenu_Save.Size = new System.Drawing.Size(98, 22);
            this.ToolStripMenu_Save.Text = "저장";
            this.ToolStripMenu_Save.Click += new System.EventHandler(this.ToolStripMenu_Save_Click);
            // 
            // ToolStripMenu_Print
            // 
            this.ToolStripMenu_Print.Name = "ToolStripMenu_Print";
            this.ToolStripMenu_Print.Size = new System.Drawing.Size(98, 22);
            this.ToolStripMenu_Print.Text = "출력";
            this.ToolStripMenu_Print.Click += new System.EventHandler(this.ToolStripMenu_Print_Click);
            // 
            // ToolStripMenu_Exit
            // 
            this.ToolStripMenu_Exit.Name = "ToolStripMenu_Exit";
            this.ToolStripMenu_Exit.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenu_Exit.Text = "종료";
            this.ToolStripMenu_Exit.Click += new System.EventHandler(this.ToolStripMenu_Exit_Click);
            // 
            // ToolStripMenu_Style
            // 
            this.ToolStripMenu_Style.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenu_Font});
            this.ToolStripMenu_Style.Name = "ToolStripMenu_Style";
            this.ToolStripMenu_Style.Size = new System.Drawing.Size(43, 20);
            this.ToolStripMenu_Style.Text = "서식";
            // 
            // ToolStripMenu_Font
            // 
            this.ToolStripMenu_Font.Name = "ToolStripMenu_Font";
            this.ToolStripMenu_Font.Size = new System.Drawing.Size(98, 22);
            this.ToolStripMenu_Font.Text = "글꼴";
            this.ToolStripMenu_Font.Click += new System.EventHandler(this.ToolStripMenu_Font_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 549);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "메모장";
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenu_File;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenu_Open;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenu_Save;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenu_Style;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenu_Font;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenu_Print;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenu_Exit;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}

