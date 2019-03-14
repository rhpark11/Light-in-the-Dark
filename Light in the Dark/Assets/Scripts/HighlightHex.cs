using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Janky UI fix to make the Hex's highlight on hover
public class HighlightHex : MonoBehaviour
{
    private SpriteRenderer hex;
    public Building building;


    private Color default_color;
    public Color hover_color;
    public Color blink_color;


    public bool blink_red = false;
    public bool hovered = false;

    private float blink_count = 0;
    public float blink_period = 0.5f;
    void Start(){
        hex = GetComponent<SpriteRenderer>();
        default_color = hex.color;
    }


    void OnMouseEnter(){
        hovered = true;
    }

    void OnMouseExit(){
        hovered = false;
   }

    void Update(){
        // We want to blink red of the building is low
        blink_red = building.curr == Building.Status.Low;

        //handling the blinking
        blink_count += Time.deltaTime;
        if(blink_red && !hovered){

            // start blinking
            if(blink_count < blink_period/2){
                float t = blink_count/(blink_period/2);
                hex.color = Color.Lerp(default_color, blink_color, t);
            }else{
                float t = 1f - (blink_count-(blink_period/2))/(blink_period/2);
                hex.color = Color.Lerp(blink_color, default_color, t);
            }

            if(blink_count > blink_period){
                blink_count = 0;
            }
        // hovering-highlight takes priority, so we color over any blinking
        }else if(hovered){
            hex.color = hover_color;
        }else{
            hex.color = default_color;
        }
    }
}
