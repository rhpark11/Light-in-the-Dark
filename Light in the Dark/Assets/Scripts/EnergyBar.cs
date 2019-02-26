using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnergyBar : MonoBehaviour
{
    public float value = 0.3f;
    private Transform bar;

    void Start(){
        bar = transform.Find("inner_fill");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            value += 0.1f;
        }

        if(Input.GetKeyDown(KeyCode.DownArrow)){
            Debug.Log("DOWN");
            value -= 0.1f;
        }

        bar.transform.localScale = new Vector3(value, 1,1);
    }

    //amt should be [0,1]
    public void set(float amt){
        if(0 <= amt && amt <= 1){
            value = amt;
        }
    }

    public void add(float amt){
        if(amt + value >= 1){
            value = 1;
        }else if(amt + value < 0){
            value = 0;
        }else{
            value += amt;
        }
    }


}
