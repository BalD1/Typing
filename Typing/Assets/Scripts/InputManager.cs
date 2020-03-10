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
                Debug.Log(UIManager.sortEcrit);
                //VerifMots();
                //Debug.Log(VerifMots());
                UIManager.Instance.CacherBoiteDeDialogue();
                UIManager.sortEcrit = "";
            }
        }

    }

    /*public bool VerifMots()
    {
        for (int i = 0; i<= spells.Count; i++)
        {
            if (UIManager.sortEcrit == spells[i])
            {
                return true;
            }
        }
            return false;
    }*/
    
    public void EcrireSpell()
    {

    }

}
