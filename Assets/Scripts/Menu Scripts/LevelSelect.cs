using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class LevelSelect : MonoBehaviour
{
    public static LevelSelect levelInstance;
    public LevelLoad currentLevel;
    public GameObject mainMenu;
    public GameObject levelSelect;

    private void Awake()
    {
        levelInstance = this;
        levelSelect.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void LoadLevel()
    {
        if(SceneManager.sceneCount >= currentLevel.curLevel.levelIndex)
        SceneManager.LoadScene(currentLevel.curLevel.levelIndex);
    }

    public void ChooseLevel()
    {
        levelSelect.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void ChooseMain()
    {
        levelSelect.SetActive(false);
        mainMenu.SetActive(true);
    }

}
