using UnityEngine;
using System.Collections;

public class TreeScript : MonoBehaviour {

	public AudioSource Audio;
	// Use this for initialization
	void Start () {
		Audio = GetComponent<AudioSource> ();
	}
	void OnCollisionEnter (Collision collision){
		if (collision.collider.CompareTag ("Player")) {
			if(!Audio.isPlaying){
				Audio.Play ();
			}
		}
}
}
