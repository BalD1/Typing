using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cecile : Ennemi
{

    protected Transform target;

    void Start()
    {
        hp = 10;
        speed = 4;
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
            case "FireBall":
                sendAffiliation = "Resistance";
                break;
            case "Water":
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
