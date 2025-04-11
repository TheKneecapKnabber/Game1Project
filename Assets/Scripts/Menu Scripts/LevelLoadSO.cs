using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Level", menuName = "ScriptableObjects/Level")]
public class LevelLoadSO : ScriptableObject
{
    public string levelName;
    public int levelIndex;
    public Image backgroundImage;
    public float bestTime;
    public bool hasBeenBeaten;

}
