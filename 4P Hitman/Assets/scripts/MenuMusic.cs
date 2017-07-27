using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Destroy(gameObject);
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        if (GameObject.FindObjectsOfType<MenuMusic>().Length > 1)
        {
            Destroy(gameObject);
        }
    }
}
