namespace SimpleShooter.Features.Player
{
    using System.Linq;
    using SimpleShooter.Features.Pool;
    using SimpleShooter.Features.Utils;
    using UnityEngine;

    /// <summary>
    /// Prefab for supply patrons
    /// </summary>
    public sealed class AmmoBonus : AbstractTrigger<EntityFacade>
    {
        [SerializeField] private int ammoSupply = 100;

        private ShootsModel shootsModel;
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

        private void Disable()
        {
            if (targetComponent.Id == "Player")
            {
                shootsModel = (ShootsModel)targetComponent.Models.First(x => x is ShootsModel);
                shootsModel.AddAmmo(ammoSupply);
                shootsModel.AmmoChange();
                itemPool.EmergenceInDelayedSpawner();
                gameObject.SetActive(false);
            }
        }
    }
}
