namespace SimpleShooter.Features.UI
{
    using SimpleShooter.Features.Utils;
    using UnityEngine;
    using SimpleShooter.Features.Spawners;
    using System.Collections.Generic;

    /// <summary>
    /// Button settings scene
    /// </summary>
    public sealed class SettingsButton : AbstractButton
    {
        public List<BaseSpawner> baseSpawners = new List<BaseSpawner>();
        [SerializeField] private GameObject prefabCanvasSettings = default;
        private BaseSpawner spawnerWidnow = default;
        private GameObject currentCanvasSettings;
        private string nameSpawner = "SpawnGameView";

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
            spawnerWidnow.ChangePrefab(prefabCanvasSettings);
            if (currentCanvasSettings == null)
            {
                spawnerWidnow.Spawn();
                currentCanvasSettings = spawnerWidnow.LastSpawnedObject;
            }
            currentCanvasSettings.SetActive(true);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CloseCanvas();
            }
        }

        private void CloseCanvas()
        {
            if (currentCanvasSettings != null)
            {
                currentCanvasSettings.SetActive(false);
            }
        }
    }
}
