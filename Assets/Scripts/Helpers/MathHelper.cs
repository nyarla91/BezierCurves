using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace NyarlaEssentials
{
    public class MathHelper : MonoBehaviour
    {
        public static void Normalize(ref float value)
        {
            value = Normalize(value);
        }

        public static float Normalize(float value)
        {
            if (value != 0)
                return value / Mathf.Abs(value);
            return 0;
        }

        public static bool InBounds(float number, float max, float min) => (number >= min && number <= max);

        public static bool InBounds(float number, float bound) =>  InBounds(number, bound, -bound);

        public static float Evaluate(float value, float min, float max) => Mathf.Clamp((value - min) / (max - min), 0, 1);

        public static float Snap(float value, float step) => Mathf.Round(value / step) * step;

        public static void Snap(ref float value, float step) => value = Snap(value, step);

        public static float ToThePowerOf(float number, int power)
        {
            float total = number;
            if (power > 0)
            {
                for (int i = 1; i < power; i++)
                    total *= number;
                return total;
            }
            else if (power < 0)
            {
                power = Mathf.Abs(power);
                for (int i = 0; i < power; i++)
                    total /= number;
                return total;
            }
            return 1;
        }
    
        public static int ToPowerOf(int number, int power) => Mathf.RoundToInt(ToPowerOf(number, power));
    }
}