using UnityEngine;

namespace XY.UXR.Slam
{
    public class ResetSlam : MonoBehaviour
    {
        public const string ResetRKSlam = "ResetSlam";
        private void Awake()
        {
            MessageDispatcher.AddListener(ResetRKSlam, OnResetSlam);
        }
        private void OnResetSlam()
        {
            // Rokid.UXR.Native.NativeInterface.NativeAPI.Recenter();
            Rokid.XR.Core.ApiLegacy.Recenter();
        }
        private void OnDestroy()
        {
            MessageDispatcher.RemoveListener(ResetRKSlam, OnResetSlam);
        }
    }
}