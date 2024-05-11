//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/InputSystem/Player.inputactions
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

namespace GameHorror.InputSystem
{
    public partial class @HorrorInput: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @HorrorInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player"",
    ""maps"": [
        {
            ""name"": ""InGame"",
            ""id"": ""78f0b829-c2f2-41ee-8085-c6505584261b"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""9f82069b-aa53-4396-82f2-e03c9ec80399"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""8ef2ef12-0955-4ebc-9be8-6e4d2a5c0084"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""d8c8ba33-5130-4a2b-8e1e-e01afb382f9f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ItemChoose"",
                    ""type"": ""PassThrough"",
                    ""id"": ""26adfb88-5e13-4568-9e40-4a789fbfaba6"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""3d8eaf33-b489-416d-8225-212efcb5b0cd"",
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
                    ""id"": ""0d800bc1-f6d9-4b84-a439-61da97c49721"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1a304213-380d-4211-8d9c-36ea936f85cf"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4f84be5e-691a-4fb1-915d-9d41ef079bce"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8876874c-6b2d-47ba-8a90-2bb5ba5912e4"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4004a98b-ec01-47b3-9523-e4d0e9b5ca26"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""462d618c-abb6-4079-bb70-718cf14e93df"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ec6d8ad3-75ed-4ba3-a96e-e18b78559e29"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ItemChoose"",
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
        }
    ]
}");
            // InGame
            m_InGame = asset.FindActionMap("InGame", throwIfNotFound: true);
            m_InGame_Move = m_InGame.FindAction("Move", throwIfNotFound: true);
            m_InGame_Interact = m_InGame.FindAction("Interact", throwIfNotFound: true);
            m_InGame_Run = m_InGame.FindAction("Run", throwIfNotFound: true);
            m_InGame_ItemChoose = m_InGame.FindAction("ItemChoose", throwIfNotFound: true);
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

        // InGame
        private readonly InputActionMap m_InGame;
        private List<IInGameActions> m_InGameActionsCallbackInterfaces = new List<IInGameActions>();
        private readonly InputAction m_InGame_Move;
        private readonly InputAction m_InGame_Interact;
        private readonly InputAction m_InGame_Run;
        private readonly InputAction m_InGame_ItemChoose;
        public struct InGameActions
        {
            private @HorrorInput m_Wrapper;
            public InGameActions(@HorrorInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_InGame_Move;
            public InputAction @Interact => m_Wrapper.m_InGame_Interact;
            public InputAction @Run => m_Wrapper.m_InGame_Run;
            public InputAction @ItemChoose => m_Wrapper.m_InGame_ItemChoose;
            public InputActionMap Get() { return m_Wrapper.m_InGame; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(InGameActions set) { return set.Get(); }
            public void AddCallbacks(IInGameActions instance)
            {
                if (instance == null || m_Wrapper.m_InGameActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_InGameActionsCallbackInterfaces.Add(instance);
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @ItemChoose.started += instance.OnItemChoose;
                @ItemChoose.performed += instance.OnItemChoose;
                @ItemChoose.canceled += instance.OnItemChoose;
            }

            private void UnregisterCallbacks(IInGameActions instance)
            {
                @Move.started -= instance.OnMove;
                @Move.performed -= instance.OnMove;
                @Move.canceled -= instance.OnMove;
                @Interact.started -= instance.OnInteract;
                @Interact.performed -= instance.OnInteract;
                @Interact.canceled -= instance.OnInteract;
                @Run.started -= instance.OnRun;
                @Run.performed -= instance.OnRun;
                @Run.canceled -= instance.OnRun;
                @ItemChoose.started -= instance.OnItemChoose;
                @ItemChoose.performed -= instance.OnItemChoose;
                @ItemChoose.canceled -= instance.OnItemChoose;
            }

            public void RemoveCallbacks(IInGameActions instance)
            {
                if (m_Wrapper.m_InGameActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IInGameActions instance)
            {
                foreach (var item in m_Wrapper.m_InGameActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_InGameActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public InGameActions @InGame => new InGameActions(this);
        private int m_KeyboardSchemeIndex = -1;
        public InputControlScheme KeyboardScheme
        {
            get
            {
                if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
                return asset.controlSchemes[m_KeyboardSchemeIndex];
            }
        }
        public interface IInGameActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnInteract(InputAction.CallbackContext context);
            void OnRun(InputAction.CallbackContext context);
            void OnItemChoose(InputAction.CallbackContext context);
        }
    }
}
