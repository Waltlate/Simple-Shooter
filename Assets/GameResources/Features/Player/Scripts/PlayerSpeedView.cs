namespace SimpleShooter.Features.Player
{
    using System.Linq;

    /// <summary>
    /// View speed player
    /// </summary>
    public class PlayerSpeedView : BaseEntityProvider
    {
        private MovementSpeedModel speedModel;
        private MovementController movementController;

        protected override void OnPlayerInited()
        {
            speedModel = (MovementSpeedModel)container.Facade.Models.First(x => x is MovementSpeedModel);
            if (speedModel != null)
            {
                speedModel.onSpeedChange += UpdateText;
                UpdateText();
            }
        }

        private void UpdateText()
        {
            if (speedModel != null)
            {
                movementController = (MovementController)container.Facade.Controllers.First(x => x is MovementController);
                if (textView != null)
                {
                    textView.text = $"Current Speed: {movementController.speedModel.SpeedModifier}";
                }
            }
        }
    }
}
