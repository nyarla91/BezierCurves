using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NyarlaEssentials
{
    public static class VectorHelper
    {
        public static Dictionary<Axis, Vector2> Axes2
        {
            get
            {
                Dictionary<Axis, Vector2> result = new Dictionary<Axis, Vector2>();
                result.Add(Axis.X, Vector2.right);
                result.Add(Axis.Y, Vector2.up);
                return result;
            }
        }
        public static Dictionary<Axis, Vector3> Axes3
        {
            get
            {
                Dictionary<Axis, Vector3> result = new Dictionary<Axis, Vector3>();
                result.Add(Axis.X, Vector3.right);
                result.Add(Axis.Y, Vector3.up);
                result.Add(Axis.Z, Vector3.forward);
                return result;
            }
        }
        
        public static Vector2 SetX(Vector2 vector, float value) => new Vector2(value, vector.y);

        public static void SetX(ref Vector2 vector, float value)
        {
            vector = SetX(vector, value);
        }

        public static Vector2 SetY(Vector2 vector, float value) => new Vector2(vector.x, value);

        public static void SetY(ref Vector2 vector, float value)
        {
            vector = SetY(vector, value);
        }

        public static Vector3 SetX(Vector3 vector, float value) => new Vector3(value, vector.y, vector.z);

        public static void SetX(ref Vector3 vector, float value)
        {
            vector = SetX(vector, value);
        }

        public static Vector3 SetY(Vector3 vector, float value) => new Vector3(vector.x, value, vector.z);

        public static void SetY(ref Vector3 vector, float value)
        {
            vector = SetY(vector, value);
        }

        public static Vector3 SetZ(Vector3 vector, float value) => new Vector3(vector.x, vector.y, value);

        public static void SetZ(ref Vector3 vector, float value)
        {
            vector = SetZ(vector, value);
        }

        public static Color SetA(Color color, float value) => new Color(color.r, color.g, color.b, value);

        public static void SetA(ref Color color, float value)
        {
            color = SetA(color, value);
        }

        public static Vector2 DegreesToVector2(float z) =>
            new Vector2(Mathf.Cos(z * Mathf.Deg2Rad), Mathf.Sin(z * Mathf.Deg2Rad));

        public static float Vector2ToDegrees(Vector2 vector)
        {
            vector.Normalize();
            return Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        }

        public static void Rotate(ref Vector2 vector, float degrees)
        {
            float oldDegrees = Vector2ToDegrees(vector);
            float oldDistance = Vector2.Distance(Vector2.zero, vector);
            vector = DegreesToVector2(oldDegrees + degrees) * oldDistance;
        }

        public static Vector2 Rotate(Vector2 vector, float degrees)
        {
            Rotate(ref vector, degrees);
            return vector;
        }

        public static Transform LookAt2D(Transform targetTransform, Vector2 lookAtPosition)
        {
            Vector2 direction = (lookAtPosition - (Vector2) targetTransform.position).normalized;
            targetTransform.rotation = Quaternion.Euler(0, 0, Vector2ToDegrees(direction));
            return targetTransform;
        }

        public static void SnapToGrid(ref Vector2 point, Vector2 gridSize)
        {
            float x = point.x;
            float y = point.y;
            MathHelper.Snap(ref x, gridSize.x);
            MathHelper.Snap(ref y, gridSize.y);
            point = new Vector2(x, y);
        }

        public static Vector2 SnapToGrid(Vector2 point, Vector2 gridSize)
        {
            SnapToGrid(ref point, gridSize);
            return point;
        }

        public static Vector2 Clamp(Vector2 vector, Vector2 minValues, Vector2 maxValues)
        {
            vector.x = Mathf.Clamp(vector.x, minValues.x, maxValues.x);
            vector.y = Mathf.Clamp(vector.y, minValues.y, maxValues.y);
            return vector;
        }

        public static void Clamp(ref Vector2 vector, Vector2 minValues, Vector2 maxValues)
        {
            vector = Clamp(vector, minValues, maxValues);
        }

        public static Vector2 XZtoXY(Vector3 vector)
        {
            return new Vector2(vector.x, vector.z);
        }

        public static Vector3 XYtoXZ(Vector2 vector)
        {
            return new Vector3(vector.x, 0, vector.y);
        }
    }

    public enum Axis
    {
        X,
        Y,
        Z
    }

}