using UnityEngine;
using System.Collections;

public class tree : MonoBehaviour {

	public AudioSource Audio;
	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter(Collision collision){
		if(collision.collider.CompareTag("Player")){
			Audio.Play();
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
