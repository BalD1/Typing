using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffensiveSpell : MonoBehaviour
{
    Vector2 position;
    Vector2 direction;

    float ThrowSpeed;

    string TypeOfSpell;

    private void Start()
    {
        DirectionThrow();
        TypeOfSpell = GameObject.Find("Billy").GetComponent<Spells>().GetSpell("Call");
        switch (TypeOfSpell)
        {
            case "FireBall" :
                ThrowSpeed = 100f;
                break;
            case "Thunder" :
                ThrowSpeed = 3f;
                break;
            //case "Bubbles" :
                //ThrowSpeed = 0.3f;
                //break;
        }

    }

    public void GetSpell()
    {

    }

    private void DirectionThrow()
    {
        direction = GameObject.Find("Billy").GetComponent<Player>().Direction();
        if(direction.x != 0)
        {
            if(direction.x > 0)
            {
                direction.x = 0.5f;
            }
            else
            {
                direction.x = -0.5f;
            }
        }
        if(direction.y != 0)
        {
            if(direction.y > 0)
            {
                direction.y = 0.5f;
            }
            else
            {
                direction.y = -0.5f;
            }
        }
    }

    void Update()
    {
        this.position = transform.position;
        position.x = (position.x + ThrowSpeed + direction.x);
        position.y = (position.y + ThrowSpeed + direction.y);
        transform.position = position;
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
