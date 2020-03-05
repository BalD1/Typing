using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public delegate void TypeAction();
    public static event TypeAction OnClicked;

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
    private void Start()
    {
        //La liste de spell
        List<string> spells = new List<string>();

        spells.Add("FEU");
        spells.Add("EAU");
        spells.Add("ECLAIR");
    }

    
    private void Update()
    {
        //Affiche la boite quand on appuie sur "T" pour l'instant
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (UIManager.Instance.boitePresent == false)
            {
                UIManager.Instance.AfficherBoiteDeDialogue();
            }
            else
            {
                UIManager.Instance.StoreSpell();
                UIManager.sortEcrit = "";
                UIManager.Instance.CacherBoiteDeDialogue();
            }
        }

    }

    /*public bool VerifMots()
    {

    }*/
    

}
