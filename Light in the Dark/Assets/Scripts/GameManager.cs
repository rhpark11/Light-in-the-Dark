using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float Energy = 100f;
    public Image energyBar;

    private float maxEnergy;
    public float dEnergy = 10f;
    
    public float energyRegenRate = 1f;

    public float timeBetweenEnergyGain;
    private float startTimebetweenEnergyGain;
    public bool isRegenerating = true;
    
    
    void Start()
    {
        maxEnergy = Energy;
        startTimebetweenEnergyGain = timeBetweenEnergyGain;
    }

   
    void Update()
    {
        
        if (Energy >= maxEnergy)
        {
            Energy = maxEnergy;
        }else if (Energy <= 0)
        {
            Energy = 0;
        }
        
        energyBar.fillAmount = Energy / maxEnergy;
        
        
        //Gaining energy per second

        if (timeBetweenEnergyGain <= 0 && Energy < maxEnergy)
        {
            if (energyRegenRate + Energy > maxEnergy)
            {
                Energy = maxEnergy;
            }
            else
            {
                Energy += energyRegenRate;
            }
            
            timeBetweenEnergyGain = startTimebetweenEnergyGain;
        }
        else
        {
            timeBetweenEnergyGain -= Time.deltaTime;
        }
        
    }


    //Energy is given from the game manager to the building requesting it
    public void TakeEnergyFromManager(float dEnergy, Building building)
    {
 

        if (dEnergy + building.Energy > building.maxEnergy)
        {
            
            dEnergy = building.maxEnergy - building.Energy;
            Energy -= dEnergy;
            building.Energy += dEnergy;
        }
        else
        {
            Energy -= dEnergy;
            building.Energy += dEnergy;
        }
    }

    public void addEnergy(float dEnergy, Building building)
    {
        if (dEnergy + building.Energy > building.maxEnergy)
        {
            dEnergy = building.maxEnergy - building.Energy;
            Energy += dEnergy;
        }
        else
        {
            Energy += dEnergy;
        }

    }
    
}
