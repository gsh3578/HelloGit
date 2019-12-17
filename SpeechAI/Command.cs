using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Speech.Recognition;
using Microsoft.Speech.Synthesis;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;

namespace SpeechAI
{
    public class Command
    {
        public Application app;
        public SpeechRecognitionEngine sre;
        public SpeechSynthesizer speaker;
        public GrammarBuilder grammarBuilder;
        public Media.MP3Player mplayer;
        public string strMediaDir;
        public List<string> MediaFiles;

        public void Action(string commandName, string strProgramPath)
        {
            ActionSpeech(commandName);

            switch (commandName.ToLower())
            {
                case "종료":
                    {
                        Application.Exit();
                        break;
                    }
                case "계산기":
                    {
                        doProgram(strProgramPath, "");
                        break;
                    }
                case "메모장":
                    {
                        doProgram(strProgramPath, "");
                        break;
                    }
                case "콘솔":
                    {
                        doProgram(strProgramPath, "");
                        break;
                    }
                case "그림판":
                    {
                        doProgram(strProgramPath, "");
                        break;
                    }
                case "계산기 닫기":
                    {
                        closeProcess(strProgramPath);
                        break;
                    }
                case "이미지분석":
                    {
                        //frmPhotoMain = new PhotoMain();
                        //frmPhotoMain.Show();
                        break;
                    }
                case "이미지분석종료":
                    {
                        //frmPhotoMain.Dispose();
                        //frmPhotoMain.Close();
                        break;
                    }
                case "음악":
                    {
                        if (!mplayer.IsPlaying)
                        {
                            MediaFiles.Clear();
                            DirectoryInfo dir = new DirectoryInfo(strMediaDir);
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
                                //pnlMediaControlPanel.Visible = true;
                                //this.Height += pnlMediaControlPanel.Height + 5;
                                //timer1.Enabled = true;
                            }
                            else
                            {
                                //if (pnlMediaControlPanel.Visible)
                                //{
                                //    pnlMediaControlPanel.Visible = false;
                                //    this.Height -= pnlMediaControlPanel.Height + 5;
                                //}
                                execMediaPlay(false);
                            }
                        }

                        break;
                    }
                case "음악종료":
                    {
                        //if (pnlMediaControlPanel.Visible)
                        //{
                        //    pnlMediaControlPanel.Visible = false;
                        //    this.Height -= pnlMediaControlPanel.Height + 5;
                        //}
                        execMediaPlay(false);
                        break;
                    }
                case "날씨":
                    {
                        getWeather(strProgramPath);
                        break;
                    }
                default:
                    {
                        //handle non-normalized recognition
                        Match m = Regex.Match(commandName, "YOUR_PATTERN_HERE");

                        if (m.Success)
                        {
                            ;// speaker.SpeakAsync("I found a match");

                            //example, probably should URL encode the value...
                            //Process.Start("http://www.google.com?q=" + m.Value);
                        }

                        break;
                    }
            }//end Switch

        }//end Action()

        private void ActionSpeech(string commandName)
        {
            List<string> speechList = new List<string>();
            switch (commandName.ToLower())
            {
                case "밍밍":
                    {
                        speechList.Add("네 밍밍입니다");
                        break;
                    }
                case "안녕":
                    {
                        speechList.Add("안녕하세요. 밍밍입니다");
                        break;
                    }
                case "종료":
                    {
                        speechList.Add("프로그램을 종료합니다");
                        break;
                    }
                case "계산기":
                    {
                        speechList.Add("계산기를 실행합니다");
                        break;
                    }
                case "메모장":
                    {
                        speechList.Add("메모장을 실행합니다");
                        break;
                    }
                case "콘솔":
                    {
                        speechList.Add("콘솔을 실행합니다");
                        break;
                    }
                case "그림판":
                    {
                        speechList.Add("그림판을 실행합니다");
                        break;
                    }
                case "계산기 닫기":
                    {
                        speechList.Add("계산기를 종료합니다");
                        break;
                    }
                case "이미지분석":
                    {
                        speechList.Add("이미지분석을 실행합니다");
                        break;
                    }
                case "이미지분석종료":
                    {
                        speechList.Add("이미지분석를 종료합니다");
                        break;
                    }
                case "음악":
                    {                        
                       speechList.Add("음악큐합니다."); 
                       break;
                    }
                case "음악종료":
                    {
                        speechList.Add("음악을 종료합니다");
                        break;
                    }
                case "지금몇시야":
                    {
                        speechList.Add(DateTime.Now.ToLocalTime().ToShortTimeString());
                        break;
                    }
                case "오늘날짜":
                    {
                        speechList.Add(DateTime.Today.ToShortDateString());
                        break;
                    }
                case "날씨":
                    {
                        speechList.Add("오늘날씨를 알려드리겠습니다");                        
                        break;
                    }
                default:
                    {
                        speechList.Add("I found a match");
                        break;
                    }
            }//end Switch

            for (int i = 0; i < speechList.Count; i++)
            {
                string strSpeech = speechList[i].ToString();
                speaker.SpeakAsync(strSpeech);
            }
        }//end Action()

        #region User Method

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
            myProcesses = Process.GetProcesses();
            foreach (Process myProcess in myProcesses)
            {
                if (myProcess.ProcessName.Trim() == filename)
                {
                    myProcess.Kill();
                }
            }
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

                //CommandHistory.Text += data + "\r\n";
                //CommandHistory.Text += pubDate + "\r\n";

                speaker.Speak(pubDate);
            }

            XmlNodeList forecastNodes1 = doc.SelectNodes("rss/channel/item/description/header");
            foreach (XmlNode node in forecastNodes1)
            {
                String wf = node["wf"].InnerText;
                string[] strwfList = wf.Replace("<br />", "!").Split('!');
                for (int iIdx = 0; iIdx < strwfList.Length; iIdx++)
                {
                    //CommandHistory.Text += strwfList[iIdx].ToString() + "\r\n";

                    speaker.Speak(strwfList[iIdx].ToString());
                }
            }
            //timerNews.Enabled = true;
        }

        //MediaPlay
        private void execMediaPlay(bool boolPlayAndStop)
        {
            /*
            if (boolPlayAndStop)
            {
                int iAuduoLen = (int)(mplayer.AudioLength / 1000);
                int iCurrentPosition = (int)(mplayer.CurrentPosition / 1000);

                //trackBar1.Value = iCurrentPosition;
                //this.lblTrackCount.Text = "[iCurrentPosition/iAuduoLen = " + iCurrentPosition.ToString() + " / " + iAuduoLen.ToString() + "]";

                if (iAuduoLen == iCurrentPosition && mplayer.IsPlaying)
                {
                    mplayer.Stop();
                    //trackBar1.Value = 0;
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
            */
        }//end execMediaPlay()

        #endregion User Method
    }
}
