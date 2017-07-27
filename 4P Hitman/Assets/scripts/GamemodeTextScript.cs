using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GamemodeTextScript : MonoBehaviour {
    // Use this for initialization
    void Start () {
        if (GameController.gamemode == GameController.MODE_TARGETS)
        {
            gameObject.GetComponent<Text>().text = ("Targets");
            
        }
        else
        {
            gameObject.GetComponent<Text>().text = ("Free For All");
        }
    }
}
