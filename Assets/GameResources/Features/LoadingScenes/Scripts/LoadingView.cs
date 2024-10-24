namespace SimpleShooter.Features.Loader
{
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// View loading level
    /// </summary>
    [RequireComponent(typeof(Image))]
    public class LoadingView : AbstractLoadView
    {
        private Image _imageView = default;
        private float _target = 0.5f;

        protected virtual void Start()
        {
            _imageView = GetComponent<Image>();
            _target = 0f;
            _imageView.fillAmount = 0f;
        }

        protected virtual void Update() => _imageView.fillAmount = Mathf.Lerp(_imageView.fillAmount, _target, 0.5f * Time.unscaledDeltaTime);

        public override void OnUpdateProgressValue(float inputValue)
        {
            if (inputValue > _target)
            {
                _target = inputValue;
            }
        }
    }
}