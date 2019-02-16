using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_Controller : MonoBehaviour
{
    public float speed;
    float rand;
    private Transform target;
    float pos;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        rand = Random.Range(-3f, 3f);
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
