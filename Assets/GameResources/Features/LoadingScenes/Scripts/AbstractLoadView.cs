namespace SimpleShooter.Features.Loader
{
    using UnityEngine;

    /// <summary>
    /// Basic abstract view to download
    /// </summary>
    public abstract class AbstractLoadView : MonoBehaviour
    {
        protected virtual void OnEnable() => LoadingController.onSceneProgressLoadChanged += OnUpdateProgressValue;

        protected virtual void OnDisable() => LoadingController.onSceneProgressLoadChanged -= OnUpdateProgressValue;

        /// <summary>
        /// Что делать view по факту получения сигнала о проценте загрузки
        /// </summary>
        /// <param name="inputValue"></param>
        public abstract void OnUpdateProgressValue(float inputValue);
    }
}