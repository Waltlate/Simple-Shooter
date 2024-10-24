namespace SimpleShooter.Features.Loader
{
    using SimpleShooter.Features.GameConditions;
    using UnityEngine;

    /// <summary>
    /// Button load next scene with current logic in game scene
    /// </summary>
    public class LoadButtonViewWithSave : LoadButtonView
    {
        [SerializeField] private bool isNewGame = false;

        protected override void OnButtonClicked()
        {
            if (isAlreadyClicked) return;
            if (isNewGame)
            {
                PlayerPrefs.SetInt("IsNewGame", 1);
            }
            else
            {
                PlayerPrefs.SetInt("IsNewGame", 0);
            }
            LoadScene();
        }

    }
}
