using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LisenerB : MonoBehaviour
{
    private void OnEnable()
    {
        DelegateTest._myDeath += B;
    }
    private void OnDisable()
    {
        DelegateTest._myDeath -= B;
    }

    private void B()
    {
        Debug.Log("listener B");
    }
}
