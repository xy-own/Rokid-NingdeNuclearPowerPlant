using UnityEngine;
using RGame.Base;
using RGame.Define;
using RGame.Utility;

namespace RGame
{
    public class Main : MonoBehaviour
    {
        [SerializeField]
        private bool LogMode = false;
        [SerializeField]
        private bool ShowFps = false;
        [SerializeField]
        private int GameFrameRate = 30;
        [SerializeField]
        private MonoBase mMonoBase = null;
        private void Awake()
        {
            InitSettings();
            InitDebug();

            InitModule();
        }
        /// <summary>
        /// 初始化设置
        /// </summary>
        private void InitSettings()
        {
            AppConst.LogMode = LogMode;
            AppConst.ShowFps = ShowFps;
            AppConst.GameFrameRate = GameFrameRate;
        }
        /// <summary>
        /// 添加调试
        /// </summary>
        private void InitDebug()
        {
            if (AppConst.ShowFps)
            {
                gameObject.AddComponent<AppFPS>();
            }
            if (AppConst.LogMode)
            {
                gameObject.AddComponent<GameCMD>();
            }
            QualitySettings.vSyncCount = 2;
            Application.targetFrameRate = AppConst.GameFrameRate;

            // 设置应用不休眠
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
        /// <summary>
        /// 启动
        /// </summary>
        private void InitModule()
        {
            if (mMonoBase != null)
            {
                mMonoBase.Initialize(new Data.LoadPar()
                {
                    type = Data.LoadType.Default,
                });
            }
        }
    }
}