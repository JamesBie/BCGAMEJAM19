using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
	/*
		Laser goes straight
		Once it hits something that is a enermy, it is destroyed
	*/
	public float speed;
	public float timer=10f;
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
		//Get velocity to change depending on gun.rotation
		Vector3 velocity = new Vector3(0,speed,0); //need to change velocity according to direction of triangle later
		pos += transform.rotation * velocity;
		transform.position=pos;
		timer-=Time.deltaTime;
		if (timer<=0){
			Destroy(gameObject);
		}
    }
	
	void OnTriggerEnter2D(Collider2D other) //other is the other collider that we touch
	{
	
		//Destroy(other.gameObject); This destroys the other game object, its assets and all of its children
		if (other.gameObject.CompareTag("Rock")){ //Tag is defined in Unity <-------------------------------------
			Debug.Log("rock + laser trigger");
			Destroy(other.gameObject);//destroy rock
			Destroy(gameObject); //Also destroy laser
			
		}
    }
}
