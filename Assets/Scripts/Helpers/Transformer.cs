using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NyarlaEssentials
{
    public class Transformer : MonoBehaviour
    {
        private Transform _transform;
        public new Transform transform => _transform ?? (_transform = gameObject.transform);
    
        private RectTransform _rectTransform;
        public RectTransform rectTransform => _rectTransform ?? (_rectTransform = GetComponent<RectTransform>());
    }

}