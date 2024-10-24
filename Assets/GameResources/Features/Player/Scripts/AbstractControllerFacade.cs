namespace SimpleShooter.Features.Player
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Abstract controller facade
    /// </summary>
    public class AbstractControllerFacade : MonoBehaviour, IDisposable
    {
        public string Id => id;

        [SerializeField] protected string id = string.Empty;

        protected EntityFacade facadeInstance = default;

        /// <summary>
        /// Initialize facade
        /// </summary>
        /// <param name="playerFacade"></param>
        public virtual void Initialize(EntityFacade playerFacade)
        {
            facadeInstance = playerFacade;
            InitModule();
        }

        /// <summary>
        /// Initialize module
        /// </summary>
        public virtual void InitModule() { }

        /// <summary>
        /// Clear module
        /// </summary>
        public virtual void Dispose() { }
    }
}
