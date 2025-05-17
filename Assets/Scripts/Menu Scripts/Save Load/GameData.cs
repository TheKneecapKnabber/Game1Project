using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public LevelLoadSO levelOne, levelTwo, levelThree, levelZero;
    public static GameData GDinstance;
    public bool beaten1, beaten2, beaten3;
    public float time1, time2, time3;

    private void Awake()
    {
        if (GDinstance == null)
        {
            GDinstance = this;
        }
        if (GDinstance != this)
        {
            Destroy(this);
        }

    }
    public void SaveData()
    {
        SaveLoad.SaveJSON(this, "SaveData");
    }

    public void LoadData(string filename)
    {
        Debug.Log(filename);
        GameDataToken token = SaveLoad.LoadJSON(filename);
        levelOne.hasBeenBeaten = token.completeOne;
        levelOne.bestTime = token.timeOne;
        levelTwo.hasBeenBeaten = token.completeTwo;
        levelTwo.bestTime = token.timeTwo;
        levelThree.hasBeenBeaten = token.completeThree;
        levelThree.bestTime = token.timeThree;
        levelZero.hasBeenBeaten = token.completeOne;
        levelZero.bestTime = token.timeOne;
    }

    public void NoDataLoad()
    {
        Debug.Log("no load");
        levelOne.hasBeenBeaten = false;
        levelOne.bestTime = 0f;
        levelTwo.hasBeenBeaten = false;
        levelTwo.bestTime = 0f;
        levelThree.hasBeenBeaten = false;
        levelThree.bestTime = 0f;
        levelZero.hasBeenBeaten = false;
        levelZero.bestTime = 0f;
    }
}



[System.Serializable]
public class GameDataToken
{
    public bool completeOne, completeTwo, completeThree, completeZero;
    public float timeOne, timeTwo, timeThree, timeZero;

    public GameDataToken(GameData data)
    {
        completeOne = data.levelOne.hasBeenBeaten;
        completeTwo = data.levelTwo.hasBeenBeaten;
        completeThree = data.levelThree.hasBeenBeaten;
        completeZero = data.levelZero.hasBeenBeaten;
        timeOne = data.levelOne.bestTime;
        timeTwo = data.levelTwo.bestTime;
        timeThree = data.levelThree.bestTime;
        timeZero = data.levelZero.bestTime;

    }


}