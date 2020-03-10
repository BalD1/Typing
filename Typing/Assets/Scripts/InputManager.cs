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
    
    //La liste de spell
    List<string> spells = new List<string>();
    private void Start()
    {
        spells.Add("feu");
        spells.Add("eau");
        spells.Add("eclair");
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

    }

    public bool VerifMots()
    {
        foreach(string spell in spells)
        {
            SortEcrit = UIManager.sortEcrit.Replace("\r", "");
            if (SortEcrit == spell)
            {
                this.valide = true;
                return true;
            }
        }
        return false;
    }
    
}
