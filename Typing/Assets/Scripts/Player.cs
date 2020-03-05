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

    float horizontal;
    float vertical;

    Rigidbody2D billy2d;

    void Start()
    {
        this.billy2d = this.GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Movment();

        billyHp -= GameManager.Instance.BillyTookDamage();
        billyHp += GameManager.Instance.BillyReceivedHeal();

        GameManager.Instance.ResetDamageHeal();
        if (timerLog >= 60)
        {
            Debug.Log(billyHp);
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
        Vector2 direction;
        direction.x = horizontal;
        direction.y = vertical;
        return direction;
    }

}
