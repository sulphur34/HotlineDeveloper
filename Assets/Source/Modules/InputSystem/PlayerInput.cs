//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Source/Modules/InputSystem/PlayerInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""PlayerDesktop"",
            ""id"": ""ab96bf4f-2e4f-4c7c-811a-fc7f90d9a2c4"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3741c190-b383-494c-b5b2-13758d1f6b0e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""8c26ca00-bf5c-4ccf-bc4b-e13d7b11ab26"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Value"",
                    ""id"": ""b404bfa0-e2a4-4b57-ad71-700ad409a8fe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Pick"",
                    ""type"": ""Button"",
                    ""id"": ""4824ff37-9db0-49c9-b6ab-544d2db68215"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""0f8dded4-217e-4f63-b26c-46c45514d3ac"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Finish"",
                    ""type"": ""Button"",
                    ""id"": ""93782974-52fe-4c22-be6c-5105485623e9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FarLook"",
                    ""type"": ""Value"",
                    ""id"": ""b1bc2b59-7098-45b5-aa01-58af552d409a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""8791d30a-9794-4d58-82eb-ddc0ea21e819"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c535c167-955e-484c-949d-1d1efc12629e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""16c639be-7aea-41ec-81d9-069bd0d3419c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1f8780e7-cbe8-4fee-94cd-336bc542e940"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3ac3fb87-8f21-48f1-b2ef-23e480fd4663"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""202988b6-2ffd-4a78-a34c-46720940e36e"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1a4e23c4-adec-43f8-a42c-80740d792a03"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7f8fdeab-2b04-4e15-b792-5d76914c2aff"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Pick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ec884501-dffd-41ae-b44e-ed0775e6070a"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ebbdc83e-6cd2-423b-8a63-393ad37fe3d6"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Finish"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""One Modifier"",
                    ""id"": ""18a885da-9b8b-4982-8d93-47c8cf13402a"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FarLook"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""45487305-160d-4bd6-80ef-729068debdbd"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FarLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""d22be28c-af62-4009-b120-373b3623a119"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FarLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""PlayerMobile"",
            ""id"": ""13247e43-a93e-4d27-9432-c8ddf8404a3f"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""36fbe9b8-004d-40f7-9e5e-364fca14a372"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""4806f985-3bba-4c3a-b827-3f435c1a9ec6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Value"",
                    ""id"": ""53c435e0-bda3-401e-afb8-29205437d27d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Pick"",
                    ""type"": ""Button"",
                    ""id"": ""baf991b8-dec4-47ce-b189-cd0fc03f8450"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""7ab4ac53-6ade-472f-8e95-7afd3fe5e603"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Finish"",
                    ""type"": ""Button"",
                    ""id"": ""82345cd8-4fae-4a1e-9ca3-d8b8a9d18c1f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FarLook"",
                    ""type"": ""Button"",
                    ""id"": ""bc80aaa6-8618-4554-9bfc-dfe16f7ca6e2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2356b7d6-6d8b-40af-9d04-6100eecea515"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone(max=1)"",
                    ""groups"": ""Mobile"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""41f1cf60-f4de-4969-8dda-fddafd1f65eb"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fbdcd43d-c4ff-4d98-a69b-89d2c706073b"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone(min=0.9,max=1)"",
                    ""groups"": ""Mobile"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""285f0b9d-d468-41bf-9cfc-7cb10e5ce660"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""702193a3-2763-4d5d-9676-02d5c24e341a"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": ""Tap(duration=0.2)"",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""Finish"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1777885-5f9b-4e43-b7c6-8f54295ceb3c"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": ""Tap(duration=0.2)"",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""Pick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""One Modifier"",
                    ""id"": ""b47f614a-680b-43b8-ab03-39ce235462d8"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FarLook"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""2af99236-96d0-4f22-af28-21276561a1bb"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""FarLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""2c9029d8-c7b3-48ef-9dce-b141e4396128"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""FarLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Desktop"",
            ""bindingGroup"": ""Desktop"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Mobile"",
            ""bindingGroup"": ""Mobile"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerDesktop
        m_PlayerDesktop = asset.FindActionMap("PlayerDesktop", throwIfNotFound: true);
        m_PlayerDesktop_Move = m_PlayerDesktop.FindAction("Move", throwIfNotFound: true);
        m_PlayerDesktop_Rotate = m_PlayerDesktop.FindAction("Rotate", throwIfNotFound: true);
        m_PlayerDesktop_Attack = m_PlayerDesktop.FindAction("Attack", throwIfNotFound: true);
        m_PlayerDesktop_Pick = m_PlayerDesktop.FindAction("Pick", throwIfNotFound: true);
        m_PlayerDesktop_Look = m_PlayerDesktop.FindAction("Look", throwIfNotFound: true);
        m_PlayerDesktop_Finish = m_PlayerDesktop.FindAction("Finish", throwIfNotFound: true);
        m_PlayerDesktop_FarLook = m_PlayerDesktop.FindAction("FarLook", throwIfNotFound: true);
        // PlayerMobile
        m_PlayerMobile = asset.FindActionMap("PlayerMobile", throwIfNotFound: true);
        m_PlayerMobile_Move = m_PlayerMobile.FindAction("Move", throwIfNotFound: true);
        m_PlayerMobile_Rotate = m_PlayerMobile.FindAction("Rotate", throwIfNotFound: true);
        m_PlayerMobile_Attack = m_PlayerMobile.FindAction("Attack", throwIfNotFound: true);
        m_PlayerMobile_Pick = m_PlayerMobile.FindAction("Pick", throwIfNotFound: true);
        m_PlayerMobile_Look = m_PlayerMobile.FindAction("Look", throwIfNotFound: true);
        m_PlayerMobile_Finish = m_PlayerMobile.FindAction("Finish", throwIfNotFound: true);
        m_PlayerMobile_FarLook = m_PlayerMobile.FindAction("FarLook", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // PlayerDesktop
    private readonly InputActionMap m_PlayerDesktop;
    private List<IPlayerDesktopActions> m_PlayerDesktopActionsCallbackInterfaces = new List<IPlayerDesktopActions>();
    private readonly InputAction m_PlayerDesktop_Move;
    private readonly InputAction m_PlayerDesktop_Rotate;
    private readonly InputAction m_PlayerDesktop_Attack;
    private readonly InputAction m_PlayerDesktop_Pick;
    private readonly InputAction m_PlayerDesktop_Look;
    private readonly InputAction m_PlayerDesktop_Finish;
    private readonly InputAction m_PlayerDesktop_FarLook;
    public struct PlayerDesktopActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerDesktopActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerDesktop_Move;
        public InputAction @Rotate => m_Wrapper.m_PlayerDesktop_Rotate;
        public InputAction @Attack => m_Wrapper.m_PlayerDesktop_Attack;
        public InputAction @Pick => m_Wrapper.m_PlayerDesktop_Pick;
        public InputAction @Look => m_Wrapper.m_PlayerDesktop_Look;
        public InputAction @Finish => m_Wrapper.m_PlayerDesktop_Finish;
        public InputAction @FarLook => m_Wrapper.m_PlayerDesktop_FarLook;
        public InputActionMap Get() { return m_Wrapper.m_PlayerDesktop; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerDesktopActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerDesktopActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerDesktopActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerDesktopActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Rotate.started += instance.OnRotate;
            @Rotate.performed += instance.OnRotate;
            @Rotate.canceled += instance.OnRotate;
            @Attack.started += instance.OnAttack;
            @Attack.performed += instance.OnAttack;
            @Attack.canceled += instance.OnAttack;
            @Pick.started += instance.OnPick;
            @Pick.performed += instance.OnPick;
            @Pick.canceled += instance.OnPick;
            @Look.started += instance.OnLook;
            @Look.performed += instance.OnLook;
            @Look.canceled += instance.OnLook;
            @Finish.started += instance.OnFinish;
            @Finish.performed += instance.OnFinish;
            @Finish.canceled += instance.OnFinish;
            @FarLook.started += instance.OnFarLook;
            @FarLook.performed += instance.OnFarLook;
            @FarLook.canceled += instance.OnFarLook;
        }

        private void UnregisterCallbacks(IPlayerDesktopActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Rotate.started -= instance.OnRotate;
            @Rotate.performed -= instance.OnRotate;
            @Rotate.canceled -= instance.OnRotate;
            @Attack.started -= instance.OnAttack;
            @Attack.performed -= instance.OnAttack;
            @Attack.canceled -= instance.OnAttack;
            @Pick.started -= instance.OnPick;
            @Pick.performed -= instance.OnPick;
            @Pick.canceled -= instance.OnPick;
            @Look.started -= instance.OnLook;
            @Look.performed -= instance.OnLook;
            @Look.canceled -= instance.OnLook;
            @Finish.started -= instance.OnFinish;
            @Finish.performed -= instance.OnFinish;
            @Finish.canceled -= instance.OnFinish;
            @FarLook.started -= instance.OnFarLook;
            @FarLook.performed -= instance.OnFarLook;
            @FarLook.canceled -= instance.OnFarLook;
        }

        public void RemoveCallbacks(IPlayerDesktopActions instance)
        {
            if (m_Wrapper.m_PlayerDesktopActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerDesktopActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerDesktopActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerDesktopActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerDesktopActions @PlayerDesktop => new PlayerDesktopActions(this);

    // PlayerMobile
    private readonly InputActionMap m_PlayerMobile;
    private List<IPlayerMobileActions> m_PlayerMobileActionsCallbackInterfaces = new List<IPlayerMobileActions>();
    private readonly InputAction m_PlayerMobile_Move;
    private readonly InputAction m_PlayerMobile_Rotate;
    private readonly InputAction m_PlayerMobile_Attack;
    private readonly InputAction m_PlayerMobile_Pick;
    private readonly InputAction m_PlayerMobile_Look;
    private readonly InputAction m_PlayerMobile_Finish;
    private readonly InputAction m_PlayerMobile_FarLook;
    public struct PlayerMobileActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerMobileActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerMobile_Move;
        public InputAction @Rotate => m_Wrapper.m_PlayerMobile_Rotate;
        public InputAction @Attack => m_Wrapper.m_PlayerMobile_Attack;
        public InputAction @Pick => m_Wrapper.m_PlayerMobile_Pick;
        public InputAction @Look => m_Wrapper.m_PlayerMobile_Look;
        public InputAction @Finish => m_Wrapper.m_PlayerMobile_Finish;
        public InputAction @FarLook => m_Wrapper.m_PlayerMobile_FarLook;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMobile; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMobileActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerMobileActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerMobileActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerMobileActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Rotate.started += instance.OnRotate;
            @Rotate.performed += instance.OnRotate;
            @Rotate.canceled += instance.OnRotate;
            @Attack.started += instance.OnAttack;
            @Attack.performed += instance.OnAttack;
            @Attack.canceled += instance.OnAttack;
            @Pick.started += instance.OnPick;
            @Pick.performed += instance.OnPick;
            @Pick.canceled += instance.OnPick;
            @Look.started += instance.OnLook;
            @Look.performed += instance.OnLook;
            @Look.canceled += instance.OnLook;
            @Finish.started += instance.OnFinish;
            @Finish.performed += instance.OnFinish;
            @Finish.canceled += instance.OnFinish;
            @FarLook.started += instance.OnFarLook;
            @FarLook.performed += instance.OnFarLook;
            @FarLook.canceled += instance.OnFarLook;
        }

        private void UnregisterCallbacks(IPlayerMobileActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Rotate.started -= instance.OnRotate;
            @Rotate.performed -= instance.OnRotate;
            @Rotate.canceled -= instance.OnRotate;
            @Attack.started -= instance.OnAttack;
            @Attack.performed -= instance.OnAttack;
            @Attack.canceled -= instance.OnAttack;
            @Pick.started -= instance.OnPick;
            @Pick.performed -= instance.OnPick;
            @Pick.canceled -= instance.OnPick;
            @Look.started -= instance.OnLook;
            @Look.performed -= instance.OnLook;
            @Look.canceled -= instance.OnLook;
            @Finish.started -= instance.OnFinish;
            @Finish.performed -= instance.OnFinish;
            @Finish.canceled -= instance.OnFinish;
            @FarLook.started -= instance.OnFarLook;
            @FarLook.performed -= instance.OnFarLook;
            @FarLook.canceled -= instance.OnFarLook;
        }

        public void RemoveCallbacks(IPlayerMobileActions instance)
        {
            if (m_Wrapper.m_PlayerMobileActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerMobileActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerMobileActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerMobileActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerMobileActions @PlayerMobile => new PlayerMobileActions(this);
    private int m_DesktopSchemeIndex = -1;
    public InputControlScheme DesktopScheme
    {
        get
        {
            if (m_DesktopSchemeIndex == -1) m_DesktopSchemeIndex = asset.FindControlSchemeIndex("Desktop");
            return asset.controlSchemes[m_DesktopSchemeIndex];
        }
    }
    private int m_MobileSchemeIndex = -1;
    public InputControlScheme MobileScheme
    {
        get
        {
            if (m_MobileSchemeIndex == -1) m_MobileSchemeIndex = asset.FindControlSchemeIndex("Mobile");
            return asset.controlSchemes[m_MobileSchemeIndex];
        }
    }
    public interface IPlayerDesktopActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnPick(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnFinish(InputAction.CallbackContext context);
        void OnFarLook(InputAction.CallbackContext context);
    }
    public interface IPlayerMobileActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnPick(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnFinish(InputAction.CallbackContext context);
        void OnFarLook(InputAction.CallbackContext context);
    }
}
