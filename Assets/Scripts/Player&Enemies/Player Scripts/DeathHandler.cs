using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathHandler : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerHealth.OnPlayerDeath += GameOver;
    }
    private void OnDisable()
    {
        PlayerHealth.OnPlayerDeath -= GameOver;
    }
    private void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
