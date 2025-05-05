using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static LevelSelectManager;

public class LevelFinishPanel : MonoBehaviour
{
    public TMP_Text levelTime;
    public float levelCompleteTime;

    private void Awake()
    {
        float minutes = Mathf.Floor(levelInstance.levelFinishTime / 60);
        float seconds = levelInstance.levelFinishTime % 60;

        levelCompleteTime = levelInstance.levelFinishTime;
        if(levelInstance.levelFinishTime == levelInstance.curLevel.bestTime)
        {
            levelTime.text = "You completed this level in " + minutes + "min : " + seconds + "sec\nThis is your fastest time!";
        }
    }
}
