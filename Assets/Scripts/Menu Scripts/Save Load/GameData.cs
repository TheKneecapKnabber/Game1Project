using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public LevelLoadSO levelOne, levelTwo, levelThree, levelZero;

    public void SaveData()
    {
        SaveLoad.SaveJSON(this, "Filename");
    }

    public void LoadData(string filename)
    {
        GameDataToken token = SaveLoad.LoadJSON(filename);
        levelOne.hasBeenBeaten = token.completeOne;
        levelOne.bestTime = token.timeOne;
        levelTwo.hasBeenBeaten = token.completeOne;
        levelTwo.bestTime = token.timeOne;
        levelThree.hasBeenBeaten = token.completeOne;
        levelThree.bestTime = token.timeOne;
        levelZero.hasBeenBeaten = token.completeOne;
        levelZero.bestTime = token.timeOne;
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