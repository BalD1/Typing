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

    [SerializeField]
    private Image barImage;

    public const int MANA_MAX = 500;

    private float manaAmount;
    public float manaRegenAmount;

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
    private float timerMark = 0.7f;

    [SerializeField]
    private float timerMarkChange;
    private bool goTimer = false;
    

    public Text textCoins;
    private int coin = 0;

    private bool oui;

    public string onMouseOverSpell;
    public bool onMouseOverActive;

    private Color color;
    

    private void Awake()
    {
        instance = this;
        manaAmount = MANA_MAX;
        manaRegenAmount = 2.5f;
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
                manaPotion.SetActive(false);
            }
        }

//----------------------------------------------------------  Les coeurs  ---------------------------------
        for (int i = 0; i < hearts.Length+5; i++)
        {
            
            if (i < GameManager.Instance.SendBillyHp())
            {
                hearts[Mathf.FloorToInt(i / 2)].sprite = fullHearts;
                this.color.a = 1;
            }
            else if(i == GameManager.Instance.SendBillyHp())
            {
                hearts[Mathf.FloorToInt(i / 2)].sprite = halfHearts;
                this.color.a = 1;
            }
            else
            {
                this.color.a = 0;   //pas de coeur
            }


            if (i < numOfHearts)
            {
                hearts[Mathf.FloorToInt(i / 2)].enabled = true;
            }
            else
            {
                hearts[Mathf.FloorToInt(i / 2)].enabled = false;
            }
        }

        // la regénération de mana
        manaAmount += manaRegenAmount * Time.deltaTime;
        manaAmount = Mathf.Clamp(manaAmount, 0, MANA_MAX);
        barImage.fillAmount = GetManaNormalized();


        textCoins.text = "x " + coin;


    }
//----------------------------------------------------------------------------------------------------------------------------

//-----------------------------------------------  La boite de dialogue qui s'affiche ou non + les inputs  -------------------

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
        if (noMana)
        {
            NoManaLeft();
            return;
        }
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
        oui = true;
        if (oui)
        {
            correct.SetActive(false);
        }
    }
    //----------------------------------------------------------------------------------------------

    //---------------------------------------  LA BARRE DE MANA  -----------------------------------

    public GameObject manaPotion;

    public void SpendMana(float amount)
    {
        if(manaAmount >= amount)
        {
            manaAmount -= amount;
        }
        else
        {
            NoManaLeft();
        }

    }

    private void NoManaLeft()
    {
        manaPotion.SetActive(true);
        wrong.SetActive(true);
        goTimer = true;
        oui = false;
        if (oui)
        {
            correct.SetActive(false);
        }
    }

    private bool noMana;
    public bool NoMana(float amount)
    {
        noMana = manaAmount < amount;
        return noMana;
    }

    public float GetManaNormalized()
    {
        return manaAmount / MANA_MAX;
    }

    public void GetCoinCount(int coinCount)
    {
        this.coin = coinCount;
    }

    //----------------------------------------------------------------------------------------------

    //---------------------------------------  LA PAGE DE SPELL  -----------------------------------

    public void GetOnMouseOverSpell(string spellName, bool active)
    {
        this.onMouseOverSpell = spellName;
        this.onMouseOverActive = active;
    }

    public string SendOnMouseOverSpellName()
    {
        return this.onMouseOverSpell;
    }

    public bool SendOnMouseOverSpellActive()
    {
        return this.onMouseOverActive;
    }
}
