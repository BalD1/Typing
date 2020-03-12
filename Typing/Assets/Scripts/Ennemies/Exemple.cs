using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exemple : Ennemi
{

    // COPIER D'ICI
    protected Transform target;

    void Start()
    {
        hp = 0;              // A MODIFIER
        speed = 0;              // A MODIFIER
        stoppingDistance = 0f;              // A MODIFIER
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
            case "sort pas efficace":              // A MODIFIER
                sendAffiliation = "Resistance";
                break;
            case "sort efficace":              // A MODIFIER
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
