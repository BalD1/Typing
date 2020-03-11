using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosnana : Ennemi
{
    
    protected Transform target;

    void Start()
    {
        hp = 20;
        speed = 2;
        stoppingDistance = 1.5f;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        Movement(target);
        if (DamageCalculated() > 0)
        {
            this.TakingDamage();
        }
    }

    private void SpellAction()
    {
        getSpell = GameManager.Instance.SendTypeOfSpell();

        switch (getSpell)
        {
            case "Water":
                sendAffiliation = "Resistance";
                break;
            case "Thunder":
                sendAffiliation = "Vulnerability";
                break;
            default:
                sendAffiliation = "Nothing";
                break;
        }
        Affiliation(sendAffiliation);
    }

    private void TakingDamage()
    {
        hp -= DamageCalculated();
        Debug.Log(this.gameObject + " hp : " + hp);
        ResetFinalDamage();
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OffensiveSpell spell = collision.collider.GetComponent<OffensiveSpell>();
        if (spell != null)
        {
            this.SpellAction();
        }
    }

}
