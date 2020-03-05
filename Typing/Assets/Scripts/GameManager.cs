using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int damage;
    private int heal;

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
    public void ResetDamageHeal()
    {
        this.damage = 0;
        this.heal = 0;
    }

    public void HealToBilly(int healReceived)
    {
        this.heal = healReceived;
    }
    public int BillyReceivedHeal()
    {
        return this.heal;
    }
}
