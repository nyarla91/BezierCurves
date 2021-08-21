using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NyarlaEssentials.Clicks
{
public class ClickableObject : MonoBehaviour
{
    [SerializeField] private float _dragPeriod;
    
    public delegate void MouseActionHandler(MouseButton button);
    public MouseActionHandler OnDown, OnUp, OnClick, OnDrag, OnDragEnd;

    private Dictionary<MouseButton, Coroutine> _dragCoroutines = new Dictionary<MouseButton, Coroutine>();

    private void Awake()
    {
        CameraClicks.instance.clickables.Add(this);
        #region Plug subscribe
        OnDown += Plug;
        OnUp += Plug;
        OnClick += Plug;
        OnDrag += Plug;
        OnDragEnd += Plug;
        #endregion
        OnDown += button => _dragCoroutines.Add(button, StartCoroutine(Drag(button)));
    }

    private void Plug(MouseButton button)
    {
        
    }

    private IEnumerator Drag(MouseButton button)
    {
        while (true)
        {
            OnDrag(button);
            if (_dragPeriod > 0)
                yield return new WaitForSeconds(_dragPeriod);
            else
                yield return null;
        }
            
    }

    public void TryEndDrag(MouseButton button)
    {
        if (_dragCoroutines.ContainsKey(button) && _dragCoroutines[button] != null)
        {
            StopCoroutine(_dragCoroutines[button]);
            _dragCoroutines.Remove(button);
            OnDragEnd(button);
        }
    }

    private void OnDestroy()
    {
        CameraClicks.instance.clickables.Remove(this);
    }
}

}