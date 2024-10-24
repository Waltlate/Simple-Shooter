namespace SimpleShooter.Features.UI
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Selector for quality game
    /// </summary>
    public class QualityLevelSelector : MonoBehaviour
    {
        [SerializeField] private Dropdown qualityDropdown;

        private void Start()
        {
            qualityDropdown.ClearOptions();
            qualityDropdown.AddOptions(new List<string>(QualitySettings.names));
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("QualityLevel", QualitySettings.names.Length - 1));
            qualityDropdown.value = QualitySettings.GetQualityLevel();
            qualityDropdown.RefreshShownValue();
            qualityDropdown.onValueChanged.AddListener(OnQualityChange);
        }

        private void OnDestroy()
        {
            qualityDropdown.onValueChanged.RemoveListener(OnQualityChange);
        }

        private void OnQualityChange(int index)
        {
            QualitySettings.SetQualityLevel(index);
            PlayerPrefs.SetInt("QualityLevel", QualitySettings.GetQualityLevel());
        }
    }
}
