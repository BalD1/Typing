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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ArmorUp armor = collision.gameObject.GetComponent<ArmorUp>();
        Ennemi bwate = collision.gameObject.GetComponent<Ennemi>();
        Coeur coeur = collision.gameObject.GetComponent<Coeur>();
        if (bwate != null)
        {
            Debug.Log("Aïe");
            GameManager.Instance.DamageToBilly(1);
        }
        if (coeur != null)
        {
            Debug.Log("Yes");
            GameManager.Instance.HealToBilly(1);
            Destroy(coeur.gameObject);
        }
        if (armor != null)
        {
            GameManager.Instance.SetArmorUp(1);
            Destroy(armor.gameObject);
        }
    }

}
