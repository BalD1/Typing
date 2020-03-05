using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("Woaw mais OMG le UIManager il est nul trop des barres x)");
            }
            return instance;
        }
    }

    public GameObject boite;

    private void Awake()
    {
        instance = this;
    }

    public void AfficherBoiteDeDialogue()
    {
        boite.SetActive(true);    
    }

    public void CacherBoiteDeDialogue()
    {
        boite.SetActive(false);
    }
}
