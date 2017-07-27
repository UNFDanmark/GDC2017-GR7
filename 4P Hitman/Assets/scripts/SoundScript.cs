using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundScript : MonoBehaviour {

    public AudioClip[] Taunts;
    public AudioSource Audio;
    public float tid = 0;
    public int Tauntdelay = 5;
    public AudioSource Audio2;

    public void TauntsFunction(int Lyd)
    {
        if (Time.time > tid)
        {
            Audio.clip = Taunts[Lyd];
            Audio.Play();
            tid = Time.time + Tauntdelay;
        }
        

    }

    public void ExplosionFunction()
    {
        if (!Audio2.isPlaying)
        {
            Audio2.Play();
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
