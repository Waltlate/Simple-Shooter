namespace SimpleShooter.Features.Player
{
    using System.Linq;

    /// <summary>
    /// View ammo player
    /// </summary>
    public class AmmoView : BaseEntityProvider
    {
        private ShootsModel shootsModel;

        protected override void OnPlayerInited()
        {
            shootsModel = (ShootsModel)container.Facade.Models.First(x => x is ShootsModel);
            if (shootsModel != null)
            {
                shootsModel.onBulletChange += UpdateText;
                UpdateText();
            }
        }

        private void UpdateText()
        {
            if (shootsModel != null)
            {
                if (textView != null)
                {
                    textView.text = $"Current bullet: {shootsModel.MaxShots}";
                }
            }
        }
    }
}
