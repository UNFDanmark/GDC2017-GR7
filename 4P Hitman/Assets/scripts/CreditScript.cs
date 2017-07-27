using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("ReturnButton").GetComponent<Button>().onClick.AddListener(OnReturnClick);

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnReturnClick()
    {
        SceneManager.LoadScene("mainmenu", LoadSceneMode.Single);
    }
}
