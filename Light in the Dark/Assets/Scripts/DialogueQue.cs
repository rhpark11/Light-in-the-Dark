using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class DialogueQue : MonoBehaviour
{


    public Queue<Dialog> dialogQ = new Queue<Dialog>();
    public AudioSource audioS;
    private bool isPlaying;
    private float duration = 0;
    public PictureManager pm;
    public Text subtitles;

    
    //tests
    public Dialog test_1;
    
    public Dialog test_2;
    
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        //dialogQ.Enqueue(test_1);
        //dialogQ.Enqueue(test_2);

    }

    // Update is called once per frame
    void Update()
    {
        duration -= Time.deltaTime;
        if (duration < 0)
        {
            isPlaying = false;
        }

        if (dialogQ.Count > 0 && !isPlaying)
        {
            Dialog currentDialog = dialogQ.Dequeue();
            audioS.clip = currentDialog.audio;
            audioS.panStereo = currentDialog.pan;
            pm.switchPic(currentDialog.speaker);
            string subs = currentDialog.subtitle;
            duration = audioS.clip.length + currentDialog.silence;
            subtitles.text = subs;
            isPlaying = true;

            // play audio
            audioS.Play();
            // display subtitle
        }
            
            
    }
}
