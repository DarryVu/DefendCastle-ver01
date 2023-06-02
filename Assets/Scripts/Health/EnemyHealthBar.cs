using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private HealthEnemy enemyHealth;
    [SerializeField] private Image totalHealthbar;
    [SerializeField] private Image currentHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        totalHealthbar.fillAmount = enemyHealth.CurrenHealth / enemyHealth.StartingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealthBar.fillAmount = enemyHealth.CurrenHealth / enemyHealth.StartingHealth;
    }
}
