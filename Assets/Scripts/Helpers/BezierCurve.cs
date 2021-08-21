using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace NyarlaEssentials
{
public class BezierCurve
{
    public Vector3[] points;
    public Vector3[] LastPath { private set; get; }

    public BezierCurve(Vector3[] points)
    {
        this.points = points;
    }

    public Vector3 Evaluate(float t)
    {
        Vector3[] previousPoints = points;
        for (int i = previousPoints.Length - 1; i > 0; i--)
        {
            Vector3[] newPoints = new Vector3[i];
            for (int j = 0; j < i; j++)
            {
                newPoints[j] = Vector3.Lerp(previousPoints[j], previousPoints[j + 1], t);
            }
            previousPoints = newPoints;
        }
        return previousPoints[0];
    }

    public Vector3[] EvaluatePath(int quality)
    {
        quality--;
        if (quality < 1)
            quality = 1;
        Vector3[] result = new Vector3[quality + 1];
        for (int i = 0; i < result.Length; i++)
        {
            float t = (float) i / (float) quality;
            result[i] = Evaluate(t);
        }
        return LastPath = result;
    }

    public Vector3[] ExtrudePath(float width)
    {
        if (LastPath == null)
            throw new Exception("No path has been calculated so far");
        return ExtrudePath(LastPath, width);
    }

    public static Vector3[] ExtrudePath(Vector3[] path, float width)
    {
        Vector3[] result = new Vector3[path.Length];
        for (int i = 0; i < path.Length; i++)
        {
            Vector3 direction = i < path.Length - 1 ? path[i + 1] - path[i] : path[i] - path[i - 1];
            Vector3 normal = VectorHelper.Rotate(direction, 90).normalized;
            result[i] = path[i] + normal * width;
        }
        return result;
    }

    public float PathLength(int quality)
    {
        if (LastPath == null)
            EvaluatePath(quality);
        float result = 0;
        for (int i = 1; i < LastPath.Length; i++)
        {
            result += Vector2.Distance(LastPath[i - 1], LastPath[i]);
        }
        return result;
    }
}

}