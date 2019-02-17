using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{


	public float startingHealth = 100;
	public Slider currentHealth;
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


	void OnTriggerEnter2D(Collider2D other) //other is the other collider that we touch
	{
		//Destroy(other.gameObject); This destroys the other game object, its assets and all of its children
		if (other.gameObject.CompareTag("Rock")){ //Tag is defined in Unity
			Destroy(other.gameObject);//deactivate pickup object
			currentHealth.value -= 10;
			if (currentHealth.value <=0){
				//Trigger Game over
				SceneManager.LoadSceneAsync(2);
			}
		}
    }

}
