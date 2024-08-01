using RGame.Define;
using RGame.Interface;
using RGame.Utility;
using UnityEngine;

namespace XYGame
{
    public class UIMgr : MonoBehaviour, ILog
    {
        private GMMgr mGMMgr = null;
        private void Awake()
        {
            GetComponent<Canvas>().worldCamera = Camera.main;
        }
        public void Initialize(GMMgr mgr)
        {
            mGMMgr = mgr;
        }

        public void Log(string log, LogColor logColor = LogColor.None)
        {
            Util.Log($" uiMgr {log}", logColor);
        }
    }
}