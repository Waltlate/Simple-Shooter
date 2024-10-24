namespace SimpleShooter.Features.Player
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Configuration speed
    /// </summary>
    [CreateAssetMenu(fileName = "SpeedModel", menuName = "SimpleShooter/Features/Player/SpeedModel")]
    public class MovementSpeedModel : AbstractModelFacade
    {
        public event Action onSpeedChange = delegate { };

        public float SpeedModifier
        {
            get => PlayerPrefs.GetFloat(SpeedKey, 2f);
            set
            {
                PlayerPrefs.SetFloat(SpeedKey, value);
                PlayerPrefs.Save();
            }
        }

        public float Speed
        {
            get => speed;
            set
            {
                speed = value;
            }
        }

        [SerializeField] protected float speed = default;
        [SerializeField] private string SpeedKey = "PlayerSpeed";

        /// <summary>
        /// Update subscribers player speed
        /// </summary>
        public void SpeedChange() => onSpeedChange.Invoke();

        /// <summary>
        /// Set new speed character
        /// </summary>
        /// <param name="newSpeed"></param>
        public void SetNewSpeed(float newSpeed)
        {
            speed = newSpeed;
        }
    }
}
