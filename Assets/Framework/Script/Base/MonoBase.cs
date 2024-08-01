using System;
using UnityEngine;
using RGame.Interface;
using RGame.Base.Extension;
using RGame.Data;
using RGame.Define;
using RGame.API;
using RGame.Utility;

namespace RGame.Base
{
    [RequireComponent(typeof(ResEx))]
    public class MonoBase : MonoBehaviour, ILog
    {
        public virtual void Initialize(LoadPar loadPar)
        {
        }
        public virtual void OnDispose()
        {
        }
        UnLoadPar unLoadPar = new UnLoadPar();
        protected void UnLoad(string data = null)
        {
            unLoadPar.type = LoadType.Package;
            unLoadPar.id = int.Parse(gameObject.name);
            unLoadPar.data = data;
            MessageDispatcher.SendMessageData(OpenAPI.UnLoad, unLoadPar);
        }

        #region UIMgr
        UIMessagePar uiMessagePar = new UIMessagePar();
        protected void UIMessage(string id, string data)
        {
            uiMessagePar.id = id;
            uiMessagePar.data = data;
            MessageDispatcher.SendMessageData(OpenAPI.UIMessage, uiMessagePar);
        }
        #endregion

        #region AudioSouce
        private AudioSource mAudioSource = null;
        private AudioSource GetAudioSource()
        {
            if (mAudioSource == null && !gameObject.TryGetComponent(out mAudioSource))
            {
                mAudioSource = gameObject.AddComponent<AudioSource>();
                mAudioSource.playOnAwake = false;
                mAudioSource.loop = false;
            }
            return mAudioSource;
        }
        protected void AudioPlay(AudioClip clip)
        {
            if (clip == null)
                return;
            GetAudioSource().PlayOneShot(clip);
        }
        protected float SoundPlay(AudioClip clip, bool loop = false)
        {
            GetAudioSource().loop = loop;
            if (GetAudioSource().clip == null || mAudioSource.clip.GetHashCode() != name.GetHashCode())
            {
                GetAudioSource().clip = clip;
            }
            GetAudioSource().Play();
            return clip.length;
        }

        protected void SoundStop()
        {
            if (GetAudioSource().isPlaying)
            {
                GetAudioSource().Stop();
                GetAudioSource().clip = null;
            }
        }

        #endregion

        #region Log
        public void Log(string log, LogColor logColor = LogColor.None)
        {
            Util.Log(log, logColor);
        }
        #endregion

        #region LoadRes
        private ResEx mLoad = null;
        protected ResEx Load()
        {
            if (mLoad == null)
            {
                mLoad = gameObject.GetComponent<ResEx>();
            }
            return mLoad;
        }
        #endregion

        // #region 动态添加组件
        // public T GetManager<T>() where T : Component
        // {
        //     // 尝试获取组件，如果不存在则添加并返回
        //     if (!gameObject.TryGetComponent<T>(out var component))
        //     {
        //         component = gameObject.AddComponent<T>();
        //     }
        //     return component;
        // }
        // #endregion
    }
}