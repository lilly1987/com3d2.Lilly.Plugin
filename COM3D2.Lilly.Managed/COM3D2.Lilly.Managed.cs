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
    public static class AudioSourceMgrLilly
    {
        static String name = "AudioSourceMgr";

        public static void LoadPlay(AudioSourceMgr that, string f_strFileName, float f_fFadeTime, bool f_bStreaming, bool f_bLoop = false)
        {
            Lilly.Log(name + ".LoadPlay:" + f_strFileName);
        }

        //        InvalidProgramException: Invalid IL code in AudioSourceMgr:LoadPlay(string, single, bool, bool) : IL_0032: ret
        //
        //             at SoundMgr+AudioFadeBuffer.PlayEx(System.String f_strFileName, Single f_fTime, Boolean f_bStreaming, Boolean f_bLoop, UnityEngine.Transform f_trAttachParent, Boolean f_bDance)[0x00000] in <filename unknown>:0 
        //  at SoundMgr+AudioFadeBuffer.Play(System.String f_strFileName, Single f_fTime, Boolean f_bStreaming, Boolean f_bLoop, UnityEngine.Transform f_trAttachParent)[0x00000] in <filename unknown>:0 
        //  at SoundMgr.PlayBGM(System.String f_strFileName, Single f_fTime, Boolean f_fLoop) [0x00000] in <filename unknown>:0 
        //  at TitleMgr.Init() [0x00000] in <filename unknown>:0 
        //  at TitleMgr.OpenTitlePanel() [0x00000] in <filename unknown>:0 
        //  at com.workman.cm3d2.scene.dailyEtc.SceneMgr.Start() [0x00000] in <filename unknown>:0 
        //
        //
        //(Filename:  Line: -1)

    }

}
