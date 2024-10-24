namespace SimpleShooter.Features.Bot
{
    using SimpleShooter.Features.Player;
    using SimpleShooter.Features.Pool;
    using SimpleShooter.Features.Utils;
    using System.Linq;
    using UnityEngine;

    /// <summary>
    /// Behavior bot in trigger
    /// </summary>
    public sealed class BotTrigger : AbstractTrigger<EntityFacade>
    {
        [SerializeField, Min(0)] private int damage = 25;

        private HealthController healthControllerBot = default;

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
            if (targetComponent.Id == "BotKamikaze")
            {
                TakeDamage();
                if (healthControllerBot.CurrentHealth == 0)
                {
                    targetComponent.GetComponent<NavAgentController>().SpawnFromPool();
                    targetComponent.GetComponent<ItemPool>().MarkKill();
                }
                gameObject.SetActive(false);
            }
            if (targetComponent.Id == "BotTurret")
            {
                TakeDamage();
                if (healthControllerBot.CurrentHealth == 0)
                {
                    targetComponent.GetComponent<ItemPool>().EmergenceInDelayedSpawner();
                    targetComponent.GetComponent<ItemPool>().SubtractPrefab();
                    targetComponent.GetComponent<ItemPool>().MarkKill();
                    targetComponent.gameObject.SetActive(false);
                }
                gameObject.SetActive(false);
            }
        }

        private void TakeDamage()
        {
            healthControllerBot = (HealthController)targetComponent.Controllers.First(x => x is HealthController);
            healthControllerBot.TakeDamage(damage);
        }
    }
}
