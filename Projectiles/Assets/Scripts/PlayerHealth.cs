using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

	private int startingHealth = 100;
	public Slider currentHealth;

	bool isDead= false;
	bool damaged= false;

	void Awake(){
		
	}

    // Start is called before the first frame update
    void Start()
    {
    	currentHealth = GameObject.Find("HealthBar").GetComponent<Slider>();
    	currentHealth.value = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {

    	//change logic to players health when time is right
    	if (Input.GetKeyDown (KeyCode.A) && currentHealth.value < 100){
    		currentHealth.value += 10;
    	}

    	if (Input.GetKeyDown (KeyCode.S) && currentHealth.value >0){
    		currentHealth.value -= 10;
    	}
        
    }
}
