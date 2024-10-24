namespace SimpleShooter.Features.Player
{
    using UnityEngine;
    using System.Collections;

    /// <summary>
    /// Class for random position generation
    /// </summary>
    public class PositionRandomizer : MonoBehaviour
    {
        [SerializeField] private bool isEnabled = true;

        private void Start()
        {
            if (isEnabled)
            {
                StartCoroutine(RandomizePositionCoroutine());
            }
        }

        private IEnumerator RandomizePositionCoroutine()
        {
            while (isActiveAndEnabled)
            {
                float randomX = Random.Range(-20f, 20f);
                float randomZ = Random.Range(-20f, 20f);
                transform.position = new Vector3(randomX, transform.position.y, randomZ);

                yield return new WaitForSeconds(1f);
            }
        }
    }
}
