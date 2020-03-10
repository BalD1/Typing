using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int timerLog = 0;

    [SerializeField]
    private int speed = 30;

    [SerializeField]
    private int billyHp = 3;

    [SerializeField]
    private int billyArmor = 0;

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

        GameManager.Instance.ResetValues();
        if (timerLog >= 60)
        {
            Debug.Log("vie : " + billyHp);
            Debug.Log("armure : " + billyArmor);
            timerLog = 0;
        }
        else
        {
            timerLog++;
        }
    }

    public int GetBillyHp
    {
        get
        {
            return billyHp;
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
        if(GameManager.Instance.BillyTookDamage() != 0 && billyArmor != 0)
        {
            this.billyHp -= (GameManager.Instance.BillyTookDamage() - billyArmor);
        }
        else
        {
            this.billyHp -= GameManager.Instance.BillyTookDamage();
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
}
