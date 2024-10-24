namespace SimpleShooter.Features.Spawners
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Behavior cube
    /// </summary>
    public class CubeLifeTime : MonoBehaviour
    {
        public static event Action onCubeCreated = delegate { };
        public static event Action onCubeDestroyed = delegate { };
        public static event Action onCubeKill = delegate { };

        /// <summary>
        /// update cube subscribers with create cube
        /// </summary>
        public void CreateCube() => onCubeCreated.Invoke();

        /// <summary>
        /// update cube subscribers with destroy cube
        /// </summary>
        public void DestroyCube() => onCubeDestroyed.Invoke();

        /// <summary>
        /// update cube subscribers with kill cube
        /// </summary>
        public void KillCube() => onCubeKill.Invoke();
    }
}
