using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private int hp;
    private int damageStock;
    private int brutDamageTaken;
    private int finalDamageTaken;

    private string typeOfSpell;

    public float stoppingDistance;

    private Transform target;
    Rigidbody2D cecileBody;

    void Start()
    {
        hp = 10;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        this.cecileBody = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
        damageStock = GameManager.Instance.EnnemiTookDamage();
        if (damageStock != 0)
        {
            this.stateModifier(damageStock);
            GameManager.Instance.ResetDamageToHostile();
        }

    }

    private void Movement()
    {
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    private void stateModifier(int damage)
    {
        brutDamageTaken = damage;
        typeOfSpell = GameManager.Instance.SendTypeOfSpell();

        switch(typeOfSpell)
        {
            case "FireBall":
                finalDamageTaken = brutDamageTaken / 2;
                break;
            case "Water":
                finalDamageTaken = brutDamageTaken * 2;
                break;
        }

        Debug.Log("brut : " + brutDamageTaken);
        Debug.Log("final : " +finalDamageTaken);
        hp -= finalDamageTaken;
        Debug.Log("hp : " + hp);
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    

}
