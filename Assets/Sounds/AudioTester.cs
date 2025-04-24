using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTester : MonoBehaviour
{
    public AudioClip clipToPlay1, clip2;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            AudioManager.instance?.PlayBGM(clipToPlay1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AudioManager.instance?.PlayBGM(clip2);
        }
    }
}
