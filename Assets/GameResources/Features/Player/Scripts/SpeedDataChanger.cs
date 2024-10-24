namespace SimpleShooter.Features.Player
{
    using UnityEngine;

    /// <summary>
    /// Speed data change in key
    /// </summary>
    public sealed class SpeedDataChanger : MonoBehaviour
    {
        [SerializeField] private MovementSpeedModel speedData;

        private void Update()
        {
            for (int i = 1; i <= 2; i++)
            {
                if (Input.GetKeyDown(i.ToString()))
                {
                    speedData.SpeedModifier = i;
                    speedData.SpeedChange();
                }
            }
        }
    }
}
