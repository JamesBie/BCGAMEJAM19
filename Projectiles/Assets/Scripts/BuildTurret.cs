using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BuildTurret : MonoBehaviour
{
	/*
	Turrets are placed when we press r and click
	There has to be no other colliders	
	*/
	
	//bools to control building system
    private bool buildModeOn = false;
    private bool buildBlocked = false;
	
	//reference to the player object
    public GameObject playerObject; //This is player
	public GameObject ObjectToPlace; //This is the Game Object we want to place down
	
	//
	public int maxBuildDistance; //This is the maximum build distance away from the ship
	public int turretspacing; //radius of area around turrets where another object cannot be turret spacing has to be less than max build distance
	//array of colliders
	private Collider2D[] Overlaps;
	
	
    void Awake()
    {
		
    }
	
	private void Update()
    {
        //if R key pressed, toggle build mode
        if(Input.GetKeyDown("r"))
        {
			Debug.Log("build mode on");
            //flip bool
            buildModeOn = !buildModeOn;
		}
		if(buildModeOn && Input.GetMouseButtonDown(0)){
			//Debug.Log("mouse button down");
			//if build mode is on and player clicks mouse button, we test area for if we can place the block or not
            //First find out x and y coordinates of mouse
            float newPosX = Mathf.Round(Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
			float newPosY = Mathf.Round(Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
			Debug.Log("mouse position"+newPosX+newPosY);
			
			//newpos - we create a 2D vector to record the position
			Vector2 newPos = new Vector2(newPosX, newPosY);
			
			//basically we can't build turrets too close to any objects at all
			Overlaps=Physics2D.OverlapCircleAll(newPos,turretspacing,0,-1,1); //NEED TO DO: FIGURE OUT LAYER MASKS
			Debug.Log("playerpos"+playerObject.transform.position);
			Debug.Log("distance "+Math.Sqrt((newPosX-playerObject.transform.position.x)*(newPosX-playerObject.transform.position.x)+((newPosY-playerObject.transform.position.y)*(newPosY-playerObject.transform.position.y))) );
			
			//AND if the distance between the player object and the new position is less than maxBuildDistance
			if (Overlaps.Length<1 && Math.Sqrt((newPosX-playerObject.transform.position.x)*(newPosX-playerObject.transform.position.x)+((newPosY-playerObject.transform.position.y)*(newPosY-playerObject.transform.position.y)))  <= maxBuildDistance)
			{
				Instantiate(ObjectToPlace,newPos,playerObject.transform.rotation);
				Debug.Log("created at " + newPos);
			}				
        }
    }
}
