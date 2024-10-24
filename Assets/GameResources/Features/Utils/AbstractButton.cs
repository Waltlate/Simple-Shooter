namespace SimpleShooter.Features.Utils
{
    using UnityEngine.UI;
    using UnityEngine;

    /// <summary>
    /// Class abstract button
    /// </summary>
    [RequireComponent(typeof(Button))]
    public abstract class AbstractButton : MonoBehaviour
    {
        public Button ButtonInstance => button;

        protected Button button = default;

        protected virtual void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnButtonClicked);
        }

        protected virtual void OnDestroy() => button.onClick.RemoveListener(OnButtonClicked);

        protected abstract void OnButtonClicked();
    }
}