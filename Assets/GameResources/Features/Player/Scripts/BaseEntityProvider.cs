namespace SimpleShooter.Features.Player
{
    using UnityEngine;
    using SimpleShooter.Features.UI;
    using UnityEngine.UI;

    public abstract class BaseEntityProvider : MonoBehaviour
    {
        [SerializeField] protected EntityContainer container = default;
        [SerializeField] protected Text textView = default;
        protected CanvasText canvasText = default;

        protected virtual void OnEnable()
        {
            if (container.Facade != null)
            {
                OnPlayerInited();
            }
            container.onPlayerInited += OnPlayerInited;
            container.onPlayerDisposed += OnPlayerDisposed;
        }

        protected virtual void OnDisable()
        {
            container.onPlayerInited -= OnPlayerInited;
            container.onPlayerDisposed -= OnPlayerDisposed;
        }

        protected abstract void OnPlayerInited();

        protected virtual void OnPlayerDisposed() { }
    }
}
