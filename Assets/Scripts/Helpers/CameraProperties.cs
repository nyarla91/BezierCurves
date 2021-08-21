using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NyarlaEssentials
{
    [RequireComponent(typeof(Camera))]
    public class CameraProperties : Transformer
    {
        public static CameraProperties instance;
        private static Camera _main;
        public static Camera Main => _main ?? (_main = instance.GetComponent<Camera>());
    
        public static Vector3 MousePosition2D => Main.ScreenToWorldPoint(Input.mousePosition);

        public static Vector3 PercentToScreenPoint(Vector2 percent)
        {
            percent += Vector2.one;
            percent /= 2;
            return new Vector2(Screen.width, Screen.height);
        }

        private void Awake()
        {
            instance = this;
        }
    }
}
