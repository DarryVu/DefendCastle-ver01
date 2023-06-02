using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOnOff : MonoBehaviour
{
    private Sprite soundOnImg;
    public Sprite soundOffImg;
    public Button btn;
    private bool isOn = true;

    public AudioSource audioSource;
    public AudioSource audioBG;

    private void Start()
    {
        soundOnImg = btn.image.sprite;
    }
    public void ButtonClick()
    {
        if(isOn)
        {
            btn.image.sprite = soundOffImg;
            isOn = false;
            audioSource.mute = true;
            audioBG.mute = true;
        }
        else
        {
            btn.image.sprite = soundOnImg;
            isOn = true;
            audioSource.mute = false;
            audioBG.mute = false;
        }
    }
}
