namespace SimpleShooter.Features.Player
{
    using System.Collections;
    using UnityEngine;

    /// <summary>
    /// Moving cube in radius
    /// </summary>
    public class MovingCube : MonoBehaviour
    {
        [SerializeField] private float moveDistance = 3f;
        [SerializeField] private float moveSpeed = 0.01f;

        private Vector3 targetPosition = Vector3.zero;
        private Vector3 startPosition = Vector3.zero;
        private float journeyLength = default;
        private float startTime = default;
        private float distCovered = default;
        private float journeyFraction = default;

        private void Start()
        {
            startPosition = transform.position; 
            StartCoroutine(MoveBackAndForth());
        }

        private IEnumerator MoveBackAndForth()
        {
            while (isActiveAndEnabled)
            {
                targetPosition = startPosition + new Vector3(moveDistance, 0, 0);
                yield return MoveToPosition(targetPosition);
                targetPosition = startPosition - new Vector3(moveDistance, 0, 0);
                yield return MoveToPosition(targetPosition);
            }
        }

        private IEnumerator MoveToPosition(Vector3 targetPosition)
        {
            journeyLength = Vector3.Distance(transform.position, targetPosition);
            startTime = Time.time;

            while (Vector3.Distance(transform.position, targetPosition) > 0.1f) 
            {
                distCovered = (Time.time - startTime) * moveSpeed; 
                journeyFraction = distCovered / journeyLength; 
                transform.position = Vector3.Lerp(transform.position, targetPosition, journeyFraction);
                yield return null;
            }

            transform.position = targetPosition;
        }
    }
}
