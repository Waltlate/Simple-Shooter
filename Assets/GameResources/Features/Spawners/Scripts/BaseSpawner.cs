namespace SimpleShooter.Features.Spawners
{
    using UnityEngine;
    using Utils;

    /// <summary>
    /// Basic prefab spawner
    /// </summary>
    public class BaseSpawner : MonoBehaviour
    {
        public GameObject Prefab => prefab;
        public GameObject LastSpawnedObject => lastSpawnedObject;
        public string IdSpawner => idSpawner;

        [SerializeField] protected GameObject prefab = default;
        [SerializeField] protected bool isAutoSpawn = default;
        [SerializeField] protected string idSpawner = string.Empty;
        protected GameObject lastSpawnedObject = default;

        protected virtual void Start()
        {
            if (isAutoSpawn)
            {
                Spawn();
            }
        }

        /// <summary>
        /// Spawning prefab
        /// </summary>
        public virtual void Spawn() => lastSpawnedObject = Instantiate(prefab, transform.position, Quaternion.identity);

        /// <summary>
        /// Spawning prefab in point
        /// </summary>
        /// <param name="spawnPoint"></param>
        public virtual void Spawn(Transform spawnPoint) => lastSpawnedObject = Instantiate(prefab, spawnPoint);

        /// <summary>
        /// Spawning prefab at point with euler
        /// </summary>
        /// <param name="spawnPoint"></param>
        public virtual void Spawn(Transform spawnPoint, Quaternion rotation) => lastSpawnedObject = Instantiate(prefab, spawnPoint.position, rotation);

        /// <summary>
        /// Change instance prefab
        /// </summary>
        /// <param name="newPrefab"></param>
        public void ChangePrefab(GameObject newPrefab)
        {
            prefab = newPrefab;
        }
    }
}