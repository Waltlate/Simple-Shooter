namespace SimpleShooter.Features.Player
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Configuration shoots
    /// </summary>
    [CreateAssetMenu(fileName = "NewShootsData", menuName = "SimpleShooter/Features/Player/ShootsData")]
    public class ShootsModel : AbstractModelFacade
    {
        public event Action onBulletChange = delegate { };

        public int MaxShots {
            get => maxShots;
            set 
            {
                maxShots = value;
            }
        }


        [SerializeField] protected int maxShots;

        /// <summary>
        /// Update subscribers ammo
        /// </summary>
        public void AmmoChange() => onBulletChange.Invoke();

        /// <summary>
        /// Supply ammo
        /// </summary>
        public void AddAmmo(int count) => maxShots += count;

        /// <summary>
        /// Decrease ammo
        /// </summary>
        public void DecreaseAmmo(int count) => maxShots -= count;
    }
}
