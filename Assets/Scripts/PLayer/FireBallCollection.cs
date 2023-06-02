using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallCollection : MonoBehaviour
{
    [SerializeField] private float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PLayer")
        {
            collision.GetComponent<FireBall>().AddDamage(damage);
            gameObject.SetActive(false);
        }
    }
}
