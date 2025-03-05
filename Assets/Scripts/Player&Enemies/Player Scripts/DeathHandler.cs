using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Debug.Log("Game Over");
    }
}
