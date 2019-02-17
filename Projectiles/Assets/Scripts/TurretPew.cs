using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPew : MonoBehaviour
{
	/*
	Turret automatically detects asteroid every 0.5f
	It finds the closest asteroid and makes it its target
	It rotates towards the target and shoots a laser
	*/
    public GameObject laser;
	public float FireInterval = 0.5f; //Time in between shoot
	public Collider2D target; //can make this private later on
	public float range = 5.0f; //range of the turret
	public string enemyTag;   // in unity change this tag to Astroid
	
	
	float cooldownTimer=0;
	Rigidbody2D rb;
	
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
		//Debug.Log(ObjectsInRange.Length);
		
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
				//Debug.Log("target changed");
			//update target to be enemy
				target= bestCollider;
			}
			else {
				target= null;
			}
		}
	}
    // Update is called once per frame
    void Update()
    {
	    cooldownTimer -= Time.deltaTime;
		if (target!=null && cooldownTimer <=0){ //When there exists a target and the cooldownTimer as reached 0, turret rotates and shoots laser
		   
			//Debug.Log("release laser");
			Vector2 prediction= 2*target.attachedRigidbody.velocity; //find current linear velocity of target	
			
			Vector3 direction= target.transform.position- transform.position; //Records the vector between turret and target
			//Add prediction to vector
			direction=new Vector3(direction.x+prediction.x,direction.y+prediction.y,0.0f);
			float angle = Mathf.Atan2(-direction.x,direction.y) * Mathf.Rad2Deg; //use tangent to find angle subtended by (x,y)
			transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));//Turn this into an angle rotation in z axis
            FindObjectOfType<AudioManager>().Play("tshoot");
			Instantiate(laser,transform.position,transform.rotation); //creates copy of gameobject prefab at position with orientation
			cooldownTimer=FireInterval; //reset cooldown timer
	    }
	   
    }
	void OnDrawGizmosSelected(){ //draws range of turret
	    Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position,range);
	}
	
}
