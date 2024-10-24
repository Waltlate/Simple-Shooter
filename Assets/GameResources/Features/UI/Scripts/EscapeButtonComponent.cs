namespace SimpleShooter.Features.UI
{
    using UnityEngine;

    /// <summary>
    /// Component that causes the window to close on keys.
    /// Must be located strictly on the screen prefab itself
    /// </summary>
    [RequireComponent(typeof(Window))]
    public class EscapeButtonComponent : MonoBehaviour
    {
        protected Window window = default;

        protected virtual void Awake() => window = GetComponent<Window>();

        protected virtual void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (window.IsFocused)
                {
                    WindowsController.onWindowClose();
                }
            }
        }
    }
}