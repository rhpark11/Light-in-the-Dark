using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    
    public float Energy = 0f; // how much energy this building currently has
    
    public float maxEnergy;    // how much energy can this building take

    public GameManager gameManager;
    
    public float changeEnergy; // how much energy the building takes 

    
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); // should only be one GameManager! more like a (EnergyManager)
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Energy < maxEnergy)
            {
                gameManager.TakeEnergy(10f); // public function from the GameManager class.
                Energy += changeEnergy;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            releaseEnergy();
        }
    }

    public void releaseEnergy()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Energy -= changeEnergy;
            GameManager.Energy += changeEnergy;
        }
    }
    
}
