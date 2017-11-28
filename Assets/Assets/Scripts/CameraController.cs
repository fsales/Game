using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LateUpdate(){
		Vector3 v = new Vector3 (transform.position.x, 0.0f, transform.position.z);
		transform.position = v;

		//Debug.Log (transform.position.y);
	}
}
