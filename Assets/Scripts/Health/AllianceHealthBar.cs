using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllianceHealthBar : MonoBehaviour
{
    [SerializeField] private HealthAlliance healthAlliance;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    private void Start()
    {
        totalHealthBar.fillAmount = healthAlliance.CurrenHealth / healthAlliance.StartingHealth;
    }

    private void Update()
    {
        currentHealthBar.fillAmount = healthAlliance.CurrenHealth / healthAlliance.StartingHealth;
    }
}
