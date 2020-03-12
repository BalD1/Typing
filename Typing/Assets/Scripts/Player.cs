using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool iceFlag = false;

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

    Animator animator;
    Vector2 lookDirection = new Vector2(-1, 0);

    void Start()
    {
        this.animator = this.GetComponent<Animator>();
        this.billy2d = this.GetComponent<Rigidbody2D>();
        direction.x = -1;
        direction.y = 0;

    }
    
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        Vector2 position = billy2d.position;
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        position = position + move * speed * Time.deltaTime;

        if(!iceFlag)
        {
            billy2d.MovePosition(position);
        }

        vide = Direction();

        Heal();
        Damage();
        Armor();
        Money();
        UIManager.Instance.GetCoinCount(coinCount);
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
