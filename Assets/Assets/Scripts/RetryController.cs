using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RetryController : MonoBehaviour {

	public Button botaoRetry;

	// Use this for initialization
	void Start () {
		botaoRetry.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick(){
		Debug.Log ("voltar");
		Application.LoadLevel(CockpitController.FASE1_SCENE);
	}
		
}
