namespace SimpleShooter.Features.UI
{
    using UnityEngine;

    /// <summary>
    /// Installer canvas
    /// </summary>
    public class CanvasInstaller : MonoBehaviour
    {
        [SerializeField] protected CanvasText canvasText = default;
        [SerializeField] protected CanvasContainer canvasContainer = default;

        protected virtual void Start() => canvasContainer.Init(canvasText);

        protected virtual void OnDestroy() => canvasContainer.Dispose();
    }
}
