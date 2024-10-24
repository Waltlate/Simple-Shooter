namespace SimpleShooter.Features.Bot
{
    using SimpleShooter.Features.Player;
    using UnityEngine;

    /// <summary>
    /// Shooting controller bot
    /// </summary>
    public sealed class BotShootingController : ShootingController
    {
        [SerializeField] private Transform player; 
        [SerializeField, Min(0)] private float detectionRange = 10f; 
        [SerializeField, Min(0)] private float shootingInterval = 1f;

        private float lastShotTime = default;

        private void Update()
        {
            if (player != null && Vector3.Distance(transform.position, player.position) <= detectionRange)
            {
                if (Time.time - lastShotTime >= shootingInterval)
                {
                    Shoot();
                    lastShotTime = Time.time;
                }
            }
        }
    }
}
