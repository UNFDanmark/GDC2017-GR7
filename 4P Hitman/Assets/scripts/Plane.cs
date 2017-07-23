using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour {
    public float moveSpeed = 40;
    public Rigidbody myRigidbody;
    public float rotationSpeed = 200;
    public GameObject bulletPrefab;
    public float timeOfLastShot = 0;
    public float reloadTime = 2;


    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start () {
        timeOfLastShot = -reloadTime;
    }
	
	// Update is called once per frame
	void Update () {

        //myRigidbody.rotation = transform.Rotate(Vector3.right * Time.deltaTime);

        transform.Rotate(0, rotationSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0);

        if ((Input.GetKeyDown(KeyCode.J)))
        {
            Shoot();
            print("Shoot");
        }
    }

    void FixedUpdate()
    {
        Move(moveSpeed);
    }

    public void Move(float speed)
    {
        myRigidbody.velocity = transform.forward * speed;
    }

    public void Shoot()
    {
        timeOfLastShot = Time.time;
        GameObject newBullet = Instantiate(bulletPrefab);

        newBullet.transform.position = transform.position;
        newBullet.transform.rotation = transform.rotation;
    } 
}
