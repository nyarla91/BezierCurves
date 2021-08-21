using System;
using System.Collections;
using System.Collections.Generic;
using NyarlaEssentials;
using NyarlaEssentials.Clicks;
using UnityEngine;

public class Node : Transformer
{
    private ClickableObject _clickable;
    [SerializeField] private GameObject _alignPrefab;
    [SerializeField] private LineRenderer _line;
    [SerializeField] private int _quality;
    public Node NextNode { get; set; }
    private Align[] _aligns = new Align[2];

    private bool Draw => _line.enabled = NextNode != null;

    private void Awake()
    {
        _clickable = GetComponent<ClickableObject>();
        _clickable.OnDrag += Drag;
        _clickable.OnClick += ResetNodes;
    }

    private void Update()
    {
        if (!Draw)
            return;
        Vector3 p0 = transform.position;
        Vector3 p1 = _aligns[1].transform.position;
        Vector3 p2 = NextNode._aligns[0].transform.position;
        Vector3 p3 = NextNode.transform.position;
        Vector3[] positions = Bezier.EvaluatePath(p0, p1, p2, p3, _quality);
        for (int i = 0; i < positions.Length; i++)
        {
            positions[i].z = 50;
        }
        _line.positionCount = _quality;
        _line.SetPositions(positions);
    }

    private void Drag(MouseButton button)
    {
        if (button == MouseButton.Middle)
            return;
        
        Vector3 delta = VectorHelper.SetZ(CameraProperties.MousePosition2D, -1) - transform.position;
        transform.position += delta;
        if (button == MouseButton.Left)
            foreach (var align in _aligns)
            {
                if (align != null)
                    align.transform.position += delta;
            }
    }

    public void AddNode(int index)
    {
        index = Mathf.Clamp(index, 0, 1);
        if (_aligns[index] != null)
            return;
        _aligns[index] = Instantiate(_alignPrefab, transform.position + Vector3.up * (index - 0.5f), Quaternion.identity).GetComponent<Align>();
        _aligns[index].parentNode = this;
        if (_aligns[0] != null && _aligns[1] != null)
        {
            _aligns[0].revertedAlign = _aligns[1];
            _aligns[1].revertedAlign = _aligns[0];
        }
    }

    private void ResetNodes(MouseButton button)
    {
        if (button != MouseButton.Middle)
            return;

        for (int i = 0; i < _aligns.Length; i++)
        {
            if (_aligns[i] != null)
                _aligns[i].transform.position = transform.position + Vector3.up * (i - 0.5f);
        }
    }
}
