//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/Inputs/IsaacInputsActions.inputactions
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

public partial class @IsaacInputsActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @IsaacInputsActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""IsaacInputsActions"",
    ""maps"": [
        {
            ""name"": ""Character"",
            ""id"": ""a2537d88-3fd3-453d-bea7-27b0b6419f10"",
            ""actions"": [
                {
                    ""name"": ""MovementHorizontal"",
                    ""type"": ""Value"",
                    ""id"": ""b760f7e3-1857-4dcc-80cd-631efa323323"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MovementVertical"",
                    ""type"": ""Value"",
                    ""id"": ""11887d5e-dd2f-40e2-a673-d886ec4d7c08"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ShootRight"",
                    ""type"": ""Value"",
                    ""id"": ""0fdc49af-21a1-4f79-b2be-517de2184b7f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ShootLeft"",
                    ""type"": ""Value"",
                    ""id"": ""6c784344-44c2-474c-9764-5418af49887e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ShootUp"",
                    ""type"": ""Value"",
                    ""id"": ""dd30eae2-7f3f-4438-a5fc-c8fcb8249432"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ShootDown"",
                    ""type"": ""Value"",
                    ""id"": ""c5136241-cdad-4ce6-8e10-0b0d8e9cf8f0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ShootBomb"",
                    ""type"": ""Button"",
                    ""id"": ""f798e7a0-1ea1-4036-a704-10ff6f0faa12"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""1a6f8800-3e73-4572-8486-9bcc1f81f28e"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementHorizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""037360a1-1218-42ae-a64c-90731779e4d2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""d9fa04f9-b6ff-4876-918c-a22bc8119f43"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""12e2b214-363e-49bc-8ceb-c7959d0ce0e9"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementVertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""493fcf4d-bce2-456e-934f-8ed67c407ad7"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""93975a2c-3e15-4d99-8687-743a359a14ac"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""eef5abfb-e677-4ea7-8215-14881fe11af2"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""622c9bb2-61f0-4795-be6d-e8bfc4d0d1a8"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""52f6cf96-986d-42ce-b819-6fc619b67fe2"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""69738462-7f4f-4491-a11f-749ab0c99bd3"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ead6fba6-8a26-4c97-a286-8773ef90a81d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootBomb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Character
        m_Character = asset.FindActionMap("Character", throwIfNotFound: true);
        m_Character_MovementHorizontal = m_Character.FindAction("MovementHorizontal", throwIfNotFound: true);
        m_Character_MovementVertical = m_Character.FindAction("MovementVertical", throwIfNotFound: true);
        m_Character_ShootRight = m_Character.FindAction("ShootRight", throwIfNotFound: true);
        m_Character_ShootLeft = m_Character.FindAction("ShootLeft", throwIfNotFound: true);
        m_Character_ShootUp = m_Character.FindAction("ShootUp", throwIfNotFound: true);
        m_Character_ShootDown = m_Character.FindAction("ShootDown", throwIfNotFound: true);
        m_Character_ShootBomb = m_Character.FindAction("ShootBomb", throwIfNotFound: true);
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

    // Character
    private readonly InputActionMap m_Character;
    private List<ICharacterActions> m_CharacterActionsCallbackInterfaces = new List<ICharacterActions>();
    private readonly InputAction m_Character_MovementHorizontal;
    private readonly InputAction m_Character_MovementVertical;
    private readonly InputAction m_Character_ShootRight;
    private readonly InputAction m_Character_ShootLeft;
    private readonly InputAction m_Character_ShootUp;
    private readonly InputAction m_Character_ShootDown;
    private readonly InputAction m_Character_ShootBomb;
    public struct CharacterActions
    {
        private @IsaacInputsActions m_Wrapper;
        public CharacterActions(@IsaacInputsActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @MovementHorizontal => m_Wrapper.m_Character_MovementHorizontal;
        public InputAction @MovementVertical => m_Wrapper.m_Character_MovementVertical;
        public InputAction @ShootRight => m_Wrapper.m_Character_ShootRight;
        public InputAction @ShootLeft => m_Wrapper.m_Character_ShootLeft;
        public InputAction @ShootUp => m_Wrapper.m_Character_ShootUp;
        public InputAction @ShootDown => m_Wrapper.m_Character_ShootDown;
        public InputAction @ShootBomb => m_Wrapper.m_Character_ShootBomb;
        public InputActionMap Get() { return m_Wrapper.m_Character; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterActions set) { return set.Get(); }
        public void AddCallbacks(ICharacterActions instance)
        {
            if (instance == null || m_Wrapper.m_CharacterActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CharacterActionsCallbackInterfaces.Add(instance);
            @MovementHorizontal.started += instance.OnMovementHorizontal;
            @MovementHorizontal.performed += instance.OnMovementHorizontal;
            @MovementHorizontal.canceled += instance.OnMovementHorizontal;
            @MovementVertical.started += instance.OnMovementVertical;
            @MovementVertical.performed += instance.OnMovementVertical;
            @MovementVertical.canceled += instance.OnMovementVertical;
            @ShootRight.started += instance.OnShootRight;
            @ShootRight.performed += instance.OnShootRight;
            @ShootRight.canceled += instance.OnShootRight;
            @ShootLeft.started += instance.OnShootLeft;
            @ShootLeft.performed += instance.OnShootLeft;
            @ShootLeft.canceled += instance.OnShootLeft;
            @ShootUp.started += instance.OnShootUp;
            @ShootUp.performed += instance.OnShootUp;
            @ShootUp.canceled += instance.OnShootUp;
            @ShootDown.started += instance.OnShootDown;
            @ShootDown.performed += instance.OnShootDown;
            @ShootDown.canceled += instance.OnShootDown;
            @ShootBomb.started += instance.OnShootBomb;
            @ShootBomb.performed += instance.OnShootBomb;
            @ShootBomb.canceled += instance.OnShootBomb;
        }

        private void UnregisterCallbacks(ICharacterActions instance)
        {
            @MovementHorizontal.started -= instance.OnMovementHorizontal;
            @MovementHorizontal.performed -= instance.OnMovementHorizontal;
            @MovementHorizontal.canceled -= instance.OnMovementHorizontal;
            @MovementVertical.started -= instance.OnMovementVertical;
            @MovementVertical.performed -= instance.OnMovementVertical;
            @MovementVertical.canceled -= instance.OnMovementVertical;
            @ShootRight.started -= instance.OnShootRight;
            @ShootRight.performed -= instance.OnShootRight;
            @ShootRight.canceled -= instance.OnShootRight;
            @ShootLeft.started -= instance.OnShootLeft;
            @ShootLeft.performed -= instance.OnShootLeft;
            @ShootLeft.canceled -= instance.OnShootLeft;
            @ShootUp.started -= instance.OnShootUp;
            @ShootUp.performed -= instance.OnShootUp;
            @ShootUp.canceled -= instance.OnShootUp;
            @ShootDown.started -= instance.OnShootDown;
            @ShootDown.performed -= instance.OnShootDown;
            @ShootDown.canceled -= instance.OnShootDown;
            @ShootBomb.started -= instance.OnShootBomb;
            @ShootBomb.performed -= instance.OnShootBomb;
            @ShootBomb.canceled -= instance.OnShootBomb;
        }

        public void RemoveCallbacks(ICharacterActions instance)
        {
            if (m_Wrapper.m_CharacterActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICharacterActions instance)
        {
            foreach (var item in m_Wrapper.m_CharacterActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CharacterActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CharacterActions @Character => new CharacterActions(this);
    public interface ICharacterActions
    {
        void OnMovementHorizontal(InputAction.CallbackContext context);
        void OnMovementVertical(InputAction.CallbackContext context);
        void OnShootRight(InputAction.CallbackContext context);
        void OnShootLeft(InputAction.CallbackContext context);
        void OnShootUp(InputAction.CallbackContext context);
        void OnShootDown(InputAction.CallbackContext context);
        void OnShootBomb(InputAction.CallbackContext context);
    }
}
