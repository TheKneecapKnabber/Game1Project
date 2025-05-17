using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LevelSelectManager;

public class EndLevel : MonoBehaviour
{
    public LevelLoadSO thisLevel;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Done");
            levelInstance.curLevel = thisLevel;
            levelInstance.LevelFinished();
        }
    }

}
