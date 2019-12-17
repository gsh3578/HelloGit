using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Media1
{
    static class MediaControl
    {
        private static string Pcommand;
        private static StringBuilder ReturnData;
        private static bool isOpen;

        [DllImport("winmm.dll")]        // MediaControl 클래스를 이루는 모든 기능에 기본이 되는 mciSendString 함수 선언. 
        private static extern long mciSendString(
            string strCommand,
            StringBuilder strReturn,
            int iReturnLength,
            IntPtr hwndCallback);

        static public void Close()    // 음악파일 닫기.
        {
            Pcommand = "close MediaFile";
            mciSendString(Pcommand, null, 0, IntPtr.Zero);
            isOpen = false;
        }

        static public void Open(string sFileName)    // 음악파일 열기.
        {
            Pcommand = "open \"" + sFileName + "\" type mpegvideo alias MediaFile";
            mciSendString(Pcommand, null, 0, IntPtr.Zero);
            isOpen = true;
        }

        static public void Play(bool loop)    // 처음부터 재생.
        {
            if (isOpen)
            {
                Pcommand = "play MediaFile";
                if (loop)
                    Pcommand += " REPEAT";

                mciSendString(Pcommand, null, 0, IntPtr.Zero);
            }
        }

        static public void Play(bool loop, int seekTime)    // 인자값으로 넘긴 시간대 부터 재생을 시작함.
        {
            if (isOpen)
            {
                Pcommand = "play MediaFile";
                if (loop)
                    Pcommand += " REPEAT";

                if (seekTime > 0)
                    Pcommand += " from " + seekTime.ToString();

                mciSendString(Pcommand, null, 0, IntPtr.Zero);
            }
        }

        static public void Seek(int seekTime)    // 탐색. 해당 시간대로 재생 지점을 옮김.
        {
            if (isOpen)
            {
                Pcommand = "seek MediaFile to " + seekTime.ToString();
                mciSendString(Pcommand, null, 0, IntPtr.Zero);
            }
        }

        static public void Stop()    // 정지. 재생을 멈추고 처음 지점으로 돌림.
        {
            Pcommand = "stop MediaFile";
            mciSendString(Pcommand, null, 0, IntPtr.Zero);
            isOpen = false;
        }

        static public void Pause()    // 일시정지. 현재 지점에서 재생을 그대로 멈춤.
        {
            Pcommand = "pause MediaFile";
            mciSendString(Pcommand, null, 0, IntPtr.Zero);
        }

        static public void Resume()     // 다시 재생. 일시정지로 멈췄던 지점에서 재생을 시작함.
        {
            Pcommand = "resume MediaFile";
            mciSendString(Pcommand, null, 0, IntPtr.Zero);
        }

        static public void MasterVolume(int value)    // 음량 조절 0~1000
        {
            int vol = value;
            vol = (vol < 0) ? 0 : vol;
            vol = (vol > 1000) ? 1000 : vol;

            Pcommand = "setaudio MediaFile volume to " + vol.ToString();
            mciSendString(Pcommand, null, 0, IntPtr.Zero);
        }

        static public string Status()    // 현재 선택된 음악이 어떤 작업을 수행중인지 판단. 
        {                                // "playing", "paused", "stopped", etc. 등을 반환
            int i = 128;

            Pcommand = "status MediaFile mode";
            ReturnData = new StringBuilder(i);
            mciSendString(Pcommand, ReturnData, i, IntPtr.Zero);

            return ReturnData.ToString();
        }

        static public int Length()    // 현재 선택된 음악의 길이를 ms단위로 반환
        {
            if (isOpen)
            {
                Pcommand = "status MediaFile length";
                mciSendString(Pcommand, ReturnData, ReturnData.Capacity, IntPtr.Zero);

                return int.Parse(ReturnData.ToString());
            }
            else
                return 0;
        }

        static public int Position()    // 선택된 음악의 현재 재생 지점을 ms단위로 반환
        {
            if (isOpen)
            {
                Pcommand = "status MediaFile position";
                mciSendString(Pcommand, ReturnData, ReturnData.Capacity, IntPtr.Zero);

                return int.Parse(ReturnData.ToString());
            }
            else
                return 0;
        }
    }
}
