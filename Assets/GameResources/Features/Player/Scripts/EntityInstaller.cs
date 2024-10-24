namespace SimpleShooter.Features.Player
{
    using UnityEngine;

    /// <summary>
    /// Installer character
    /// </summary>
    public class EntityInstaller : MonoBehaviour
    {
        [SerializeField] protected EntityFacade facade = default;
        [SerializeField] protected EntityContainer container = default;

        protected virtual void Start() => container.Init(facade);

        protected virtual void OnDestroy() => container.Dispose();
    }
}
