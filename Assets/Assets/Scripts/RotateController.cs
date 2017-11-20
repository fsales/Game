using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 0, -5);

//		Vector3 scala = transform.localScale;
//		scala.x = 1;
//		transform.localScale = scala;
//
//		Vector3 pos = transform.position;
//		pos.x -= 0.2f;
//
//		transform.position = pos;
	}
}
