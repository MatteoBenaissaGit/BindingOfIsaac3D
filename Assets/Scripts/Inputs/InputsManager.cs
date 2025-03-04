using System;
using UnityEngine;

namespace Inputs
{
    public class InputsManager
    {
        private IsaacInputsActions _isaacInputsActions;

        public Action<float> OnHorizontalInput { get; set; }
        public Action<float> OnVerticalInput { get; set; }
        
        public Action<Vector2Int> OnShootInput { get; set; }
        public static readonly Vector2Int Left = new Vector2Int(-1, 0);
        public static readonly Vector2Int Right = new Vector2Int(1, 0);
        public static readonly Vector2Int Up = new Vector2Int(0, 1);
        public static readonly Vector2Int Down = new Vector2Int(0, -1);

        public void Initialize()
        {
            _isaacInputsActions = new IsaacInputsActions();
            _isaacInputsActions.Enable();
            
            _isaacInputsActions.Character.MovementHorizontal.performed += ctx => OnHorizontalInput?.Invoke(ctx.ReadValue<float>());
            _isaacInputsActions.Character.MovementHorizontal.canceled += ctx => OnHorizontalInput?.Invoke(ctx.ReadValue<float>());
            _isaacInputsActions.Character.MovementVertical.performed += ctx => OnVerticalInput?.Invoke(ctx.ReadValue<float>());
            _isaacInputsActions.Character.MovementVertical.canceled += ctx => OnVerticalInput?.Invoke(ctx.ReadValue<float>());
         
            _isaacInputsActions.Character.ShootLeft.started += ctx => OnShootInput?.Invoke(Left);
            _isaacInputsActions.Character.ShootRight.started += ctx => OnShootInput?.Invoke(Right);
            _isaacInputsActions.Character.ShootUp.started += ctx => OnShootInput?.Invoke(Up);
            _isaacInputsActions.Character.ShootDown.started += ctx => OnShootInput?.Invoke(Down);
        }

        public void Kill()
        {
            _isaacInputsActions.Disable();
            _isaacInputsActions = null;
        }
    }
}
