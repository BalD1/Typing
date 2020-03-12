using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{

    protected int hp;
    protected float speed;
    protected int damageStock;
    protected int brutDamageTaken;
    protected int finalDamageTaken;

    protected string getSpell;
    protected string sendAffiliation;

    protected string typeOfSpell;

    public float stoppingDistance;

    void Start()
    {
        this.speed = 4;
        this.stoppingDistance = 1;
        typeOfSpell = "";

    }

    void Update()
    {


    }

    protected void Movement(Transform target)
    {
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    protected void Affiliation(string affiliation)
    {
        damageStock = GameManager.Instance.EnnemiTookDamage();
        if (affiliation != "")
        {
            this.typeOfSpell = affiliation;
        }
        if (typeOfSpell != "")
        {
            this.damageCalculation(damageStock);
        }
    }

    private void damageCalculation(int damage)
    {
        brutDamageTaken = damage;

        switch(typeOfSpell)
        {
            case "Vulnerability":
                finalDamageTaken = brutDamageTaken * 2;
                break;
            case "Resistance":
                finalDamageTaken = brutDamageTaken / 2;
                break;
        }


        Debug.Log("brut : " + brutDamageTaken);
        Debug.Log("final : " + finalDamageTaken);
        typeOfSpell = "";
        GameManager.Instance.ResetDamageToHostile();
    }

    protected int DamageCalculated()
    {
        return finalDamageTaken;
    }

    protected void ResetFinalDamage()
    {
        finalDamageTaken = 0;
    }


    

}
