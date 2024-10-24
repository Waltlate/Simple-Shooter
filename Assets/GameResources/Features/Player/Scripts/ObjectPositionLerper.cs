namespace SimpleShooter.Features.Player
{
    using System.Collections;
    using UnityEngine;

    /// <summary>
    /// Change position with lerp
    /// </summary>
    public class ObjectPositionLerper : MonoBehaviour
    {
        [SerializeField] private float targetX = 5f;
        [SerializeField] private float speed = 2f;

        private void Start()
        {
            StartCoroutine(ChangePositionLerper());
        }

        private IEnumerator ChangePositionLerper()
        {
            while (isActiveAndEnabled)
            {
                Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);

                if (Mathf.Abs(transform.position.x - targetX) < 0.1f)
                {
                    targetX = -targetX;
                }
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}
