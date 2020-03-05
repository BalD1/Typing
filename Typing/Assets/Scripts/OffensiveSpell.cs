﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffensiveSpell : MonoBehaviour
{
    Vector2 position;
    Vector2 direction;
    float ThrowSpeed;


    private void Start()
    {
        DirectionThrow();
        ThrowSpeed = 1; 
        // switch (gameObject)
        // case (Fireball)
        // case (Thunder)
        // ...
    }

    private void DirectionThrow()
    {
        direction = GameObject.Find("Billy").GetComponent<Player>().Direction();
        if(direction.x != 0)
        {
            if(direction.x > 0)
            {
                direction.x = 1;
            }
            else
            {
                direction.x = -1;
            }
        }
        if(direction.y != 0)
        {
            if(direction.y > 0)
            {
                direction.y = 1;
            }
            else
            {
                direction.y = -1;
            }
        }
    }

    void Update()
    {
        this.position = transform.position;
        position += direction;
        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
