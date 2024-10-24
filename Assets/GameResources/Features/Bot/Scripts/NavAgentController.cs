namespace SimpleShooter.Features.Bot
{
    using SimpleShooter.Features.Player;
    using SimpleShooter.Features.Pool;
    using SimpleShooter.Features.UI;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.AI;

    /// <summary>
    /// Hunt target with AI
    /// </summary>
    public sealed class NavAgentController : AbstractControllerFacade
    {
        [SerializeField] private Transform target = default;
        [SerializeField] private NavMeshAgent navMeshAgent = default;
        [SerializeField] private EntityContainer playerContainer = default;
        [SerializeField] private MovementSpeedModel speedModel;
        [SerializeField, Min(0)] private float distance = 3f;
        [SerializeField, Min(1)] private int damage = 1;

        private ItemPool itemPool = default;
        private HealthController healthControllerPlayer = default;
        private HealthController healthControllerBot = default;
        private bool isContainerInit = false;

        private void OnEnable()
        {
            if (playerContainer.Facade != null)
            {
                OnPlayerInited();
            }
            playerContainer.onPlayerInited += OnPlayerInited;
            playerContainer.onPlayerDisposed += OnPlayerDisposed;

            navMeshAgent.speed = speedModel.Speed;
            SetDestinationPlayer();
            itemPool = GetComponent<ItemPool>();
        }

        private void OnDisable()
        {
            playerContainer.onPlayerInited -= OnPlayerInited;
            playerContainer.onPlayerDisposed -= OnPlayerDisposed;
        }

        private void OnPlayerInited()
        {
            healthControllerPlayer = (HealthController)playerContainer.Facade.Controllers.First(x => x is HealthController);
            isContainerInit = true;
        }

        private void OnPlayerDisposed() { }

        private void Update()
        {
            if (isContainerInit)
            {
                if (navMeshAgent.remainingDistance < distance)
                {
                    BehaviorNearPlayer();
                }
                navMeshAgent.speed = speedModel.Speed;
                SetDestinationPlayer();
            }
        }

        private void SetDestinationPlayer()
        {
            if (playerContainer.Facade != null)
            {
                target.position = playerContainer.Facade.GetComponentInParent<Transform>().position;
            }
            if (isActiveAndEnabled)
            {
                navMeshAgent.SetDestination(target.position);
            }
        }

        private void BehaviorNearPlayer()
        {
            if (isContainerInit)
            {
                healthControllerPlayer.TakeDamage(damage);
                if (healthControllerPlayer.CurrentHealth == 0)
                {
                    WindowsController.onWindowOpen("GameOver");
                }
                healthControllerPlayer.healthData.HealthChange();
                SpawnFromPool();
            }
        }

        /// <summary>
        /// Destroy bot and spawn new bot
        /// </summary>
        public void SpawnFromPool()
        {
            itemPool.SubtractPrefab();
            gameObject.SetActive(false);
            healthControllerBot = (HealthController)facadeInstance.Controllers.First(x => x is HealthController);
            healthControllerBot.SetNewHealth();
        }
    }
}
