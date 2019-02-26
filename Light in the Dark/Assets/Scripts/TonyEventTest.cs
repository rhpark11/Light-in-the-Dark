using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TonyEventTest : MonoBehaviour
{

    public UnityEvent spacebarEvent;

    // Start is called before the first frame update
    void Start(){

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            spacebarEvent.Invoke();
        }
    }
}
