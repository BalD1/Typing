using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffensiveSpell : MonoBehaviour
{
    Vector2 position;
    Vector2 direction;
    Vector2 ThunderDirection;

    Animator animator;

    float ThrowSpeed;
    float BubbleWiggle;

    int BrutDamageDealt;

    string TypeOfSpell;

    bool Flag;
    bool ThunderFlag;
    bool AnimFlag;
    bool deathFlag = false;

    float WaterTimer;
    float WaterTimerTime;
    float WindTimer;
    float WindTimerTime;
    float AnimTimer;
    float AnimTimerTime;
    float deathTimer = 0;

    Rigidbody2D rb;
    Collision2D collision2;

    List<GameObject> MultipleSpells = new List<GameObject>();

    private void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();

        Flag = false;
        ThunderFlag = false;
        AnimFlag = false;

        WaterTimer = 0;
        WaterTimerTime = 0.3f;
        WindTimerTime = 0.6f;
        WindTimer = WindTimerTime;
        

        BubbleWiggle = 4;

        rb = GetComponent<Rigidbody2D>();
        DirectionThrow();

        ThunderDirection = Vector2.zero;

        TypeOfSpell = GameObject.Find("Billy").GetComponent<Spells>().GetSpell("Call");

        SpellsInfo.Instance.GetSpellName(TypeOfSpell, false);

        ThrowSpeed = SpellsInfo.Instance.SendThrowSpeed();
        AnimTimerTime = SpellsInfo.Instance.SendSpellAnimTime();
        BrutDamageDealt = SpellsInfo.Instance.SendSpellDamage();

        AnimTimer = AnimTimerTime;


    }

    void Update()
    {
        SpecialComportment();
        SpellThrow();

        if(deathFlag == true)
        {
            deathTimer++;
            if(deathTimer >= 30)
            {
                deathFlag = false;
                deathTimer = 0;
                Destroy(this.gameObject);
            }
        }
    }

    private void SpellThrow()
    {
        if (AnimTimer == 0 && !AnimFlag)
        {
            this.rb.AddForce(direction * ThrowSpeed);
            AnimFlag = true;
        }
        AnimTimer = Mathf.Clamp(AnimTimer - Time.deltaTime, 0, AnimTimerTime);
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
            if (WaterTimer == 0 && !deathFlag && AnimTimer <= 0)
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
                ThunderDirection.x = 1.4f;
            }
            if (direction.y == 0)
            {
                ThunderDirection.y = 1.4f;
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
                collision2.rigidbody.AddForce(direction * 100000);       // à modifier
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
            GameManager.Instance.DamageToHostile(BrutDamageDealt);
            GameManager.Instance.GetTypeOfSpell(TypeOfSpell);

            if (TypeOfSpell == "Wind")
            {
                collision2 = collision;
            }
            else
            {
                animator.SetBool("Contact", true);
                this.rb.velocity = Vector2.zero;
                deathFlag = true;
            }
        }
        else
        {
            Physics2D.IgnoreCollision(this.rb.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
        }
    }
    
}
