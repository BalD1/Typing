using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffre : MonoBehaviour
{
    [SerializeField]
    GameObject Heart;

    [SerializeField]
    GameObject Coin;

    Animator animator;

    private bool flag = false;
    private int timer;

    private Vector2 position;
    void Start()
    {
        animator = this.GetComponent<Animator>();
        position = this.transform.position;
        position.y -= 1;
    }

    void Update()
    {
        if(flag == true)
        {
            timer++;
            if(timer >= 59)
            {
                flag = false;
                animator.speed = 0;
                timer = 0;
                Instantiate();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BillyHitbox hitbox = collision.gameObject.GetComponent<BillyHitbox>();
        Player player = collision.gameObject.GetComponent<Player>();
        if (hitbox != null || player != null)
        {
            animator.SetBool("Open",true);
            flag = true;
        }
    }

    private void Instantiate()
    {
        int rand = Random.Range(0, 1);
        if (rand == 1)
        {
            Instantiate(Heart, position, Quaternion.identity);
        }
        else
        {
            Instantiate(Coin, position, Quaternion.identity);
        }
    }
}
