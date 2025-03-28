using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    //equip to canvas/ui
    [SerializeField] private TMP_Text healthText;

    private void OnEnable()
    {
        PlayerHealth.OnHealthChange += UpdateHealthUI;
    }
    private void OnDisable()
    {
        PlayerHealth.OnHealthChange -= UpdateHealthUI;
    }


    private void UpdateHealthUI(int newHealth)
    {
        healthText.text = ("Health: " + newHealth);
    }
}
