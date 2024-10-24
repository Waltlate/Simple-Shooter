namespace SimpleShooter.Features.UI
{
    using UnityEngine;

    /// <summary>
    /// Custom Key Code Open Window
    /// </summary>
    [RequireComponent(typeof(Window))]
    public class CustomKeyCodeOpenWindow : MonoBehaviour
    {
        [SerializeField] protected KeyCode keyCode = default;
        [Header("Расположите здесь префаб экрана, который надо будет показать"),SerializeField] protected Window targetWindow = default;

        protected Window window = default;

        protected virtual void Awake() => window = GetComponent<Window>();

        protected virtual void Update()
        {
            if (Input.GetKeyDown(keyCode))
            {
                if (window.IsFocused)
                {
                    WindowsController.onWindowOpen(targetWindow.Id);
                }
            }
        }

    }
}