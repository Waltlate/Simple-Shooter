namespace SimpleShooter.Features.UI
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Container canvas
    /// </summary>
    [CreateAssetMenu(fileName = "CanvasContainer", menuName = "SimpleShooter/Features/UI/CanvasContainer")]
    public class CanvasContainer : ScriptableObject, IDisposable
    {
        public event Action onCanvasInited = delegate { };

        public event Action onCanvasDisposed = delegate { };

        public CanvasText CanvasText
        {
            get => canvasText;
            protected set
            {
                if (value != null)
                {
                    canvasText = value;
                    onCanvasInited();
                }
            }
        }

        [SerializeField] protected CanvasText canvasText = default;

        private void Start()
        {
            onCanvasInited.Invoke();
        }

        /// <summary>
        /// Initialization component canvas 
        /// </summary>
        /// <param name="canvas"></param>
        public void Init(CanvasText canvas) => CanvasText = canvas;

        /// <summary>
        /// Clear canvas
        /// </summary>
        public void Dispose() => CanvasText = null;
    }
}
