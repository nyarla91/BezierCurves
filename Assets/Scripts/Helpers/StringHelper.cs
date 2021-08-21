using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NyarlaEssentials
{
    public class StringHelper : MonoBehaviour
    {
        public static void Replace(ref string origin, string oldText, string newText)
        {
            origin = origin.Replace(oldText, newText);
        }
    }

}