using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// simple data structure to store audio and text corresponding to the audio
[System.Serializable]
public class Dialog
{

    public AudioClip audio;
    public string subtitle;
    public float silence;
    [Range(-1.0f, 1.0f)]
    public float pan;
    
    // engineer = 0; nurse = 1; researcher = 2
    public int speaker;

    public void DialogConstructor(AudioClip ac, string s, float time = 0, float p = 0)
    {
        audio = ac;
        subtitle = s;
        silence = time;
        pan = p;
    }
}