using System;
using System.Collections;
using System.Collections.Generic;
using NyarlaEssentials;
using NyarlaEssentials.Clicks;
using UnityEngine;

public class Align : Transformer
{
    private ClickableObject _clickable;
    [SerializeField] private Gradient _originColor;
    [SerializeField] private Gradient _endColor;
    [SerializeField] private LineRenderer _line;

    public Align revertedAlign;
    public Node parentNode;

    private float lastAngle;
    private float lastDistance;

    private void Awake()
    {
        _clickable = GetComponent<ClickableObject>();
        _clickable.OnDown += StartDrag;
        _clickable.OnDrag += Drag;
    }

    private void Update()
    {
        _line.positionCount = 2;
        _line.SetPosition(0, transform.position);
        _line.SetPosition(1, parentNode.transform.position);
    }

    private void StartDrag(MouseButton button)
    {
        if (button == MouseButton.Middle)
            return;
        
        lastAngle = VectorHelper.Vector2ToDegrees(transform.position - parentNode.transform.position);
        lastDistance = Vector2.Distance(transform.position, parentNode.transform.position);
    }

    public void SetDirection(bool origin)
    {
        if (origin)
            _line.colorGradient = _originColor;
        else
            _line.colorGradient = _endColor;
    }

    private void Drag(MouseButton button)
    {
        if (button == MouseButton.Middle)
            return;

        Vector3 newPosition = VectorHelper.SetZ(CameraProperties.MousePosition2D, -1);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            float newDistance = Vector2.Distance(newPosition, parentNode.transform.position);
            print(newDistance);
            newPosition = parentNode.transform.position + (Vector3) VectorHelper.DegreesToVector2(lastAngle) * newDistance;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            float newAngle = VectorHelper.Vector2ToDegrees(newPosition - parentNode.transform.position);
            print(newAngle);
            newPosition = parentNode.transform.position + (Vector3) VectorHelper.DegreesToVector2(newAngle) * lastDistance;
        }
        transform.position = VectorHelper.SetZ(newPosition, -1);
        if (revertedAlign != null && button == MouseButton.Left)
        {
            Vector3 deltaFromParent = transform.position - parentNode.transform.position;
            revertedAlign.transform.position = parentNode.transform.position - deltaFromParent;
        }
    }
}
