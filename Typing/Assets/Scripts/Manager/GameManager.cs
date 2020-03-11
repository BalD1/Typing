using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int damage;
    private int damageToHostile;
    private int heal;
    private int armor;
    private int coin;

    private string LearnSpellByGrimory;
    private string typeOfSpell;

    private int hp = 10;

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("Lol wtf l'instance du GameManager est null XD");
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
        LearnSpellByGrimory = "";
    }

    enum GameState
    {
        MainMenu,
        InGame,
        Pause,
        GameOver
    }

    public void DamageToBilly(int damageDealt)
    {
        this.damage = damageDealt;
    }

    public int BillyTookDamage()
    {
        return this.damage;
    }

    public void DamageToHostile(int damageTaken)
    {
        this.damageToHostile = damageTaken;
    }

    public int EnnemiTookDamage()
    {
        if (damageToHostile != 0)
        {
            return this.damageToHostile;
        }
        return 0;
    }

    public void ResetDamageToHostile()
    {
        this.damageToHostile = 0;
    }

    public void GetTypeOfSpell(string type)
    {
        this.typeOfSpell = type;
    }

    public string SendTypeOfSpell()
    {
        return this.typeOfSpell;
    }

    public void ResetValues()
    {
        this.damage = 0;
        this.heal = 0;
        this.armor = 0;
        this.coin = 0;
    }

    public void SetArmorUp(int armorup)
    {
        this.armor = armorup;
    }

    public int GetArmorUp()
    {
        return this.armor;
    }

    public void HealToBilly(int healReceived)
    {
        this.heal = healReceived;
    }

    public int BillyReceivedHeal()
    {
        return this.heal;
    }

    public void AddCoin(int coinAdd)
    {
        this.coin = coinAdd;
    }

    public int GetCoin()
    {
        return this.coin;
    }

    public void GetBillyHp(int billyHp)
    {
        this.hp = billyHp;
    }

    public int SendBillyHp()
    {
        return this.hp;
    }

    public void GetLearnSpell(string LearnSpell)
    {
        this.LearnSpellByGrimory = LearnSpell;
        Debug.Log(LearnSpellByGrimory);
    }

    public string SendLearnSpell()
    {
        return this.LearnSpellByGrimory;
    }

    public void ResetLearning()
    {
        this.LearnSpellByGrimory = "";
    }

    public void DevMode()
    {

    }
}
