namespace SimpleShooter.Features.Loader
{
    using SimpleShooter.Features.Utils;
    using UnityEngine;

    /// <summary>
    /// Button load next scene 
    /// </summary>
    public class LoadButtonView : AbstractButton
    {
        [SerializeField] protected string targetScene = default;

        protected bool isAlreadyClicked = false;

        protected override void OnButtonClicked()
        {
            if (isAlreadyClicked) return;
            LoadScene();
        }

        protected void LoadScene()
        {
            LoadingController.NameNextScene = targetScene;
            isAlreadyClicked = true;
            LoadingController.StartLoad();
        }
    }
}