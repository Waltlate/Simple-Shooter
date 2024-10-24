namespace SimpleShooter.Features.Player
{
    using UnityEngine;
    using SimpleShooter.Features.Input;

    /// <summary>
    /// Movement controller player
    /// </summary>
    public sealed class MovementController : AbstractControllerFacade
    {
        [SerializeField] public MovementSpeedModel speedModel = default;
        [SerializeField] private InputPlayerController inputPlayerController = default;
        [SerializeField] private VirtualJoystick virtualJoystick = default;
        [SerializeField, Min(0)] private float rotationSpeed = 100f;

        private Vector3 movement = Vector3.zero;
        private Vector2 moveInput = Vector2.zero;
        private float horizontalInput = default;
        private float verticalInput = default;

        private void Awake()
        {
#if UNITY_ANDROID
            virtualJoystick.gameObject.SetActive(true);
#endif
        }

        private void Update()
        {
#if UNITY_ANDROID
            moveInput = virtualJoystick.GetDirection();
#else
            moveInput = inputPlayerController.MovementVector;
#endif
            horizontalInput = moveInput.x;
            verticalInput = moveInput.y;

            if (horizontalInput != 0)
            {
                transform.Rotate(0, horizontalInput * rotationSpeed * Time.deltaTime, 0);
            }
            movement = transform.forward * verticalInput;
            transform.position += movement * speedModel.SpeedModifier * speedModel.Speed * Time.deltaTime;
        }
    }
}
