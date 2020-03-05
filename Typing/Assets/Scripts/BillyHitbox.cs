using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillyHitbox : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ennemi bwate = collision.gameObject.GetComponent<Ennemi>();
        if(bwate != null)
        {
            Debug.Log("Aïe");
        }
    }
}
