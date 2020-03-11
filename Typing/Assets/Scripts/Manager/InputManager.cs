using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("Ptdr wtf l'instance du Input est null O.o");
            }
            return instance;
        }
    }

    void Awake()
    {
        instance = this;
    }

    public bool valide = false;
    public string SortEcrit;
    public string NewSpellName;
    
    //La liste de spell

    List<string> spells = new List<string>();
    List<bool> LearnedSpells = new List<bool>();

    private void Start()
    {
        spells.Add("devmode");              // DEVMODE
        spells.Add("feu");
        spells.Add("eau");
        spells.Add("foudre");
        spells.Add("vent");

        LearnedSpells.Add(true);            // DEVMODE
        LearnedSpells.Add(true);
        for (int i = 1; i < spells.Count; i++)
        {
            LearnedSpells.Add(false);
        }
    }

    
    private void Update()
    {
        string input = Input.inputString;
        if (UIManager.Instance.boitePresent == true)
        {
            UIManager.Instance.inputField.text += input;
        }

        //Affiche la boite quand on appuie sur "Entrée"
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (UIManager.Instance.boitePresent == false)
            {
                UIManager.Instance.AfficherBoiteDeDialogue();
                UIManager.Instance.inputField.text = "";

            }
            else
            {
                UIManager.Instance.StoreSpell();

                VerifMots();

                UIManager.Instance.CacherBoiteDeDialogue();

                if (valide)
                {
                    UIManager.Instance.ReponseCorrecte();
                    GameObject.Find("Billy").GetComponent<Spells>().SpellLaunch(UIManager.sortEcrit);
                    this.valide = false;
                }
                else
                {
                    UIManager.Instance.ReponseFausse();
                }
                UIManager.sortEcrit = "";
            }
        }

        if (GameManager.Instance.SendLearnSpell() != "")
        {
            this.UnlockingSpells();
            GameManager.Instance.ResetLearning();
        }

    }

    public void UnlockingSpells()
    {
        NewSpellName = GameManager.Instance.SendLearnSpell();
        NewSpellName = NewSpellName.Replace("\r", "");
        foreach(string spell in spells)
        {
            if (spell == NewSpellName)
            {
                LearnedSpells[spells.IndexOf(spell)] = true;
            }
        }

    }

    public bool VerifMots()
    {
        foreach(string spell in spells)
        {
            SortEcrit = UIManager.sortEcrit.Replace("\r", "");
            if (SortEcrit == spell && LearnedSpells[spells.IndexOf(spell)] == true)
            {
                if (SortEcrit == "devmode")                     // DEVMODE
                {
                    this.DevMode();
                }
                this.valide = true;
                return true;
            }
        }
        
        return false;
    }

    private void DevMode()                          // DEVMODE
    {
        for (int i = 1; i < LearnedSpells.Count; i++)
        {
            LearnedSpells[i] = true;
        }
    }
    
}
