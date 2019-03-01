using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float timer;

    public string sceneToLoad;

    public Text timeLeft;


    private string minutes;
    private string seconds;
    
    
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            SetText();
        }


    }

    void SetText()
    {
        
        minutes = Mathf.Floor(timer / 60).ToString("00");        
        seconds = Mathf.Floor(timer % 60).ToString("00");
        

        timeLeft.text = minutes + " : " + seconds;

    }
}
