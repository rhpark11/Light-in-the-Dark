using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This is intended to give the Medbay a secondary "health bar" of sorts.
// If this "health" goes to zero, a "Captain is Dead" boolean will
// probably be updated in the GameManager
public class MedbayHealth : MonoBehaviour
{

    public float _MAX_HEALTH = 100f;
    public float _health = 100f;
    public float _health_decline_rate = 0.1f;

    public Building _parent;
    public EnergyBar _bar;
    public GameManager gm;
    public AudioSource audioS;
    public Dialog sadNurse;
    private bool isDead = false;

    public DialogueQue dQ;
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        _parent = GetComponent<Building>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_parent.energy <= 0){
            //Debug.Log("Oh no we're losing the captain!!!");
            _health -= _health_decline_rate;
        }

        if(_health < 0 && !isDead){
            _health = 0;
            // change some flag or boolean in GM
            Debug.Log("Press F for respects");
            dQ.dialogQ.Enqueue(sadNurse);
            audioS.Play();
            isDead = true;
        }

        _bar.set(_health/_MAX_HEALTH);
    }
}
