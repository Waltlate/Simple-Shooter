namespace SimpleShooter.Features.Player
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Configuration health
    /// </summary>
    [CreateAssetMenu(fileName = "NewHealthData", menuName = "SimpleShooter/Features/Player/HealthData")]
    public class HealthData : AbstractModelFacade
    {
        public event Action onHealthChange = delegate { };

        public int MinHealth => minHealth;
        public int MaxHealth => maxHealth;

        [SerializeField, Min(0)] protected int minHealth;
        [SerializeField, Min(0)] protected int maxHealth;

        /// <summary>
        /// Update subscribers player health
        /// </summary>
        public void HealthChange() => onHealthChange.Invoke();   
    }
}