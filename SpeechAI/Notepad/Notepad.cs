using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace SpeechAI.MediaPlayer
{
    public partial class Notepad : Form
    {
        public Notepad()
        {
            InitializeComponent();
        }

        private void ToolStripMenu_Open_Click(object sender, EventArgs e)
        {
            // 파일 열기 다이얼로그 생성 
            OpenFileDialog fdOpen = new OpenFileDialog();
            fdOpen.Filter = "Text Files|*.txt";
            fdOpen.Title = "Select a Text File";

            if (fdOpen.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = null;

                string[] filelines = File.ReadAllLines(fdOpen.FileName);
                foreach (string s in filelines)
                {
                    richTextBox1.Text += s + Environment.NewLine;
                }

                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                //richTextBox1.Focus();
            }
        }

        private void ToolStripMenu_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog fdSave = new SaveFileDialog();
            fdSave.FileName = "notepad1.txt";
            fdSave.Filter = "Text File | *.txt";

            if (fdSave.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(fdSave.OpenFile());

                writer.Write(richTextBox1.Text);

                writer.Dispose();
                writer.Close();
            }
        }

        private void ToolStripMenu_Font_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowColor = true;

            fontDialog.Font = richTextBox1.Font;
            fontDialog.Color = richTextBox1.ForeColor;

            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                //richTextBox1.ForeColor = fontDialog.Color;
                //richTextBox1.Font = fontDialog.Font;

                richTextBox1.SelectionColor = fontDialog.Color;
                richTextBox1.SelectionFont = fontDialog.Font;
            }
        }

        private void ToolStripMenu_Print_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            string text = richTextBox1.Text;
            Font font = richTextBox1.Font;
            Brush brush = new SolidBrush(richTextBox1.ForeColor);

            e.Graphics.DrawString(text, font, brush, e.MarginBounds.Left, e.MarginBounds.Top);
        }

        private void ToolStripMenu_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
