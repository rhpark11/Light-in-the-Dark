using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Building : MonoBehaviour
{
    
    public float Energy = 0f; // how much energy this building currently has
    
    public float maxEnergy;    // how much energy can this building take

    public GameManager gameManager;
    
    public float changeEnergy; // how much energy the building takes 
    
    public float timeBetweenEnergylossPerSecond = 1f;
    private float startEnergyLossRate;

    public float energyLostPerSecond;

    public Image EnergyBar;

    
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); // should only be one GameManager! more like a (EnergyManager)
        startEnergyLossRate = timeBetweenEnergylossPerSecond;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            increaseBuildingEnergy();
        }
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            releaseEnergy();
        }

        if (Energy > 0)
        {
            if (timeBetweenEnergylossPerSecond > 0)
            {
                timeBetweenEnergylossPerSecond -= Time.deltaTime;
            }
            else
            {
                Energy -= energyLostPerSecond;
                timeBetweenEnergylossPerSecond = startEnergyLossRate;
            }
        }

        EnergyBar.fillAmount = Energy / maxEnergy;
    }

    private void FixedUpdate()
    {
        
    }

    public void increaseBuildingEnergy()
    {
        if (Energy < maxEnergy)
        {
            
            gameManager.TakeEnergy(changeEnergy, this); // public function from the GameManager class.
        }
    }

    public void releaseEnergy()
    {
        if (Energy > 0)
        {
            Energy -= 10f;
            gameManager.addEnergy(changeEnergy, this);
        }
    }
    
}
