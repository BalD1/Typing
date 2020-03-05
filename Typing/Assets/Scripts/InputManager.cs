using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent onTyped;

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

        spells.Add("Feu");
        spells.Add("Eau");
        spells.Add("Eclair");
    }

    
    private void Update()
    {
        string input = Input.inputString;
        Debug.Log(input);
        if (UIManager.Instance.boitePresent == true)
        {
            UIManager.Instance.inputField.text += input;
        }

        //Affiche la boite quand on appuie sur "T" pour l'instant
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
                UIManager.sortEcrit = "";
                UIManager.Instance.CacherBoiteDeDialogue();
            }
        }

    }

    public bool VerifMots()
    {
        return true;
    }
    
    public void EcrireSpell()
    {

    }

}
