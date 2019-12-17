using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Speech.Recognition;
using Microsoft.Speech.Synthesis;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Serialization;

namespace SpeechAI
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine rec = new SpeechRecognitionEngine();
        SpeechSynthesizer dummy = new SpeechSynthesizer();


        public Form1()
        {
            InitializeComponent();

            /*
            Choices searching = new Choices("Porsche");
            GrammarBuilder searchService = new GrammarBuilder("Search");

            searchService.Append(searching);


            // Create a Grammar object from the GrammarBuilder and load it to the  recognizer.
            Grammar googleGrammar = new Grammar(searchService); ;
            rec.RequestRecognizerUpdate();
            rec.LoadGrammar(googleGrammar);

            // Add a handler for the speech recognized event.
            rec.SpeechRecognized +=
              new EventHandler<SpeechRecognizedEventArgs>(_recognizer_SpeechRecognized);

            // Configure the input to the speech recognizer.
            rec.SetInputToDefaultAudioDevice();

            // Start asynchronous, continuous speech recognition.
            rec.RecognizeAsync(RecognizeMode.Multiple);
             * */
        }



        //참조 : https://github.com/gillesdemey/google-speech-v2
        private void _recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

            try
            {
                FileStream FS_Audiofile = new FileStream("temp.flac", FileMode.Open, FileAccess.Read);
                BinaryReader BR_Audiofile = new BinaryReader(FS_Audiofile);
                byte[] BA_AudioFile = BR_Audiofile.ReadBytes((Int32)FS_Audiofile.Length);
                FS_Audiofile.Close();
                BR_Audiofile.Close();


                //recognizedAudio.WriteToAudioStream(FS_Audiofile);

                HttpWebRequest _HWR_SpeechToText = null;

                _HWR_SpeechToText = (HttpWebRequest)WebRequest.Create("http://www.google.com/speech-api/v1/recognize?xjerr=1&client=chromium&lang=de-DE&maxresults=1&pfilter=0");

                _HWR_SpeechToText.Method = "POST";
                _HWR_SpeechToText.ContentType = "audio/x-flac; rate=44100";
                _HWR_SpeechToText.ContentLength = BA_AudioFile.Length;
                _HWR_SpeechToText.GetRequestStream().Write(BA_AudioFile, 0, BA_AudioFile.Length);

                HttpWebResponse HWR_Response = (HttpWebResponse)_HWR_SpeechToText.GetResponse();
                if (HWR_Response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader SR_Response = new StreamReader(HWR_Response.GetResponseStream());
                    textBox1.Text = SR_Response.ToString();

                }

            }
            catch (Exception ex)
            {

            }
        }

        public static String gvoice(string key)
        {
            //set the input file name
            FileStream fileStream = File.OpenRead(@"test1.flac");
            MemoryStream memoryStream = new MemoryStream();
            memoryStream.SetLength(fileStream.Length);
            fileStream.Read(memoryStream.GetBuffer(), 0, (int)fileStream.Length);
            byte[] BA_AudioFile = memoryStream.GetBuffer();
            HttpWebRequest _HWR_SpeechToText = null;

            //this points to the google speech API (key goes at end after &key=)
            _HWR_SpeechToText =
            (HttpWebRequest)HttpWebRequest.Create(
            "https://www.google.com/speech-api/v2/recognize?output=json&lang=en-us&key=" + key);

            _HWR_SpeechToText.Credentials = CredentialCache.DefaultCredentials;
            _HWR_SpeechToText.Method = "POST";
            //sets kMhz and file type (flac)
            _HWR_SpeechToText.ContentType = "audio/x-flac; rate=44100";
            _HWR_SpeechToText.ContentLength = BA_AudioFile.Length;
            Stream stream = _HWR_SpeechToText.GetRequestStream();
            stream.Write(BA_AudioFile, 0, BA_AudioFile.Length);
            stream.Close();
            HttpWebResponse HWR_Response = (HttpWebResponse)_HWR_SpeechToText.GetResponse();
            if (HWR_Response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader SR_Response = new StreamReader(HWR_Response.GetResponseStream());
                string result = SR_Response.ReadToEnd();
                return result;
            }
            else
            {
                return "error";
            }
        }

        private void getWeather(string strURL)
        {
            /*
             try
            {
                //WebRequest request = WebRequest.Create("http://google.co.kr");
                WebRequest request = WebRequest.Create("http://" + strURL);
                request.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                
                //Console.WriteLine(response.StatusDescription);
                //Console.WriteLine("Charset = " + response.CharacterSet);
                ////Console.WriteLine("content type = " + response.ContentType);
                ////Console.WriteLine("content encoding = " + response.ContentEncoding);
                ////Console.WriteLine("content length = " + response.ContentLength);
                //Console.WriteLine("headers = " + response.Headers);
                //return;

                Encoding encode;
                if (response.CharacterSet.ToLower() == "utf-8") { encode = Encoding.UTF8; }
                else { encode = Encoding.Default; }
                Stream dataStream = response.GetResponseStream();
                //StreamReader reader = new StreamReader(dataStream);
                //StreamReader reader = new StreamReader(dataStream, Encoding.Default);
                StreamReader reader = new StreamReader(dataStream, encode);
                string responseFromServer = reader.ReadToEnd();
                CommandHistory.Text += "\r\n" +responseFromServer;

                reader.Close();
                dataStream.Close();
                response.Close();
            }
            catch (WebException e)
            {
                CommandHistory.Text += "\r\n" +"주소값이 유효하지 않거나 열리지 않는 사이트입니다.";
                CommandHistory.Text += "\r\n" +e.Message;
            }
            */

            XmlReader __rss = new XmlTextReader(strURL);
            //DataSet ds = new DataSet();
            //ds.ReadXml(__rss);

            XmlSerializer s = new XmlSerializer(typeof(RSS));

            using (Stream input = new MemoryStream())
            using (StreamWriter writer = new StreamWriter(input, Encoding.UTF8))
            {
                writer.Write(__rss.ToString());
                writer.Flush();

                if (0 < input.Position)
                {
                    input.Position = 0;
                }

                RSS rss = s.Deserialize(input) as RSS;

                Console.WriteLine(rss.Version);

                Console.WriteLine(rss.Channels[0].Title);
                Console.WriteLine(rss.Channels[0].Link);
                Console.WriteLine(rss.Channels[0].Description);
                Console.WriteLine(rss.Channels[0].LastBuildDate);

                foreach (Item item in rss.Channels[0].Items)
                {
                    Console.WriteLine("- Title : " + item.Title);
                    Console.WriteLine("- Link : " + item.Link);
                    Console.WriteLine("- Description : " + item.Description);
                    Console.WriteLine("=========================================================");
                }

                DataTable dt = new DataTable("Items");

                dt.Columns.Add("Idx", typeof(Int32));
                dt.Columns.Add("title", typeof(String));
                dt.Columns.Add("link", typeof(String));
                dt.Columns.Add("description", typeof(String));
                dt.Columns["Idx"].ReadOnly = true;
                dt.Columns["Idx"].Unique = true;
                dt.Columns["Idx"].AutoIncrement = true;
                dt.Columns["Idx"].AutoIncrementSeed = 1;
                dt.Columns["Idx"].AutoIncrementStep = 1;
                dt.PrimaryKey = new DataColumn[] { dt.Columns[0] };

                foreach (Item item in rss.Channels[0].Items)
                {
                    dt.Rows.Add(null, item.Title, item.Link, item.Description);
                }

                foreach (DataRow dr in dt.Rows)
                {
                    Console.WriteLine("- Idx : " + dr["Idx"]);
                    Console.WriteLine("- Title : " + dr["title"]);
                    Console.WriteLine("- Link : " + dr["link"]);
                    Console.WriteLine("- Description : " + dr["description"]);
                    Console.WriteLine("=========================================================");
                }

                Console.ReadKey();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.textBox1.Text = "http://www.kma.go.kr/weather/forecast/mid-term-rss3.jsp?stnId=108";
            //getWeather(this.textBox1.Text);
            GetNews(this.textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "http://news.google.co.kr/news?pz=1&hdlOnly=1&cf=i&ned=kr&hl=ko&output=rss";
            GetNews(this.textBox1.Text);
        }

        private void GetNews(string strURL)
        {
            WebClient wc = new WebClient();
            wc.Encoding = System.Text.UTF8Encoding.UTF8;
            //String buffer = wc.DownloadString("http://media.daum.net/rss/today/primary/all/rss2.xml");
            //String buffer = wc.DownloadString(String.Format("{0}ig/api?news", _Global.headerURL));
            //String buffer = wc.DownloadString("http://news.google.co.kr/news?pz=1&hdlOnly=1&cf=i&ned=kr&hl=ko&output=rss");
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
                listBoxNew.Items.Add(data);
                listBoxNew.Items.Add(pubDate);
                
                textBox2.Text += data + "\r\n";
                textBox2.Text += pubDate + "\r\n";
            }


            XmlNodeList forecastNodes1 = doc.SelectNodes("rss/channel/item/description/header");
            foreach (XmlNode node in forecastNodes1)
            {
                String wf = node["wf"].InnerText;
                listBoxNew.Items.Add(wf);

                string[] strwfList = wf.Replace("<br />", "!").Split('!');
                for (int iIdx = 0; iIdx < strwfList.Length; iIdx++)
                {
                    textBox2.Text += strwfList[iIdx].ToString() + "\r\n";
                }
            }
            //timerNews.Enabled = true;
        }

        

    }
}
