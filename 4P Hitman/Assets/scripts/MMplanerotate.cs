using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MMplanerotate : MonoBehaviour {

    public float spinbot = 0.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        transform.Rotate(0, spinbot, 0, Space.World);

    }
}
