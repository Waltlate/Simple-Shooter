namespace SimpleShooter.Features.Bot
{
    using SimpleShooter.Features.Player;
    using UnityEngine;

    /// <summary>
    /// Aim controller
    /// </summary>
    public sealed class AimController : AbstractControllerFacade
    {
        [SerializeField] private Transform player;
        [SerializeField] private MovementSpeedModel speedModel = default;

        private void Update()
        {
            if (player != null)
            {
                Vector3 direction = (player.position - transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speedModel.Speed);
            }
        }
    }
}
