namespace SimpleShooter.Features.UI
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Class for canvas objects
    /// </summary>
    public class CanvasText : MonoBehaviour
    {
        public event Action onEnableCanvas = delegate { };

        private void OnEnable()
        {
            onEnableCanvas();
        }
    }
}
