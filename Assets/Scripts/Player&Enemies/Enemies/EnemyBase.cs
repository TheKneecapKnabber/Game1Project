using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class EnemyBase : MonoBehaviour, IDamageable
{
    [SerializeField] protected int health;
    [SerializeField] protected int maxHealth; 
    [SerializeField] protected int damage; //attack damage to player
    [SerializeField] private TextMeshPro healthText;//keeps track of health can be changed to a bar later
    

    // Start is called before the first frame update
    void Awake()
    {
        health = maxHealth;
        healthText.text = ($"Health: {health}");
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthText.text = ($"Health: {health}");
        if (health <= 0)
        {
            OnDeath();
        }
    }
    public abstract void Attack();

    public virtual void OnDeath()//it can be changed to allow dropping of pick up items
        //but has destroy object by default
    {
        Destroy(this.gameObject);
    }
}
