using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MMplanerotate : MonoBehaviour {

    public float spinbot = 0.5f;

    // Use this for initialization
    void Start () {


        GameObject.Find("ExitButton").GetComponent<Button>().onClick.AddListener(OnExitClick);
        GameObject.Find("CreditsButton").GetComponent<Button>().onClick.AddListener(OnCreditsClick);
        GameObject.Find("FFAButton").GetComponent<Button>().onClick.AddListener(OnFFAClick);
        GameObject.Find("TargetsButton").GetComponent<Button>().onClick.AddListener(OnTargetsClick);
        FixedUpdate();
    }

    // Update is called once per frame
    void Update () {

    }

    void FixedUpdate()
    {
        transform.Rotate(0, spinbot, 0, Space.World);
    }

    void OnExitClick()
    {
        Application.Quit();
    }

    void OnCreditsClick()
    {
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }
    void OnFFAClick()
    {
        SceneManager.LoadScene("Intermission", LoadSceneMode.Single);
        GameController.gamemode = GameController.MODE_FREE_FOR_ALL;
    }
    void OnTargetsClick()
    {
        SceneManager.LoadScene("Intermission", LoadSceneMode.Single);
        GameController.gamemode = GameController.MODE_TARGETS;
    }
}
