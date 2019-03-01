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

    public Building _parent;
    public EnergyBar _bar;
    public GameManager gm;
    void Start()
    {
        _parent = GetComponent<Building>();
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
            research_credits += 1;
            
            // if I have time I want to implement a snazzy
            // animation for "emptying" the bar
            _progress = 0;
        }

        _bar.set(_progress/_MAX);
    }
}
