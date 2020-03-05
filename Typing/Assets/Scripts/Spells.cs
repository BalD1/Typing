using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    [SerializeField]
    private GameObject FireballPrefab;

    Rigidbody2D rigidbody2d;

    Vector2 position;


    void Awake()
    {
        rigidbody2d = this.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            this.FireBall();
        }
    }

    // ---------------------------- SPELL LIST

    private void FireBall()
    {
        Vector2 direction = this.transform.position;
        GameObject fireballObject = Instantiate(FireballPrefab, this.rigidbody2d.position, Quaternion.identity);
    }
}
