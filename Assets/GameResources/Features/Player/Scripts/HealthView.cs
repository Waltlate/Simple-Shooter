namespace SimpleShooter.Features.Player
{
    using System.Linq;
    using UnityEngine;

    /// <summary>
    /// View health character
    /// </summary>
    public class HealthView : BaseEntityProvider
    {
        private HealthData healthData;
        private HealthController healthController;
        [SerializeField] private string beginText = "Health: ";

        protected override void OnPlayerInited()
        {
            healthData = (HealthData)container.Facade.Models.First(x => x is HealthData);
            if (healthData != null)
            {
                healthData.onHealthChange += UpdateText;
                UpdateText();
            }
        }

        private void UpdateText()
        {
            if (healthData != null)
            {
                healthController = (HealthController)container.Facade.Controllers.First(x => x is HealthController);
                if (textView != null)
                {
                    textView.text = $"{beginText}{healthController.CurrentHealth}";
                }
            }
        }
    }

}
