using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    [SerializeField]
    private GameObject FireballPrefab;
    [SerializeField]
    private GameObject ThunderPrefab;
    [SerializeField]
    private GameObject WaterPrefab;

    Rigidbody2D rigidbody2d;

    Vector2 position;
    Vector2 direction;


    string SpellNameStock;

    void Awake()
    {
        rigidbody2d = this.GetComponent<Rigidbody2D>();
        direction = this.transform.position;
        SpellNameStock = "";
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
        if (Input.GetKeyDown(KeyCode.B))
        {
            this.Water();
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

    public void Water()
    {
        GameObject waterObject = Instantiate(WaterPrefab, this.rigidbody2d.position, Quaternion.identity);
        GetSpell("Water");
    }

    public string GetSpell(string Spell)
    {
        if(Spell != "Call")
        {
            SpellNameStock = Spell;
        }
        else
        {
            Spell = SpellNameStock;
        }
        return Spell;
    }
}
