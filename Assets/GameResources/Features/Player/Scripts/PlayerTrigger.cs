namespace SimpleShooter.Features.Player
{
    using SimpleShooter.Features.Utils;

    /// <summary>
    /// Behavior player in trigger
    /// </summary>
    public sealed class PlayerTrigger : AbstractTrigger<EntityFacade>
    {
        private void Start()
        {
            onTriggerEnter += Disable;
        }

        private void OnDestroy()
        {
            onTriggerEnter -= Disable;
        }

        private void Disable() => gameObject.SetActive(false);
    }
}
