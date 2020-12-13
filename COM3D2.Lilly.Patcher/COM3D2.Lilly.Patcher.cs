using System;
using System.Collections.Generic;
using Mono.Cecil;




namespace COM3D2.Lilly.Patcher
{
    public static class Patcher
    {
        static String name = "Lilly.Patcher";

        // 불러올 dll 목록. 시바리스용
        public static readonly string[] TargetAssemblyNames = { "Assembly-CSharp.dll", "UnityEngine.dll", "Assembly-CSharp-firstpass.dll" };

        // 불러올 dll 목록. BepInEx용
        // 플러그인 https://github.com/BepInEx/BepInEx
        // 가이드 https://bepinex.github.io/bepinex_docs/master/articles/index.html
        public static IEnumerable<string> TargetDLLs { get; } = new[] { "Assembly-CSharp.dll", "UnityEngine.dll", "Assembly-CSharp-firstpass.dll" };

        // Patches the assemblies
        public static void Patch(AssemblyDefinition assembly)
        {
            LogError(assembly.Name.Name);

            AssemblyDefinition ta = assembly;
            AssemblyDefinition da = PatcherHelper.GetAssemblyDefinition("COM3D2.Lilly.Managed.dll");
            TypeDefinition typedef = da.MainModule.GetType("COM3D2.Lilly.Managed,LillyManaged");
            try
            {
                if (assembly.Name.Name == "Assembly-CSharp")
                {
                    Log("Assembly-CSharp");

                    // private void SetProp(MaidProp mp, string filename, int f_nFileNameRID, bool f_bTemp, bool f_bNoScale = false)
                    PatcherHelper.SetHook(
                        PatcherHelper.HookType.PreCall,
                        ta, "Maid.SetProp",
                        da, "COM3D2.Lilly.Managed.MaidLilly.SetPropPreCall");

                    // PresetSet(Maid f_maid, Preset f_prest)
                    PatcherHelper.SetHook(
                        PatcherHelper.HookType.PreCall,
                        ta, "CharacterMgr.PresetSet",
                        da, "COM3D2.Lilly.Managed.CharacterMgrLilly.PresetSetPreCall");

                    // 사운드 파일명 출력용 후킹. 
                    PatcherHelper.SetHook(
                        PatcherHelper.HookType.PreCall,
                        ta, "AudioSourceMgr.LoadPlay",
                        da, "COM3D2.Lilly.Managed.AudioSourceMgrLilly.LoadPlayPreCall");

                    PatcherHelper.SetHook(
                        PatcherHelper.HookType.PostCall,
                        ta, "AudioSourceMgr.LoadPlay",
                        da, "COM3D2.Lilly.Managed.AudioSourceMgrLilly.LoadPlayPostCall");
                    
                    PatcherHelper.SetHook(
                        PatcherHelper.HookType.PreCall,
                        ta, "ImportC.ReadMaterial",
                        da, "COM3D2.Lilly.Managed.ImportCMLilly.ReadMaterial");


                }
                else if (assembly.Name.Name == "UnityEngine")
                {
                    Log(" UnityEngine");

                }
                else if (assembly.Name.Name == "Assembly-CSharp-firstpass")
                {
                    Log(" Assembly-CSharp-firstpass");

                }
            }
            catch (Exception e)
            {
                Log(e);
            }

        }

        // 패치가 발생하기 전에 호출 
        public static void Initialize()
        {
            Log("Initialize");
        }

        // 현재 patcher가 완료된 후 호출 
        public static void Finish()
        {
            Log("Finish");
        }


        /// <summary>
        /// 유니티엔진의 로그는 BepInEx 기본값 사용시 콘솔 출력이 안됨.
        /// BepInEx의 설정파일 logger-displayed-levels=Info 값을 수정하면 되긴 함.
        /// </summary>
        /// <param name="s"></param>
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
}