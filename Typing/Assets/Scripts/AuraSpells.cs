using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraSpells : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            Soin();
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
            Dégâts();
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            Bouclier();
        }
    }

    private void Soin()
    {
        GameManager.Instance.HealToBilly(1);
    }

    private void Dégâts()
    {

    }

    private void Bouclier()
    {
        GameManager.Instance.SetArmorUp(1);
    }
}
