using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TargetDummy : MonoBehaviour, IEnemy
{
    [SerializeField]private int health;
    public int maxHealth;
    public TMP_Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthText.text =("Target Dummy<br>Health: " + health);
        
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <=0)
        {
            health = maxHealth;
        }
    }
    // Update is called once per frame
    void Update()
    {
        healthText.text =("Target Dummy<br>Health: " + health);
    }
}
