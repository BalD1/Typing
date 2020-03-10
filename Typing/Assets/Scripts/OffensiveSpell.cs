using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffensiveSpell : MonoBehaviour
{
    Vector2 position;
    Vector2 direction;
    Vector2 ThunderDirection;

    float ThrowSpeed;
    float BubbleWiggle;

    string TypeOfSpell;

    bool Flag;
    bool ThunderFlag;

    float WaterTimer;
    float WaterTimerTime;
    float WindTimer;
    float WindTimerTime;

    Rigidbody2D rb;
    Collision2D collision2;

    List<GameObject> MultipleSpells = new List<GameObject>();

    private void Start()
    {
        Flag = false;
        ThunderFlag = false;

        WaterTimer = 0;
        WaterTimerTime = 0.3f;
        WindTimerTime = 1.3f;
        WindTimer = WindTimerTime;

        BubbleWiggle = 4;

        rb = GetComponent<Rigidbody2D>();
        DirectionThrow();

        ThunderDirection = Vector2.zero;

        TypeOfSpell = GameObject.Find("Billy").GetComponent<Spells>().GetSpell("Call");

        switch (TypeOfSpell)
        {
            case "FireBall":
                ThrowSpeed = 100;         // pour modifier la vitesse des projectiles
                break;
            case "Thunder":
                ThrowSpeed = 70;
                break;
            case "Water":
                ThrowSpeed = 50;
                break;
            case "Wind":
                ThrowSpeed = 100;
                break;
        }
        this.rb.AddForce(direction * ThrowSpeed);

    }

    void Update()
    {
        SpecialComportment();
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
                switch (direction.x)
                {
                    case 4:
                        this.rb.velocity = Vector3.zero;
                        this.rb.AddForce(direction * 50);
                        direction.x *= -1;
                        break;
                    case -4:
                        this.rb.velocity = Vector3.zero;
                        this.rb.AddForce(direction * 50);
                        direction.x *= -1;
                        break;
                }
                switch (direction.y)
                {
                    case 4:
                        this.rb.velocity = Vector3.zero;
                        this.rb.AddForce(direction * 50);
                        direction.y *= -1;
                        break;
                    case -4:
                        this.rb.velocity = Vector3.zero;
                        this.rb.AddForce(direction * 50);
                        direction.y *= -1;
                        break;
                }
                WaterTimer = WaterTimerTime;
                        
            }
            WaterTimer = Mathf.Clamp(WaterTimer -= Time.deltaTime, 0, WaterTimerTime);
        }

        if (TypeOfSpell == "Thunder" && !ThunderFlag)
        {
            MultipleSpells = GameObject.Find("Billy").GetComponent<Spells>().ListSend();
            bool CanClear = false;
            if (direction.x == 0)
            {
                ThunderDirection.x = 4.5f;
            }
            if (direction.y == 0)
            {
                ThunderDirection.y = 4.5f;
            }
            foreach (GameObject ThunderSolo in MultipleSpells)
            {

                if (ThunderSolo == this.gameObject)
                {
                    if(MultipleSpells.IndexOf(ThunderSolo) == 0)
                    {
                        this.rb.AddForce(ThunderDirection * ThrowSpeed);
                    }
                    else if (MultipleSpells.IndexOf(ThunderSolo) == 1)
                    {
                        this.rb.AddForce(-(ThunderDirection * ThrowSpeed));
                    }
                    else if (MultipleSpells.IndexOf(ThunderSolo) == 2)
                    {
                        CanClear = true;
                    }
                }
            }
            if (CanClear)
            {
                MultipleSpells.Clear();
            }
            ThunderFlag = true;
        }

        if (TypeOfSpell == "Wind" && collision2 != null)
        {
            if (WindTimer == WindTimerTime)
            {
                collision2.rigidbody.AddForce(direction * 50000);       // à modifier
            }
            if (WindTimer == 0)
            {
                collision2.rigidbody.velocity = Vector3.zero;
                Destroy(this.gameObject);
            }
            WindTimer = Mathf.Clamp(WindTimer - Time.deltaTime, 0, WindTimerTime);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.collider.GetComponent<Player>();
        if (player == null)
        {
            if (TypeOfSpell == "Wind")
            {
                collision2 = collision;
            }
            else
            {
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
        }
        else
        {
            Physics2D.IgnoreCollision(this.rb.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
        }
    }
    
}
