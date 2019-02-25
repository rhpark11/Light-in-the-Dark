﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusDialogueManager : MonoBehaviour
{

    public DialogueQue dQ;
    
    
    public Building nurse;
    public Building engineer;
    public Building researcher;

    public Dialog[][] nurseDialog;
    public Dialog[][] engineerDialog;
    public Dialog[][] researcherDialog;


    public float nurseCooldown = 5f;
    private float startNurseCooldown;
    
    public float engineerCooldown = 5f;
    private float startEngineerCooldown;
    
    public float researcherCooldown = 5f;
    private float startResearcherCooldown;

    public Dialog[] nurseHigh;
    public Dialog[] nurseMid;
    public Dialog[] nurseLow;

    public Dialog[] engineerHigh;
    public Dialog[] engineerMid;
    public Dialog[] engineerLow;

    public Dialog[] researcherHigh;
    public Dialog[] researcherMid;
    public Dialog[] researcherLow;

    
    // Start is called before the first frame update
    void Start()
    {
        startNurseCooldown = nurseCooldown;
        startEngineerCooldown = engineerCooldown;
        startResearcherCooldown = researcherCooldown;

        researcherCooldown = 0f;
        engineerCooldown = 0f;
        nurseCooldown = 0f;

        nurseDialog[0] = nurseLow;
        nurseDialog[1] = nurseMid;
        nurseDialog[2] = nurseHigh;
        
        
        engineerDialog[0] = engineerLow;
        engineerDialog[1] = engineerMid;
        engineerDialog[2] = engineerHigh;
        
        researcherDialog[0] = researcherLow;
        researcherDialog[1] = researcherMid;
        researcherDialog[2] = researcherHigh;
        

        dQ.dialogQ.Enqueue(nurseDialog[0][0]);
    }

    // Update is called once per frame
    void Update()
    {

        if (nurse.prev != nurse.curr && nurseCooldown < 0) //change in state
        {
            /*

            if (nurse.curr == Building.Status.Low)
            {
                // send low status audio to queue
                dQ.dialogQ.Enqueue(nurseDialog[0][energyIndex]);
            }
            else
            {
                dQ.dialogQ.Enqueue(nurseDialog[1]);
            }
            */
            
            dQ.dialogQ.Enqueue(nurseDialog[(int)nurse.currMorale][(int)nurse.curr]);
            nurseCooldown = startNurseCooldown;
        }
        else
        {
            nurseCooldown -= Time.deltaTime;
        }
        
        if (engineer.prev != engineer.curr && engineerCooldown < 0) //change in state
        {

            if (engineer.curr == Building.Status.Low)
            {
                // send low status audio to queue
                //dQ.dialogQ.Enqueue(engineerDialog[0]);

            }
            else
            {
                //send high status audio to queue
                //dQ.dialogQ.Enqueue(engineerDialog[1]);

            }

            engineerCooldown = startEngineerCooldown;
        }
        else
        {
            engineerCooldown -= Time.deltaTime;
        }

        if (researcher.prev != researcher.curr && researcherCooldown < 0) //change in state
        {

            if (researcher.curr == Building.Status.Low)
            {
                // send low status audio to queue
                //dQ.dialogQ.Enqueue(researcherDialog[0]);

            }
            else
            {
                //send high status audio to queue
                //dQ.dialogQ.Enqueue(researcherDialog[1]);

            }

            researcherCooldown = startResearcherCooldown;
        }
        else
        {
            researcherCooldown -= Time.deltaTime;
        }

        
    }
}
