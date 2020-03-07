﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffensiveSpell : MonoBehaviour
{
    Vector2 position;
    Vector2 direction;

    float ThrowSpeed;
    float BubbleWiggle;

    string TypeOfSpell;

    bool Flag;

    float WaterTimer;
    float TimerTime;

    private void Start()
    {
        Flag = false;

        WaterTimer = 0;
        TimerTime = 0.3f;

        BubbleWiggle = 4;

        DirectionThrow();

        TypeOfSpell = GameObject.Find("Billy").GetComponent<Spells>().GetSpell("Call");

        switch (TypeOfSpell)
        {
            case "FireBall":
                ThrowSpeed = 0;         // pour modifier la vitesse des projectiles
                break;
            case "Thunder":
                ThrowSpeed = 0;
                break;
            case "Water":
                ThrowSpeed = 0;
                break;
        }

    }

    void Update()
    {
        this.position = transform.position;

        SpecialComportment();

        position.x = position.x + (direction.x + ThrowSpeed) * Time.deltaTime;
        position.y = position.y + (direction.y + ThrowSpeed) * Time.deltaTime;
        transform.position = position;
    }

    private void DirectionThrow()       // vers où le sort est lancé par rapport à la position de Billy
    {
        direction = GameObject.Find("Billy").GetComponent<Player>().Direction();
        if (direction.x != 0)
        {
            if (direction.x > 0)
            {
                direction.x = 4.5f;
            }
            else
            {
                direction.x = -4.5f;
            }
        }
        if (direction.y != 0)
        {
            if (direction.y > 0)
            {
                direction.y = 4.5f;
            }
            else
            {
                direction.y = -4.5f;
            }
        }
    }

    private void SpecialComportment()
    {
        if (TypeOfSpell == "Water")
        {
            if (WaterTimer == 0)
            {
                if (!Flag)
                {
                    if (direction.x == 0)
                    {
                        direction.x = BubbleWiggle;
                    }
                    else
                    {
                        direction.y = BubbleWiggle;
                    }
                    Flag = true;
                }
                if (direction.x == BubbleWiggle || direction.x == -BubbleWiggle)
                {
                    direction.x *= -1;
                }
                if (direction.y == BubbleWiggle || direction.y == -BubbleWiggle)
                {
                    direction.y *= -1;
                }
                WaterTimer = TimerTime;
            }
            WaterTimer = Mathf.Clamp(WaterTimer -= Time.deltaTime, 0, TimerTime);
        }

        if (TypeOfSpell == "Thunder")
        {

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.collider.GetComponent<Player>();
        if (player == null)
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
