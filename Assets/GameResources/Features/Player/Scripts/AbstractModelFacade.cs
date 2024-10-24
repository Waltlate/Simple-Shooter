namespace SimpleShooter.Features.Player
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Abstract model facade
    /// </summary>
    public class AbstractModelFacade : ScriptableObject, IDisposable
    {
        public string Id => id;

        [SerializeField] protected string id = string.Empty;

        protected EntityFacade facadeInstance = default;

        /// <summary>
        /// Initialize facade
        /// </summary>
        /// <param name="playerFacade"></param>
        public virtual void Initialize(EntityFacade playerFacade) => facadeInstance = playerFacade;

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

