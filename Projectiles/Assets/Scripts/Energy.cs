using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    float energy; //Total energy 
    float energyGain; //Amount of energy gained
    float energyLoss;//Amount of energy lost
    float next_gain = 0f; //Time
    public float energyRate = 1.0f; //Rate at which energy is either gained or lost

    void Start()
    {
        energy = 100;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Finds the number of panels and 
        float number_of_panels = GameObject.FindGameObjectsWithTag("Panel").Length;
        float number_of_turrets = GameObject.FindGameObjectsWithTag("Turret").Length;
        //Complicated calculations
        energyGain = 2.0f * (number_of_panels);
        energyLoss = 3.0f * (number_of_turrets);

        if (Time.time>next_gain){
            //Calculate next time interval to be reached
            next_gain = Time.time + energyRate;

        //Energy is gained

            energy = energy + energyGain - energyLoss;

            //if set minimun energy to zero
            if (energy < 0)
            {
                energy = 0;
            }
            Debug.Log("Current gain: " + energyGain);
            Debug.Log("Current energy: " + energy);
        
		}

    }
}
