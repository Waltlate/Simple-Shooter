namespace SimpleShooter.Features.Bot
{
    using UnityEngine;
    using SimpleShooter.Features.Player;

    /// <summary>
    /// Installer player for single instance
    /// </summary>
    public class SingleEntityInstaller : MonoBehaviour
    {
        [SerializeField] protected EntityFacade facade = default;
        [SerializeField] protected SingleEntityContainer container = default;

        protected virtual void Start() => container.Init(facade);

        protected virtual void OnDestroy() => container.Dispose();
    }
}
