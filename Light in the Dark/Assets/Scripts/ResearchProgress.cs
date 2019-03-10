using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchProgress : MonoBehaviour
{
    public float _MAX = 100f;
    public float _progress = 0.1f;
    public float _progress_increase_rate = 0.1f;

    // The point wher research commences/stops
    public float _energy_threshold = 85f;
    public int research_credits = 1;
    public int max_credits = 5;

    public GameObject[] credits = new GameObject[5];

    public Building _parent;
    public EnergyBar _bar;
    public GameManager gm;
    void Start()
    {
        _parent = GetComponent<Building>();
        updateCreditDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        if(_parent.energy > _energy_threshold){
            //Debug.Log("Oh no we're losing the captain!!!");
            _progress += _progress_increase_rate;
        }

        if(_progress >= 100){
            // Once we've "completed some research"
            // we obtain a "research credit" or something
            // spendable
            if(research_credits < max_credits){
                research_credits += 1;
                //TODO play a "credit earned" sound
                updateCreditDisplay();
                
                if(research_credits == max_credits){
                    gm.enableResearchWin();
                }
            }
            
            // if I have time I want to implement a snazzy
            // animation for "emptying" the bar
            _progress = 0;
        }

        _bar.set(_progress/_MAX);
    }

    private void updateCreditDisplay(){
        for(int i = 0; i < research_credits; i++){
            // we enable/disable all the credits
            // we assume they all start out disabled
            credits[i].SetActive(true);
        }
    }
}
