using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TargetDummy : EnemyBase
{
    
    public TMP_Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        
        healthText.text =("Target Dummy<br>Health: " + health);
        
    }
    
    // Update is called once per frame
    void Update()
    {
        healthText.text =("Target Dummy<br>Health: " + health);
    }
    public override void Attack()
    {
        Debug.Log("Do Nothing");
    }
}
