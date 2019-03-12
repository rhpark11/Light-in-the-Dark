using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Sprite[] pics = new Sprite[3];
    public SpriteRenderer sr;
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchPic(int index)
    {

        sr.sprite = pics[index];
    }
}
