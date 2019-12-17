using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace SpeechAI.MediaPlayer
{
    public class JE_SR
    {
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern uint mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);

        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        private static extern int mciGetErrorString(uint errorCode, StringBuilder errorText, int errorTextSize);
        
        private static bool recording = false;
        public static uint lastResult;

        public static void startRecording()
        {
            if (recording)
            {
                return;
            }

            tryMCISendString("open new Type waveaudio Alias recsound", "", 0, 0);
            tryMCISendString("record recsound", "", 0, 0);

            recording = true;
        }

        public static void stopRecording(string file)
        {
            if (!recording)
            {
                return;
            }

            if (!file.Equals(""))
            {
                tryMCISendString("save recsound " + file, "", 0, 0);
                tryMCISendString("close recsound ", "", 0, 0);
            }
            else
            {
                tryMCISendString("close all", "", 0, 0);
            }

            recording = false;
        }

        public static void tryMCISendString(string lpstrCommand,
            string lpstrReturnString, int uReturnLength, int hwndCallback)
        {
            lastResult = mciSendString(lpstrCommand, lpstrReturnString, uReturnLength, hwndCallback);

            StringBuilder error = new StringBuilder(256);
            if (lastResult != 0)
            {
                mciGetErrorString(lastResult, error, error.Length);
                //JE_Log.logMessage("MCIERROR(JE_SR): " + error.ToString());
            }
        }
        
    }
}
