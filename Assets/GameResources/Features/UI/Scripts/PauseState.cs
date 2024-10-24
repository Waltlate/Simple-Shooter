namespace SimpleShooter.Features.UI
{
    using UnityEngine;

    /// <summary>
    /// The component controls the pause, is located on the prefab of the pause window or another screen that should stop time
    /// </summary>
    public sealed class PauseState : MonoBehaviour
    {
        private void OnEnable()
        {
            Time.timeScale = 0f;
        }

        private void OnDisable()
        {
            Time.timeScale = 1f;
        }
    }
}