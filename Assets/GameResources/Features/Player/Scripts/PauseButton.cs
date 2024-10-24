namespace SimpleShooter.Features.Player
{
    using SimpleShooter.Features.Utils;
    using UnityEngine;
    using SimpleShooter.Features.Spawners;
    using System.Collections.Generic;

    /// <summary>
    /// Button pause scene
    /// </summary>
    public class PauseButton : AbstractButton
    {
        private bool isPaused = false;
        private string nameSpawner = "SpawnGameView";

        public List<BaseSpawner> baseSpawners = new List<BaseSpawner>();
        private BaseSpawner spawnerWidnow = default;
        [SerializeField] private GameObject prefabCanvasPause = default;
        private GameObject currentCanvasPause;

        protected override void Awake()
        {
            base.Awake();
            baseSpawners.AddRange(FindObjectsOfType<BaseSpawner>());

            foreach (BaseSpawner elem in baseSpawners)
            {
                if (elem.IdSpawner == nameSpawner)
                {
                    spawnerWidnow = elem;
                    break;
                }
            }
        }

        protected override void OnButtonClicked()
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                Time.timeScale = 0;
                spawnerWidnow.ChangePrefab(prefabCanvasPause);
                if (currentCanvasPause == null)
                {
                    spawnerWidnow.Spawn();
                    currentCanvasPause = spawnerWidnow.LastSpawnedObject;
                }
                currentCanvasPause.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                currentCanvasPause.SetActive(false);
            }
        }
    }
}
