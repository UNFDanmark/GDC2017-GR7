using UnityEngine;
using System.Collections;

public class LydScript : MonoBehaviour {

	public AudioClip[] jump;
	public AudioClip walk;
	AudioSource Audio;
	public float Volume;

	// Use this for initialization
	void Start () {
		Audio = GetComponent<AudioSource>();
	
	}

	public void hopfunction(){
		Volume = 1.0f;
		Audio.volume = Volume;
		int lyd = Random.Range (0, jump.Length);
		Audio.clip = jump[lyd];
		Audio.Play ();
	}

	public void movementSound(){
		if (!Audio.isPlaying) {
			Volume = 0.2f;
			Audio.volume = Volume;
			Audio.clip = walk;
			Audio.Play ();
		}
	}
	// Update is called once per frame
	void Update () {
	  
	}
}
