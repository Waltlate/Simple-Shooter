namespace SimpleShooter.Features.UI
{
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Class for button interactable for loading game
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class ButtonLoadingAble : MonoBehaviour
    {
        private void Start()
        {
            if (PlayerPrefs.GetInt("MaxShotsPlayer", 50) == 50 &&
               PlayerPrefs.GetInt("MaxShotsTurret", 200) == 200 &&
               PlayerPrefs.GetFloat("ModifierSpawnBot", 1f) == 1f &&
               PlayerPrefs.GetInt("HealthPlayer", 100) == 100)
            {
                GetComponent<Button>().interactable = false;
            }
        }
    }
}
