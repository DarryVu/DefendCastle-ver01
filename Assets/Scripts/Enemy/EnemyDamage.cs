using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] protected float damage;
   
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PLayer")
            collision.GetComponent<Health>().TakeDamage(damage);        
    }
    private void Update()
    {
    }
}
