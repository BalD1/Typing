using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    [SerializeField]
    private GameObject FireballPrefab;
    [SerializeField]
    private GameObject ThunderPrefab;

    Rigidbody2D rigidbody2d;

    Vector2 position;
    Vector2 direction;


    void Awake()
    {
        rigidbody2d = this.GetComponent<Rigidbody2D>();
        direction = this.transform.position;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            this.FireBall();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            this.Thunder();
        }
    }

    // ---------------------------- SPELL LIST

    public void FireBall()
    {
        GameObject fireballObject = Instantiate(FireballPrefab, this.rigidbody2d.position, Quaternion.identity);
        GetSpell("FireBall");
    }

    public void Thunder()
    {
        GameObject thunderObject = Instantiate(ThunderPrefab, this.rigidbody2d.position, Quaternion.identity);
        GetSpell("Thunder");
    }

    public string GetSpell(string Spell)
    {
        string stock;
        stock = "";
        if(Spell != "Call")
        {
            stock = Spell;
        }
        return stock;
    }
}
