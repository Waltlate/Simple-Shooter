namespace SimpleShooter.Features.UI
{
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// View best score in main menu
    /// </summary>
    public sealed class HighScoreView : MonoBehaviour
    {
        [SerializeField] private Text highScoreText = default;
        [SerializeField] private Text currentScoreText = default;

        private int highScore = default;
        private int currentScore = default;

        private void Start()
        {
            currentScore = PlayerPrefs.GetInt("CurrentKill", 0);
            highScore = PlayerPrefs.GetInt("BestEnemyKill", 0);
            if(currentScore > highScore)
            {
                highScore = currentScore;
                PlayerPrefs.SetInt("BestEnemyKill", highScore);
            }

            if(currentScoreText != null)
                currentScoreText.text = $"Score: {currentScore}";
            highScoreText.text = $"Highscore: {highScore}";
        }
    }
}
