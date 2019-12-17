using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

using Microsoft.Speech.Recognition;
using Microsoft.Speech.Synthesis;
using Media;
using System.IO;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Net;
using System.Xml;
using System.Xml.Serialization;

namespace SpeechAI
{
    public partial class SpeechAI : Form
    {
        int intSEQ = -1;
        string strMediaDir = @"D:\학습공간\영어공부\생 텍쥐페리 - 어린 왕자(The Little Prince) - eBook포함";
        List<string> MediaFiles = new List<string>();
        Media.MP3Player mplayer;
        PhotoMain frmPhotoMain;

        SpeechRecognitionEngine sre;
        SpeechSynthesizer speaker;
        GrammarBuilder grammarBuilder = new GrammarBuilder();
        string strVoiceName = "Microsoft Server Speech Text to Speech Voice (ko-KR, Heami)";

        public SpeechAI()
        {
            InitializeComponent();

            initRS();
            initTTS(strVoiceName);
            initMedia();
        }

        private void SpeechAI_Load(object sender, EventArgs e)
        {
            CommandHistory.Text = "";
        }

        public void initRS()
        {
            try
            {
                CommandHistory.Text += "SpeechRecognition Engine Loading....\r\n";
                sre = new SpeechRecognitionEngine(new CultureInfo("ko-KR"));

                CommandHistory.Text += "SpeechRecognition Grammar Loading....OK!\r\n";
                //grammarBuilder.Append(new Choices("one", "two", "three"));
                //Grammar customGrammar = new Grammar(grammarBuilder);

                Grammar customGrammar = new Grammar("speechBox.xml");
                //sre.UnloadAllGrammars();
                sre.LoadGrammar(customGrammar);

                //speaker.SelectVoice("Microsoft David Desktop");
                //grammarBuilder.AppendDictation();
                //Grammar customGrammar = new Grammar(grammarBuilder);
                //sre = new SpeechRecognitionEngine();
                //sre.LoadGrammar(customGrammar);

                System.Threading.Thread t1 = new System.Threading.Thread(delegate()
                {
                    //set our recognition engine to use the default audio device
                    sre.SetInputToDefaultAudioDevice();
                    sre.RecognizeAsync(RecognizeMode.Multiple);
                });
                t1.Start();

                sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
                CommandHistory.Text += "SpeechRecognition Starting....OK!\r\n";
            }
            catch (Exception e)
            {
                CommandHistory.Text += "init RS Error : " + e.ToString() + "\r\n";
            }
        }

        public void initTTS(string strVoiceName)
        {
            try
            {
                speaker = new SpeechSynthesizer();
                speaker.SelectVoice(strVoiceName);
                speaker.SetOutputToDefaultAudioDevice();
                speaker.Volume = 100;
                CommandHistory.Text += "SpeechSynthesizer Starting....OK!\r\n";
            }
            catch (Exception e)
            {
                CommandHistory.Text += "init TTS Error : " + e.ToString() + "\r\n";
            }
        }

        public void initMedia()
        {
            try
            {
                mplayer = new Media.MP3Player();
                pnlMediaControlPanel.Visible = false;
                this.Height -= pnlMediaControlPanel.Height;
                CommandHistory.Text += "SpeechSynthesizer Starting....OK!\r\n";
            }
            catch (Exception e)
            {
                CommandHistory.Text += "init Media Error : " + e.ToString() + "\r\n";
            }
        }

        public void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            /*
             if (e.Result != null)
             {
                List<MediaObject> m_RecognizedObjects = new List<MediaObject>();                

                // Get the parent's components collection
                ReadOnlyCollection<RecognizedWordUnit> words = e.Result.Words;

                #region Test to get private variable via reflection
                for (int i = 0; i < words.Count; i++)
                {
                    MediaObject obj = new MediaObject(i);
                    if (i == 0)
                    {
                        obj.TStartTimeTS = (TimeSpan)e.Result.Audio.AudioPosition;
                        obj.TSentence = e.Result.Text;
                    }

                    // Get private audioPosition
                    Type parentType = ((RecognizedWordUnit)words[i]).GetType();
                    System.Reflection.FieldInfo fieldInfo = parentType.GetField("_audioPosition", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

                    TimeSpan audioPosition = (TimeSpan)fieldInfo.GetValue(words[i]);

                    // Get private audioDuration
                    fieldInfo = parentType.GetField("_audioDuration", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

                    TimeSpan audioDuration = (TimeSpan)fieldInfo.GetValue(words[i]);
                    obj.SetMediaObject_Trasnscript(audioPosition, audioDuration, words[i].Text);

                    m_RecognizedObjects.Add(obj);
                }
                #endregion
                m_RecognizedWordsList.Add(m_RecognizedObjects);
            }
            */
            string commandName = e.Result.Text;
            txtCommand.Text = commandName;

