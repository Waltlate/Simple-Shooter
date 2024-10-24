namespace SimpleShooter.Features.Spawners
{
    using UnityEngine;
    using UnityEngine.UI;
    using SimpleShooter.Features.UI;
    using System;

    /// <summary>
    /// Display count cubes
    /// </summary>
    public class ActiveCubesDisplay : MonoBehaviour
    {
        [SerializeField] private Text activeCubesText;
        [SerializeField] private Text killCubesText;

        private CurrentSpawnedCubes currentSpawnedCubes;

        private void Awake()
        {
            currentSpawnedCubes = new CurrentSpawnedCubes();
            currentSpawnedCubes.OnCubeCountChanged += UpdateActiveCubesDisplay;
            currentSpawnedCubes.OnCubeKillChanged += UpdateKillCubesDisplay;
        }

        private void OnDisable()
        {
            PlayerPrefs.SetInt("CurrentKill", currentSpawnedCubes.TotalCubesKill);
        }

        private void OnDestroy()
        {
            currentSpawnedCubes.OnCubeCountChanged -= UpdateActiveCubesDisplay;
            currentSpawnedCubes.OnCubeKillChanged -= UpdateKillCubesDisplay;
        }

        private void UpdateActiveCubesDisplay(int count)
        {
            if (activeCubesText != null)
            {
                activeCubesText.text = "Active Cubes: " + count;
            }
        }

        private void UpdateKillCubesDisplay(int count)
        {
            if (killCubesText != null)
            {
                killCubesText.text = "Kill Cubes: " + count;
            }
        }
    }
}