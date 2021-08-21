using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NyarlaEssentials
{
    public struct Watch<T>
    {
        private T _v;
        public T V
        {
            get => _v;
            set
            {
                if (!value.Equals(_v))
                {
                    _v = value;
                    OnChanged(_v);
                }
            }
        }

        public delegate void ChangedHandler(T newValue);
        public ChangedHandler OnChanged;
    }

}