using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//[!!!] Too Specific, a general UI Handler could be better.
public class PopUpHandler : Singleton<PopUpHandler>
{
    public List<PopUpObject> listPopUpPrefabs;

    private new void Awake()
    {
        base.Awake();
        listPopUpPrefabs = Resources.LoadAll<PopUpObject>("PopUps").ToList();
    }
}
