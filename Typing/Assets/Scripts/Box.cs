using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        OffensiveSpell spell = collision.gameObject.GetComponent<OffensiveSpell>();
        if(spell != null)
        {
            Destroy(this.gameObject);
        }
    }
}
