using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private float direction;
    private bool hit;
    private float lifeTime;

    private Animator anim;
    private BoxCollider2D boxcoll;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxcoll = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if (hit)
            return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        lifeTime += Time.deltaTime;
        if (lifeTime > 0.5) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxcoll.enabled = false;
        anim.SetTrigger("Explosion");

        if (collision.tag == "Enemy")
            collision.GetComponent<HealthEnemy>().TakeDamage(damage);
        if (collision.tag == "Alliance")
            collision.GetComponent<HealthAlliance>().TakeDamage(damage);
    }

    public void SetDirection(float _direction)
    {
        lifeTime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxcoll.enabled = true;

        float localscaleX = transform.localScale.x;
        if (Mathf.Sign(localscaleX) != _direction)
            localscaleX = -localscaleX;
        transform.localScale = new Vector3(localscaleX, transform.localScale.y, transform.localScale.z);
    }
    public void AddDamage(float _damage)
    {
        damage += _damage;
    }
    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    
}
