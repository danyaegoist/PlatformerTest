using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StickController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image background;
    [SerializeField] private Image pointer;
    private static Vector2 direction;

    private void Start()
    {
        background = GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(background.rectTransform, eventData.position, eventData.pressEventCamera, out position))
        {
            position.x = (position.x / background.rectTransform.sizeDelta.x);
            position.y = (position.y / background.rectTransform.sizeDelta.y);
            direction = new Vector2(position.x * 2 - 1, position.y * 2 - 1);
            direction = direction.magnitude > 1.0f ? direction.normalized : direction;

            pointer.rectTransform.anchoredPosition = new Vector2(direction.x * (background.rectTransform.sizeDelta.x / 2), direction.y * (background.rectTransform.sizeDelta.y / 2));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        direction = Vector2.zero;
        pointer.rectTransform.anchoredPosition = Vector2.zero;
    }

    public static float Horizontal()
    {
        return direction.x != 0 ? direction.x : Input.GetAxis("Horizontal");
    }

    public static float Vertical()
    {
        return direction.y != 0 ? direction.y : Input.GetAxis("Vertical");
    }
}
