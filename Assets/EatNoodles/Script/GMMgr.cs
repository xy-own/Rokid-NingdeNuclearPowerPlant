using RGame.Base;
using RGame.Base.Extension;
using RGame.Data;
using UnityEngine;

namespace XYGame
{
    public class GMMgr : MonoBase
    {
        private UIMgr mUIMgr = null;
        private UIOverlayMgr mUIOverlayMgr = null;
        private LoadPar loadPar = null;
        /// <summary>
        /// 游戏入口
        /// </summary>
        /// <param name="loadPar"></param>
        public override void Initialize(LoadPar loadPar)
        {
            this.loadPar = loadPar;
            mUIMgr = transform.Find("UICanvas").gameObject.AddComponent<UIMgr>();
            mUIMgr.Initialize(this);
            mUIMgr.gameObject.SetActive(true);

            GameObject uiOverlay = GetLoad().GetAssets<GameObject>(0);
            GameObject obj = Instantiate(uiOverlay, Camera.main.transform, false);
            obj.SetActive(false);
            mUIOverlayMgr = obj.AddComponent<UIOverlayMgr>();
            mUIOverlayMgr.Initialize(this);
            mUIOverlayMgr.gameObject.SetActive(true);
        }
        public ResEx GetLoad()
        {
            return Load();
        }
        public float PlayAudio(AudioClip clip, bool loop = false)
        {
            return SoundPlay(clip, loop);
        }
        public void PlayAudioOneShot(AudioClip clip)
        {
            AudioPlay(clip);
        }
        /// <summary>
        /// 立即释放游戏
        /// </summary>
        public override void OnDispose()
        {
            base.OnDispose();
            UnLoad();
        }
    }
}