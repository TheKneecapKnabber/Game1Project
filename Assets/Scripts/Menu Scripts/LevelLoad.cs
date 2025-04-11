using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelLoad : MonoBehaviour
{
    public LevelLoadSO curLevel;
    [SerializeField] private TextMeshProUGUI _levelName;
    [SerializeField] private TextMeshProUGUI _levelBestTime;
    [SerializeField] private Image _levelImage;

    private void Awake()
    {
        float minutes = Mathf.Floor(curLevel.bestTime / 60);
        float seconds = curLevel.bestTime % 60;
        _levelName.text = curLevel.levelName;
        _levelBestTime.text = "Best Time<br>" + minutes + " : " + seconds;
        _levelImage = curLevel.backgroundImage;
    }


}
