﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane1 : MonoBehaviour
{
    public float moveSpeed = 40;
    public Rigidbody myRigidbody;
    public float rotationSpeed = 200;
    public GameObject bulletPrefab;
    public float timeOfLastShot = 0;
    public float reloadTime = 2;
    public int turn = 0;
    public int rotate = 0;
    public int maxRotate = 30;
    public int endOfMap = 122;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start()
    {
        timeOfLastShot = -reloadTime;
    }

    // Update is called once per frame
    void Update()
    {
        KeyboardInput();

        transform.Rotate(0, rotationSpeed * turn * Time.deltaTime, 0, Space.World);

        if (Input.GetKeyDown(KeyCode.S))
        {
            Shoot();
        }

        InfiniteMap();
    }

    void FixedUpdate()
    {
        RotateZ();
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

    public void RotateZ()
    {
        if (rotate < maxRotate && rotate > -maxRotate && (turn == -1 || turn == 1))
        {
            transform.Rotate(0, 0, -turn);
            rotate = rotate + turn;
        }
        else if (rotate <= maxRotate && rotate > 0 && (turn == 0 || turn == -1))
        {
            transform.Rotate(0, 0, 1);
            rotate = rotate - 1;
        }
        else if (rotate >= -maxRotate && rotate < 0 && (turn == 0 || turn == 1))
        {
            transform.Rotate(0, 0, -1);
            rotate = rotate + 1;
        }
    }

    public void KeyboardInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            turn = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            turn = 1;
        }
        else
        {
            turn = 0;
        }
    }

    public void InfiniteMap()
    {
        if (GameObject.Find("Plane1").transform.position.x > endOfMap || GameObject.Find("Plane1").transform.position.x < -endOfMap)
        {
            transform.position = new Vector3(-GameObject.Find("Plane1").transform.position.x, 3000, GameObject.Find("Plane1").transform.position.z);
        }

        if (GameObject.Find("Plane1").transform.position.z > endOfMap || GameObject.Find("Plane1").transform.position.z < -endOfMap)
        {
            transform.position = new Vector3(GameObject.Find("Plane1").transform.position.x, 3000, -GameObject.Find("Plane1").transform.position.z);
        }
    }
    
}