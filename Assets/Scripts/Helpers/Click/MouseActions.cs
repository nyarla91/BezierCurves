// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Helpers/Click/MouseActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MouseActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MouseActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MouseActions"",
    ""maps"": [
        {
            ""name"": ""All"",
            ""id"": ""c300bc73-4668-49d3-91c2-aedaffaa4784"",
            ""actions"": [
                {
                    ""name"": ""LeftClick"",
                    ""type"": ""Button"",
                    ""id"": ""a3d04975-5c73-4b4c-a6ca-95bd970b9354"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""Button"",
                    ""id"": ""360009cd-f1d6-4a66-b1a7-faa27247a94d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MiddleClick"",
                    ""type"": ""Button"",
                    ""id"": ""075f7738-b300-4335-99df-3a02594ec32e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftMouse"",
                    ""type"": ""Button"",
                    ""id"": ""6e55d6eb-e88f-41cb-914f-6577ad843f54"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightMouse"",
                    ""type"": ""Button"",
                    ""id"": ""489b67ca-1431-4540-bad4-826db9efc61f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MiddleMouse"",
                    ""type"": ""Button"",
                    ""id"": ""2a01e055-7e9b-489a-9077-2e4c31f5b215"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b17660e8-0230-4b96-8f64-be401d059b17"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""LeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""87961dac-ff92-4899-8d84-c01efaf5ad21"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ba87b9f4-d9a7-4f4f-82b6-70b9c283b44c"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""MiddleClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d816cfc-cb8b-405e-b24d-492c94073b37"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""LeftMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4deb0c1d-68f7-42e4-b898-df7e3f4b9c1f"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""RightMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""29db7115-caa8-41e7-89eb-b81043cf97fa"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""MiddleMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse"",
            ""bindingGroup"": ""Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // All
        m_All = asset.FindActionMap("All", throwIfNotFound: true);
        m_All_LeftClick = m_All.FindAction("LeftClick", throwIfNotFound: true);
        m_All_RightClick = m_All.FindAction("RightClick", throwIfNotFound: true);
        m_All_MiddleClick = m_All.FindAction("MiddleClick", throwIfNotFound: true);
        m_All_LeftMouse = m_All.FindAction("LeftMouse", throwIfNotFound: true);
        m_All_RightMouse = m_All.FindAction("RightMouse", throwIfNotFound: true);
        m_All_MiddleMouse = m_All.FindAction("MiddleMouse", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // All
    private readonly InputActionMap m_All;
    private IAllActions m_AllActionsCallbackInterface;
    private readonly InputAction m_All_LeftClick;
    private readonly InputAction m_All_RightClick;
    private readonly InputAction m_All_MiddleClick;
    private readonly InputAction m_All_LeftMouse;
    private readonly InputAction m_All_RightMouse;
    private readonly InputAction m_All_MiddleMouse;
    public struct AllActions
    {
        private @MouseActions m_Wrapper;
        public AllActions(@MouseActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftClick => m_Wrapper.m_All_LeftClick;
        public InputAction @RightClick => m_Wrapper.m_All_RightClick;
        public InputAction @MiddleClick => m_Wrapper.m_All_MiddleClick;
        public InputAction @LeftMouse => m_Wrapper.m_All_LeftMouse;
        public InputAction @RightMouse => m_Wrapper.m_All_RightMouse;
        public InputAction @MiddleMouse => m_Wrapper.m_All_MiddleMouse;
        public InputActionMap Get() { return m_Wrapper.m_All; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AllActions set) { return set.Get(); }
        public void SetCallbacks(IAllActions instance)
        {
            if (m_Wrapper.m_AllActionsCallbackInterface != null)
            {
                @LeftClick.started -= m_Wrapper.m_AllActionsCallbackInterface.OnLeftClick;
                @LeftClick.performed -= m_Wrapper.m_AllActionsCallbackInterface.OnLeftClick;
                @LeftClick.canceled -= m_Wrapper.m_AllActionsCallbackInterface.OnLeftClick;
                @RightClick.started -= m_Wrapper.m_AllActionsCallbackInterface.OnRightClick;
                @RightClick.performed -= m_Wrapper.m_AllActionsCallbackInterface.OnRightClick;
                @RightClick.canceled -= m_Wrapper.m_AllActionsCallbackInterface.OnRightClick;
                @MiddleClick.started -= m_Wrapper.m_AllActionsCallbackInterface.OnMiddleClick;
                @MiddleClick.performed -= m_Wrapper.m_AllActionsCallbackInterface.OnMiddleClick;
                @MiddleClick.canceled -= m_Wrapper.m_AllActionsCallbackInterface.OnMiddleClick;
                @LeftMouse.started -= m_Wrapper.m_AllActionsCallbackInterface.OnLeftMouse;
                @LeftMouse.performed -= m_Wrapper.m_AllActionsCallbackInterface.OnLeftMouse;
                @LeftMouse.canceled -= m_Wrapper.m_AllActionsCallbackInterface.OnLeftMouse;
                @RightMouse.started -= m_Wrapper.m_AllActionsCallbackInterface.OnRightMouse;
                @RightMouse.performed -= m_Wrapper.m_AllActionsCallbackInterface.OnRightMouse;
                @RightMouse.canceled -= m_Wrapper.m_AllActionsCallbackInterface.OnRightMouse;
                @MiddleMouse.started -= m_Wrapper.m_AllActionsCallbackInterface.OnMiddleMouse;
                @MiddleMouse.performed -= m_Wrapper.m_AllActionsCallbackInterface.OnMiddleMouse;
                @MiddleMouse.canceled -= m_Wrapper.m_AllActionsCallbackInterface.OnMiddleMouse;
            }
            m_Wrapper.m_AllActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftClick.started += instance.OnLeftClick;
                @LeftClick.performed += instance.OnLeftClick;
                @LeftClick.canceled += instance.OnLeftClick;
                @RightClick.started += instance.OnRightClick;
                @RightClick.performed += instance.OnRightClick;
                @RightClick.canceled += instance.OnRightClick;
                @MiddleClick.started += instance.OnMiddleClick;
                @MiddleClick.performed += instance.OnMiddleClick;
                @MiddleClick.canceled += instance.OnMiddleClick;
                @LeftMouse.started += instance.OnLeftMouse;
                @LeftMouse.performed += instance.OnLeftMouse;
                @LeftMouse.canceled += instance.OnLeftMouse;
                @RightMouse.started += instance.OnRightMouse;
                @RightMouse.performed += instance.OnRightMouse;
                @RightMouse.canceled += instance.OnRightMouse;
                @MiddleMouse.started += instance.OnMiddleMouse;
                @MiddleMouse.performed += instance.OnMiddleMouse;
                @MiddleMouse.canceled += instance.OnMiddleMouse;
            }
        }
    }
    public AllActions @All => new AllActions(this);
    private int m_MouseSchemeIndex = -1;
    public InputControlScheme MouseScheme
    {
        get
        {
            if (m_MouseSchemeIndex == -1) m_MouseSchemeIndex = asset.FindControlSchemeIndex("Mouse");
            return asset.controlSchemes[m_MouseSchemeIndex];
        }
    }
    public interface IAllActions
    {
        void OnLeftClick(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
        void OnMiddleClick(InputAction.CallbackContext context);
        void OnLeftMouse(InputAction.CallbackContext context);
        void OnRightMouse(InputAction.CallbackContext context);
        void OnMiddleMouse(InputAction.CallbackContext context);
    }
}
