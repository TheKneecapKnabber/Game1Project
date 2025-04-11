using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    //equip to player
    public static event Action<int> OnHealthChange;
    public static event Action OnPlayerDeath;

    public int maxHealth = 100;
    [SerializeField] private int health;
    public int damageAmount = 10;

    //public GameObject healthPack, hp;
    //public Transform hpLocation;

    private void Start()
    {
        //hpLocation = hp.transform;
        health = maxHealth;
        OnHealthChange?.Invoke(health);
    }
    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.X))
        {
            TakeDamage(damageAmount);
        }
        if (Input.GetKeyDown(KeyCode.Z) && hp == null)
        {
            hp = Instantiate(healthPack, hpLocation);
        }*/  
    }

    public void TakeDamage(int amt)
    {
        health -= amt;
        OnHealthChange?.Invoke(health);

        if(health <= 0)
        {
            health = maxHealth;
            OnPlayerDeath?.Invoke();
            //Destroy(gameObject);
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
