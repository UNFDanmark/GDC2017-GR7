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

    public void TauntsFunction(int Lyd)
    {
        if (Time.time > tid)
        {
            Audio.clip = Taunts[Lyd];
            Audio.Play();
            tid = Time.time + Tauntdelay;
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
