using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeAttack : MonoBehaviour
{
    [Header ("Attack Parameters")]
    [SerializeField] private float attackCooldownMelee;
    [SerializeField] private float range;
    [SerializeField] private float currentDamage;
    public float CurrentDamage    { get => currentDamage; }

        [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask enemyLayer;
    private float cooldownTimerMelee = Mathf.Infinity;
    private float cooldownTimerRange = Mathf.Infinity;

    [Header("Ranged Attack")]
    [SerializeField] private float attackCooldownRange;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireBalls;

    [Header ("Sound")]
    [SerializeField] private AudioClip fireballAudio;
    [SerializeField] private AudioClip meleeAudio;
    [SerializeField] private AudioClip collectionAudio;


    private Animator anim;
    private HealthEnemy healthEnemy;

    private void Awake()
    {
        anim = GetComponent<Animator>();       
    }

    private void Update()
    {   
        if (Input.GetKey(KeyCode.Z))
            Strike();
        if (Input.GetKey(KeyCode.X))
            DamageEnemy();        
    }
    
    private bool PlayerInSight() //khoang cach tan cong
    {
        RaycastHit2D hit =
            Physics2D.BoxCast
           (boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, enemyLayer);

        if (hit.collider != null)
            healthEnemy = hit.transform.GetComponent<HealthEnemy>();
        return hit.collider != null;
    }
    private void OnDrawGizmoz()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center, boxCollider.bounds.size);
    }

    private void DamageEnemy()
    {
        
        cooldownTimerMelee += Time.deltaTime;
        if (cooldownTimerMelee >= attackCooldownMelee)
        {
            anim.SetTrigger("Attack");
            cooldownTimerMelee = 0;
            if (PlayerInSight())
                healthEnemy.TakeDamage(currentDamage); 
            SoundManager.instance.PlaySound(meleeAudio);    
        }
    }
    public void MeleeBtn()
    {

        if (GetComponent<PLayerMovement>().CanAttack())
        {
            anim.SetTrigger("Attack");
            if (PlayerInSight())
                healthEnemy.TakeDamage(currentDamage);
            SoundManager.instance.PlaySound(meleeAudio);
        }
    }

    public void StrikeBtn()
    {
        
        if (GetComponent<PLayerMovement>().CanAttack())
        { 
        anim.SetTrigger("Strike");
        fireBalls[FindFireBalls()].transform.position = firePoint.position;
        fireBalls[FindFireBalls()].GetComponent<FireBall>().SetDirection(Mathf.Sign(transform.localScale.y));
        SoundManager.instance.PlaySound(fireballAudio);
        }
    }

    private void Strike()
    {
            cooldownTimerRange += Time.deltaTime;
            if (cooldownTimerRange >= attackCooldownRange)
            {
                anim.SetTrigger("Strike");
                cooldownTimerRange = 0;
                fireBalls[FindFireBalls()].transform.position = firePoint.position;
                fireBalls[FindFireBalls()].GetComponent<FireBall>().SetDirection(Mathf.Sign(transform.localScale.y));
                SoundManager.instance.PlaySound(fireballAudio);
             }
    }
    private int FindFireBalls()
    {
        for (int i = 0; i < fireBalls.Length; i++)
        {
            if (!fireBalls[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    public void AddDamage(float _damage)
    {
        currentDamage += _damage;
        SoundManager.instance.PlaySound(collectionAudio);
      //  currentDamage = Mathf.Clamp(startingDamage + _damage,startingDamage, currentDamage);
    }
}
