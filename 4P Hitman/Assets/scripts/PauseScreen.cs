using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour {

    public GameObject continueButton;
    public GameObject endButton;
    public bool pause = false;
    public float countdown = 120;
    public GameObject scoreUIText;
    private float timeRemaining = 120;
    public static List<ScoreContext> scores = new List<ScoreContext>();

    // Use this for initialization
    void Start () {
        GameObject timeText = GameObject.Find("Time");
        continueButton = GameObject.Find("Continue");
        endButton = GameObject.Find("EndRoundButton");
        GameObject.Find("Continue").GetComponent<Button>().onClick.AddListener(OnContinueClick);
        GameObject.Find("EndRoundButton").GetComponent<Button>().onClick.AddListener(OnEndRoundClick);

        if (GameController.maplength == GameController.MODE_2MIN)
        {
            timeText.SetActive(true);
        } else {
            timeText.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (GameController.maplength == GameController.MODE_2MIN)
        {
        timeRemaining -= Time.deltaTime;
        }


        if (Input.GetKeyDown(KeyCode.Escape) && pause == false)
        {
            pause = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pause == true)
        {
            pause = false;
        }

        endButton.SetActive(pause);
        continueButton.SetActive(pause);
        Time.timeScale = pause ? 0 : 1;

        if (timeRemaining < 0)
        {
            OnEndRoundClick();
        }
        countdown = (int)timeRemaining;
        scoreUIText.GetComponent<Text>().text = countdown.ToString();
    }

    void OnContinueClick()
    {
        pause = false;
    }
    void OnEndRoundClick()
    {
        scores = new List<ScoreContext>();
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Plane"))
        {
            Plane1 plane = obj.GetComponent<Plane1>();
            scores.Add(new ScoreContext(plane.id, plane.famePoints, plane.color));
        }

        SceneManager.LoadScene("RoundOver", LoadSceneMode.Single);
        pause = false;
    }
}
