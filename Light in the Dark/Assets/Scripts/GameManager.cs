using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float energy = 100f;
    
    public Image energyBar;

    public float maxEnergy;
    
    public float energyRegenRate = 1f;
    public Transform buttonLocation;

    
    public float timeBetweenEnergyGain;
    private float startTimebetweenEnergyGain;

    public Building thermal;
    public ResearchProgress research;
    public GameObject researchButton;
    public string researchEnding;
    
    public string thermalEndScene;
    private bool barSpawned = false;
    
    void Start()
    {
        energy = maxEnergy;
        startTimebetweenEnergyGain = timeBetweenEnergyGain;
    }

   
    void Update()
    {
        //checks if the energy has reached the floor or ceiling (needs work)
        if (energy >= maxEnergy)
        {
            energy = maxEnergy;
        }
        else if (energy <= 0)
        {
            energy = 0;
        }
        
        energyBar.fillAmount = energy / maxEnergy;
        
        
        //Gaining energy per time specified in the variable timeBetweenEnergyGain
        
        //updateEnergy();
        if (timeBetweenEnergyGain <= 0 && energy < maxEnergy)
        {
            if (energyRegenRate + energy > maxEnergy)
            {
                energy = maxEnergy;
            }
            else
            {
                energy += energyRegenRate;
            }
            
            timeBetweenEnergyGain = startTimebetweenEnergyGain;
        }
        else
        {
            timeBetweenEnergyGain -= Time.deltaTime;
        }

        if (thermal.energy <= 0)
        {
            SceneManager.LoadScene(thermalEndScene);
        }

        if (research.research_credits == research.max_credits && !barSpawned )
        {
            Instantiate(researchButton, buttonLocation);
            barSpawned = true;
        }
        
    }


    //Energy is given from the GameManager to the building requesting it
    public void TakeEnergyFromManager(float dEnergy, Building building)
    {
 

        if (dEnergy + building.energy > building.maxEnergy)
        {
            
            dEnergy = building.maxEnergy - building.energy;
            energy -= dEnergy;
            building.energy += dEnergy;
        }
        else
        {
            energy -= dEnergy;
            building.energy += dEnergy;
        }

        if (energy <= 0)
        {
            building.ToggleEnergy = false;
        }
        
    }

    private void updateEnergy()
    {
        if (timeBetweenEnergyGain <= 0 && energy < maxEnergy)
        {
            if (energyRegenRate + energy > maxEnergy)
            {
                energy = maxEnergy;
            }
            else
            {
                energy += energyRegenRate;
            }
                
            timeBetweenEnergyGain = startTimebetweenEnergyGain;
        }
        else
        {
            timeBetweenEnergyGain -= Time.deltaTime;
        }
    }

    //Not being used in the game.
 //   public void addEnergy(float dEnergy, Building building)
 //   {
 //      if (dEnergy + building.Energy > building.maxEnergy)
 //       {
 //           dEnergy = building.maxEnergy - building.Energy;
 //           Energy += dEnergy;
 //       }
 //       else
 //       {
 //           Energy += dEnergy;
 //       }

}
