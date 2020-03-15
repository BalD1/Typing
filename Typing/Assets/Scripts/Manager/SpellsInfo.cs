using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class SpellsInfo : MonoBehaviour
{
    private static SpellsInfo instance;
    public static SpellsInfo Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("Bah ça alors le SpellsInfo est null c'est bizarre ?_?");
            }
            return instance;
        }
    }

    private List<List<string>> spellsList = new List<List<string>>();
        private List<string> spellName = new List<string>();
        private List<string> damage = new List<string>();
        private List<string> incantationTime = new List<string>();
        private List<string> throwSpeed = new List<string>();
        private List<string> manaCost = new List<string>();
        private List<string> description = new List<string>();
        private List<string> vulnerableEnnemies = new List<string>();
        private List<string> resistantsEnnemies = new List<string>();
    private List<bool> showVulnerable = new List<bool>();
    private List<bool> showResistants = new List<bool>();

    private string neededSpellName;
    private int indexOfSpell;
    private bool needToTranslate;
    private bool canShowEnnemieAffiliation;
    

    private void Awake()
    {
        instance = this;
        this.SpellsInitalization();
    }

    private void SpellsInitalization()
    {
        spellName.Add("FireBall");
        damage.Add("5");
        incantationTime.Add("0.6");
        throwSpeed.Add("100");
        manaCost.Add("0");
        description.Add("Une boule de feu en ligne droite");
        vulnerableEnnemies.Add("");                 //Index : 0
        resistantsEnnemies.Add("Cecile");           //Index : 0

        spellName.Add("Thunder");
        damage.Add("4");
        incantationTime.Add("0");
        throwSpeed.Add("75");
        manaCost.Add("0");
        description.Add("3 éclairs en diagonale et ligne droite");
        vulnerableEnnemies.Add("Bosnana");          //Index : 1
        resistantsEnnemies.Add("");                 //Index : 1

        spellName.Add("Water");
        damage.Add("3");
        incantationTime.Add("0.6");
        throwSpeed.Add("25");
        manaCost.Add("0");
        description.Add("Une bulle d'eau se déplacant en wiggle");
        vulnerableEnnemies.Add("Cecile");           //Index : 2
        resistantsEnnemies.Add("Bosnana");          //Index : 2

        spellName.Add("Wind");
        damage.Add("2");
        incantationTime.Add("0.6");
        throwSpeed.Add("80");
        manaCost.Add("0");
        description.Add("Bourrasque en ligne droite poussant les ennemies");
        vulnerableEnnemies.Add("");                 //Index : 3
        resistantsEnnemies.Add("");                 //Index : 3
        
        foreach (string vulnerable in vulnerableEnnemies)
        {
            showVulnerable.Add(false);
        }
        foreach (string resistant in resistantsEnnemies)
        {
            showResistants.Add(false);
        }
    }

    public void GetSpellName(string spellname, bool needToTranslate)
    {
        this.neededSpellName = spellname;
        if (needToTranslate)
        {
            this.Translation();
        }
        this.SearchSpell();
    }

    public void ShowAffiliation(string ennemie, string affiliation)
    {
        if (affiliation == "Vulnerability")
        {
            foreach(string ennemie2 in vulnerableEnnemies)
            {
                if(ennemie == ennemie2)
                {
                    showVulnerable[vulnerableEnnemies.IndexOf(ennemie2)] = true;
                }
            }
        }
        else
        {
            foreach(string ennemie2 in resistantsEnnemies)
            {
                if(ennemie == ennemie2)
                {
                    showResistants[resistantsEnnemies.IndexOf(ennemie2)] = true;
                }
            }
        }
    }

    private void Translation()
    {
        switch (this.neededSpellName)
        {
            case "eau":
                this.neededSpellName = "Water";
                break;
            case "vent":
                this.neededSpellName = "Wind";
                break;
            case "feu":
                this.neededSpellName = "FireBall";
                break;
            case "foudre":
                this.neededSpellName = "Thunder";
                break;
            default:
                Debug.Log("Can't translate " + this.neededSpellName);
                break;

        }
    }

    private void SearchSpell()
    {
        foreach(string spell in spellName)
        {
            if (spell == neededSpellName)
            {
                indexOfSpell = spellName.IndexOf(spell);
            }
        }
    }
    

    public int SendSpellDamage()
    {
        return int.Parse(damage[indexOfSpell]);
    }

    public float SendSpellAnimTime()
    {
        return float.Parse(incantationTime[indexOfSpell], CultureInfo.InvariantCulture);
    }

    public int SendThrowSpeed()
    {
        return int.Parse(throwSpeed[indexOfSpell]);
    }

    public int SendManaCost()
    {
        return int.Parse(manaCost[indexOfSpell]);
    }

    public string SendDescription()
    {
        return description[indexOfSpell];
    }

    public string SendVulnerables()
    {
        if (showVulnerable[indexOfSpell])
        {
            return vulnerableEnnemies[indexOfSpell];
        }
        return "XXXXXXX";
    }

    public string SendResistants()
    {
        if (showResistants[indexOfSpell])
        {
            return resistantsEnnemies[indexOfSpell];
        }
        return "XXXXXXX";
    }
}
