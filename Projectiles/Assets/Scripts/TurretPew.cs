using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPew : MonoBehaviour
{
    public GameObject laser;
	public float FireInterval = 1f; //Time in between shoot
	public Transform target; //can make this private later on
	public float range = 5f; //range of the turret
	public string enemyTag;
	float cooldownTimer=0;
	bool EnemiesFound= false;
    // Start is called before the first frame update
    void Start()
    { 
	InvokeRepeating("UpdateTarget",0f,0.5f); //2 times a second
    }
	void UpdateTarget(){ //Search in range- find the closest target
		//will check on a fixed basis - 2 times a second
		Collider[] ObjectsInRange = Physics.OverlapSphere(transform.position,range);
		
		foreach (Collider ColliderOfObject in ObjectsInRange){
			Debug.Log("Object in range");
			GameObject CurrentObject= ColliderOfObject.GameObject;
		}			
	}
    // Update is called once per frame
    void Update()
    {
	   cooldownTimer -= Time.deltaTime;
	   if (EnemiesFound && cooldownTimer <=0){ //Fire1 is space, when hold down space and timer reaches 0
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
