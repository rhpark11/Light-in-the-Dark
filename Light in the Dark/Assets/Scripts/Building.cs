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
    
    public float timeBetweenEnergyloss = 1f;
    private float startEnergyLossRate;

    public float timeBetweenEnergyGain;
    private float startEnergyGainRate;

    public float energyLostPerSecond;

    public Image EnergyBar;

    public bool ToggleEnergy = false;

    private Collider2D buildingHitBox;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); // should only be one GameManager! more like a (EnergyManager)
        buildingHitBox = gameObject.GetComponent<Collider2D>();
        startEnergyLossRate = timeBetweenEnergyloss;
        startEnergyGainRate = timeBetweenEnergyloss;    //Energy is gained at the same time interval as energy being lost.
    }

    // Update is called once per frame
    void Update()
    {
        // If the player clicks on the buildings 2D collider it will toggle from giving energy to not giving energy.
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);


            if (buildingHitBox.OverlapPoint(mp))
            {
                ToggleEnergy = !ToggleEnergy;
            }

        }
        
        if (ToggleEnergy)
        {
            increaseBuildingEnergy();
        }
        
        if (!ToggleEnergy)
        {
           // releaseEnergy();
        }

        if (Energy > 0 && !ToggleEnergy)
        {
            if (timeBetweenEnergyloss > 0)
            {
                timeBetweenEnergyloss -= Time.deltaTime;
            }
            else
            {
                Energy -= energyLostPerSecond;
                timeBetweenEnergyloss = startEnergyLossRate;
            }
        }

        EnergyBar.fillAmount = Energy / maxEnergy;
    }



    public void increaseBuildingEnergy()
    {
        if (Energy < maxEnergy)
        {
            if (timeBetweenEnergyGain > 0)
            {
                timeBetweenEnergyGain -= Time.deltaTime;
            }
            else
            {
                gameManager.TakeEnergyFromManager(changeEnergy, this); // public function from the GameManager class.
                timeBetweenEnergyGain = startEnergyGainRate;
            }
        }
    }

//    public void releaseEnergy()
//    {
 //       if (Energy > 0)
 //       {
 //           Energy -= 10f;
//            gameManager.addEnergy(changeEnergy, this);
//        }
//    }
    
}
