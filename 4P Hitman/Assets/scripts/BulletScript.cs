using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public Vector2 initialVelocity;
    public Rigidbody myRigidbody;
    public float lifeTime = 5;
    public GameObject mainPlane;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start()
    {
        myRigidbody.velocity = transform.forward * initialVelocity.x;

        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (mainPlane != other.gameObject && !other.name.StartsWith("Wing"))
        { 
            Destroy(gameObject);
        }
    }


}

