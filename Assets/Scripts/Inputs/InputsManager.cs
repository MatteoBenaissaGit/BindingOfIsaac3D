using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Inputs
{
    public class InputsManager
    {
        private IsaacInputsActions _isaacInputsActions;

        //character
        public Action<float> OnHorizontalInput { get; set; }
        public Action<float> OnVerticalInput { get; set; }
        public Action<Vector2Int> OnShootInput { get; set; }
        private bool _shootLeft, _shootRight, _shootUp, _shootDown;
        private static readonly Vector2Int Left = new Vector2Int(-1, 0);
        private static readonly Vector2Int Right = new Vector2Int(1, 0);
        private static readonly Vector2Int Up = new Vector2Int(0, 1);
        private static readonly Vector2Int Down = new Vector2Int(0, -1);
        public Action OnBombShoot { get; set; }
        
        //menu
        public Action OnMenuUp { get; set; }
        public Action OnMenuDown { get; set; }
        public Action OnMenuEnter { get; set; }
        public Action OnMenuEscape { get; set; }

        public InputsManager()
        {
            Initialize();
        }
        
        private void Initialize()
        {
            _isaacInputsActions = new IsaacInputsActions();
            _isaacInputsActions.Enable();
            
            //CHARACTER
            _isaacInputsActions.Character.MovementHorizontal.performed += ctx => OnHorizontalInput?.Invoke(ctx.ReadValue<float>());
            _isaacInputsActions.Character.MovementHorizontal.canceled += ctx => OnHorizontalInput?.Invoke(ctx.ReadValue<float>());
            _isaacInputsActions.Character.MovementVertical.performed += ctx => OnVerticalInput?.Invoke(ctx.ReadValue<float>());
            _isaacInputsActions.Character.MovementVertical.canceled += ctx => OnVerticalInput?.Invoke(ctx.ReadValue<float>());
         
            _isaacInputsActions.Character.ShootLeft.performed += ctx => _shootLeft = true;
            _isaacInputsActions.Character.ShootLeft.canceled += ctx => _shootLeft = false;
            _isaacInputsActions.Character.ShootRight.performed += ctx => _shootRight = true;
            _isaacInputsActions.Character.ShootRight.canceled += ctx => _shootRight = false;
            _isaacInputsActions.Character.ShootUp.performed += ctx => _shootUp = true;
            _isaacInputsActions.Character.ShootUp.canceled += ctx => _shootUp = false;
            _isaacInputsActions.Character.ShootDown.performed += ctx => _shootDown = true;
            _isaacInputsActions.Character.ShootDown.canceled += ctx => _shootDown = false;

            _isaacInputsActions.Character.ShootBomb.started += ctx => OnBombShoot?.Invoke();
            
            //MENU
            _isaacInputsActions.Menu.Up.started += ctx => OnMenuUp?.Invoke();
            _isaacInputsActions.Menu.Down.started += ctx => OnMenuDown?.Invoke();
            _isaacInputsActions.Menu.Enter.started += ctx => OnMenuEnter?.Invoke();
            _isaacInputsActions.Menu.Echap.started += ctx => OnMenuEscape?.Invoke();
        }

        public void Update()
        {
            if (_shootLeft) OnShootInput?.Invoke(Left);
            if (_shootRight) OnShootInput?.Invoke(Right);
            if (_shootUp) OnShootInput?.Invoke(Up);
            if (_shootDown) OnShootInput?.Invoke(Down);
        }

        public void Kill()
        {
            _isaacInputsActions.Disable();
            _isaacInputsActions = null;
        }
    }
}
