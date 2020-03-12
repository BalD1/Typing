using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterButton : MonoBehaviour
{

    [SerializeField]
    private bool Active;
    public string ButtonType;

    [SerializeField]
    GameObject button1;
    [SerializeField]
    GameObject button2;

    void Awake()
    {
        button1.SetActive(false);
        button2.SetActive(false);
    }

    public void SetActiveButton(bool State)
    {
        button1.SetActive(State);
        button2.SetActive(State);
    }

}
