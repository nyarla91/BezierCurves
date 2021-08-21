using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _nodePrefab;
    [SerializeField] private int _nodes;
    [SerializeField] private bool _loop;

    private void Start()
    {
        if (_nodes <= 0)
            return;
        
        Node firstNode = null;
        Node lastNode = null;
        for (int i = 0; i < _nodes; i++)
        {
            Node newNode = Instantiate(_nodePrefab, transform.position + Vector3.right * i, Quaternion.identity).GetComponent<Node>();
            if (lastNode == null)
            {
                firstNode = lastNode = newNode;
                continue;
            }
            lastNode.AddNode(1);
            lastNode.NextNode = newNode;
            newNode.AddNode(0);
            lastNode = newNode;
        }
        
        if (_loop)
        {
            firstNode.AddNode(0);
            lastNode.AddNode(1);
            lastNode.NextNode = firstNode;
        }
    }
}
