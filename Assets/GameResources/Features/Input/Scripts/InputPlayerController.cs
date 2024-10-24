namespace SimpleShooter.Features.Input
{
    using UnityEngine;
    using System;
    using SimpleShooter.Features.Player;

    /// <summary>
    /// Settings input player
    /// </summary>
    public class InputPlayerController : AbstractControllerFacade
    {
        public event Action onMovementInputChanged = delegate { };
        public Vector2 MovementVector
        {
            get => movementVector;
            protected set
            {
                movementVector = value;
                onMovementInputChanged();
            }
        }

        protected Vector2 movementVector = Vector2.zero;

        protected PlayerInput input = default;

        protected virtual void Awake()
        {
            input = new PlayerInput();
            input.Enable();
            input.Player_Map.Movement.performed += ctx => MovementVector = ctx.ReadValue<Vector2>();
            input.Player_Map.MovementStick.performed += ctx => MovementVector = ctx.ReadValue<Vector2>();
            input.Player_Map.Movement.canceled += ctx => MovementVector = Vector2.zero;
            input.Player_Map.MovementStick.canceled += ctx => MovementVector = Vector2.zero;
        }

        protected virtual void OnDestroy()
        {
            input.Player_Map.Movement.performed -= ctx => MovementVector = ctx.ReadValue<Vector2>();
            input.Player_Map.MovementStick.performed -= ctx => MovementVector = ctx.ReadValue<Vector2>();
            input.Player_Map.Movement.canceled -= ctx => MovementVector = Vector2.zero;
            input.Player_Map.MovementStick.canceled -= ctx => MovementVector = Vector2.zero;
            input.Disable();
        }
    }
}
