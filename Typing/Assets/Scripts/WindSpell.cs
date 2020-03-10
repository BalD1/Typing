using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSpell : MonoBehaviour
{
    Rigidbody2D winded;
    int speed = 3;

    void Start()
    {
        this.winded = this.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Vector2 position = this.winded.position;
        position.x += this.speed * Time.deltaTime;
        position.y += 0;
        this.winded.MovePosition(position);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 dir;
        dir.x = 2000;
        dir.y = 0;
        Ennemi ennemi = collision.gameObject.GetComponent<Ennemi>();
        if (ennemi != null)
        {
            ennemi.GetComponent<Rigidbody2D>().AddForce(dir);
            Destroy(this.gameObject);
        }
    }
}
