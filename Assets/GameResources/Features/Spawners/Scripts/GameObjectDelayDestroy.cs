namespace SimpleShooter.Features.Spawners
{
    using SimpleShooter.Features.Pool;
    using System.Collections;
    using UnityEngine;

    /// <summary>
    /// Destroy gameobject with delay
    /// </summary>
    public class GameObjectDelayDestroy : MonoBehaviour
    {
        protected ItemPool tempItem = default;

        [SerializeField] private float timeToDestroy = 3f;

        private Coroutine coroutine;

        private void OnEnable()
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
                coroutine = null;
            }
            coroutine = StartCoroutine(DestroyAfterDelay(timeToDestroy));
        }

        private IEnumerator DestroyAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            gameObject.SetActive(false); ;
        }
    }
}