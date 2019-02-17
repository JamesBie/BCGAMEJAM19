using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_Controller : MonoBehaviour
{
    float randX;
    float randY;
    private Rigidbody2D rb;
	float timer=10f;
    void Start()
    {
        randX = Random.Range(-0.1f, 0.1f);
        randY = Random.Range(0, 0.15f);
        rb = GetComponent< Rigidbody2D > ();
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = rb.position;
        rb.velocity = new Vector2(randX, randY);
        pos += rb.velocity;
        rb.position = pos;
		timer-=Time.deltaTime;
		if (timer<=0){
			Destroy(gameObject);
		}
		
    }
}
