using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dest : MonoBehaviour
{
    //public GameObject movement;
    //public GameObject other;
    public void OnTriggerEnter2D(Collider2D cool)
    {
        Debug.Log("loustside");
        if (cool.tag == "rock")
        {
            Debug.Log("l");
            Destroy(cool.gameObject);
        }
    }
}
