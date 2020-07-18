using UnityEngine;
using UnityEngine.EventSystems;

public class PopUpElement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] PopUpObject popUpPrefab = null;
    [TextArea(2, 10)]
    public string popUpDescription;

    PopUpObject popUpObject;

    public void OnPointerEnter(PointerEventData eventData)
    {
        popUpObject = Instantiate(popUpPrefab, transform, false);
        popUpObject.SetText(popUpDescription);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(popUpObject.gameObject);
    }
}
