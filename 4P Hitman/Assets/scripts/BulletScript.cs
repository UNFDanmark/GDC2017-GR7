using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public Vector2 initialVelocity;
    public Rigidbody myRigidbody;
    public float lifeTime = 5;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start()
    {
        myRigidbody.velocity = transform.forward * initialVelocity.x + transform.up * initialVelocity.y;

        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

