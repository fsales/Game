using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour {

	 
	public int forca = 10;
	public string sentidoForca = "U";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnCollisionEnter2D(Collision2D other){

		Vector2 sentido = Vector2.left;

		if (sentidoForca == "U") {
			sentido = Vector2.up;
		} else if (sentidoForca == "L") {
			sentido = Vector2.left;
		} else if (sentidoForca == "R") {
			sentido = Vector2.right;
		} else if (sentidoForca == "D") {
			sentido = Vector2.down;
		}
			



			if (other.gameObject.tag != "chao") {
				Vector2 x = sentido * forca;
				other.gameObject.GetComponent<Rigidbody2D> ().AddForce(x, ForceMode2D.Impulse);
				Debug.Log ("IMPULSO");
			}
			//Time.timeScale -= 0.1f;
			
	}
}
