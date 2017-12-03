using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour {

	float escalaRunning = 0.1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 pos = transform.position;
		pos.x -= escalaRunning;

		transform.position = pos;
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Start") {
			Destroy (gameObject);
		}
	}
}
