// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControlNew : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControlNew()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControl"",
    ""maps"": [
        {
            ""name"": ""PlayerControl"",
            ""id"": ""3d057d10-e242-42e0-8d0c-68d344b77def"",
            ""actions"": [
                {
                    ""name"": ""PlayerMovement"",
                    ""type"": ""Value"",
                    ""id"": ""4052ade5-8521-499e-9959-caec2a1bbb4e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PlayerHeight"",
                    ""type"": ""Value"",
                    ""id"": ""aa24a619-f6c7-424a-91b1-b6a50a2a5186"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PlayerAudio"",
                    ""type"": ""Button"",
                    ""id"": ""1fa1224a-271c-48ac-b30b-c5a60a10e2a5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PauseGame"",
                    ""type"": ""Button"",
                    ""id"": ""ffd92ca2-e242-4c67-83f1-640a6da17940"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""wsad"",
                    ""id"": ""26db1138-e30c-4ecb-aeb5-94fa5a816cd2"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2268412c-758d-43a8-822e-18785a1e2dc3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f08be383-8ef0-45f0-8895-7f01308b6270"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""228a2c17-755f-49be-8ffb-c4d442fc4037"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""10d51e97-09a3-4296-9f5e-06457009f548"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""db9cd6fb-81c4-444b-b006-d2798aec94d0"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MobileInput"",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ecfdf42-165a-4a44-a44b-5d027ab0e6ed"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MobileInput"",
                    ""action"": ""PlayerHeight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf3d071b-0dbb-4e60-83f6-8d2fa91d5bd6"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""PlayerAudio"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""403d17a9-43f6-405f-84ba-97d4ac01b251"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MobileInput;Keyboard"",
                    ""action"": ""PlayerAudio"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""991d8d5b-6675-4256-9bd4-682951b3a015"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""TestPlayer"",
            ""id"": ""4c60243f-4a87-4aa7-9408-442f02bb2bc3"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""b02edb2e-2163-4625-b7f2-88f5fd09dccb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PlayerMove"",
                    ""type"": ""Button"",
                    ""id"": ""1ae8f252-25b1-4667-bdf3-f971c716accc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""e1abf866-d5eb-4a4a-b68e-bf74d7c757b5"",
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
                    ""id"": ""98a0f6d0-1ec4-4ad8-b9c0-0ddc66f036d1"",
                    ""path"": ""<Keyboard>/#(W)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7bdca648-6d90-456a-ac43-ac0952d531e8"",
                    ""path"": ""<Keyboard>/#(S)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b7bc38f3-be1f-453d-ab70-ec152a998be2"",
                    ""path"": ""<Keyboard>/#(A)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""efea1ddf-1f56-4f3e-a377-45e39811eff9"",
                    ""path"": ""<Keyboard>/#(D)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""fac6d4fa-5a51-427a-af5d-ea9d75a41dcc"",
                    ""path"": ""<XInputController>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Devices"",
                    ""action"": ""PlayerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7445e703-5fd4-4c8c-9cb7-a860e6bb45d3"",
                    ""path"": ""<XInputController>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Devices"",
                    ""action"": ""PlayerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""67586ea7-eddc-4e1b-a425-edc27ca25811"",
                    ""path"": ""<XInputController>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Devices"",
                    ""action"": ""PlayerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f48cd25c-4b83-452e-969a-d4830b432944"",
                    ""path"": ""<XInputController>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Devices"",
                    ""action"": ""PlayerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""effde9b4-9969-481a-b901-f32c9c1aff15"",
                    ""path"": ""<Keyboard>/#(W)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Devices"",
                    ""action"": ""PlayerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""91f7ab09-708a-4680-aafa-b71209b48b7c"",
                    ""path"": ""<Keyboard>/#(A)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Devices"",
                    ""action"": ""PlayerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35f169f5-ee8e-4437-ad58-874c845624ce"",
                    ""path"": ""<Keyboard>/#(S)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Devices"",
                    ""action"": ""PlayerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c5cb98e1-a999-46fd-bc42-2295185b943f"",
                    ""path"": ""<Keyboard>/#(D)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Devices"",
                    ""action"": ""PlayerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""MobileInput"",
            ""bindingGroup"": ""MobileInput"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Devices"",
            ""bindingGroup"": ""Devices"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerControl
        m_PlayerControl = asset.FindActionMap("PlayerControl", throwIfNotFound: true);
        m_PlayerControl_PlayerMovement = m_PlayerControl.FindAction("PlayerMovement", throwIfNotFound: true);
        m_PlayerControl_PlayerHeight = m_PlayerControl.FindAction("PlayerHeight", throwIfNotFound: true);
        m_PlayerControl_PlayerAudio = m_PlayerControl.FindAction("PlayerAudio", throwIfNotFound: true);
        m_PlayerControl_PauseGame = m_PlayerControl.FindAction("PauseGame", throwIfNotFound: true);
        // TestPlayer
        m_TestPlayer = asset.FindActionMap("TestPlayer", throwIfNotFound: true);
        m_TestPlayer_Move = m_TestPlayer.FindAction("Move", throwIfNotFound: true);
        m_TestPlayer_PlayerMove = m_TestPlayer.FindAction("PlayerMove", throwIfNotFound: true);
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

    // PlayerControl
    private readonly InputActionMap m_PlayerControl;
    private IPlayerControlActions m_PlayerControlActionsCallbackInterface;
    private readonly InputAction m_PlayerControl_PlayerMovement;
    private readonly InputAction m_PlayerControl_PlayerHeight;
    private readonly InputAction m_PlayerControl_PlayerAudio;
    private readonly InputAction m_PlayerControl_PauseGame;
    public struct PlayerControlActions
    {
        private @PlayerControlNew m_Wrapper;
        public PlayerControlActions(@PlayerControlNew wrapper) { m_Wrapper = wrapper; }
        public InputAction @PlayerMovement => m_Wrapper.m_PlayerControl_PlayerMovement;
        public InputAction @PlayerHeight => m_Wrapper.m_PlayerControl_PlayerHeight;
        public InputAction @PlayerAudio => m_Wrapper.m_PlayerControl_PlayerAudio;
        public InputAction @PauseGame => m_Wrapper.m_PlayerControl_PauseGame;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlActions instance)
        {
            if (m_Wrapper.m_PlayerControlActionsCallbackInterface != null)
            {
                @PlayerMovement.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnPlayerMovement;
                @PlayerMovement.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnPlayerMovement;
                @PlayerMovement.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnPlayerMovement;
                @PlayerHeight.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnPlayerHeight;
                @PlayerHeight.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnPlayerHeight;
                @PlayerHeight.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnPlayerHeight;
                @PlayerAudio.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnPlayerAudio;
                @PlayerAudio.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnPlayerAudio;
                @PlayerAudio.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnPlayerAudio;
                @PauseGame.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnPauseGame;
                @PauseGame.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnPauseGame;
                @PauseGame.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnPauseGame;
            }
            m_Wrapper.m_PlayerControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PlayerMovement.started += instance.OnPlayerMovement;
                @PlayerMovement.performed += instance.OnPlayerMovement;
                @PlayerMovement.canceled += instance.OnPlayerMovement;
                @PlayerHeight.started += instance.OnPlayerHeight;
                @PlayerHeight.performed += instance.OnPlayerHeight;
                @PlayerHeight.canceled += instance.OnPlayerHeight;
                @PlayerAudio.started += instance.OnPlayerAudio;
                @PlayerAudio.performed += instance.OnPlayerAudio;
                @PlayerAudio.canceled += instance.OnPlayerAudio;
                @PauseGame.started += instance.OnPauseGame;
                @PauseGame.performed += instance.OnPauseGame;
                @PauseGame.canceled += instance.OnPauseGame;
            }
        }
    }
    public PlayerControlActions @PlayerControl => new PlayerControlActions(this);

    // TestPlayer
    private readonly InputActionMap m_TestPlayer;
    private ITestPlayerActions m_TestPlayerActionsCallbackInterface;
    private readonly InputAction m_TestPlayer_Move;
    private readonly InputAction m_TestPlayer_PlayerMove;
    public struct TestPlayerActions
    {
        private @PlayerControlNew m_Wrapper;
        public TestPlayerActions(@PlayerControlNew wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_TestPlayer_Move;
        public InputAction @PlayerMove => m_Wrapper.m_TestPlayer_PlayerMove;
        public InputActionMap Get() { return m_Wrapper.m_TestPlayer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TestPlayerActions set) { return set.Get(); }
        public void SetCallbacks(ITestPlayerActions instance)
        {
            if (m_Wrapper.m_TestPlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnMove;
                @PlayerMove.started -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnPlayerMove;
                @PlayerMove.performed -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnPlayerMove;
                @PlayerMove.canceled -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnPlayerMove;
            }
            m_Wrapper.m_TestPlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @PlayerMove.started += instance.OnPlayerMove;
                @PlayerMove.performed += instance.OnPlayerMove;
                @PlayerMove.canceled += instance.OnPlayerMove;
            }
        }
    }
    public TestPlayerActions @TestPlayer => new TestPlayerActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_MobileInputSchemeIndex = -1;
    public InputControlScheme MobileInputScheme
    {
        get
        {
            if (m_MobileInputSchemeIndex == -1) m_MobileInputSchemeIndex = asset.FindControlSchemeIndex("MobileInput");
            return asset.controlSchemes[m_MobileInputSchemeIndex];
        }
    }
    private int m_DevicesSchemeIndex = -1;
    public InputControlScheme DevicesScheme
    {
        get
        {
            if (m_DevicesSchemeIndex == -1) m_DevicesSchemeIndex = asset.FindControlSchemeIndex("Devices");
            return asset.controlSchemes[m_DevicesSchemeIndex];
        }
    }
    public interface IPlayerControlActions
    {
        void OnPlayerMovement(InputAction.CallbackContext context);
        void OnPlayerHeight(InputAction.CallbackContext context);
        void OnPlayerAudio(InputAction.CallbackContext context);
        void OnPauseGame(InputAction.CallbackContext context);
    }
    public interface ITestPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnPlayerMove(InputAction.CallbackContext context);
    }
}
