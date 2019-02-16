using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPew : MonoBehaviour
{
    public GameObject laser;
	public float FireInterval = 1f; //Time in between shoot
	public Transform target; //can make this private later on
	public float range = 5.0f; //range of the turret
	public string enemyTag;
	
	
	float cooldownTimer=0;
	
	
    // Start is called before the first frame update
    void Start()
    { 
	InvokeRepeating("UpdateTarget",0f,0.5f); //2 times a second
    }
	void UpdateTarget(){ //Search in range- find the closest target
		//Debug.Log("UpdateTarget running");
		//will check on a fixed basis - 2 times a second
		float bestDistance=9999.0f;
		Collider2D bestCollider = null;
		
		
		Collider2D[] ObjectsInRange = Physics2D.OverlapCircleAll(transform.position,range); //list of colliders of all objects within range of turret
		Debug.Log(ObjectsInRange.Length);
		
		if (ObjectsInRange.Length>=1){
			//Debug.Log("ObjectsInRange.Length>=1");
			foreach (Collider2D Object in ObjectsInRange){ //for each object in that list
				if (Object.tag==enemyTag){ //need to make sure object is actually an enemy  - use tag
					Debug.Log("Object in range");
					float distance = Vector3.Distance(transform.position, Object.transform.position);
					if (distance < bestDistance){ //calculate the object closest to the turret
						
						bestDistance = distance;
						bestCollider = Object;
					}
				}
			}
			if (bestCollider != null){
				Debug.Log("target changed");
			//update target to be enemy
				target= bestCollider.transform;
			}
		}
	}
    // Update is called once per frame
    void Update()
    {
	   cooldownTimer -= Time.deltaTime;
	   if (target!=null && cooldownTimer <=0){ //Fire1 is space, when hold down space and timer reaches 0
		   cooldownTimer=FireInterval;
		   Debug.Log("release laser");
		   Instantiate(laser,transform.position,transform.rotation); //creates copy of gameobject prefab at position with orientation
	   }
    }
	void OnDrawGizmosSelected(){ //draws range of turret
	    Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position,range);
	}
	
}
