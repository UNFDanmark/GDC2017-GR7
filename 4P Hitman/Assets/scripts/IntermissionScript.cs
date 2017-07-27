using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntermissionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("ReturnButton").GetComponent<Button>().onClick.AddListener(OnReturnClick);
        GameObject.Find("2MinButton").GetComponent<Button>().onClick.AddListener(On2MinClick);
        GameObject.Find("InfiniteButton").GetComponent<Button>().onClick.AddListener(OnInfiniteClick);

    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnReturnClick()
    {
        SceneManager.LoadScene("mainmenu", LoadSceneMode.Single);
    }
    void On2MinClick()
    {
        SceneManager.LoadScene("scene", LoadSceneMode.Single);
        GameController.maplength = GameController.MODE_2MIN;
    }
    void OnInfiniteClick()
    {
        SceneManager.LoadScene("scene", LoadSceneMode.Single);
        GameController.maplength = GameController.MODE_INFINITE;
    }
}
