using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    public GameObject player; //This is the game object that is the player sphere
	private Vector3 offset; //offset between camera and game object
    // Start is called before the first frame update
    void Start()
    {
        offset= transform.position - player.transform.position; //offset= distance between initial camera + initial player
    }

    // LateUpdate is better for gethering last known states, follow cameras, procedural animation
	//LateUpdate runs every frame, but always runs after update
    void LateUpdate()
    {
        transform.position= player.transform.position + offset; //The camera position is always player position + offset
    }
}
