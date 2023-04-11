using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void OnEnable()
    {
        CoreSignals.Instance.onLevelFailed += OnCoinFailedSound;
        AudioSignals.Instance.onClickSound += OnClickSound;
        PlayerSignals.Instance.onCollectibleCoinContact += OnCoinCollectedSound;
        PlayerSignals.Instance.onFinishArch += OnFinishStageSound;
    }

    private void OnDisable()
    {
        CoreSignals.Instance.onLevelFailed -= OnCoinFailedSound;
        AudioSignals.Instance.onClickSound -= OnClickSound;
        PlayerSignals.Instance.onCollectibleCoinContact -= OnCoinCollectedSound;
        PlayerSignals.Instance.onFinishArch -= OnFinishStageSound;
    }
    private void Start()
    {
        //Play("ThemeSound1");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) return;
        s.source.Play();
    }

    private void OnCoinFailedSound()
    {
        Play("CoinFailedSound");
    }
    private void OnClickSound()
    {
        Play("ClickSound");
    }

    private void OnCoinCollectedSound(Transform arg0)
    {
        Play("CoinCollectedSound");
    }

    private void OnFinishStageSound()
    {
        Play("LevelSuccededSound");
    }

}
