using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	public float speed;  
	/*public float angularVelocity;
	public float maxAngularVelocity;*/
	public float max_speed = 3.5f;
    public float rot_speed = 180f;


	private Rigidbody2D rb2d;
	SpriteRenderer m_SpriteRenderer;
	public Sprite m_Sprite;
	private Sprite original_Sprite;
    // Start is called before the first frame update
    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();
        m_SpriteRenderer = GetComponent <SpriteRenderer>();
        original_Sprite = m_SpriteRenderer.sprite;
    }

	void FixedUpdate() { //just before performing any physics calulations
		/*float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb2d.AddForce(movement * max_speed);
		*/
		
		if (Input.GetKey (KeyCode.W) || Input.GetKey("up")){
    		m_SpriteRenderer.sprite =m_Sprite;
			Debug.Log("inputkey up");
    	}else if(m_SpriteRenderer.sprite == m_Sprite){
    		m_SpriteRenderer.sprite = original_Sprite;
    	}
		/*
		Quaternion rot = transform.rotation;
		float z= rot.eulerAngles.z;
		z -= Input.GetAxis("Horizontal") * rot_speed * Time.deltaTime;
		rot = Quaternion.Euler(0,0,z);
		transform.rotation = rot;
		Vector3 pos = transform.position;
		Vector3 velocity= new Vector3(0, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);
		pos+= rot*velocity;
		transform.position=pos;
		*/
		//using forces
		float rotate=Input.GetAxis("Horizontal");  //gets left right from arrow keys
		float moveVertical=Input.GetAxis("Vertical");  // gets up down from arrow keys
		
		Vector2 movement = new Vector2(0,moveVertical); //movement is a vector made of 3 floats for x,y,z
		rb2d.AddRelativeForce(movement * speed *Time.deltaTime,ForceMode2D.Impulse);  //adds a force to the ball
		
		if (rb2d.angularVelocity < 35.0&&rb2d.angularVelocity>-35.0){
			rb2d.AddTorque(rotate*-1);
		}
		
    }
	/*void OnTriggerEnter2D(Collider2D other) //other is the other collider that we touch
	{
		if (other.gameObject.CompareTag("Rock")){ //Tag is defined in Unity
			Destroy(other.gameObject);
		}
    }*/
}
