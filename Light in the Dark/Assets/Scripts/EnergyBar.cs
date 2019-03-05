using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnergyBar : MonoBehaviour
{
    public float value = 0.9f;
    private Transform bar;

    void Start(){
        bar = transform.Find("inner_fill");
    }

    // Update is called once per frame
    void Update()
    {
        // I could go change the art ORRRRR     |
        // I could change a line of code!       V
        bar.transform.localScale = new Vector3(1 - value, 1,1);
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
