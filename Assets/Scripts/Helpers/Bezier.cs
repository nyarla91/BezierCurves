using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Vector3 = UnityEngine.Vector3;

namespace NyarlaEssentials
{
public static class Bezier
{
    public static Vector3 Evaluate(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        // 1st iteration
        Vector3 p01 = Vector3.Lerp(p0, p1, t);
        Vector3 p12 = Vector3.Lerp(p1, p2, t);
        Vector3 p23 = Vector3.Lerp(p2, p3, t);
        // 2nditeration
        Vector3 p012 = Vector3.Lerp(p01, p12, t);
        Vector3 p123 = Vector3.Lerp(p12, p23, t);
        // Result
        return Vector3.Lerp(p012, p123, t);
    }
    
    public static Vector3 Evaluate(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        // 1st iteration
        Vector3 p01 = Vector3.Lerp(p0, p1, t);
        Vector3 p12 = Vector3.Lerp(p1, p2, t);
        // Result
        return Vector3.Lerp(p01, p12, t);
    }
    
    public static Vector3 Evaluate(Vector3[] points, float t)
    {
        for (int i = points.Length - 1; i >= 0; i--)
        {
            for (int j = 0; j < i; j++)
            {
                points[j] = Vector3.Lerp(points[j], points[j + 1], t);
            }
        }
        return points[0];
    }

    public static Vector3[] EvaluatePath(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, int quality)
    {
        quality--;
        if (quality < 1)
            quality = 1;
        Vector3[] result = new Vector3[quality + 1];
        for (int i = 0; i < result.Length; i++)
        {
            float t = (float) i / (float) quality;
            result[i] = Evaluate(p0, p1, p2, p3, t);
        }
        return result;
    }

    public static Vector3[] EvaluatePath(Vector3 p0, Vector3 p1, Vector3 p2, int quality)
    {
        quality--;
        if (quality < 1)
            quality = 1;
        Vector3[] result = new Vector3[quality + 1];
        for (int i = 0; i < result.Length; i++)
        {
            float t = (float) i / (float) quality;
            result[i] = Evaluate(p0, p1, p2, t);
        }
        return result;
    }
}

}