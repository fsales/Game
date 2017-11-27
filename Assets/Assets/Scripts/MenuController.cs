using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour {

    public string scenaNewGame;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NewGame() {
        SceneManager.LoadScene(sceneName: scenaNewGame);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
