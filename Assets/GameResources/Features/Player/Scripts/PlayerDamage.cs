namespace SimpleShooter.Features.Player
{
    using UnityEngine;
    using System.Linq;
    using SimpleShooter.Features.Utils;
    using SimpleShooter.Features.UI;

    /// <summary>
    /// Prefab for reduce health
    /// </summary>
    public sealed class PlayerDamage : AbstractTrigger<EntityFacade>
    {
        [SerializeField, Min(0)] private int damage = 10;

        private HealthController healthController;

        private void Start()
        {
            onTriggerEnter += Disable;
        }

        private void OnDestroy()
        {
            onTriggerEnter -= Disable;
        }

        private void Disable()
        {
            if (targetComponent.Id == "Player")
            {
                healthController = (HealthController)targetComponent.Controllers.First(x => x is HealthController);
                healthController.TakeDamage(damage);
                if (healthController.CurrentHealth == 0)
                {
                    WindowsController.onWindowOpen("GameOver");
                }
                healthController.healthData.HealthChange();
                gameObject.SetActive(false);
            }
        }
    }
}
