using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IDamageable, IHeal
{
    //equip to player
    public static event Action<int> OnHealthChange;
    public static event Action OnPlayerDeath;
    [SerializeField] private AudioClip takeDamageSound;
    [SerializeField] private ParticleSystem damageParticles;
    private ParticleSystem particleInstance;

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
        AudioManager.instance?.PlaySfx(takeDamageSound, Camera.main.transform.position);
        SpawnParticles();

        if (health <= 0)
        {
            health = maxHealth;
            OnPlayerDeath?.Invoke();
            //Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
    private void SpawnParticles()
    {
        particleInstance = Instantiate(damageParticles, transform.position, Quaternion.identity);
    }
}
