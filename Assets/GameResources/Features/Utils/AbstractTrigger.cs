namespace SimpleShooter.Features.Utils
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Abstract class for getting a specific component from triggers
    /// </summary>
    public abstract class AbstractTrigger<T> : MonoBehaviour where T : Component
    {
        /// <summary>
        /// Signals that a component has been received
        /// </summary>
        public event Action onTriggerEnter = delegate { };

         /// <summary>
         /// Signals that a component has been received
         /// </summary>
        public event Action onTriggerExit = delegate { };

        protected T targetComponent = default;

        protected virtual void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out targetComponent))
            {
                onTriggerEnter();
            }
            else
            {
                targetComponent = other.GetComponentInParent<T>();
                if(targetComponent != null)
                {
                    onTriggerEnter();
                }
            }
        }


        protected virtual void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out targetComponent))
            {
                onTriggerExit();
            }
            else
            {
                targetComponent = other.GetComponentInParent<T>();
                if (targetComponent != null)
                {
                    onTriggerExit();
                    targetComponent = null;
                }
            }
        }
    }
}
