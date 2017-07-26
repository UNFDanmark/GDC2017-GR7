using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    public bool alive = true;
    public bool deathSpin = false;
    public KeyCode left;
    public KeyCode right;
    public KeyCode shoot;
    public int famePoints = 0;
    public float timeOfDeath = 0;
    public Vector3 startPosition;
    public Quaternion startRotation;
    public GameObject targetPlane;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start()
    {
        timeOfLastShot = -reloadTime;
        startPosition = transform.position;
        startRotation = transform.rotation;

        RandomTarget();
    }

    // Update is called once per frame
    void Update()
    {
        KeyboardInput();

        transform.Rotate(0, rotationSpeed * turn * Time.deltaTime, 0, Space.World);
        
        if (Input.GetKeyDown(shoot) && alive)
        {
            Shoot();
        }

        InfiniteMap();
    }

    void FixedUpdate()
    {
        RotateZ();
        Move(alive ? moveSpeed : moveSpeed * 2);

        if (deathSpin)
        {
            transform.Rotate(0, 0, 5);
        }

        CheckRespawn();
    }

    public void Move(float speed)
    {
        if (alive)
        {
            transform.position = new Vector3(transform.position.x, 3000, transform.position.z);
        } else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y-1, transform.position.z);
        }
        print(transform.forward);
        myRigidbody.velocity = transform.forward * speed;
    }


    public void Shoot()
    {
        timeOfLastShot = Time.time;
        GameObject newBullet = Instantiate(bulletPrefab);

        newBullet.transform.position = transform.position;
        newBullet.transform.rotation = transform.rotation;

        newBullet.GetComponent<BulletScript>().mainPlane = gameObject;
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
            transform.Rotate(0, 0, 3);
            rotate = rotate - 3;
        }
        else if (rotate >= -maxRotate && rotate < 0 && (turn == 0 || turn == 1))
        {
            transform.Rotate(0, 0, -3);
            rotate = rotate + 3;
        }
    }

    public void KeyboardInput()
    {
        if (alive)
        {
            if (Input.GetKey(left))
            {
                turn = -1;
            }
            else if (Input.GetKey(right))
            {
                turn = 1;
            }
            else
            {
                turn = 0;
            }
        }

    }

    public void InfiniteMap()
    {
        if(alive) {
            if (transform.position.x > endOfMap || transform.position.x < -endOfMap)
            {
                transform.position = new Vector3(-(transform.position.x * 0.95f), 3000, transform.position.z);
            }

            if (transform.position.z > endOfMap || transform.position.z < -endOfMap)
            {
                transform.position = new Vector3(transform.position.x, 3000, -(transform.position.z * 0.95f));
            }
        }
    }

    public void Death()
    {
        print("dead");
        alive = false;
        turn = 0;
        transform.Rotate(50, 0, 0);
        deathSpin = true;
        timeOfDeath = Time.realtimeSinceStartup;
    }

    public void CheckRespawn()
    {
        if (!alive && Time.realtimeSinceStartup - timeOfDeath > 4)
        {
            alive = true;
            deathSpin = false;
            transform.rotation = startRotation;
            transform.position = startPosition;
        }
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.StartsWith("Bullet")
            && other.gameObject.GetComponent<BulletScript>().mainPlane != this.gameObject)
        {
            Destroy(other.gameObject);
            if (alive)
            {
                Death();
            }
        } else if (other.gameObject.name.StartsWith("Plane"))
        {
            Death();
        }
         
    }

    public void RandomTarget()
    {
        int index = 0;

        GameObject[] others = new GameObject[3];
        
        foreach( GameObject obj in GameObject.FindGameObjectsWithTag("Plane"))
        {
            if (obj != this.gameObject)
            {
                others[index] = obj;
                index++;
            }
        }

        targetPlane = others[UnityEngine.Random.Range(0, 3)];
    }
}
