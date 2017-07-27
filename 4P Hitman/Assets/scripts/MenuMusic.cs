using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        if (GameObject.FindObjectsOfType<MenuMusic>().Length > 1)
        {
            Destroy(gameObject);
        }

        SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
    }

    private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
    {
        if(SceneManager.GetActiveScene().name == "scene")
        {
            Destroy(gameObject);
        }
    }
}
