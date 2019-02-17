using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHp : MonoBehaviour
{
	public int health = 5;
	void OnTriggerEnter(Collider other) //other is the other collider that we touch
	{
		if (other.gameObject.CompareTag("Rock")){ //Tag is defined in Unity
			Destroy(other.gameObject);//deactivate pickup object
			health -= 1;
			if (health <=0){ //When HP is 0, destroy current wall
				Destroy(gameObject);
				Debug.Log("WallDed");
			}
		}
	}
}

