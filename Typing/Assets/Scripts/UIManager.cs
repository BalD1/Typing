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


    private Player billy = new Player();
    [SerializeField]
    private int numOfHearts;

    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite halfHearts;

    public bool boitePresent = false;
    public GameObject panel;
    public GameObject boiteTexte;
    public Text inputField;

    public static string sortEcrit;

    public GameObject correct;
    public GameObject wrong;

    [SerializeField]
    private float timerMark = 1.5f;

    [SerializeField]
    private float timerMarkChange;
    private bool goTimer = false;

    private bool oui;

    

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        timerMarkChange = timerMark;
        numOfHearts = GameManager.Instance.SendBillyHp();
        
    }

    private void Update()
    {
        if (goTimer)
        {
            timerMarkChange -= Time.deltaTime;
            if (timerMarkChange <= 0)
            {
                timerMarkChange = timerMark;
                goTimer = false;
                correct.SetActive(false);
                wrong.SetActive(false);
            }
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            
            if (i < GameManager.Instance.SendBillyHp())
            {
                hearts[i].sprite = fullHearts;
            }
            else if(i == GameManager.Instance.SendBillyHp())
            {
                hearts[i].sprite = halfHearts;
            }
            else
            {
                hearts[i].sprite = null;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void AfficherBoiteDeDialogue()
    {
        panel.SetActive(true);
        boiteTexte.SetActive(true);
        boitePresent = true;
    }

    public void StoreSpell()
    {
        sortEcrit = inputField.GetComponent<Text>().text;
        inputField.GetComponent<Text>().text = null;
    }

    public void CacherBoiteDeDialogue()
    {
        panel.SetActive(false);
        boiteTexte.SetActive(false);
        boitePresent = false;
    }

    public void ReponseCorrecte()
    {
        correct.SetActive(true); 
        goTimer = true;
        oui = true;
        if (!oui)
        {
            wrong.SetActive(false);
        }
    }

    public void ReponseFausse()
    {
        wrong.SetActive(true);
        goTimer = true;
        oui = false;
        if (oui)
        {
            correct.SetActive(false);
        }
    }


}
