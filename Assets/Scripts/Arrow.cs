using System;
using System.Collections;
using System.Collections.Generic;
using NyarlaEssentials;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private LineRenderer _line;
    [SerializeField] private int _quality;
    [SerializeField] private Vector2 _alignModifier;
    
    private void Update()
    {
        Vector3 targetPoint = VectorHelper.SetZ(CameraProperties.MousePosition2D, transform.position.z);
        Vector3 alignPoint = targetPoint * _alignModifier;
        alignPoint.z = transform.position.z;
        Vector3[] curve = Bezier.EvaluatePath(transform.position, alignPoint, targetPoint, _quality);
        _line.positionCount = curve.Length;
        _line.SetPositions(curve);
    }
}
