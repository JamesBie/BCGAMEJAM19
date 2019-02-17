using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class earthcollision : MonoBehaviour
{
	
	public Slider PlanetHealth;
	
	void Start()
    {
    	PlanetHealth = GameObject.Find("PlanetHealthBar").GetComponent<Slider>();
    	PlanetHealth.value = 20;
    }
    void OnTriggerEnter2D(Collider2D other) //other is the other collider that we touch
	{
		//Destroy(other.gameObject); This destroys the other game object, its assets and all of its children
		if (other.gameObject.CompareTag("Rock")){ //Tag is defined in Unity
			Destroy(other.gameObject);//destroy rock
			PlanetHealth.value -= 1;
			if (PlanetHealth.value <=0){
				//Trigger Game over
				SceneManager.LoadSceneAsync(2);
			}
		}
    }
}
