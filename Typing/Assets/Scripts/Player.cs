using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int speed = 30;

    [SerializeField]
    private int hp = 3;

    Rigidbody2D billy2d;

    void Start()
    {
        this.billy2d = this.GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 position = billy2d.position;
        position.x = position.x + this.speed * horizontal * Time.deltaTime;
        position.y = position.y + this.speed * vertical * Time.deltaTime;

        this.billy2d.MovePosition(position);
    }
}
