using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Plane1 : MonoBehaviour
{
    public int id;

    public float moveSpeed = 40;
    public Rigidbody myRigidbody;
    public float rotationSpeed = 200;
    public GameObject bulletPrefab;
    public float timeOfLastShot = 0;
    public float reloadTime = 0.1f;
    public int burstAmount = 0;
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
    public float trailTime = 1;
    public float timeOfDeath = 0;
    public float respawnProtection = 0.5f;
    public GameObject scoreUIText;
    public Vector3 startPosition;
    public Quaternion startRotation;
    public GameObject targetPlane = null;
    public List<GameObject> planesTargettingMe = new List<GameObject>();
    public Color color;
    public TrailRenderer trailColor;
    public SoundScript soundScript;
    public GameObject soundManager;


    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start()

    {
        soundScript = soundManager.GetComponent<SoundScript>();
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
        
        if (Input.GetKeyDown(shoot) && alive && (Time.time - timeOfLastShot) >= reloadTime)
        {
            Shoot();
        }

        if (alive)
        {
            this.gameObject.GetComponent<TrailRenderer>().time = trailTime;
            respawnProtection -= Time.deltaTime;
        }





        InfiniteMap();


        if (GameController.gamemode == GameController.MODE_TARGETS && planesTargettingMe.Count == 0)
        {
            trailColor.time = 0;
        } else if(GameController.gamemode == GameController.MODE_TARGETS)
        {
            /*
            float sumR = 0;
            float sumG = 0;
            float sumB = 0;

            foreach (GameObject obj in planesTargettingMe) {
                Plane1 otherPlane = obj.GetComponent<Plane1>();
                sumR += otherPlane.color.r;
                sumG += otherPlane.color.g;
                sumB += otherPlane.color.b;
            }

            Color newColor = new Color(sumR / planesTargettingMe.Count, sumG / planesTargettingMe.Count, sumB / planesTargettingMe.Count);
            trailColor.material.color = newColor;*/

            int colorPick = ((int) (Time.time * 2)) % planesTargettingMe.Count;
            trailColor.material.color = planesTargettingMe[colorPick].GetComponent<Plane1>().color;
        }
        UpdateTargetingMe();
        CheckRespawn();

    }

    void FixedUpdate()
    {
        RotateZ();
        Move(alive ? moveSpeed : moveSpeed * 2);

        if (deathSpin)
        {
            transform.Rotate(0, 0, 5);
        }

        scoreUIText.GetComponent<Text>().text = famePoints.ToString();

        if (alive && GameController.gamemode == GameController.MODE_TARGETS && targetPlane == null)
        {
            RandomTarget();
        }

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
        myRigidbody.velocity = transform.forward * speed;
    }


    public void Shoot()
    {

        GameObject newBullet = Instantiate(bulletPrefab);

        newBullet.transform.position = transform.position;
        newBullet.transform.rotation = transform.rotation;

        newBullet.GetComponent<BulletScript>().mainPlane = gameObject;

        timeOfLastShot = Time.time;
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
                this.gameObject.GetComponent<TrailRenderer>().time = 0;
            }

            if (transform.position.z > endOfMap || transform.position.z < -endOfMap)
            {
                transform.position = new Vector3(transform.position.x, 3000, -(transform.position.z * 0.95f));
                this.gameObject.GetComponent<TrailRenderer>().time = 0;
            }
        }
    }

    public void Death()
    {
        alive = false;
        turn = 0;
        transform.Rotate(50, 0, 0);
        deathSpin = true;
        timeOfDeath = Time.realtimeSinceStartup;
    }

    public void CheckRespawn()
    {
        if (!alive && Time.realtimeSinceStartup - timeOfDeath > 2)
        {
            alive = true;
            deathSpin = false;
            transform.rotation = startRotation;
            transform.position = startPosition;
            respawnProtection = 0.8f;
        } else if (!alive && Time.realtimeSinceStartup - timeOfDeath > 1.5f)
        {
            this.gameObject.GetComponent<TrailRenderer>().time = 0;
        }   
    }


    void OnTriggerEnter(Collider other)
    {   
        if (respawnProtection >= 0)
        { 
            return;
        }

        if (other.gameObject.name.StartsWith("Bullet")
            && other.gameObject.GetComponent<BulletScript>().mainPlane != this.gameObject)
        {
            Plane1 script = other.gameObject.GetComponent<BulletScript>().mainPlane.GetComponent<Plane1>();
            print(script.targetPlane.name + gameObject.name);
            if (GameController.gamemode == GameController.MODE_TARGETS &&
                script.targetPlane != gameObject)
            {
                return;
            }
            
            script.famePoints += 100;
            Destroy(other.gameObject);
            soundScript.TauntsFunction(script.id);

            if (alive)
            {
                Death();
                RandomTarget();
                script.RandomTarget();
            }
        } else if (other.gameObject.name.StartsWith("Plane"))
        {
            Death();
            famePoints -= 25;
            soundScript.ExplosionFunction();
        }
         
    }

    public List<GameObject> GetOtherPlanes()
    {
        List<GameObject> others = new List<GameObject>();

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Plane"))
        {
            if (obj != this.gameObject)
            {
                others.Add(obj);
            }
        }

        return others;
    }

    public void RandomTarget()
    {
        targetPlane = GetOtherPlanes()[UnityEngine.Random.Range(0, 3)];

        planesTargettingMe = new List<GameObject>();
        foreach (GameObject obj in GetOtherPlanes())
        {
            obj.GetComponent<Plane1>().UpdateTargetingMe();
        }
    }

    public void UpdateTargetingMe()
    {
        planesTargettingMe = new List<GameObject>();
        foreach (GameObject obj in GetOtherPlanes())
        {
            Plane1 script = obj.GetComponent<Plane1>();
            if (script.targetPlane == gameObject)
            {
                planesTargettingMe.Add(obj.gameObject);
            }
        }
        
    }

}
