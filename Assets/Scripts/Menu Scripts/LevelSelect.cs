using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelSelect : MonoBehaviour
{
    public LevelLoadSO currentLevel;



    public void LoadLevel()
    {
        SceneManager.LoadScene(currentLevel.levelIndex);
    }

}
