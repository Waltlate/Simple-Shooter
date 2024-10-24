namespace SimpleShooter.Features.Spawners
{
    using System;

    /// <summary>
    /// Counts spawned cubes
    /// </summary>
    public class CurrentSpawnedCubes
    {
        public event Action<int> OnCubeCountChanged = delegate { };
        public event Action<int> OnCubeKillChanged = delegate { };
        public int TotalCubesSpawned => totalCubesSpawned;
        public int TotalCubesKill => totalCubesKill;

        private int totalCubesSpawned;
        private int totalCubesKill;

        public CurrentSpawnedCubes()
        {
            totalCubesSpawned = 0;
            totalCubesKill = 0;
            CubeLifeTime.onCubeCreated += HandleCubeCreated;
            CubeLifeTime.onCubeDestroyed += HandleCubeDestroyed;
            CubeLifeTime.onCubeKill += HandleCubeKill;
        }

        private void HandleCubeCreated()
        {
            totalCubesSpawned++;
            OnCubeCountChanged?.Invoke(totalCubesSpawned);
        }

        private void HandleCubeDestroyed()
        {
            if (totalCubesSpawned > 0)
            {
                totalCubesSpawned--;
                OnCubeCountChanged?.Invoke(totalCubesSpawned);
            }
        }

        private void HandleCubeKill()
        {
                totalCubesKill++;
                OnCubeKillChanged?.Invoke(totalCubesKill);
        }
    }
}
