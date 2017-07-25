using UnityEngine;
using UnityEngine.Audio;
using System.Collections;


public class Lydscript : MonoBehaviour {

	public AudioClip[] jump;
	public AudioClip Walk;
	public AudioSource Audio;
	public float volume;

	public float minWalkingPitch = 0.8f;
	public float maxWalkingPitch = 1.2f;

	// Use this for initialization
	void Start () {
	
	}

	public void JumpSound (){
		volume = 1.0f;
		int lyd = Random.Range (0, jump.Length);
		Audio.volume = volume;
		Audio.clip = jump[lyd];
		Audio.Play ();
	}

	public void WalkSound(){
		if (!Audio.isPlaying) {
			volume = 0.2f;
			Audio.volume = volume;
			Audio.pitch = Random.Range (minWalkingPitch, maxWalkingPitch);
			Audio.clip = Walk;
			Audio.Play ();
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
