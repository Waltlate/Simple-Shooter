namespace SimpleShooter.Features.GameConditions
{
    using SimpleShooter.Features.Player;
    using SimpleShooter.Features.UI;
    using System.Collections;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Controller for game scene logic
    /// </summary>
    public class DifficultyLevelController : MonoBehaviour
    {
        public static float modifier = 1f;

        [SerializeField] private ShootsModel playerShootsModel = default;
        [SerializeField] private ShootsModel turretShootsModel = default;
        [SerializeField] private MovementSpeedModel kamikazeSpeedModel = default;
        [SerializeField] private MovementSpeedModel turretSpeedModel = default;
        [SerializeField] private MovementSpeedModel playerSpeedModel = default;
        [SerializeField] private HealthController playerHealthController = default;
        [SerializeField] private Text timeText = default;
        [SerializeField, Min(0)] private float timeGame = 30f;
        [SerializeField, Min(0)] protected float timeForHarder = 10f;

        private float currentTime = default;
        private float addTime = default;

        private void Start()
        {
            if(PlayerPrefs.GetInt("IsNewGame", 1) == 1)
            {
                SetDefalutParameters();
            }
            else
            {
                LoadSavedParameters();
            }

            StartCoroutine(IncreaseParameters());
        }

        private void Update()
        {
            currentTime += addTime;
            currentTime -= Time.deltaTime;
            timeText.text = ConvertSecondsToMinutesAndSeconds(currentTime);
            if (currentTime < 0)
            {
                WindowsController.onWindowOpen("GameOver");
            }
            addTime = 0;
        }

        private void OnDisable()
        {
            SaveParameters();
        }

        /// <summary>
        /// Add time game
        /// </summary>
        /// <param name="addTime"></param>
        public void AddTime(float value)
        {
            currentTime += value;
        }

        /// <summary>
        /// Translate seconds in minutes and seconds
        /// </summary>
        /// <param name="totalSeconds">Общее количество секунд.</param>
        /// <returns>Строка в формате "минуты:секунды".</returns>
        public string ConvertSecondsToMinutesAndSeconds(float totalSeconds)
        {
            return $"{(int)totalSeconds / 60:D2}mm:{(int)totalSeconds % 60:D2}ss";
        }

        private void SetDefalutParameters()
        {
            playerShootsModel.MaxShots = 50;
            turretShootsModel.MaxShots = 200;
            kamikazeSpeedModel.Speed = 1f;
            turretSpeedModel.Speed = 0.5f;
            modifier = 1f;
            currentTime = timeGame;
        }

        private void LoadSavedParameters()
        {
            playerShootsModel.MaxShots = PlayerPrefs.GetInt("MaxShotsPlayer", 50);
            turretShootsModel.MaxShots = PlayerPrefs.GetInt("MaxShotsTurret", 200);
            kamikazeSpeedModel.Speed = PlayerPrefs.GetFloat("SpeedKamikaze", 1f);
            turretSpeedModel.Speed = PlayerPrefs.GetFloat("SpeedTurret", 0.5f);
            playerSpeedModel.Speed = PlayerPrefs.GetFloat("SpeedPlayer", 2f);
            modifier = PlayerPrefs.GetFloat("ModifierSpawnBot", 1f);
            currentTime = PlayerPrefs.GetFloat("CurrentTime", 30f);
            playerHealthController.CurrentHealth = PlayerPrefs.GetInt("HealthPlayer", 100);
        }

        /// <summary>
        /// Save games parameters
        /// </summary>
        public void SaveParameters()
        {
            PlayerPrefs.SetInt("MaxShotsPlayer", playerShootsModel.MaxShots);
            PlayerPrefs.SetInt("MaxShotsTurret", turretShootsModel.MaxShots);
            PlayerPrefs.SetFloat("SpeedKamikaze", kamikazeSpeedModel.Speed);
            PlayerPrefs.SetFloat("SpeedTurret", turretSpeedModel.Speed);
            PlayerPrefs.SetFloat("SpeedPlayer", playerSpeedModel.Speed);
            PlayerPrefs.SetFloat("ModifierSpawnBot", modifier);
            PlayerPrefs.SetFloat("CurrentTime", currentTime);
            PlayerPrefs.SetInt("HealthPlayer", playerHealthController.CurrentHealth);
        }

        private IEnumerator IncreaseParameters()
        {
            while (isActiveAndEnabled)
            {
                yield return new WaitForSeconds(timeForHarder);
                kamikazeSpeedModel.Speed = Mathf.Clamp(kamikazeSpeedModel.Speed + 1.2f, 1f, 2f);
                turretSpeedModel.Speed = Mathf.Clamp(turretSpeedModel.Speed + 0.2f, 0.5f, 2f);
                modifier = Mathf.Clamp(modifier + 0.2f, 1,2);
            }
        }
    }
}
