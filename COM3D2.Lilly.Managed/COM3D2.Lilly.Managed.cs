using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace COM3D2.Lilly.Managed
{

    // 로그 툴력용. 사실 utill에 해당
    public static class Lilly
    {
        static String name = "Lilly.Managed";

        public static void Test()
        {
            Log("test");
        }
        public static void Log(System.Object s)
        {
            LogConsole(s, ConsoleColor.White);
            //Debug.Log(s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        public static void LogWarning(System.Object s)
        {
            LogConsole(s, ConsoleColor.Yellow);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        public static void LogError(System.Object s)
        {
            LogConsole(s, ConsoleColor.Red);
        }

        public static void LogConsole(System.Object s, ConsoleColor c = ConsoleColor.White)
        {
            Console.ForegroundColor = c;
            Console.WriteLine(name + ":" + s);
            Console.ResetColor();
        }
    }

    public static class AudioSourceMgrLilly // 클래스명은 편한대로. 단지 AudioSourceMgr로 똑같이 적어버리면 아래 메소드에서 처리하기가 좀 곤란
    {
        static String name = "AudioSourceMgr";

        // 사운드 파일명 출력용
        public static void LoadPlay(AudioSourceMgr that, string f_strFileName, float f_fFadeTime, bool f_bStreaming, bool f_bLoop = false) // 후킹시 원본 클래스도 같이 받도록 돼있음
        //     public void LoadPlay(                     string f_strFileName, float f_fFadeTime, bool f_bStreaming, bool f_bLoop = false) // 원본
        {
            Lilly.Log(name + ".LoadPlay:" + f_strFileName);
        }


    }

}
