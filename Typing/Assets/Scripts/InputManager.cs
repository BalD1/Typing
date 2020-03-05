using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private void Start()
    {
        //La liste de spell
        List<Spells> spells = new List<Spells>();
    }

    
    private void Update()
    {
        //Affiche la boite quand on appuie sur "T" pour l'instant
        if (Input.GetKeyDown(KeyCode.T))
        {
            UIManager.Instance.AfficherBoiteDeDialogue();
        }


    }
}
