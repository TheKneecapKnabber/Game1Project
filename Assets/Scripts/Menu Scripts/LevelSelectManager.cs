using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class LevelSelectManager : MonoBehaviour
{
    public static LevelSelectManager levelInstance;
    public LevelLoad currentLevel;
    public GameObject mainMenu, levelSelectMenu, settingsMenu, endLevelScreen, creditsMenu;
    public float curLevelTime;
    public float levelFinishTime;
    public bool curLevelCompleted;
    public LevelLoadSO curLevel;
    public bool hasLoadedSave, firstPlay;



    private void Awake()
    {
        hasLoadedSave = false;
        firstPlay = false;
        if (levelInstance == null)
        {
            levelInstance = this;
        }
        else if (levelInstance != this)
        {
            Destroy(this.gameObject);
        }
        endLevelScreen.SetActive(false);
        levelSelectMenu.SetActive(false);
        mainMenu.SetActive(true);
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(this);
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(currentLevel.curLevel.levelIndex);
        StartLevelTimer();
        levelSelectMenu.SetActive(false);
    }
    public void ChooseLevelMenu()
    {
        levelSelectMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void ChooseMainMenu()
    {
        levelSelectMenu.SetActive(false);
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }

    public void ChooseSettingsMenu()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void ChooseCredits()
    {
        creditsMenu.SetActive(true);
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

    public void CloseGame()
    {
        Application.Quit();
    }

    public void FirstPlay()
    {
        if (!firstPlay)
        {
            firstPlay = true;
            if (!hasLoadedSave)
            {
                GameData.GDinstance.NoDataLoad();
            }
        }
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
        GameData.GDinstance.SaveData();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public IEnumerator ShowEndMenu()
    {
        SceneManager.LoadScene(0);
        endLevelScreen.SetActive(true);
        levelSelectMenu.SetActive(true);
        mainMenu.SetActive(false);
        yield return new WaitForSeconds(3f);
        endLevelScreen.SetActive(false) ;
        yield return null;
    }



}
