using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAlliance : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    private float currenHealth;
    public float CurrenHealth { get => currenHealth; }
    public float StartingHealth { get => startingHealth; }

    bool Dead;
    private Animator anim;
    private UIManager ui;

    private void Awake()
    {
        currenHealth = startingHealth;
        anim = GetComponent<Animator>();
        ui = FindObjectOfType<UIManager>();
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
            if (!Dead)
            {
                anim.SetTrigger("Die");
                Time.timeScale = 0;
                ui.GameVictory();
                Dead = true;
            }
        }
    }
}
