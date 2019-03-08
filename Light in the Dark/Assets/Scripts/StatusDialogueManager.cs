using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusDialogueManager : MonoBehaviour
{

    public DialogueQue dQ;
    
    
    public Building nurse;
    public Building engineer;
    public Building researcher;

    public Dialog[][] nurseDialog = new Dialog[3][];
    public Dialog[][] engineerDialog = new Dialog[3][];
    public Dialog[][] researcherDialog = new Dialog[3][];


    public float nurseCooldown = 5f;
    private float startNurseCooldown;
    
    public float engineerCooldown = 5f;
    private float startEngineerCooldown;
    
    public float researcherCooldown = 5f;
    private float startResearcherCooldown;

    public Dialog[] nurseHigh = new Dialog[2];
    public Dialog[] nurseMid = new Dialog[2];
    public Dialog[] nurseLow = new Dialog[2];

    public Dialog[] engineerHigh = new Dialog[2];
    public Dialog[] engineerMid = new Dialog[2];
    public Dialog[] engineerLow = new Dialog[2];

    public Dialog[] researcherHigh = new Dialog[2];
    public Dialog[] researcherMid = new Dialog[2];
    public Dialog[] researcherLow = new Dialog[2];

    
    // Start is called before the first frame update
    void Start()
    {
        startNurseCooldown = nurseCooldown;
        startEngineerCooldown = engineerCooldown;
        startResearcherCooldown = researcherCooldown;

        researcherCooldown = 0f;
        engineerCooldown = 0f;
        nurseCooldown = 0f;

        Debug.Log("Loading dialogue...");
        nurseDialog[0] = nurseLow;
        nurseDialog[1] = nurseMid;
        nurseDialog[2] = nurseHigh;
        
        
        engineerDialog[0] = engineerLow;
        engineerDialog[1] = engineerMid;
        engineerDialog[2] = engineerHigh;
        
        researcherDialog[0] = researcherLow;
        researcherDialog[1] = researcherMid;
        researcherDialog[2] = researcherHigh;
        
        Debug.Log(nurseDialog[0][0].subtitle);
//        dQ.dialogQ.Enqueue(nurseDialog[0][1]);
//        dQ.dialogQ.Enqueue(nurseDialog[0][2]);
//        dQ.dialogQ.Enqueue(nurseDialog[0][3]);
        nurseCooldown = startNurseCooldown;
        engineerCooldown = startEngineerCooldown;
        researcherCooldown = startResearcherCooldown;


    }

    // Update is called once per frame
    void Update()
    {
        // If nurse's energy-state has changed, and our cooldown has ended,
        // we send appropriate dialogue to the queue.
        if (nurse.prev != nurse.curr && nurseCooldown < 0)
        {
            

            if (nurse.curr == Building.Status.Low)
            {
                // send low status audio to queue
                dQ.dialogQ.Enqueue(nurseDialog[0][0]);
            }
            else if (nurse.curr == Building.Status.Medium)
            {
                dQ.dialogQ.Enqueue(nurseDialog[1][0]);
            }
            else if (nurse.curr == Building.Status.High)
            {
                dQ.dialogQ.Enqueue(nurseDialog[2][0]);

            }
            
            //dQ.dialogQ.Enqueue(nurseDialog[(int)nurse.curr_morale][(int)nurse.curr]);
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
                dQ.dialogQ.Enqueue(engineerDialog[0][0]);
            }
            else if (engineer.curr == Building.Status.Medium)
            {
                dQ.dialogQ.Enqueue(engineerDialog[1][0]);
            }
            else if (engineer.curr == Building.Status.High)
            {
                dQ.dialogQ.Enqueue(engineerDialog[2][0]);

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
                dQ.dialogQ.Enqueue(researcherDialog[0][0]);
            }
            else if (researcher.curr == Building.Status.Medium)
            {
                dQ.dialogQ.Enqueue(researcherDialog[1][0]);
            }
            else if (researcher.curr == Building.Status.High)
            {
                dQ.dialogQ.Enqueue(researcherDialog[2][0]);
            }

            researcherCooldown = startResearcherCooldown;
        }
        else
        {
            researcherCooldown -= Time.deltaTime;
        }

        
    }
}
