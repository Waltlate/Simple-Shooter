namespace SimpleShooter.Features.Pool
{
    using UnityEngine;

    /// <summary>
    /// Ñlass required for activation from pool and back
    /// </summary>
    public class ItemPool : MonoBehaviour
    {
        protected PoolSpawner spawner = default;

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="_spawner"></param>
        public void Init(PoolSpawner _spawner)
        {
            spawner = _spawner;
        }

        protected virtual void OnDisable()
        {
            if (spawner == null) return;
            spawner.ReturnToPool(this);
        }

        /// <summary>
        /// Emergence in spawner
        /// </summary>
        public void EmergenceInSpawner()
        {
            spawner.Spawn(spawner.transform);
        }

        /// <summary>
        /// Delayed spawn
        /// </summary>
        public void EmergenceInDelayedSpawner()
        {
            spawner.DelayedSpawn(spawner.transform);
        }

        /// <summary>
        /// Subtract prefab
        /// </summary>
        public void SubtractPrefab()
        {
            spawner.SubtractPrefab();
        }

        /// <summary>
        /// Mark kill prefab
        /// </summary>
        public void MarkKill()
        {
            spawner.MarkKill();
        }
    }
}
