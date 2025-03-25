using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TargetDummy : MonoBehaviour
{
    private int health;
    public int maxHealth;
    public TMP_Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        
    }
    public void Damage(int damage)
    {
        health -= damage;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
