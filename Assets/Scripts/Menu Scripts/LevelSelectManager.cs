using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class LevelSelectManager : MonoBehaviour
{
    public static LevelSelectManager levelInstance;
    public LevelLoad currentLevel;
    public GameObject mainMenu, levelSelectMenu, pickSaveMenu, endLevelScreen;
    public float curLevelTime;
    public float levelFinishTime;
    public bool curLevelCompleted;
    public LevelLoadSO curLevel;    



    private void Awake()
    {
        if (levelInstance == null)
        {
            levelInstance = this;
        }
        else if (levelInstance != this)
        {
            Destroy(this);
        }
        endLevelScreen.SetActive(false);
        levelSelectMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(currentLevel.curLevel.levelIndex);
    }
    public void ChooseLevelMenu()
    {
        levelSelectMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void ChooseMainMenu()
    {
        levelSelectMenu.SetActive(false);
        pickSaveMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ChooseSaveMenu()
    {
        pickSaveMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void StartLevelTimer()
    {
        curLevelTime = 0f;
    }
    private void Update()
    {
        curLevelTime += Time.deltaTime;
    }

    public void LevelFinished()
    {
        levelFinishTime = curLevelTime;
        if(curLevel.hasBeenBeaten != true)
        {
            curLevel.bestTime = levelFinishTime;
            curLevel.hasBeenBeaten = true;
        }
        else if(curLevel.bestTime > levelFinishTime)
        {
            curLevel.bestTime = levelFinishTime;
        }
        StartCoroutine(ShowEndMenu());

    }
    public IEnumerator ShowEndMenu()
    {
        endLevelScreen.SetActive(true);
        SceneManager.LoadScene(0);
        levelSelectMenu.SetActive(true);
        mainMenu.SetActive(false);
        yield return new WaitForSeconds(5f);
        endLevelScreen.SetActive(false) ;
        yield return null;
    }



}
