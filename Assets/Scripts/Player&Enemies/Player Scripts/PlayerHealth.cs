using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //equip to player
    public static event Action<int> OnHealthChange;
    public static event Action OnPlayerDeath;

    public int maxHealth = 100;
    [SerializeField] private int health;
    public int damageAmount = 10;


    private void Start()
    {
        health = maxHealth;
        OnHealthChange?.Invoke(health);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(damageAmount);
        }
    }

    private void TakeDamage(int amt)
    {
        health -= amt;
        OnHealthChange?.Invoke(health);

        if(health < 0)
        {
            OnPlayerDeath?.Invoke();
            Destroy(gameObject);
        }

    }
    public void Heal(int amt)
    {
        health += amt;
        if (health > maxHealth)
        {
            health = maxHealth;
            OnHealthChange?.Invoke(health);
        }
        else
        {
            OnHealthChange?.Invoke(health);
        }
        
    }
}
