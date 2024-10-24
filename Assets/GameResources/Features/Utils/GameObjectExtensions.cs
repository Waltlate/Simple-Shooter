namespace SimpleShooter.Features.Utils
{
    using UnityEngine;

    /// <summary>
    /// Class with extension methods
    /// </summary>
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Reset local position
        /// </summary>
        /// <param name="target"></param>
        /// <param name="parent"></param>
        public static void ResetLocalPosition(this GameObject target, GameObject parent)
        {
            target.transform.SetParent(parent.transform);
            target.transform.localPosition = Vector3.zero;
            target.transform.SetParent(null);
        }
    }
}
