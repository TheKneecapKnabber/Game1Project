using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IHot 
{
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
    }
}
