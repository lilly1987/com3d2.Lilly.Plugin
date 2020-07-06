using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityInjector;
using UnityInjector.Attributes;
//using System.Threading.Tasks;
using System.IO;
using PluginExt;
using GearMenu;
using System.Drawing.Imaging;

namespace COM3D2.LILLY.Plugin
{
    [PluginFilter("COM3D2x64"), PluginName("LILLY"), PluginVersion("3.0")]
    public class LILLY : ExPluginBase
    //public class LILLY : UnityInjector.PluginBase // 뭐가 다른거지..
    {
        static new readonly String name = "Lilly.Plugin";

        // アイコンのバイナリ 아이콘 이진
        public byte[] IconPng { get; protected set; }
        // ボタンの管理名 버튼의 관리 이름
        public string ButtonName { get { return "AutoCompileSample"; } }
        // ボタンにホバーした際のラベル 버튼에 마우스를 가져 가면했을 때 레이블
        public string Label { get { return "AutoCompileSample" + ((m_isEnable) ? ("ON") : ("OFF")); } }

        private bool m_isEnable = true;

        private int GameVersion
        {
            get
            {
                return (int)typeof(Misc).GetField("GAME_VERSION").GetValue(null);
            }
        }



        public LILLY()
        {

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


        // called zero
        // Used by the Unity Engine Scripting API
        // 실행 순서는 https://docs.unity3d.com/kr/530/Manual/ExecutionOrder.html 참고
        public void Awake()
        {

            // Called once the MonoBehaviour is added into the game
            //Debug.Log("Awake");
            Log("Awake Log");
            LogWarning("Awake LogWarning");
            LogError("Awake LogError");
            //Log(this.Name);

            // 게임 설정값
            gameInfo();

            // リソースからアイコンをロード
            // 자원에서 아이콘을로드
            MemoryStream ms = new MemoryStream();
            Properties.Resources.SampleIcon.Save(ms, ImageFormat.Png);
            IconPng = ms.GetBuffer();
        }


        public void OnEnable()
        {
            Log("OnEnable called");

            // OnSceneLoaded 사용시 이렇게 먼저 처리해줘야함
            try
            {
                GameObject.DontDestroyOnLoad(this);
                SceneManager.sceneLoaded += OnSceneLoaded;
                Log("OnSceneLoaded Succ");
            }
            catch (Exception e)
            {
                LogError("OnSceneLoaded add error : " + e);
            }

        }



        // called third
        // 한번만 실행됨
        public void Start()
        {
            Log("Start");

            pluginInfo();
        }


        // Used by the Unity Engine Scripting API
        public void Update()
        {
        }

        public void OnGUI()
        {

        }

        // called when the game is terminated
        public void OnDisable()
        {
            Log("OnDisable");
            //SceneManager.sceneLoaded -= OnSceneLoaded;
        }


        public void OnLevelWasLoaded(int level)
        {
            Log("OnLevelWasLoaded: " + level);

            // 메이드 목록 없을때 에러 처리 필요
            //maidInfo();

            _registerGearButton();
        }

        // called second
        /// <summary>
        /// 
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="mode"></param>
        public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            Log("OnSceneLoaded: " + scene.name + " : " + mode);

        }

        public void gameInfo()
        {
            Log("GameVersion : " + GameVersion);
            Log("Application.installerName : " + Application.installerName);
            Log("Application.version : " + Application.version);
            Log("Application.unityVersion : " + Application.unityVersion);
           //Log("Application.loadedLevel : " + Application.loadedLevel);
           //Log("Application.levelCount : " + Application.levelCount);
            Log("Application.companyName : " + Application.companyName);
            Log("CharacterMgr.MaidStockMax : " + CharacterMgr.MaidStockMax);
            Log("CharacterMgr.ActiveMaidSlotCount : " + CharacterMgr.ActiveMaidSlotCount);
            Log("CharacterMgr.NpcMaidCreateCount : " + CharacterMgr.NpcMaidCreateCount);
            Log("CharacterMgr.ActiveManSloatCount : " + CharacterMgr.ActiveManSloatCount);
        }

        public void pluginInfo()
        {
            PluginBase[] array = UnityEngine.Object.FindObjectsOfType<PluginBase>();
            for (int i2 = 0; i2 < array.Length; i2++)
            {
                Log(array[i2].Name + "," + array[i2].enabled + "," + array[i2].name + "," + array[i2].tag + "," + array[i2].DataPath);
            }

        }

        // メニュークリック時のコールバック
        // 메뉴 클릭시 콜백
        private void OnGearMenuClick(GameObject gameObject)
        {
            m_isEnable = !m_isEnable;

            if (m_isEnable)
            {
                Buttons.SetFrameColor(gameObject, Color.red);
            }
            else
            {
                Buttons.SetFrameColor(gameObject, new Color(0.827f, 0.827f, 0.827f));
            }

            // ラベル再設定 라벨 재구성
            Buttons.SetText(gameObject, Label);
        }

        // ボタンを登録 버튼 등록
        private void _registerGearButton()
        {
            try
            {

                if (Buttons.Contains(ButtonName))
                {
                    Buttons.Remove(ButtonName);
                }
                GameObject btn = Buttons.Add(ButtonName, Label, IconPng, OnGearMenuClick);

                if (m_isEnable)
                {
                    Buttons.SetFrameColor(btn, Color.red);
                }
                else
                {
                    Buttons.SetFrameColor(btn, new Color(0.827f, 0.827f, 0.827f));
                }
            }
            catch (Exception e)
            {
                Log(e);
            }


        }







    }
}
