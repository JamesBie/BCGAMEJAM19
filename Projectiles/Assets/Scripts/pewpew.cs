using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pewpew : MonoBehaviour
{
	public GameObject laser;
	public float fireInterval = 0.25f; //Time in between shoot
	float cooldownTimer = 0;
	
    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
	   cooldownTimer -= Time.deltaTime;
	   if (Input.GetButton("Fire1") && cooldownTimer <=0){ //Fire1 is space, when hold down space and timer reaches 0
		   cooldownTimer=fireInterval;
		   Debug.Log("release laser");
            FindObjectOfType<AudioManager>().Play("pshoot");
		   Instantiate(laser,transform.position,transform.rotation); //creates copy of gameobject prefab at position with orientation
	   }
    }
}
