using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHp : MonoBehaviour
{
	/*
	Solar Panel HP decreases when hit until it gets destroyed
	
	
	*/
	int health = 2;
	void OnTriggerEnter2D(Collider2D other) //other is the other collider that we touch
	{
		if (other.gameObject.CompareTag("Rock")){ //Tag is defined in Unity
			Destroy(other.gameObject);//destroy meteor
			health -= 1;
			if (health <=0){ //When HP is 0, destroy current wall
				Destroy(gameObject);
				Debug.Log("WallDed");
			}
		}
	}
}

