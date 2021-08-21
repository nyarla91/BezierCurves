using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using MouseButton = NyarlaEssentials.Clicks.MouseButton;

namespace NyarlaEssentials.Clicks
{
    public class CameraClicks : MonoBehaviour
    {
        private enum MouseAction
        {
            Down,
            Up,
            Click,
            Hover,
        
        }
        private enum DetectionType
        {
            Overlap2D,
            Paycast3D
        }

        public static CameraClicks instance;

        [SerializeField] private DetectionType _detectionType;
        
        public List<ClickableObject> clickables = new List<ClickableObject>();
        
        private MouseActions _mouseActions;

        private void Awake()
        {
            instance = this;
            _mouseActions = new MouseActions();
            _mouseActions.Enable();
            #region Callbacks subscribe
            // Actions
            _mouseActions.All.LeftMouse.started += ctx => PerformAction(MouseButton.Left, MouseAction.Down);
            _mouseActions.All.LeftMouse.canceled += ctx => PerformAction(MouseButton.Left, MouseAction.Up);
            _mouseActions.All.LeftClick.performed += ctx => PerformAction(MouseButton.Left, MouseAction.Click);
            _mouseActions.All.RightMouse.started += ctx => PerformAction(MouseButton.Right, MouseAction.Down);
            _mouseActions.All.RightMouse.canceled += ctx => PerformAction(MouseButton.Right, MouseAction.Up);
            _mouseActions.All.RightClick.performed += ctx => PerformAction(MouseButton.Right, MouseAction.Click);
            _mouseActions.All.MiddleMouse.started += ctx => PerformAction(MouseButton.Middle, MouseAction.Down);
            _mouseActions.All.MiddleMouse.canceled += ctx => PerformAction(MouseButton.Middle, MouseAction.Up);
            _mouseActions.All.MiddleClick.performed += ctx => PerformAction(MouseButton.Middle, MouseAction.Click);
            // Drag end
            _mouseActions.All.LeftMouse.canceled += ctx => DragEnd(MouseButton.Left);
            _mouseActions.All.RightMouse.canceled += ctx => DragEnd(MouseButton.Right);
            _mouseActions.All.MiddleMouse.canceled += ctx => DragEnd(MouseButton.Middle);
            #endregion
        }

        private void PerformAction(MouseButton button, MouseAction action)
        {
            ClickableObject target = Raycast();
            if (target == null)
                return;
            switch (action)
            {
                case MouseAction.Down:
                {
                    target.OnDown(button);
                    break;
                }
                case MouseAction.Up:
                {
                    target.OnUp(button);
                    break;
                }
                case MouseAction.Click:
                {
                    target.OnClick(button);
                    break;
                }
            }
        }

        private void DragEnd(MouseButton button)
        {
            foreach (var clickable in clickables)
            {
                if (clickable != null)
                    clickable.TryEndDrag(button);
            }
        }

        private ClickableObject Raycast()
        {
            if (_detectionType == DetectionType.Overlap2D)
            {
                Collider2D[] colliders = Physics2D.OverlapPointAll(CameraProperties.MousePosition2D);
                if (colliders.Length > 0)
                {
                    colliders.OrderBy(collider => -collider.transform.position.z);
                    return colliders[0].GetComponent<ClickableObject>();
                }
            }
            else
            {
                Ray ray = CameraProperties.Main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    return hit.collider.GetComponent<ClickableObject>();
                }
            }
            return null;
        }
    }

    public enum MouseButton
    {
        Left,
        Right,
        Middle
    }
}