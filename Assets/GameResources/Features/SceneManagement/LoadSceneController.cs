namespace SimpleShooter.Features.SceneManagement
{
    using UnityEngine.SceneManagement;
    using UnityEngine;

    /// <summary>
    /// Load scene controller
    /// </summary>
    public class LoadSceneController : MonoBehaviour
    {
        private static bool isMenuScene = true;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                isMenuScene = !isMenuScene;
                SceneManager.LoadScene(isMenuScene ? "Menu" : "Game");
            }
        }
    }
}
