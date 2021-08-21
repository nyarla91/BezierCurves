using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NyarlaEssentials
{
    public class CollectionHelper : MonoBehaviour
    {
        public static List<T> ChooseRandomElements<T>(List<T> collection, int ammount)
        {
            List<T> choosed = new List<T>();
            for (int i = 0; i < ammount; i++)
            {
                if (collection.Count > 0)
                {
                    T element = collection[Random.Range(0, collection.Count)];
                    choosed.Add(element);
                    collection.Remove(element);
                }
                else
                {
                    break;
                }
            }
            return choosed;
        }

        public static T ChooseRandomElement<T>(List<T> collection)
        {
            if (collection.Count <= 0)
                throw new IndexOutOfRangeException();
            return collection[Random.Range(0, collection.Count)];
        }
    }
}
