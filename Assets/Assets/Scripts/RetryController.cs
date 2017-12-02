using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RetryController : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}

	public void jogarNovamente(){
		Debug.Log ("voltar");
		SceneManager.LoadScene(CockpitController.FASE1_SCENE);
	}
		
}
