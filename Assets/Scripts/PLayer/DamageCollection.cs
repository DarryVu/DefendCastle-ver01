using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollection : MonoBehaviour
{
    [SerializeField]private float damageValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PLayer")
        {
            collision.GetComponent<PlayerRangeAttack>().AddDamage(damageValue);
            gameObject.SetActive(false);
        }
    }
}