            switch (commandName.ToLower())
            {
                case "밍밍":
                    {
                        speaker.SpeakAsync("네 밍밍입니다");
                        break;
                    }
                case "안녕":
                    {
                        speaker.SpeakAsync("안녕하세요. 밍밍입니다");
                        //string query = "How can I get a word not defined in Grammar recognised and passed into here!";
                        //launchGoogle(query);
                        break;
                    }
                case "종료":
                    {
                        speaker.Speak("프로그램을 종료합니다");
                        Application.Exit();
                        break;
                    }
                case "계산기":
                    {
                        speaker.SpeakAsync("계산기를 실행합니다");
                        doProgram(@"C:\Windows\System32\calc.exe", "");
                        break;
                    }
                case "메모장":
                    {
                        speaker.SpeakAsync("메모장을 실행합니다");
                        doProgram(@"C:\Windows\System32\notepad.exe", "");
                        break;
                    }
                case "콘솔":
                    {
                        speaker.SpeakAsync("콘솔을 실행합니다");
                        doProgram(@"C:\Windows\System32\cmd.exe", "");
                        break;
                    }
                case "그림판":
                    {
                        speaker.SpeakAsync("그림판을 실행합니다");
                        doProgram(@"C:\Windows\System32\mspaint.exe", "");
                        break;
                    }
                case "계산기 닫기":
                    {
                        speaker.SpeakAsync("계산기를 종료합니다");
                        closeProcess("calc");
                        break;
                    }
                case "이미지분석":
                    {
                        speaker.SpeakAsync("이미지분석을 실행합니다");
                        frmPhotoMain = new PhotoMain();
                        frmPhotoMain.Show();
                        break;
                    }
                case "이미지분석종료":
                    {
                        speaker.SpeakAsync("이미지분석를 종료합니다");
                        frmPhotoMain.Dispose();
                        frmPhotoMain.Close();
                        break;
                    }
                case "음악":
                    {
                        //if(mplayer == null) initMedia();

                        if (!mplayer.IsPlaying)
                        {
                            MediaFiles.Clear();
                            //string IsSuccess = "";
                            DirectoryInfo dir = new DirectoryInfo(strMediaDir);
                            CommandHistory.Text += "\r\n";
                            CommandHistory.Text += "Directory : " + strMediaDir;
                            foreach (FileInfo file in dir.GetFiles())
                            {
                                //TODO: 엑셀 파일 읽기및 디비 업로드 작업 코드 작성
                                string strFilePrefix = file.Name.Trim().Substring(file.Name.Trim().Length - 3, 3);
                                if (file.Name != "")
                                {
                                    if (strFilePrefix.Trim().Equals("mp3"))
                                    {
                                        MediaFiles.Add(file.Name.Trim());
                                    }
                                }
                            }

                            if (MediaFiles.Count > 0)
                            {
                                speaker.SpeakAsync("음악큐합니다.");
                                pnlMediaControlPanel.Visible = true;
                                this.Height += pnlMediaControlPanel.Height + 5;
                                timer1.Enabled = true;
                            }
                            else
                            {
                                if (pnlMediaControlPanel.Visible)
                                {
                                    pnlMediaControlPanel.Visible = false;
                                    this.Height -= pnlMediaControlPanel.Height + 5;
                                }
                                execMediaPlay(false);
                            }
                        }

                        break;
                    }
                case "음악종료":
                    {
                        speaker.SpeakAsync("음악을 종료합니다");
                        if (pnlMediaControlPanel.Visible)
                        {
                            pnlMediaControlPanel.Visible = false;
                            this.Height -= pnlMediaControlPanel.Height + 5;
                        }
                        execMediaPlay(false);
                        break;
                    }
                case "지금몇시야":
                    {
                        CommandHistory.Text += "\r\n" + DateTime.Now.ToLocalTime().ToShortTimeString();
                        speaker.SpeakAsync(DateTime.Now.ToLocalTime().ToShortTimeString());
                        break;
                    }
                case "오늘날짜":
                    {
                        CommandHistory.Text += "\r\n" + DateTime.Today.ToShortDateString();
                        speaker.SpeakAsync(DateTime.Today.ToShortDateString());
                        break;
                    }
                case "날씨":
                    {
                        speaker.SpeakAsync("오늘날씨를 알려드리겠습니다");
                        getWeather("http://www.kma.go.kr/weather/forecast/mid-term-rss3.jsp?stnId=108");
                        break;
                    }
                default:
                    {
                        //handle non-normalized recognition
                        Match m = Regex.Match(commandName, "YOUR_PATTERN_HERE");

                        if (m.Success)
                        {
                            speaker.SpeakAsync("I found a match");

                            //example, probably should URL encode the value...
                            //Process.Start("http://www.google.com?q=" + m.Value);
                        }

                        break;
                    }
            }
        }

