namespace SimpleShooter.Features.Player
{
    using SimpleShooter.Features.Spawners;
    using UnityEngine;

    /// <summary>
    /// Player shooting controller
    /// </summary>
    public sealed class PlayerShootingController : ShootingController
    {
        private void Start()
        {
            shootsModel.AmmoChange();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }
    }
}

