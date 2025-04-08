using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, IDamageable
{
    [SerializeField] protected int health;
    [SerializeField] protected int maxHealth; 
    [SerializeField] protected int damage; //attack damage to player
    [SerializeField] protected float moveSpeed; // patrol speed
    [SerializeField] protected float chaseSpeed;// chasing the player
    [SerializeField] protected float waitTime;//time inbetween actions
    [SerializeField] protected float attackRange;
    public bool alerted, chasingPlayer, patrolling;
    

    //amount of time on the search action (might not be needed since animation could help)
    [SerializeField] protected float searchingTime;

    // Start is called before the first frame update
    void Awake()
    {
        health = maxHealth;
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            OnDeath();
        }
    }
    public abstract void Attack();

    public virtual void OnDeath()
    {
        Destroy(this.gameObject);
    }
}
