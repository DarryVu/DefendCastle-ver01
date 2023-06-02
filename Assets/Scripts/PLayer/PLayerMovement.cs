using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class PLayerMovement : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    [Header("Audio")]
    [SerializeField] private AudioClip shieldAudio;
    [SerializeField] private AudioClip jumpAudio;

    private float dirX ;
    private Rigidbody2D rb;
    private Animator anim;

    bool _isGround;

    [SerializeField] private FixedJoystick joystick;

    private bool m_shield;
    [SerializeField] private GameObject shield;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.C))
            OnShield();

        if (Input.GetKeyDown(KeyCode.Space) && _isGround)        
            Jump();
            anim.SetBool("Jump", rb.velocity.y > 0);

        Movement();
    }

    public void Movement()
    {
        dirX = joystick.Horizontal;
       // dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);
        //flip
        if(dirX > 0f)
        {
            transform.localScale = Vector3.one;
        }
        else if (dirX <0f)
        {
            transform.localScale = new Vector3(-1, 1, 1);            
        }
        
        anim.SetBool("Run", dirX != 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            _isGround = true;
    }

    public void Jump()
    {
        if (!_isGround)
            return;
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
          _isGround = false;
        SoundManager.instance.PlaySound(jumpAudio);
    }

    public bool CanAttack()
    {
        return dirX == 0 && _isGround;
    }

    public void OnShield()
    {
        if (!m_shield && CanAttack())
        {
            anim.SetTrigger("Block");
            shield.SetActive(true);
            m_shield = true;
            Invoke("OffShield", 0.5f);
            SoundManager.instance.PlaySound(shieldAudio);
        }
    }
    public void OffShield()
    {
        shield.SetActive(false);
        m_shield = false;
    }
}
