using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsMenu;
    public bool menuOpen;
    public PlayerMovement player;
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void Update()
    { 
        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                settingsMenu.SetActive(!menuOpen);
                Cursor.visible = !menuOpen;
                if (menuOpen)
                {
                    Cursor.lockState = CursorLockMode.None;
                }
                if (player != null)
                {
                    player.isInMenu = !menuOpen;
                }
                menuOpen = !menuOpen;
            }
        }
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.buildIndex != 0)
        {
            player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        }
    }
}
