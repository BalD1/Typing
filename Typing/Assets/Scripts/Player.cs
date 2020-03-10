using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int timerLog = 0;

    [SerializeField]
    private int speed = 30;

    [SerializeField]
    private int billyHp = 5;

    [SerializeField]
    private int billyArmor = 0;

    [SerializeField]
    private int coinCount = 0;

    float horizontal;
    float vertical;

    Vector2 vide;
    Vector2 direction;

    Rigidbody2D billy2d;

    void Start()
    {
        this.billy2d = this.GetComponent<Rigidbody2D>();
        direction.x = -1;
        direction.y = 0;

    }
    
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        vide = Direction();
        Movment();

        Heal();
        Damage();
        Armor();
        Money();
        GameManager.Instance.GetBillyHp(billyHp);

        GameManager.Instance.ResetValues();

        if (timerLog >= 60)
        {
            Debug.Log("vie : " + billyHp);
            Debug.Log("armure : " + billyArmor);
            Debug.Log("money : " + coinCount);
            timerLog = 0;
        }
        else
        {
            timerLog++;
        }
    }

    private void Movment()
    {
        Vector2 position = billy2d.position;
        position.x = position.x + this.speed * horizontal * Time.deltaTime;
        position.y = position.y + this.speed * vertical * Time.deltaTime;
        this.billy2d.MovePosition(position);
    }

    public Vector2 Direction()
    {
        if(horizontal != 0 || vertical != 0)
        {
            direction.x = horizontal;
            direction.y = vertical;
            return direction;
        }
        return direction;
    }

    private void Damage()
    {
        if (GameManager.Instance.BillyTookDamage() > billyArmor)
        {
            this.billyHp -= (GameManager.Instance.BillyTookDamage() - billyArmor);
        }
    }

    private void Heal()
    {
        this.billyHp += GameManager.Instance.BillyReceivedHeal();
    }

    private void Armor()
    {
        this.billyArmor += GameManager.Instance.GetArmorUp();
    }

    private void Money()
    {
        this.coinCount += GameManager.Instance.GetCoin();
    }
}
