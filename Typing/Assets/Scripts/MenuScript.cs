using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    private bool Play;
    private bool Settings;
    MasterButton masterButtonPlay;
    MasterButton masterButtonSettings;

    private void Start()
    {
        masterButtonPlay = GameObject.FindGameObjectWithTag("MasterButtonPlay").GetComponent<MasterButton>();
        masterButtonSettings = GameObject.FindGameObjectWithTag("MasterButtonSettings").GetComponent<MasterButton>();
        Play = false;
        Settings = false;
    }

    public void OnclickEvent(string Button)
    {
        switch (Button)
        {
            case "Play":
                this.ButtonActivation(Button);
                break;
            case "Settings":
                this.ButtonActivation(Button);
                break;
            case "Quit":
                Application.Quit();
                break;

            case "Continue":

                break;
            case "NewGame":
                SceneManager.LoadScene("Salle1");
                break;

            case "Language":

                break;
            case "Controls":

                break;
        }
    }

    public void ButtonActivation(string WhatButton)
    {
        switch(WhatButton)
        {
            case "Play":
                if (!Settings)
                {
                    if (!Play)
                    {
                        masterButtonPlay.SetActiveButton(true);
                        Play = true;
                    }
                    else
                    {
                        masterButtonPlay.SetActiveButton(false);
                        Play = false;
                    }
                }
                break;
            case "Settings":
                if (!Play)
                {
                    if (!Settings)
                    {
                        masterButtonSettings.SetActiveButton(true);
                        Settings = true;
                    }
                    else
                    {
                        masterButtonSettings.SetActiveButton(false);
                        Settings = false;
                    }
                }
            break;
        }
    }

}
