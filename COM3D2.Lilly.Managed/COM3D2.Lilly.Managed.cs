using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace COM3D2.Lilly.Managed
{
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
    public static class AudioSourceMgr
    {
        static String name = "Lilly.Managed.AudioSourceMgr";

        public static void LoadPlay(string f_strFileName, float f_fFadeTime, bool f_bStreaming, bool f_bLoop = false)
        {
            Log("소리 재생:" + f_strFileName);
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

    public static class Input
    {
        static String name = "Lilly.Managed.Input";

        public static bool GetKeyDown(string name)
        {
            if (name.Length > 0)
            {
                Lilly.Log("GetKeyDown.name:" + name);
                return true;
            }
            return false;
            //return name.Length != 0 && UnityEngine.Input.GetKeyDown(name);
        }


    }


    public static class NDebug
    {
        public static void MessageBox(string f_strTitle, string f_strMsg)
        {
            //NUty.WinMessageBox(NUty.GetWindowHandle(), f_strMsg, f_strTitle, 0);
            Lilly.Log(f_strTitle + ":" + f_strMsg);
        }

    }

}
