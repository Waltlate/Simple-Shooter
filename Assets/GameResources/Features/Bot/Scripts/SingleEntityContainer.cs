namespace SimpleShooter.Features.Bot
{
    using System;
    using UnityEngine;
    using SimpleShooter.Features.Player;

    /// <summary>
    /// Container character for single instance
    /// </summary>
    public class SingleEntityContainer : MonoBehaviour
    {
        public event Action onPlayerInited = delegate { };

        public event Action onPlayerDisposed = delegate { };

        public EntityFacade Facade
        {
            get => entityFacade;
            protected set
            {
                if (value != null)
                {
                    entityFacade = value;
                    onPlayerInited();
                }
            }
        }
        public string Id => id;

        [SerializeField] protected string id = string.Empty;
        [SerializeField] protected EntityFacade entityFacade = default;

        private void Start()
        {
            onPlayerInited.Invoke();
        }

        /// <summary>
        /// Initialization component player 
        /// </summary>
        /// <param name="facade"></param>
        public void Init(EntityFacade facade) => Facade = facade;

        /// <summary>
        /// Clear facade
        /// </summary>
        public void Dispose() => Facade = null;
    }
}

