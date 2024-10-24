namespace SimpleShooter.Features.UI
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Class for prefab window
    /// </summary>
    public class Window : MonoBehaviour
    {
        public event Action<bool> onWindowIsFocused = delegate { };
        public string Id => id;
        [SerializeField] protected string id = default;

        public bool IsFocused
        {
            get => isFocused;
            set
            {
                isFocused = value;
                onWindowIsFocused(isFocused);
            }
        }

        protected bool isFocused = default;
    }
}
