using UnityEngine;
using System.Collections;

public class gamePlayScript : MonoBehaviour {
	void Start () {
	
	}
	void Update () {
        
            
	}
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Plane1"))
        {

        }
    }

}
