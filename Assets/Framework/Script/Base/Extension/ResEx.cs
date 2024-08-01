using System;
using UnityEngine;
using RGame.Interface;
using RGame.Define;
using RGame.Utility;

namespace RGame.Base.Extension
{
    public class ResEx : MonoBehaviour, ILog
    {
        [SerializeField]
        private GameObject[] mPrefab;
        [SerializeField]
        private Texture[] mTexture;
        [SerializeField]
        private Sprite[] mSprite;
        [SerializeField]
        private AudioClip[] mAudioClip;
        [SerializeField]
        private TextAsset mTextAsset;


        /// <summary>
        /// 获取资源
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="index">索引</param>
        /// <returns></returns>
        public T GetAssets<T>(int index) where T : class
        {
            // 根据类型参数T从相应数组中获取资源
            object obj = typeof(T) switch
            {
                Type t when t == typeof(GameObject) => mPrefab[index],
                Type t when t == typeof(Texture) => mTexture[index],
                Type t when t == typeof(Sprite) => mSprite[index],
                Type t when t == typeof(AudioClip) => mAudioClip[index],
                Type t when t == typeof(TextAsset) => mTextAsset,
                _ => null
            };

            // 如果找不到相应资源，记录错误并返回null
            if (obj == null)
            {
                Log($"Get assets error for type {typeof(T)}. Check resource configuration at index {index}");
                return null;
            }

            // 将对象转换为类型T并返回
            return obj as T;
        }

        /// <summary>
        /// 获取资源
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <returns></returns>
        public T GetAssets<T>() where T : class
        {
            // 根据类型参数T从相应数组中获取资源
            object obj = typeof(T) switch
            {
                Type t when t == typeof(GameObject[]) => mPrefab,
                Type t when t == typeof(Texture[]) => mTexture,
                Type t when t == typeof(Sprite[]) => mSprite,
                Type t when t == typeof(AudioClip[]) => mAudioClip,
                Type t when t == typeof(TextAsset) => mTextAsset,
                _ => null
            };

            // 如果找不到相应资源，记录错误并返回null
            if (obj == null)
            {
                Log($"Get assets error for type {typeof(T)}.");
                return null;
            }

            // 将对象转换为类型T并返回
            return obj as T;
        }

        public void Log(string log, LogColor logColor = LogColor.Red)
        {
            Util.Log(log, logColor);
        }
    }
}
