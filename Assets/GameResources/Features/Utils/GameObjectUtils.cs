namespace SimpleShooter.Features.Utils
{
    using UnityEngine;

    /// <summary>
    /// Class for gameobject operations
    /// </summary>
    public static class GameObjectUtils
    {
        /// <summary>
        /// Reset position gameobject
        /// </summary>
        /// <param name="gameObject"></param>
        public static void ResetPosition(this GameObject gameObject)
        {
            gameObject.transform.localPosition = Vector3.zero;
        }

        /// <summary>
        /// Reset velocity gameobject
        /// </summary>
        /// <param name="gameObject"></param>
        public static void ResetVelocity(this GameObject gameObject)
        {
            var rb = gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
            }
        }
    }
}