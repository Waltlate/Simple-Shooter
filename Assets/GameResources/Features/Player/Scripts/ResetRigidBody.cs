namespace SimpleShooter.Features.Player
{
    using SimpleShooter.Features.Utils;
    using UnityEngine;

    /// <summary>
    /// Reset velocity
    /// </summary>
    public class ResetRigidBody : MonoBehaviour
    {
        private void OnEnable()
        {
            gameObject.ResetVelocity();
        }
    }
}
