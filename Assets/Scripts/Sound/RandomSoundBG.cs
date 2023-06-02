using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundBG : MonoBehaviour
{
    private AudioSource soundRandom;
    public AudioClip[] clips;

    private void Start()
    {
        soundRandom = FindObjectOfType<AudioSource>();
        soundRandom.loop = false;
    }

    private void Update()
    {
        if(!soundRandom.isPlaying)
        {
            soundRandom.clip = GetRandom();
            soundRandom.Play();
        }
    }
    private AudioClip GetRandom()
    {
        return clips[Random.Range(0, clips.Length)];
    }

}
