using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyMain
{

    // Main Energy "Data Struct" I guess you could call this
    // The UI pieces should all directly access this
    // Things like Room or EnergyHandler or something

    const int MAX_ENERGY = 100;
    private int energy = 100;

    int take(){
        if(energy > 0){
            energy--;
        }
        return 1;
    }

    void add(){
        if(energy < MAX_ENERGY){
            energy++;
        }
    }

    int get(){
        return energy;
    }
}
