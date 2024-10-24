namespace SimpleShooter.Features.Pool
{
    using System.Collections;
    using System.Collections.Generic;
    using SimpleShooter.Features.GameConditions;
    using SimpleShooter.Features.Spawners;
    using SimpleShooter.Features.Utils;
    using UnityEngine;

    /// <summary>
    /// Pool spawner prefabs
    /// </summary>
    public class PoolSpawner : CycleSpawner
    {
        [SerializeField] protected List<ItemPool> items = new List<ItemPool>();
        [SerializeField, Min(0)] protected int countPrewarm = 3;

        protected ItemPool tempItem = default;

        [SerializeField] private Vector3 shiftSpawn = Vector3.zero;
        [SerializeField] private bool isOneSpawn = false;

        private Coroutine coroutine = default;

        /// <summary>
        /// Changing the number of pre-prepared items is valid for calling in Awake, there is no point in calling later
        /// </summary>
        /// <param name="_newPrewarm"></param>
        public void ChangePrewarm(int _newPrewarm) => countPrewarm = _newPrewarm;

        protected override void Start()
        {
            for (int i = 0; i < countPrewarm; i++)
            {
                base.Spawn();
                tempItem = LastSpawnedObject.GetComponent<ItemPool>();
                tempItem.Init(this);
                tempItem.gameObject.SetActive(false);
            }
            base.Start();
            if (isOneSpawn)
            {
                Spawn(gameObject.transform);
            }
        }

        /// <summary>
        /// Spawn with pool
        /// </summary>
        [ContextMenu("Test Spawn")]
        public override void Spawn()
        {
            if (items.Count <= 0)
            {
                base.Spawn();
                ItemPool itemPool = LastSpawnedObject.GetComponent<ItemPool>();
                itemPool.Init(this);
            }
            else
            {
                items[items.Count - 1].gameObject.ResetLocalPosition(gameObject);
                items[items.Count - 1].gameObject.transform.position += shiftSpawn;
                items[items.Count - 1].gameObject.SetActive(true);
                lastSpawnedObject = items[items.Count - 1].gameObject;
                items.RemoveAt(items.Count - 1);
            }

            if (cubeLifeTime != null)
            {
                cubeLifeTime.CreateCube();
            }
        }

        /// <summary>
        /// Spawn with pool in point
        /// </summary>
        public override void Spawn(Transform spawnPoint)
        {
            Spawn();

            lastSpawnedObject.ResetLocalPosition(spawnPoint.gameObject);
        }

        /// <summary>
        /// Subtract prefab
        /// </summary>
        public void SubtractPrefab()
        {
            if (cubeLifeTime)
            {
                cubeLifeTime.DestroyCube();
            }
        }

        /// <summary>
        /// Mark kill prefab
        /// </summary>
        public void MarkKill()
        {
            if (cubeLifeTime)
            {
                cubeLifeTime.KillCube();
            }
        }

        /// <summary>
        /// Spawn with pool in point with delay
        /// </summary>
        public void DelayedSpawn(Transform spawnPoint)
        {
            coroutine = StartCoroutine(SpawnCubes(spawnPoint));
        }

        /// <summary>
        /// Back in pool
        /// </summary>
        /// <param name="itemPool"></param>
        public void ReturnToPool(ItemPool itemPool)
        {
            items.Add(itemPool);
            itemPool.gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            if(coroutine != null)
            StopCoroutine(coroutine);
        }

        private IEnumerator SpawnCubes(Transform spawnPoint)
        {
            yield return new WaitForSeconds(timeForSpawn / DifficultyLevelController.modifier);
            Spawn(spawnPoint);
        }
    }
}