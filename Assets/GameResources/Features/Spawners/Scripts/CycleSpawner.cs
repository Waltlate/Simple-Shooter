namespace SimpleShooter.Features.Spawners
{
    using SimpleShooter.Features.GameConditions;
    using System.Collections;
    using UnityEngine;

    /// <summary>
    /// Cyclic prefab spawner
    /// </summary>
    public class CycleSpawner : BaseSpawner
    {
        [SerializeField] protected CubeLifeTime cubeLifeTime = default;
        [SerializeField] protected float timeForSpawn = 1f;

        protected override void Start() 
        {
            if (isAutoSpawn)
            {
                StartCoroutine(SpawnCubesOverTime());
            }
        }

        private IEnumerator SpawnCubesOverTime()
        {
            while (isActiveAndEnabled)
            {
                Spawn();
                yield return new WaitForSeconds(timeForSpawn / DifficultyLevelController.modifier); 
            }
        }
    }
}