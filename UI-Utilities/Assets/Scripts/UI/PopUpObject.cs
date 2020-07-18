using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PopUpObject : MonoBehaviour
{
    public TextMeshProUGUI text;

    private RectTransform rectTransform;
    private Vector2 positionToMouse;
    private InputHandler inputHandler;


    private void Awake()
    {
        inputHandler = InputHandler.Instance;
        rectTransform = GetComponent<RectTransform>();
        positionToMouse = new Vector2(rectTransform.rect.width / 2, rectTransform.rect.height / 2);
    }
    private void LateUpdate()
    {
        Vector3 newPosition = new Vector3(inputHandler.mousePosition.x + positionToMouse.x, inputHandler.mousePosition.y + positionToMouse.y, 0);
        Vector3 mousePosition = new Vector3(inputHandler.mousePosition.x, inputHandler.mousePosition.y, 0);
        transform.localPosition = mousePosition;
    }

    public void SetText(string newText)
    {
        text.text = newText;
    }
}
