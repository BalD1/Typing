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

    Dictionary<string,> sorts = new Dictionary<string, >();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            UIManager.Instance.AfficherBoiteDeDialogue();
        }
    }
}
