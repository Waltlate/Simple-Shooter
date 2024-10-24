namespace SimpleShooter.Features.Player
{
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Facade for character
    /// </summary>
    public class EntityFacade : MonoBehaviour
    {
        public IReadOnlyList<AbstractControllerFacade> Controllers => controllers;
        public IReadOnlyList<AbstractModelFacade> Models => models;
        public string Id => id;

        [SerializeField] protected string id = string.Empty;
        [SerializeField] protected List<AbstractControllerFacade> controllers = new List<AbstractControllerFacade>();
        [SerializeField] protected List<AbstractModelFacade> models = new List<AbstractModelFacade>();

        protected virtual void Awake()
        {
            controllers.ForEach(x => x.Initialize(this));
            models.ForEach(x => x.Initialize(this));
        }

        protected virtual void OnDestroy()
        {
            controllers.ForEach(x => x.Dispose());
            models.ForEach(x => x.Dispose());
        }
    }
}
