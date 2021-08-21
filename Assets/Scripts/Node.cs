using System;
using System.Collections;
using System.Collections.Generic;
using NyarlaEssentials;
using NyarlaEssentials.Clicks;
using UnityEngine;
using Random = UnityEngine.Random;

public class Node : Transformer
{
    private ClickableObject _clickable;
    [SerializeField] private GameObject _alignPrefab;
    [SerializeField] private GameObject _linePrefab;
    [SerializeField] private int _quality;
    [SerializeField] private float _thickness;
    public Node NextNode { get; set; }
    private Align[] _aligns = new Align[2];
    private List<LineRenderer> _lines = new List<LineRenderer>();

    private bool Draw
    {
        get
        {
            bool result = NextNode != null;
            foreach (var line in _lines)
            {
                line.enabled = result;
            }
            return result;
        }
    }

    private void Awake()
    {
        _clickable = GetComponent<ClickableObject>();
        _clickable.OnDrag += Drag;
        _clickable.OnClick += ResetNodes;
        for (int i = 0; i < 3; i++)
        {
            _lines.Add(Instantiate(_linePrefab, transform.position, Quaternion.identity).GetComponent<LineRenderer>());
        }
    }

    private void Update()
    {
        if (!Draw)
            return;
        BezierCurve bezier = new BezierCurve(new Vector3[4]);
        bezier.points[0] = transform.position;
        bezier.points[1] = _aligns[1].transform.position;
        bezier.points[2] = NextNode._aligns[0].transform.position;
        bezier.points[3] = NextNode.transform.position;
        print(bezier.EvaluatePath(5)[2]);
        Vector3[] path = bezier.EvaluatePath(_quality);
        for (int i = 0; i < path.Length; i++)
        {
            path[i].z = 50;
        }
        for (int i = 0; i < _lines.Count; i++)
        {
            _lines[i].positionCount = _quality;
            //_lines[i].SetPositions(positions);
            _lines[i].SetPositions(BezierCurve.ExtrudePath(path, _thickness * (i - 1)));
        }
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
