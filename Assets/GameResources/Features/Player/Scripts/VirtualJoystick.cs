namespace SimpleShooter.Features.Player
{
    using UnityEngine;
    using UnityEngine.EventSystems;

    /// <summary>
    /// Class for movement character with mobile stick
    /// </summary>
    public class VirtualJoystick : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
    {
        [SerializeField] private RectTransform joystickArea = default;
        [SerializeField] private RectTransform joystick = default;

        private Vector2 inputDirection = Vector2.zero;


        /// <summary>
        /// Move stick on begin drag
        /// </summary>
        /// <param name="eventData"></param>
        public void OnBeginDrag(PointerEventData eventData)
        {
            joystick.gameObject.SetActive(true);
            OnDrag(eventData);
        }

        /// <summary>
        /// Move stick in drag
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrag(PointerEventData eventData)
        {
            Vector2 position = eventData.position - new Vector2(joystickArea.position.x, joystickArea.position.y);
            inputDirection = position.normalized;
            joystick.anchoredPosition = inputDirection * (joystickArea.sizeDelta.x / 2);
        }

        /// <summary>
        /// Move stick on end drag
        /// </summary>
        /// <param name="eventData"></param>
        public void OnEndDrag(PointerEventData eventData)
        {
            joystick.anchoredPosition = Vector2.zero;
            inputDirection = Vector2.zero;
        }

        /// <summary>
        /// Get vector axis
        /// </summary>
        /// <returns></returns>
        public Vector2 GetDirection()
        {
            return inputDirection;
        }
    }
}
