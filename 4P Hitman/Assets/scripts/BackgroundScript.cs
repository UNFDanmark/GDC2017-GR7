using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BackgroundScript : MonoBehaviour {

    public int backgroundSpeed = 5;
    public int backgroundTravel = 2006;
    public int backgroundCounter = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    }

    void FixedUpdate()
    {
        if (backgroundCounter > backgroundTravel)
        {
            backgroundCounter = 0;
            transform.position = new Vector3(-1003, transform.position.y, transform.position.z);
        } else
        {
            backgroundCounter = backgroundCounter + backgroundSpeed;
            transform.position = new Vector3(transform.position.x + backgroundSpeed, transform.position.y, transform.position.z);
        }
        

    } 
}
