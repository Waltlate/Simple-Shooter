namespace SimpleShooter.Features.Player
{
    using System.Collections;
    using System.Linq;
    using SimpleShooter.Features.Pool;
    using SimpleShooter.Features.Utils;
    using UnityEngine;

    /// <summary>
    /// Prefab for health recovery
    /// </summary>
    public sealed class HealthBonus : AbstractTrigger<EntityFacade>
    {
        [SerializeField] private int healthRecovery = 20;
        
        private HealthController healthController;
        private ItemPool itemPool = default;

        private void Start()
        {
            itemPool = GetComponent<ItemPool>();
            onTriggerEnter += Disable;
        }

        private void OnDestroy()
        {
            onTriggerEnter -= Disable;
        }

        private void Disable() {
            if (targetComponent.Id == "Player")
            {
                healthController = (HealthController)targetComponent.Controllers.First(x => x is HealthController);
                healthController.AddHealth(healthRecovery);
                healthController.healthData.HealthChange();
                itemPool.EmergenceInDelayedSpawner();
                gameObject.SetActive(false);
            }
        }
    }
}

