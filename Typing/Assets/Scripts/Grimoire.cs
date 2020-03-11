using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grimoire : MonoBehaviour
{
    [SerializeField]
    string SpellType;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.collider.GetComponent<Player>();
        if (player != null)
        {
            GameManager.Instance.GetLearnSpell(SpellType);
            Destroy(this.gameObject);
        }
    }
}
