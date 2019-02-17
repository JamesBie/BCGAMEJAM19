using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn_X_Axis : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    float randX, randY;
    Vector3 whereToSpawn;
    public float spawnRate = 1f;
    float nextSpawn = 0.0f;
	public Camera cam;
	

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(0, 2.0f);
			randY = Random.Range(0, 2);
            whereToSpawn = cam.ViewportToWorldPoint(new Vector3(randX, randY, cam.nearClipPlane));
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
			spawnRate -= 0.001f;
			if (spawnRate < 0.1){
				spawnRate = 0.1f;
			}
		}
    }
}
