namespace SimpleShooter.Features.Player
{
    using SimpleShooter.Features.Spawners;
    using UnityEngine;

    /// <summary>
    /// Shooting controller
    /// </summary>
    public class ShootingController : AbstractControllerFacade
    {
        [SerializeField] protected ShootsModel shootsModel;
        [SerializeField] protected BaseSpawner baseSpawner;
        [SerializeField, Min(0)] private float speedBullet = 1f;

        /// <summary>
        /// Imitation shoot
        /// </summary>
        public void Shoot()
        {
            if (shootsModel.MaxShots > 0)
            {
                baseSpawner.Spawn(transform, transform.rotation);
                Rigidbody bulletRb = baseSpawner.LastSpawnedObject.GetComponent<Rigidbody>();
                bulletRb.AddForce(baseSpawner.LastSpawnedObject.transform.forward * speedBullet, ForceMode.Impulse);
                shootsModel.DecreaseAmmo(1);
                shootsModel.AmmoChange();
            }
        }
    }
}
