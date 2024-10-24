namespace SimpleShooter.Features.Player
{
    using UnityEngine;
    /// <summary>
    /// Health controller
    /// </summary>
    public sealed class HealthController : AbstractControllerFacade
    {
        [SerializeField] public HealthData healthData;

        public int CurrentHealth
        {
            get => currentHealth;
            set
            {
                currentHealth = value;
            }
        }

        private int currentHealth;

        private void Start()
        {
            SetNewHealth();
        }

        /// <summary>
        /// Begin health for character
        /// </summary>
        public void SetNewHealth()
        {
            currentHealth = Random.Range(healthData.MinHealth,
                                   healthData.MaxHealth);
            healthData.HealthChange();
        }

        /// <summary>
        /// Increase health 
        /// </summary>
        /// <param name="healthRecovery"></param>
        public void AddHealth(int healthRecovery) => currentHealth = Mathf.Clamp(currentHealth + healthRecovery, 0, healthData.MaxHealth);

        /// <summary>
        /// Decrease health 
        /// </summary>
        public void TakeDamage(int healthReduce) => currentHealth = Mathf.Clamp(currentHealth - healthReduce, 0, healthData.MaxHealth);
    }
}
