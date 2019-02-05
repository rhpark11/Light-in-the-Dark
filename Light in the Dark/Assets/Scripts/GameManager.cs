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
    
    void Start()
    {
        maxEnergy = Energy;
    }

   
    void Update()
    {
        if (Energy >= maxEnergy)
        {
            Energy = maxEnergy;
        }
        
        energyBar.fillAmount = Energy / maxEnergy;
    }



    public void TakeEnergy(float dEnergy, Building building)
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
