namespace SimpleShooter.Features.Player
{
    using UnityEngine;

    /// <summary>
    /// Behavior bullet
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public sealed class MoveBullet : MonoBehaviour
    {
        [SerializeField] private Vector3 directionBullet = Vector3.forward;
        private Rigidbody rb;

        private void OnEnable()
        {
            rb = gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = directionBullet;
            }
        }
    }
}
