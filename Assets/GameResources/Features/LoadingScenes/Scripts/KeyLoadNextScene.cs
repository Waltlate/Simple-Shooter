namespace SimpleShooter.Features.Loader
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    /// <summary>
    /// Component that causes scenes to load
    /// </summary>
    public class KeyLoadNextScene : MonoBehaviour
    {
        [SerializeField] protected KeyCode keyCode = KeyCode.Return;
        [SerializeField] protected string targetNameScene = "Menu";

        protected virtual void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                LoadingController.NameNextScene = targetNameScene;
                SceneManager.LoadScene("Loading");
            }
        }
    }
}
