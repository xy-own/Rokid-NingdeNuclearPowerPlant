using System;
using UnityEngine;
namespace XY.UXR.Gesture.Button
{
    public class BtnItem : MonoBehaviour
    {
        public Action<FingerEvent, Collider> enterAction;
        public Action<FingerEvent, Collider> exitAction;

        public void Enter(FingerEvent finger, Collider go)
        {
            enterAction?.Invoke(finger, go);
        }
        public void Exit(FingerEvent finger, Collider go)
        {
            exitAction?.Invoke(finger, go);
        }
    }
}