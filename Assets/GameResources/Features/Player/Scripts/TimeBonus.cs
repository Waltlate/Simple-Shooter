namespace SimpleShooter.Features.Player
{
    using SimpleShooter.Features.GameConditions;
    using SimpleShooter.Features.Pool;
    using SimpleShooter.Features.Utils;
    using UnityEngine;

    /// <summary>
    /// Prefab for add time
    /// </summary>
    public class TimeBonus : AbstractTrigger<EntityFacade>
    {
        [SerializeField] private DifficultyLevelController difficultyLevelController = default;
        [SerializeField, Min(0)] private float addTime = 10f;

        private ItemPool itemPool = default;

        private void Start()
        {
            difficultyLevelController = FindObjectOfType<DifficultyLevelController>();
            itemPool = GetComponent<ItemPool>();
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
                difficultyLevelController.AddTime(addTime);
                itemPool.EmergenceInDelayedSpawner();
                gameObject.SetActive(false);
            }
        }
    }
}
