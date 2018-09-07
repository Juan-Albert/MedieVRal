using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource music;
    public AudioSource soundEffect;

    public float lowPitchRange = 0.95f; //mas grave
    public float highPitchRange = 1.05f; //mas agudo

    public static SoundManager instance;

    private void Awake()
    {
        if (SoundManager.instance == null)
        {
            SoundManager.instance = this;
        }
        else if (SoundManager.instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    //Reproduce un sonido
    public void PlaySingle(AudioClip clip)
    {
        soundEffect.pitch = 1f;
        soundEffect.clip = clip;
        soundEffect.Play();
    }

    //Reproduce un sonido aleatorio de un array.
    public void RandomizeSfx(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);
        soundEffect.pitch = randomPitch;
        soundEffect.clip = clips[randomIndex];
        soundEffect.Play();


    }
}
