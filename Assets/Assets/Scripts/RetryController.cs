using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RetryController : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}

	public void jogarNovamente(){
		Debug.Log ("voltar");
		Application.LoadLevel(CockpitController.FASE1_SCENE);
	}
		
}
