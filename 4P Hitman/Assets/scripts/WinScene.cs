using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScene : MonoBehaviour {

    private float spinStart;
    private float spinRemaining = 0.85f;
    public GameObject scoreText1;
    public GameObject scoreText2;
    public GameObject scoreText3;
    public GameObject scoreText4;
    public Sprite[] winningScreens;

    // Use this for initialization
    void Start()
    {
        spinStart = Time.time;
        GameObject.Find("ReturnButton").GetComponent<Button>().onClick.AddListener(OnReturnClick);
        //scoreText1.SetActive(false);
        //scoreText2.SetActive(false);
        //scoreText3.SetActive(false);
        //scoreText4.SetActive(false);
        HandleScores();
    }

    void Awake()
    {
        spinRemaining = 0.85f;
    }

    // Update is called once per frame
    void Update()
    {
        SpinningPaper();
    }
    void OnReturnClick()
    {
        SceneManager.LoadScene("mainmenu", LoadSceneMode.Single);
    }


   public void SpinningPaper()
    {
        if (spinRemaining != 0)
        {
            float t = Math.Min(Time.deltaTime, spinRemaining);
            spinRemaining = Math.Max(0, spinRemaining - Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 200 * t);
            transform.Rotate(0, 0, -850 * t);

            if(spinRemaining == 0)
            {
                //scoreText1.SetActive(true);
                //scoreText2.SetActive(true);
                //scoreText3.SetActive(true);
                //scoreText4.SetActive(true);
            }
        }

    }

    public void HandleScores()
    {
        List<ScoreContext> list = PauseScreen.scores;
        list.Sort();

        scoreText1.GetComponent<Text>().text = PauseScreen.scores[0].score.ToString();
        scoreText1.GetComponent<Text>().color = PauseScreen.scores[0].color;

        scoreText2.GetComponent<Text>().text = PauseScreen.scores[1].score.ToString();
        scoreText2.GetComponent<Text>().color = PauseScreen.scores[1].color;

        scoreText3.GetComponent<Text>().text = PauseScreen.scores[2].score.ToString();
        scoreText3.GetComponent<Text>().color = PauseScreen.scores[2].color;

        scoreText4.GetComponent<Text>().text = PauseScreen.scores[3].score.ToString();
        scoreText4.GetComponent<Text>().color = PauseScreen.scores[3].color;

        GameObject.Find("Paper").GetComponent<SpriteRenderer>().sprite = winningScreens[PauseScreen.scores[0].id];
    }
}


