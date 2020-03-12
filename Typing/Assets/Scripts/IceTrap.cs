using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTrap : MonoBehaviour
{
    Animator animator;

    private bool flag = false;
    private float timer = 0;

    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if(flag)
        {
            timer++;
            if(timer == 60)
            {
                animator.speed = 0;
            }
            else if(timer >= 240)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool("Contact", true);
        var PEGU = collision.gameObject.GetComponent<Transform>();
        flag = true;
        PEGU.position = this.transform.position;
    }
}
