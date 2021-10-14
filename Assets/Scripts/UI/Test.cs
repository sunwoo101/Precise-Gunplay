using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SFB;

public class Test : MonoBehaviour
{
    string[] soundPath;
    WWW www;
    AudioSource sound;

    private void Start()
    {
        PickCustomSound();
    }

    private void Update()
    {
        Debug.Log(soundPath[0]);
    }

    public void PickCustomSound()
    {
        // 
        soundPath = StandaloneFileBrowser.OpenFilePanel("Overwrite with png", "", "", false);
        if (soundPath.Length != 0)
        {
            www = new WWW(soundPath[0]);
            sound.clip = www.GetAudioClip();
            sound.Play();
        }
    }
}
