using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static LevelSelectManager;

public class LevelLoad : MonoBehaviour
{
    public LevelLoadSO curLevel;
    [SerializeField] private TextMeshProUGUI _levelName;
    [SerializeField] private TextMeshProUGUI _levelBestTime;
    private Sprite _levelSprite;
    [SerializeField]private Image _levelImage;
    public GameObject levelSelectImage;


    private void Awake()
    {
        float minutes = Mathf.Floor(curLevel.bestTime / 60);
        float seconds = curLevel.bestTime % 60;
        _levelName.text = curLevel.levelName;
        _levelSprite = curLevel.backgroundImage;
        _levelImage.sprite = _levelSprite;

        if(curLevel.hasBeenBeaten)
        {
            _levelBestTime.gameObject.SetActive(true);
            _levelBestTime.text = "Best Time<br>" + minutes + " : " + seconds;
        }
        else
        {
            _levelBestTime.gameObject.SetActive(false   );
        }


    }

    public void ChangeCurrentLevel()
    {
        levelInstance.currentLevel = this;
        levelSelectImage.transform.position = this.transform.position;
    }

}
