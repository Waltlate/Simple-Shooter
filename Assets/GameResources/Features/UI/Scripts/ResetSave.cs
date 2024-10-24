namespace SimpleShooter.Features.UI
{
    using UnityEngine;

    /// <summary>
    /// Reset Save data
    /// </summary>
    public class ResetSave : MonoBehaviour
    {
        private void Start()
        {
            PlayerPrefs.DeleteKey("MaxShotsPlayer");
            PlayerPrefs.DeleteKey("MaxShotsTurret");
            PlayerPrefs.DeleteKey("SpeedKamikaze");
            PlayerPrefs.DeleteKey("SpeedTurret");
            PlayerPrefs.DeleteKey("SpeedPlayer");
            PlayerPrefs.DeleteKey("ModifierSpawnBot");
            PlayerPrefs.DeleteKey("CurrentTime");
            PlayerPrefs.DeleteKey("HealthPlayer");
        }
    }
}
