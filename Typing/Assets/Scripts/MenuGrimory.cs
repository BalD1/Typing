using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuGrimory : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    string spellName;


    public void OnPointerEnter(PointerEventData eventData)
    {
        spellName = gameObject.name.Replace("Grimoire_", "");
        UIManager.Instance.GetOnMouseOverSpell(spellName, true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager.Instance.GetOnMouseOverSpell(spellName, false);
    }

}
