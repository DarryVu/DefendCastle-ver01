using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    private float currenHealth;
    public float CurrenHealth { get => currenHealth; }
    public float StartingHealth { get => startingHealth; }
    private Animator anim;
    private void Awake()
    {
        currenHealth = startingHealth;
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
      
    }
    public void TakeDamage(float _damage)
    {
        currenHealth = Mathf.Clamp(currenHealth - _damage, 0, startingHealth);
        if (currenHealth > 0)
        {
            anim.SetTrigger("Hurt");
        }
        else 
            {
            anim.SetTrigger("Die");
            //Enemy
            if (GetComponentInParent<EnemyPatrol>() != null)
                GetComponentInParent<EnemyPatrol>().enabled = false;

            if (GetComponent<MeleeEnemy>() != null)
                GetComponent<MeleeEnemy>().enabled = false;

            if (GetComponent<RangedEnemy>() != null)
                GetComponent<RangedEnemy>().enabled = false;
            Invoke("Destroy", 1f);
        }               
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
