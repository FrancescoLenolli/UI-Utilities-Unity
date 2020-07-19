using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopUpElement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Tooltip("Decide what type of PopUp will be shown.\nType None will not show any PopUp.\nFull list in Assets > Resources > PopUps.")]
    [SerializeField] private PopUpObject.PopUpType popUpType = PopUpObject.PopUpType.None;
    [Tooltip("Text for the PopUp for this Object.")]
    [TextArea(2, 10)]
    public string popUpDescription = "PopUp Description.";

    private PopUpObject popUpPrefab;
    private PopUpObject popUpObject;

    private void Start()
    {
        popUpPrefab = ChoosePopUp();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (popUpPrefab != null)
        {
            popUpObject = Instantiate(popUpPrefab, transform, false);
            popUpObject.SetText(popUpDescription);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(popUpObject != null) Destroy(popUpObject.gameObject);
    }

    // Chose the right Prefab from the list of PopUps in the PopUpHandler, based on the Type
    private PopUpObject ChoosePopUp()
    {
        PopUpObject p = null;
        foreach (PopUpObject popUp in PopUpHandler.Instance.listPopUpPrefabs)
        {
            if (popUp.type == popUpType) p = popUp;
        }
        return p;
    }
}
