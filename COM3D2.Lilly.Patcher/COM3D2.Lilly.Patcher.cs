using System;
using System.Collections.Generic;
using Mono.Cecil;




namespace COM3D2.Lilly.Patcher
{
    public static class Patcher
    {
        static String name = "Lilly.Patcher";

        // List of assemblies to patch
        //public static readonly string[] TargetAssemblyNames = { "Assembly-CSharp.dll" };
        public static readonly string[] TargetAssemblyNames = { "Assembly-CSharp.dll" ,"UnityEngine.dll","Assembly-CSharp-firstpass.dll"};
        public static IEnumerable<string> TargetDLLs { get; } = new[] { "Assembly-CSharp.dll"  ,"UnityEngine.dll","Assembly-CSharp-firstpass.dll"};
        //public static IEnumerable<string> TargetDLLs { get; } = new[] { "Assembly-CSharp.dll"  };



        // Patches the assemblies
        public static void Patch(AssemblyDefinition assembly)
        {
            LogError( assembly.Name.Name);
            // Patcher code here

            //AssemblyDefinition assemblyDefinition = PatcherHelper.GetAssemblyDefinition("COM3D2.QuickEditStart.Managed.dll");
            //TypeDefinition type = assemblyDefinition.MainModule.GetType("COM3D2.QuickEditStart.Managed.QuickEditStartManaged");

            //AssemblyDefinition assemblyDefinition = PatcherHelper.GetAssemblyDefinition("COM3D2.Lilly.Managed.dll");
            //TypeDefinition type = assemblyDefinition.MainModule.GetType("COM3D2.Lilly.Managed.Lilly");

            //Patcher.BeforeConstructer(assembly, type, "SceneEdit/ColorItemSet", "MenuItemSet");

            AssemblyDefinition ta = assembly;
            AssemblyDefinition da = PatcherHelper.GetAssemblyDefinition("COM3D2.Lilly.Managed.dll");
            TypeDefinition typedef = da.MainModule.GetType("COM3D2.Lilly.Managed,LillyManaged");
            try
            {

                if (assembly.Name.Name == "Assembly-CSharp")
                {
                    // The assembly is Assembly-CSharp.dll
                    Log("Assembly-CSharp");

                    //PatcherHelper.SetHook(
                    //    PatcherHelper.HookType.PreCall, 
                    //    assembly, "AudioSourceMgr.LoadPlay", 
                    //    assemblyDefinition, "COM3D2.Lilly.Managed.AudioSourceMgr.LoadPlay");
                    //PatcherHelper.SetHook(PatcherHelper.HookType.PostCall, assembly, "AudioSourceMgr", "LoadPlay", assemblyDefinition, "COM3D2.Lilly.Managed.AudioSourceMgr", "LoadPlay");
                    PatcherHelper.SetHook(
                        PatcherHelper.HookType.PostCall,
                        ta, "AudioSourceMgr.LoadPlay",
                        da, "COM3D2.Lilly.Managed.AudioSourceMgr.LoadPlay");
                }
                else if (assembly.Name.Name == "UnityEngine")
                {
                    // The assembly is UnityEngine.dll
                    Log(" UnityEngine");
                    //PatcherHelper.SetHook(PatcherHelper.HookType.PreJump, assembly, "Input", "GetKeyDown", assemblyDefinition, "COM3D2.Lilly.Managed.Input", "GetKeyDown");
                    //PatcherHelper.SetHook(
                    //    PatcherHelper.HookType.PreCall,
                    //    ta, "Input.GetKeyDown",
                    //    da, "COM3D2.Lilly.Managed.Input.GetKeyDown");
                }
                else if (assembly.Name.Name == "Assembly-CSharp-firstpass")
                {
                    Log(" Assembly-CSharp-firstpass");

                    PatcherHelper.SetHook(
                       PatcherHelper.HookType.PreJump,
                       ta, "NDebug.MessageBox",
                       da, "COM3D2.Lilly.Managed.NDebug.MessageBox");
                }
            }
            catch (Exception e)
            {
                Log(e);
                //throw;
            }
                //LogError("Patch2 : " + assembly.Name.Name);
                //string text = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "COM3D2.Lilly.Managed.dll");
                //if (!File.Exists(text))
                //{
                //    LogError(" File.Exists(text)");
                //    return;
                //}
                ////TypeDefinition type = AssemblyDefinition.ReadAssembly(text).MainModule.GetType("CM3D2.ExternalPreset.Managed.ExPreset");
                //type = AssemblyDefinition.ReadAssembly(text).MainModule.GetType("COM3D2.Lilly.Managed.AudioSourceMgr");
                //if (type == null)
                //{
                //    LogError("type == null");
                //    return;
                //}
                //TypeDefinition type2 = assembly.MainModule.GetType("AudioSourceMgr");
                //if (type2 == null)
                //{
                //    LogError("type2 == null");
                //    return;
                //}
                //MethodDefinition methodDefinition = type2.Methods.FirstOrDefault((MethodDefinition meth) => meth.Name == "LoadPlay");
                //if (methodDefinition == null)
                //{
                //    LogError("methodDefinition == null");
                //    return;
                //}            
                //PatcherHelper.SetHook(PatcherHelper.HookType.PostCall, assembly, "AudioSourceMgr", "LoadPlay", assemblyDefinition,
                //    "COM3D2.Lilly.Managed.AudioSourceMgr", "LoadPlay");
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