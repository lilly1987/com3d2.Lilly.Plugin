using System;
using System.Collections.Generic;
using System.IO;
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

    public static class MaidLilly // 클래스명은 편한대로. 단지 AudioSourceMgr로 똑같이 적어버리면 아래 메소드에서 처리하기가 좀 곤란
    {
        static String name = "MaidLilly";
        public static void SetPropPreCall(Maid that, MaidProp mp, string filename, int f_nFileNameRID, bool f_bTemp, bool f_bNoScale = false) // 후킹시 원본 클래스도 같이 받도록 돼있음
    // private void SetProp(MaidProp mp, string filename, int f_nFileNameRID, bool f_bTemp, bool f_bNoScale = false)    
        {
            Lilly.Log(name + ".SetPropPreCall:" + filename);
        }
    }

    public static class CharacterMgrLilly // 클래스명은 편한대로. 단지 AudioSourceMgr로 똑같이 적어버리면 아래 메소드에서 처리하기가 좀 곤란
    {
        static String name = "CharacterMgrLilly";
        public static void PresetSetPreCall(CharacterMgr that, Maid f_maid, CharacterMgr.Preset f_prest) // 후킹시 원본 클래스도 같이 받도록 돼있음
        //     public void PresetSet(Maid f_maid, Preset f_prest)// 원본
        {
            Lilly.Log(name + ".PresetSetPreCall:" + f_prest.strFileName);
        }
    }
        public static class AudioSourceMgrLilly // 클래스명은 편한대로. 단지 AudioSourceMgr로 똑같이 적어버리면 아래 메소드에서 처리하기가 좀 곤란
    {
        static String name = "AudioSourceMgr";

        // PreCall
        // 사운드 파일명 출력용
        public static void LoadPlayPreCall(AudioSourceMgr that, string f_strFileName, float f_fFadeTime, bool f_bStreaming, bool f_bLoop = false) // 후킹시 원본 클래스도 같이 받도록 돼있음
        //     public void LoadPlay(                     string f_strFileName, float f_fFadeTime, bool f_bStreaming, bool f_bLoop = false) // 원본
        {
            Lilly.Log(name + ".LoadPlay.LoadPlayPreCall:" + f_strFileName);
        }
        
        // PreCall
        // 사운드 파일명 출력용
        public static void LoadPlayPostCall(AudioSourceMgr that, string f_strFileName, float f_fFadeTime, bool f_bStreaming, bool f_bLoop = false) // 후킹시 원본 클래스도 같이 받도록 돼있음
        //     public void LoadPlay(                     string f_strFileName, float f_fFadeTime, bool f_bStreaming, bool f_bLoop = false) // 원본
        {
            Lilly.Log(name + ".LoadPlay.LoadPlayPostCall:" + f_strFileName);
        }


    }
    public static class ImportCMLilly // 클래스명은 편한대로. 단지 원래와 똑같이 적어버리면 아래 메소드에서 처리하기가 좀 곤란
    {
        static String name = "ImportCMLilly";

        //PreJump
        public static void ReadMaterial(ImportCM importCM, BinaryReader r, TBodySkin bodyskin = null, Material existmat = null)
        //public static Material ReadMaterial(            BinaryReader r, TBodySkin bodyskin = null, Material existmat = null)
        {
             Lilly.Log(name + "." +
                 "ReadMaterial:" + existmat.shader.name);
        }

    }

}
