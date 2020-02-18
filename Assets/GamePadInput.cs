// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/GamePad.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputPad : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputPad()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GamePad"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""428f1448-3d9f-4349-aa70-4312aeb9e407"",
            ""actions"": [
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""bbf318e0-9213-4390-8f9f-9e7c259eb3cd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""7fb1f022-6b7e-4343-a6e5-f1c15ce75e3f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""9d398e22-fbe6-4423-8165-85ebd833fab7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Time"",
                    ""type"": ""Button"",
                    ""id"": ""39e966a5-7815-4c96-8d98-1bb1baff7681"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ice"",
                    ""type"": ""Button"",
                    ""id"": ""a7900ba3-c1c1-4d8e-8922-d1499da29a2f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Electric"",
                    ""type"": ""Button"",
                    ""id"": ""3a6a7946-62ea-4d6c-ad8d-5e649cb861b2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""d24ac612-8a70-42b2-85d5-8db99c9ab7f7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RunL"",
                    ""type"": ""Button"",
                    ""id"": ""e280ce9f-5ee1-4a05-a358-309fae2cdca1"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RunR"",
                    ""type"": ""Button"",
                    ""id"": ""5329a1bb-0554-448c-9a7d-211465fd71a3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump2"",
                    ""type"": ""Button"",
                    ""id"": ""08afbf05-6927-41dc-83f0-2c4e843669a5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Roll2"",
                    ""type"": ""Button"",
                    ""id"": ""f71d9f17-a042-4178-9b2d-ebadb075ed9b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Time2"",
                    ""type"": ""Button"",
                    ""id"": ""abd9c95b-f50b-49fe-b0ee-d08ecdf05c28"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ice2"",
                    ""type"": ""Button"",
                    ""id"": ""79d4e697-ca3d-4807-8b07-59f9638bdba2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Electric2"",
                    ""type"": ""Button"",
                    ""id"": ""9c670662-4e78-48ac-9af1-32bf7b255a27"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire2"",
                    ""type"": ""Button"",
                    ""id"": ""67dd587e-e8b1-4d53-84a6-aa2c9694cff5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d955cde9-7a45-4082-bfd9-b7bdaa458995"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2dcfa8c3-5fb3-4132-a40a-9d697b5e7b7d"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f927ea89-e303-40ff-b0a0-0896ca950a3a"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""99e8809c-b993-457d-b1f4-56ec7a2e6247"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Time"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""80050aa1-7647-4dc6-bb6c-4c39eb869ab7"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ice"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73243ed2-8f44-4545-a998-24bb97d7f4a1"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Electric"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""25001c4a-6c66-4b14-b487-97e84bab545e"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""53fd98e0-a950-4c8a-89ce-03f01357c759"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RunL"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a05d53eb-800f-4187-8551-dbcee2680284"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RunR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b93693a5-004a-4375-b0ff-3332058a0752"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0cfacca8-d8a8-4b2c-bfd2-3450bf6000c1"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1d456b3-fb71-44cc-a213-264055e7ced1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Time2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc87d905-5643-4fd4-b9f9-89ed610a83ef"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ice2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f60d728-2cc1-4fd5-a027-4562d0d76b3f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Electric2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23d4377d-afab-4235-a01b-b9998071ff1a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""id"": ""153ec28d-abd9-4b2a-9c86-8bbdb2268bae"",
            ""actions"": [
                {
                    ""name"": ""RunL"",
                    ""type"": ""Button"",
                    ""id"": ""e79a0acc-143e-4476-8047-9707c4c427ab"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RunR"",
                    ""type"": ""Button"",
                    ""id"": ""6e58c978-b6a6-420b-aaeb-e28b54e646d7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""35c9c6f0-8c96-48d0-93f6-d50ad4c9fae9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Thunder"",
                    ""type"": ""Button"",
                    ""id"": ""db24e843-7ac5-4b83-ba89-67963a5fbce7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ice"",
                    ""type"": ""Button"",
                    ""id"": ""1e33d20a-e652-4ec0-84d9-44e9cc23738a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e33fab0b-bcbd-4934-a088-e62633ebeb29"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RunL"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9589e0d2-4bb4-40b2-8e6e-2233979680d8"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RunR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04bcf8df-ab46-4b33-ac60-b3c10473d8d4"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ecec24cf-16de-49a5-89e6-b76d58e3e8ac"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Thunder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8deae58-3a36-4c11-9319-41c97a6e4f37"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ice"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Run = m_Gameplay.FindAction("Run", throwIfNotFound: true);
        m_Gameplay_Roll = m_Gameplay.FindAction("Roll", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_Time = m_Gameplay.FindAction("Time", throwIfNotFound: true);
        m_Gameplay_Ice = m_Gameplay.FindAction("Ice", throwIfNotFound: true);
        m_Gameplay_Electric = m_Gameplay.FindAction("Electric", throwIfNotFound: true);
        m_Gameplay_Fire = m_Gameplay.FindAction("Fire", throwIfNotFound: true);
        m_Gameplay_RunL = m_Gameplay.FindAction("RunL", throwIfNotFound: true);
        m_Gameplay_RunR = m_Gameplay.FindAction("RunR", throwIfNotFound: true);
        m_Gameplay_Jump2 = m_Gameplay.FindAction("Jump2", throwIfNotFound: true);
        m_Gameplay_Roll2 = m_Gameplay.FindAction("Roll2", throwIfNotFound: true);
        m_Gameplay_Time2 = m_Gameplay.FindAction("Time2", throwIfNotFound: true);
        m_Gameplay_Ice2 = m_Gameplay.FindAction("Ice2", throwIfNotFound: true);
        m_Gameplay_Electric2 = m_Gameplay.FindAction("Electric2", throwIfNotFound: true);
        m_Gameplay_Fire2 = m_Gameplay.FindAction("Fire2", throwIfNotFound: true);
        // Keyboard
        m_Keyboard = asset.FindActionMap("Keyboard", throwIfNotFound: true);
        m_Keyboard_RunL = m_Keyboard.FindAction("RunL", throwIfNotFound: true);
        m_Keyboard_RunR = m_Keyboard.FindAction("RunR", throwIfNotFound: true);
        m_Keyboard_Jump = m_Keyboard.FindAction("Jump", throwIfNotFound: true);
        m_Keyboard_Thunder = m_Keyboard.FindAction("Thunder", throwIfNotFound: true);
        m_Keyboard_Ice = m_Keyboard.FindAction("Ice", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Run;
    private readonly InputAction m_Gameplay_Roll;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_Time;
    private readonly InputAction m_Gameplay_Ice;
    private readonly InputAction m_Gameplay_Electric;
    private readonly InputAction m_Gameplay_Fire;
    private readonly InputAction m_Gameplay_RunL;
    private readonly InputAction m_Gameplay_RunR;
    private readonly InputAction m_Gameplay_Jump2;
    private readonly InputAction m_Gameplay_Roll2;
    private readonly InputAction m_Gameplay_Time2;
    private readonly InputAction m_Gameplay_Ice2;
    private readonly InputAction m_Gameplay_Electric2;
    private readonly InputAction m_Gameplay_Fire2;
    public struct GameplayActions
    {
        private @InputPad m_Wrapper;
        public GameplayActions(@InputPad wrapper) { m_Wrapper = wrapper; }
        public InputAction @Run => m_Wrapper.m_Gameplay_Run;
        public InputAction @Roll => m_Wrapper.m_Gameplay_Roll;
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @Time => m_Wrapper.m_Gameplay_Time;
        public InputAction @Ice => m_Wrapper.m_Gameplay_Ice;
        public InputAction @Electric => m_Wrapper.m_Gameplay_Electric;
        public InputAction @Fire => m_Wrapper.m_Gameplay_Fire;
        public InputAction @RunL => m_Wrapper.m_Gameplay_RunL;
        public InputAction @RunR => m_Wrapper.m_Gameplay_RunR;
        public InputAction @Jump2 => m_Wrapper.m_Gameplay_Jump2;
        public InputAction @Roll2 => m_Wrapper.m_Gameplay_Roll2;
        public InputAction @Time2 => m_Wrapper.m_Gameplay_Time2;
        public InputAction @Ice2 => m_Wrapper.m_Gameplay_Ice2;
        public InputAction @Electric2 => m_Wrapper.m_Gameplay_Electric2;
        public InputAction @Fire2 => m_Wrapper.m_Gameplay_Fire2;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Run.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRun;
                @Roll.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRoll;
                @Roll.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRoll;
                @Roll.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRoll;
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Time.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTime;
                @Time.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTime;
                @Time.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTime;
                @Ice.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnIce;
                @Ice.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnIce;
                @Ice.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnIce;
                @Electric.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnElectric;
                @Electric.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnElectric;
                @Electric.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnElectric;
                @Fire.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire;
                @RunL.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRunL;
                @RunL.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRunL;
                @RunL.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRunL;
                @RunR.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRunR;
                @RunR.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRunR;
                @RunR.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRunR;
                @Jump2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump2;
                @Jump2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump2;
                @Jump2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump2;
                @Roll2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRoll2;
                @Roll2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRoll2;
                @Roll2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRoll2;
                @Time2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTime2;
                @Time2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTime2;
                @Time2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTime2;
                @Ice2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnIce2;
                @Ice2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnIce2;
                @Ice2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnIce2;
                @Electric2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnElectric2;
                @Electric2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnElectric2;
                @Electric2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnElectric2;
                @Fire2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire2;
                @Fire2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire2;
                @Fire2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire2;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Time.started += instance.OnTime;
                @Time.performed += instance.OnTime;
                @Time.canceled += instance.OnTime;
                @Ice.started += instance.OnIce;
                @Ice.performed += instance.OnIce;
                @Ice.canceled += instance.OnIce;
                @Electric.started += instance.OnElectric;
                @Electric.performed += instance.OnElectric;
                @Electric.canceled += instance.OnElectric;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @RunL.started += instance.OnRunL;
                @RunL.performed += instance.OnRunL;
                @RunL.canceled += instance.OnRunL;
                @RunR.started += instance.OnRunR;
                @RunR.performed += instance.OnRunR;
                @RunR.canceled += instance.OnRunR;
                @Jump2.started += instance.OnJump2;
                @Jump2.performed += instance.OnJump2;
                @Jump2.canceled += instance.OnJump2;
                @Roll2.started += instance.OnRoll2;
                @Roll2.performed += instance.OnRoll2;
                @Roll2.canceled += instance.OnRoll2;
                @Time2.started += instance.OnTime2;
                @Time2.performed += instance.OnTime2;
                @Time2.canceled += instance.OnTime2;
                @Ice2.started += instance.OnIce2;
                @Ice2.performed += instance.OnIce2;
                @Ice2.canceled += instance.OnIce2;
                @Electric2.started += instance.OnElectric2;
                @Electric2.performed += instance.OnElectric2;
                @Electric2.canceled += instance.OnElectric2;
                @Fire2.started += instance.OnFire2;
                @Fire2.performed += instance.OnFire2;
                @Fire2.canceled += instance.OnFire2;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // Keyboard
    private readonly InputActionMap m_Keyboard;
    private IKeyboardActions m_KeyboardActionsCallbackInterface;
    private readonly InputAction m_Keyboard_RunL;
    private readonly InputAction m_Keyboard_RunR;
    private readonly InputAction m_Keyboard_Jump;
    private readonly InputAction m_Keyboard_Thunder;
    private readonly InputAction m_Keyboard_Ice;
    public struct KeyboardActions
    {
        private @InputPad m_Wrapper;
        public KeyboardActions(@InputPad wrapper) { m_Wrapper = wrapper; }
        public InputAction @RunL => m_Wrapper.m_Keyboard_RunL;
        public InputAction @RunR => m_Wrapper.m_Keyboard_RunR;
        public InputAction @Jump => m_Wrapper.m_Keyboard_Jump;
        public InputAction @Thunder => m_Wrapper.m_Keyboard_Thunder;
        public InputAction @Ice => m_Wrapper.m_Keyboard_Ice;
        public InputActionMap Get() { return m_Wrapper.m_Keyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardActions instance)
        {
            if (m_Wrapper.m_KeyboardActionsCallbackInterface != null)
            {
                @RunL.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnRunL;
                @RunL.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnRunL;
                @RunL.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnRunL;
                @RunR.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnRunR;
                @RunR.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnRunR;
                @RunR.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnRunR;
                @Jump.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnJump;
                @Thunder.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnThunder;
                @Thunder.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnThunder;
                @Thunder.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnThunder;
                @Ice.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnIce;
                @Ice.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnIce;
                @Ice.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnIce;
            }
            m_Wrapper.m_KeyboardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @RunL.started += instance.OnRunL;
                @RunL.performed += instance.OnRunL;
                @RunL.canceled += instance.OnRunL;
                @RunR.started += instance.OnRunR;
                @RunR.performed += instance.OnRunR;
                @RunR.canceled += instance.OnRunR;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Thunder.started += instance.OnThunder;
                @Thunder.performed += instance.OnThunder;
                @Thunder.canceled += instance.OnThunder;
                @Ice.started += instance.OnIce;
                @Ice.performed += instance.OnIce;
                @Ice.canceled += instance.OnIce;
            }
        }
    }
    public KeyboardActions @Keyboard => new KeyboardActions(this);
    public interface IGameplayActions
    {
        void OnRun(InputAction.CallbackContext context);
        void OnRoll(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnTime(InputAction.CallbackContext context);
        void OnIce(InputAction.CallbackContext context);
        void OnElectric(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnRunL(InputAction.CallbackContext context);
        void OnRunR(InputAction.CallbackContext context);
        void OnJump2(InputAction.CallbackContext context);
        void OnRoll2(InputAction.CallbackContext context);
        void OnTime2(InputAction.CallbackContext context);
        void OnIce2(InputAction.CallbackContext context);
        void OnElectric2(InputAction.CallbackContext context);
        void OnFire2(InputAction.CallbackContext context);
    }
    public interface IKeyboardActions
    {
        void OnRunL(InputAction.CallbackContext context);
        void OnRunR(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnThunder(InputAction.CallbackContext context);
        void OnIce(InputAction.CallbackContext context);
    }
}
