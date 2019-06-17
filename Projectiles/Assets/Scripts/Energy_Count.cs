using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy_Count : MonoBehaviour
{
    float energy = 0; //Total energy 
    float energyGain; //Amount of energy gained
    float energyLoss;//Amount of energy lost
    float next_gain = 0f; //Time
    public float energyRate = 1.0f; //Rate at which energy is either gained or lost

    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        //Finds the number of panels and 
        float number_of_panels = GameObject.FindGameObjectsWithTag("panel").Length;
        float number_of_turrets = GameObject.FindGameObjectsWithTag("panel").Length;
        //Complicated calculations
        energyGain = 20.0f * (number_of_panels + 1);
        energyLoss = 30.0f * (number_of_turrets);

        //If time interval is reached
        if (Time.time > next_gain)
        {
            //Calculate next time interval to be reached
            next_gain = Time.time + energyRate;
            
            //Energy is gained

            energy += energyGain - energyLoss;

            //if set minimun energy to zero
            if (energy < 0)
            {
                energy = 0;
            }
        }


    }
}
