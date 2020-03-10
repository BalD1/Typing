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
    [SerializeField]
    private GameObject WindPrefab;

    Rigidbody2D rigidbody2d;

    Vector2 position;
    Vector2 direction;

    List<GameObject> MultipleSpell = new List<GameObject>();


    string SpellNameStock;
    string SortEcrit;

    void Awake()
    {
        rigidbody2d = this.GetComponent<Rigidbody2D>();
        direction = this.transform.position;
        SpellNameStock = "";
        SortEcrit = "";
        
    }


    void Update()
    {
        
    }

    public void SpellLaunch(string SortEcrit)
    {
        SortEcrit = UIManager.sortEcrit.Replace("\r", "");
        switch (SortEcrit)
        {
            case "feu":
                this.FireBall();
                break;
            case "foudre":
                this.Thunder();
                break;
            case "eau":
                this.Water();
                break;
            case "vent":
                this.Wind();
                break;
            default:
                Debug.Log("Can't launch the spell");
                break;

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
        GameObject thunderObjectUp = Instantiate(ThunderPrefab, this.rigidbody2d.position, transform.rotation * Quaternion.Euler(0f, 0f, -30f));
        GameObject thunderObjectDown = Instantiate(ThunderPrefab, this.rigidbody2d.position, transform.rotation * Quaternion.Euler(0f, 0f, 30f));
        GameObject thunderObjectFront = Instantiate(ThunderPrefab, this.rigidbody2d.position, transform.rotation * Quaternion.identity);
        MultipleSpell.Add(thunderObjectUp);
        MultipleSpell.Add(thunderObjectDown);
        MultipleSpell.Add(thunderObjectFront);
        GetSpell("Thunder");
    }

    public void Water()
    {
        GameObject waterObject = Instantiate(WaterPrefab, this.rigidbody2d.position, Quaternion.identity);
        GetSpell("Water");
    }

    public void Wind()
    {
        GameObject windObject = Instantiate(WindPrefab, this.rigidbody2d.position, Quaternion.identity);
        GetSpell("Wind");
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

    public List<GameObject> ListSend()
    {
        return MultipleSpell;
    }
    
}
