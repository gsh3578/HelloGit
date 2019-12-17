using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Media;

namespace SpeechAI.MediaPlayer
{
    public partial class MP3Player : Form
    {
        Media.MP3Player mplayer;
        public MP3Player()
        {
            InitializeComponent();
            mplayer = new Media.MP3Player();
            mplayer.OpenFile += new Media.MP3Player.OpenFileEventHandler(mplayer_OpenFile);
            mplayer.PlayFile += new Media.MP3Player.PlayFileEventHandler(mplayer_PlayFile);
            mplayer.StopFile += new Media.MP3Player.StopFileEventHandler(mplayer_StopFile);
            mplayer.PauseFile += new Media.MP3Player.PauseFileEventHandler(mplayer_PauseFile);
        }

        void mplayer_OpenFile(Object sender, Media.MP3Player.OpenFileEventArgs e)
        {
            trackBar1.Maximum = (int)(mplayer.AudioLength/1000);
            this.Text = e.FileName;
            trackBar1.Value = 0;
            timer1.Enabled = false;
        }

        void mplayer_StopFile(Object sender, Media.MP3Player.StopFileEventArgs e)
        {
            this.Text = "Stopped";
            timer1.Enabled = false;
            trackBar1.Value = 0;
        }

        void mplayer_PauseFile(Object sender, Media.MP3Player.PauseFileEventArgs e)
        {
            this.Text = "Paused";
            timer1.Enabled = false;
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            mplayer.Seek((ulong)(trackBar1.Value * 1000));
        }

        void mplayer_PlayFile(Object sender, Media.MP3Player.PlayFileEventArgs e)
        {
            trackBar1.Maximum = (int)(mplayer.AudioLength / 1000);
            this.Text = "Playing " + mplayer.FileName;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            trackBar1.Value = (int)(mplayer.CurrentPosition/1000);
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            mplayer.VolumeAll = trackBar3.Value;
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            mplayer.Balance = trackBar2.Value;
        }

        private void trackBar5_ValueChanged(object sender, EventArgs e)
        {
            mplayer.VolumeTreble = trackBar5.Value;
        }

        private void trackBar4_ValueChanged(object sender, EventArgs e)
        {
            mplayer.VolumeBass = trackBar4.Value;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            mplayer.MuteAll = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //mplayer.Looping = checkBox2.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mplayer.Play();
            //bool boolPlay = mplayer.Play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mplayer.Pause();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mplayer.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "mp3 files|*.mp3";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                button1.Text = fd.FileName;
                mplayer.Open(fd.FileName);
            }
        }
    }
}