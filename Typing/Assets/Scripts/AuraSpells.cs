using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraSpells : MonoBehaviour
{
    private bool spellFlag = false;
    private int timer = 0;

    Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I) && spellFlag == false)
        {
            spellFlag = true;
            Soin();
        }
        if(Input.GetKeyDown(KeyCode.O) && spellFlag == false)
        {
            spellFlag = true;
            Dégâts();
        }
        if(Input.GetKeyDown(KeyCode.P) && spellFlag == false)
        {
            spellFlag = true;
            Bouclier();
        }

        if(spellFlag == true)
        {
            timer++;
            if(timer == 60)
            {
                timer = 0;
                spellFlag = false;
                animator.SetBool("Heal", false);
                animator.SetBool("Armure", false);
                animator.SetBool("Puissance", false);
            }
        }
    }

    private void Soin()
    {
        GameManager.Instance.HealToBilly(1);
        animator.SetBool("Heal", true);
    }

    private void Dégâts()
    {
        animator.SetBool("Puissance", true);
    }

    private void Bouclier()
    {
        GameManager.Instance.SetArmorUp(1);
        animator.SetBool("Armure", true);
    }
}
