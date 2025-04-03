using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class HOTPack : InstantUseBase, IHot
{
    //player is found by the base script
    public float secBetweenTicks = 1; // this is the time between health ticks
    public int tickAmounts = 5; //the amount of ticks before it stops
    public int HealthRecovery = 5;
    [SerializeField] private BoxCollider bc;
    [SerializeField] private GameObject meshHolder;

    
    
        
    public override void OnPickup()
    {
        StartCoroutine((Hot(secBetweenTicks, tickAmounts, HealthRecovery, player)));
        bc.enabled = false;
        meshHolder.SetActive(false);
    }
    public IEnumerator Hot(float timeBetweenTicks, int tickAmounts, int healing, GameObject target)
    {
        for (int i = 0; i < tickAmounts; i++)
        {
            //heal player
            if (target.TryGetComponent<IHeal>(out IHeal iHeal))
            {
                iHeal.Heal(healing);
            }
            //wait
            yield return new WaitForSeconds(timeBetweenTicks);
        }
        Destroy(gameObject);
    }


}
