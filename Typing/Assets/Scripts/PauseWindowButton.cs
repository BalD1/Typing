using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseWindowButton : MonoBehaviour
{
    private List<GameObject> GrimoireList = new List<GameObject>();
    private List<string> LearnedSpells = new List<string>();
    [SerializeField]
    private GameObject GrimoireFeu;
    [SerializeField]
    private GameObject GrimoireEau;
    [SerializeField]
    private GameObject GrimoireGlace;
    [SerializeField]
    private GameObject GrimoireVampirisme;
    [SerializeField]
    private GameObject GrimoireVent;
    [SerializeField]
    private GameObject GrimoireBouclier;
    [SerializeField]
    private GameObject GrimoireFoudre;
    [SerializeField]
    private GameObject GrimoirePower;
    [SerializeField]
    private GameObject GrimoireSoin;
    [SerializeField]
    private GameObject spellPage;
    [SerializeField]
    private Text spellInfos;
    [SerializeField]
    private Text vulnerables;
    [SerializeField]
    private Text resistants;

    
    

    private void Start()
    {
        GrimoireList.Add(GrimoireFeu);
        GrimoireList.Add(GrimoireEau);
        GrimoireList.Add(GrimoireGlace);
        GrimoireList.Add(GrimoireVampirisme);
        GrimoireList.Add(GrimoireVent);
        GrimoireList.Add(GrimoireBouclier);
        GrimoireList.Add(GrimoireFoudre);
        GrimoireList.Add(GrimoirePower);
        GrimoireList.Add(GrimoireSoin);

        foreach(GameObject grimoire in GrimoireList)
        {
            if (grimoire != GrimoireFeu)
            {
                grimoire.SetActive(false);
            }
        }
        
    }

    private void Update()
    {
        this.LearnedSpells = GameManager.Instance.SendLearnedSpellList();
        foreach(string learnedSpell in LearnedSpells)
        {
            UnlockingSpell(learnedSpell);
        }
        if (UIManager.Instance.SendOnMouseOverSpellActive())
        {
            this.spellPage.SetActive(true);
            SpellsInfo.Instance.GetSpellName(UIManager.Instance.SendOnMouseOverSpellName(), true);
            this.spellInfos.text = UIManager.Instance.SendOnMouseOverSpellName() + "\n" +
                                    "Dégats : " + SpellsInfo.Instance.SendSpellDamage() + "\n" +
                                    "Coût : " + SpellsInfo.Instance.SendManaCost() + "\n" +
                                    SpellsInfo.Instance.SendDescription();
            this.vulnerables.text = SpellsInfo.Instance.SendVulnerables();
            this.resistants.text = SpellsInfo.Instance.SendResistants();
        }
        else
        {
            this.spellPage.SetActive(false);
            
        }
    }

    private void UnlockingSpell(string UnlockedSpell)
    {
        switch (UnlockedSpell)
        {
            case "eau":
                GrimoireList[1].SetActive(true);
                break;
            case "glace":
                GrimoireList[2].SetActive(true);
                break;
            case "vampirisme":
                GrimoireList[3].SetActive(true);
                break;
            case "vent":
                GrimoireList[4].SetActive(true);
                break;
            case "bouclier":
                GrimoireList[5].SetActive(true);
                break;
            case "foudre":
                GrimoireList[6].SetActive(true);
                break;
            case "power":
                GrimoireList[7].SetActive(true);
                break;
            case "soin":
                GrimoireList[8].SetActive(true);
                break;
        }
    }

    public void OnClicEvent(string button)
    {
        switch (button)
        {
            case "Continue":
                GameManager.Instance.ChangeGameState("InGame");
                break;
            case "Save":

                break;
            case "MainMenu":
                GameManager.Instance.ChangeGameState("MainMenu");
                break;
        }
    }

}
