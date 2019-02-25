using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Building : MonoBehaviour
{

    public enum Status
    {
        Low = 0,
        High = 1
    };

    public enum Morale
    {
        Low = 0,
        Medium = 1,
        High = 2
    };

    public Morale currMorale;
    public Status prev = Status.High;
    public Status curr = Status.High;
    
    public float energy = 0f; // how much energy this building currently has
    
    public float maxEnergy;    // how much energy can this building take

    public GameManager gameManager;
    
    public float changeEnergy; // how much energy the building takes from the GameManager
    
    //These are the time variables I used
    public float timeBetweenEnergyloss = 1f;
    private float startEnergyLossRate;

    public float timeBetweenEnergyGain;
    private float startEnergyGainRate;
    
    //Moral for the person in the building
    public float moral;
    private float maxMoral;

    //Rate at which the energy is lost per the value of time between energy lost
    public float energyLostPerTick;

    //The image associated to the bar
    public Image EnergyBar;

    public bool ToggleEnergy = false;

    private Collider2D buildingHitBox;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); // should only be one GameManager! more like a (EnergyManager)
        buildingHitBox = gameObject.GetComponent<Collider2D>(); //So the game knows when you clicked on a building
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
        
//        if (Input.GetMouseButton(0))
//        {
//
//            Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//
//
//            if (buildingHitBox.OverlapPoint(mp))
//            {
//                ToggleEnergy = true;
//            }
//            else
//            {
//                ToggleEnergy = false;
//            }
//
//        }
//        // toggle true when player holds button down
//        if (Input.GetMouseButtonUp(0))
//        {
//
//            Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//
//
//            if (buildingHitBox.OverlapPoint(mp))
//            {
//                ToggleEnergy = false;
//            }
//
//        }
        
        
        
        
        if (ToggleEnergy)
        {
            increaseBuildingEnergy();
        }
        
        if (energy >= maxEnergy)
        {
            ToggleEnergy = false;
        }

        if (energy > 0 && !ToggleEnergy)
        {
            if (timeBetweenEnergyloss > 0)
            {
                timeBetweenEnergyloss -= Time.deltaTime;
            }
            else
            {
                energy -= energyLostPerTick;
                timeBetweenEnergyloss = startEnergyLossRate;
            }
        }

        EnergyBar.fillAmount = energy / maxEnergy;


        if (energy / maxEnergy < 0.5)
        {
            prev = curr;
            curr = Status.Low;
        }
        else if(energy / maxEnergy >= 0.5)
        {
            prev = curr;
            curr = Status.High;
        }

        checkMorale();

    }

    public void checkMorale()
    {
        // checl conditions, see if morale state needs to be changed
        currMorale = Morale.High;
    }

    //Takes energy (value of changeEnergy) from the Game manager and adds it to the Building.
    public void increaseBuildingEnergy()
    {
        if (energy < maxEnergy)
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

    
}
