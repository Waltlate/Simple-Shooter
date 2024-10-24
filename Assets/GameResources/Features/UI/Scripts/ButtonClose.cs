namespace SimpleShooter.Features.UI
{
    using SimpleShooter.Features.Utils;

    /// <summary>
    /// Button close current view
    /// </summary>
    public class ButtonClose : AbstractButton
    {
        protected override void OnButtonClicked() => WindowsController.onWindowClose();
    }
}