        //MediaPlay
        private void execMediaPlay(bool boolPlayAndStop)
        {
            if (boolPlayAndStop)
            {
                int iAuduoLen = (int)(mplayer.AudioLength / 1000);
                int iCurrentPosition = (int)(mplayer.CurrentPosition / 1000);

                trackBar1.Value = iCurrentPosition;

                this.lblTrackCount.Text = "[iCurrentPosition/iAuduoLen = " + iCurrentPosition.ToString() + " / " + iAuduoLen.ToString() + "]";

                if (iAuduoLen == iCurrentPosition && mplayer.IsPlaying)
                {
                    mplayer.Stop();
                    trackBar1.Value = 0;
                }
                else
                {
                    if (!mplayer.IsPlaying)
                    {
                        if (MediaFiles.Count > 0)
                        {
                            intSEQ = intSEQ + 1;
                            string filename = MediaFiles[intSEQ];

                            if (mplayer.Open(strMediaDir + @"\" + filename.Trim()))
                            {
                                CommandHistory.Text += "\r\n";
                                CommandHistory.Text += (intSEQ + 1).ToString() + "번째 File Playing.... " + filename.Trim();
                                this.lblMediaFileName.Text = filename;
                                trackBar1.Maximum = (int)(mplayer.AudioLength / 1000);
                                mplayer.Play();
                            }
                        }
                    }
                }
            }
            else
            {
                timer1.Enabled = false;
                mplayer.Stop();
                MediaFiles.Clear();
            }
        }//end execMediaPlay()

        private void timer1_Tick(object sender, EventArgs e)
        {
            execMediaPlay(true);
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            mplayer.Seek((ulong)(trackBar1.Value * 1000));
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "mp3 files|*.mp3";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                lblMediaFileName.Text += fd.FileName;
                mplayer.Open(fd.FileName);
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            mplayer.Play();
            timer1.Enabled = true;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            mplayer.Pause();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            mplayer.Stop();
            timer1.Enabled = false;
        }
        
        // 프로세스 실행
        private static void doProgram(string filename, string arg)
        {
            ProcessStartInfo psi;
            if (arg.Length != 0)
                psi = new ProcessStartInfo(filename, arg);
            else
                psi = new ProcessStartInfo(filename);
            Process.Start(psi);
        }

        // 프로세스 종료
        private static void closeProcess(string filename)
        {
            Process[] myProcesses;
            // Returns array containing all instances of Notepad.
            myProcesses = Process.GetProcesses();// .GetProcessesByName(filename);
            foreach (Process myProcess in myProcesses)
            {
                if (myProcess.ProcessName.Trim() == filename)
                {
                    myProcess.Kill();
                }
                //myProcess.CloseMainWindow();
            }
        }

        private void launchGoogle(string term)
        {
            Process.Start("IEXPLORE", "google.com?q=" + term);
        }

        private void getWeather(string strURL)
        {
            GetRSS(strURL);
        }

        private void GetRSS(string strURL)
        {
            WebClient wc = new WebClient();
            wc.Encoding = System.Text.UTF8Encoding.UTF8;
            String buffer = wc.DownloadString(strURL);
            wc.Dispose();

            StringReader sr = new StringReader(buffer);
            XmlDocument doc = new XmlDocument();
            doc.Load(sr);
            sr.Close();
            //XmlNodeList forecastNodes = doc.SelectNodes("xml_api_reply/news/news_entry");

            XmlNodeList forecastNodes = doc.SelectNodes("rss/channel/item");
            foreach (XmlNode node in forecastNodes)
            {
                String data = node["title"].InnerText;
                String pubDate = node.ParentNode.ChildNodes[5].InnerText;

                CommandHistory.Text += data + "\r\n";
                CommandHistory.Text += pubDate + "\r\n";

                speaker.Speak(pubDate);
            }
            
            XmlNodeList forecastNodes1 = doc.SelectNodes("rss/channel/item/description/header");
            foreach (XmlNode node in forecastNodes1)
            {
                String wf = node["wf"].InnerText;
                string[] strwfList = wf.Replace("<br />", "!").Split('!');
                for (int iIdx = 0; iIdx < strwfList.Length; iIdx++)
                {
                    CommandHistory.Text += strwfList[iIdx].ToString() + "\r\n";

                    speaker.Speak(strwfList[iIdx].ToString());
                }
            }
            //timerNews.Enabled = true;
        }

    }
}
