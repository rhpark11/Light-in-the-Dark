using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static float Energy = 100f;
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

    public void TakeEnergy(float dEnergy)
    {
        Energy -= dEnergy; // lost dEnergy amound of energy called from other object
    }
}
