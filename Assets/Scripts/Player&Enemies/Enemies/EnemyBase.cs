using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] private int maxHealth; 
    [SerializeField] protected int Damage; //attack damage to player
    [SerializeField] protected float moveSpeed; // patrol speed
    [SerializeField] protected float chaseSpeed;// chasing the player
    [SerializeField] protected float waitTime;//time inbetween actions
    public bool seesPlayer, chasingPlayer, patrolling;

    //amount of time on the search action (might not be needed since animation could help)
    [SerializeField] protected float searchingTime;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = maxHealth;
        }
    }
    public abstract void Attack();
}
