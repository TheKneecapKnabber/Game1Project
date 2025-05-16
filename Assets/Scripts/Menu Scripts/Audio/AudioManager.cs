using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private AudioSource[] _sfxSources;

    [SerializeField, Min(0)] private int _numberOfSources;

    private int curSfxIndex = 0;

    private AudioSource _bgmSource;

    private float _sfxVolumePref;
    private float _bgmVolumePref;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }




        int firstTimeRunning = PlayerPrefs.GetInt("firstTimeRunning");

        if(firstTimeRunning == 0)
        {
            PlayerPrefs.SetFloat("_sfxVolumePref", 1);
            PlayerPrefs.SetFloat("_bgmVolumePref", 1);
            PlayerPrefs.SetInt("firstTimeRunning", 1);
        }
        else
        {
            _sfxVolumePref = PlayerPrefs.GetFloat("_sfxVolumePref");
            _bgmVolumePref = PlayerPrefs.GetFloat("_bgmVolumePref");
        }
  

        InitSFX();
        _bgmSource = gameObject.AddComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }
    
    public void ChangeBGMVolumePref(float v)
    {
        _bgmVolumePref = v;
        _sfxVolumePref = v;
        PlayerPrefs.SetFloat("_bgmVolumePref", v);
        PlayerPrefs.SetFloat("_sfxVolumePref", v);
        Debug.Log(v);
    }


    private void InitSFX()
    {
        _sfxSources = new AudioSource[_numberOfSources];

        for (int i = 0; i < _sfxSources.Length; i++)
        {
            _sfxSources[i] = gameObject.AddComponent<AudioSource>();

        }
    }

    public void PlaySfx(AudioClip clipToPlay, float volume = 1, float pitch = 1)
    {
        _sfxSources[curSfxIndex].clip = clipToPlay;
        _sfxSources[curSfxIndex].volume = volume * _sfxVolumePref;
        _sfxSources[curSfxIndex].pitch = pitch;
        _sfxSources[curSfxIndex].Play();

        curSfxIndex++;

       /* if (curSfxIndex > _numberOfSources - 1)
        {
            curSfxIndex = 0;
        }
       */
        curSfxIndex = curSfxIndex > _sfxSources.Length -1 ? 0 : curSfxIndex;

    }

    public void PlaySfx(AudioClip clipToPlay, Vector3 position, float volume = 1, float pitch = 1)
    {
        GameObject go = new GameObject();
        go.transform.position = position;
        AudioSource newSource = go.AddComponent<AudioSource>();
        newSource.clip = clipToPlay;
        newSource.volume = volume * _sfxVolumePref;
        newSource.pitch = pitch;
        newSource.spatialBlend = 1;
        newSource.Play();

        //pitch will change lengths of clip
        StartCoroutine(DestroyAfterTime(go,clipToPlay.length));
    }

    public void PlayBGM(AudioClip clipToPlay, float fadeDuration = 1, float volume = 1, bool isLooping = true)
    {
        StartCoroutine(PlayBGMCo(clipToPlay,fadeDuration,volume,isLooping));
    }

    private IEnumerator PlayBGMCo(AudioClip clipToPlay, float fadeDuration = 1, float volume = 1, bool isLooping = true)
    {
        float t = 0f;
        AudioSource newBGM = gameObject.AddComponent<AudioSource>();
        newBGM.clip = clipToPlay;
        newBGM.loop = isLooping;
        newBGM.Play();

        float startingVolume = _bgmSource.volume;

        while (t <= fadeDuration)
        {
            float percent = t / fadeDuration;
            _bgmSource.volume = Mathf.Lerp(startingVolume, 0f, percent);
            newBGM.volume = Mathf.Lerp(0f,volume * _bgmVolumePref, percent);
            t += Time.unscaledDeltaTime;
            yield return null;
        }

        Destroy(_bgmSource);
        _bgmSource = newBGM;

    }

    private IEnumerator DestroyAfterTime(GameObject go, float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(go);
    }

}
