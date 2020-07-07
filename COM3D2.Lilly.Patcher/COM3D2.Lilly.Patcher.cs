using System;
using System.Collections.Generic;
using Mono.Cecil;




namespace COM3D2.Lilly.Patcher
{
    public static class Patcher
    {
        static String name = "Lilly.Patcher";

        public static readonly string[] TargetAssemblyNames = { "Assembly-CSharp.dll", "UnityEngine.dll", "Assembly-CSharp-firstpass.dll" };
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

                    PatcherHelper.SetHook(
                        PatcherHelper.HookType.PreCall,
                        ta, "AudioSourceMgr.LoadPlay",
                        da, "COM3D2.Lilly.Managed.AudioSourceMgrLilly.LoadPlay");
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