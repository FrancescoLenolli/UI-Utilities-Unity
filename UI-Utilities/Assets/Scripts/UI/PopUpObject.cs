using System.Collections;
using TMPro;
using UnityEngine;

public class PopUpObject : MonoBehaviour
{
    // Type inside the brackets below to add new parameters.
    public enum PopUpType { None, TextBlack, TextWhite, ImageRed }
    public TextMeshProUGUI text;
    [Tooltip("When adding a new PopUp Prefab in the Assets > Resources > PopUp folder, add a new Type to the enum PopUpType contained in this Script.")]
    public PopUpType type = PopUpType.None;
    [Tooltip("Check if the PopUp will show up with a fade effect.")]
    [SerializeField] private bool canFade = true;
    [SerializeField] private float fadeTime = 1.0f;

    [HideInInspector] public CanvasGroup canvasGroup;

    private InputHandler inputHandler;
    private RectTransform rectTransform;
    private Vector2 offsetToMousePosition;

    private void Awake()
    {
        inputHandler = InputHandler.Instance;

        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        offsetToMousePosition = new Vector2(rectTransform.rect.width * 0.5f, rectTransform.rect.height * 0.5f);

        StartingBehaviour();
    }

    private void LateUpdate()
    {
        Vector3 newPosition = new Vector3(inputHandler.mousePosition.x + offsetToMousePosition.x, inputHandler.mousePosition.y + offsetToMousePosition.y, 0);
        transform.position = newPosition;
    }

    public void SetText(string newText)
    {
        text.text = newText;
    }

    private void StartingBehaviour()
    {
        canvasGroup.alpha = 0;
        if (canFade) StartCoroutine(FadeIn());
        else canvasGroup.alpha = 1;
    }

    private IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            canvasGroup.alpha += Time.deltaTime * fadeTime;
            yield return null;
        }
    }
}
