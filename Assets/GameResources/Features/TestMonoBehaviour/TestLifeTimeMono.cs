namespace SimpleShooter.Features.TestMonoBehavior
{
    using UnityEngine;

    /// <summary>
    /// Test class that demonstrates how the Life Cycle works
    /// </summary>
    public class TestLifeTimeMono : MonoBehaviour
    {
        protected virtual void Awake() => Debug.Log("Awake");

        private void OnEnable() => Debug.Log("OnEnable");

        private void Start() => Debug.Log("Start");

        private void Update() => Debug.Log($"Update {Time.deltaTime}");

        private void FixedUpdate() => Debug.Log($"FixedUpdate {Time.deltaTime}");

        private void OnDisable() => Debug.Log("OnDisable");

        private void OnDestroy() => Debug.Log("OnDestroy");
    }
}
