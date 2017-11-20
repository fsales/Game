using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Animator anim;
	float escalaRunning = 0.2f;
	float escalaJumping = 0.5f;
	float plano = -2.5f;
	float maxEscalaJumping = 2f;
	bool  cair = false;


	bool debugStates = false;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {

		//Debug.Log (transform.position.y);

		if (playerCanJump()){
			playerStateStopped ();
		}


		// Esquerda
		if (Input.GetKey(KeyCode.LeftArrow)){
			Vector3 scala = transform.localScale;
			scala.x = -1;
			transform.localScale = scala;

			Vector3 pos = transform.position;
			pos.x -= escalaRunning;

			transform.position = pos;

			playerStateRunning ();
		}

		// Direita
		if (Input.GetKey(KeyCode.RightArrow)){
			Vector3 scala = transform.localScale;
			scala.x = 1;
			transform.localScale = scala;

			Vector3 pos = transform.position;
			pos.x += escalaRunning;

			transform.position = pos;

			playerStateRunning ();
		}


		// Pulando
		if (Input.GetKey(KeyCode.Space)){

			if ( (playerCanJump() || playerJumping()) && !cair) {

				Vector3 pos = transform.position;

				Debug.Log (pos.y);

				if (pos.y <= maxEscalaJumping) {
					pos.y += escalaJumping;
					transform.position = pos;

					playerStateJumping ();
				} else {
					cair = true;
				}


			}


		}



		if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)){
			playerStateStopped ();
		}

		// Soltar a barra de espaco
		if (Input.GetKeyUp (KeyCode.Space)) {
			cair = true;
		}


	}



	void OnCollisionEnter(Collision col){
		if (col != null) {
			Debug.Log (col.gameObject.tag);
		} else {
			Debug.Log ("vazioooo");
		}
	}

	bool playerCanJump(){
		

		bool pode = (transform.position.y < plano);

		// Identificar se esta encima de um objeto

		if (pode) {
			cair = false;
		}

		return pode;

	}

	bool playerJumping(){
		return anim.GetBool ("jumping");
	}

	void playerStateRunning(){

		if (!anim.GetBool ("jumping") || playerCanJump()) {
			if(debugStates){
				Debug.Log ("Correndo...");
			}
			anim.SetBool ("stopped", false);
			anim.SetBool ("running", true);
			anim.SetBool ("jumping", false);
		}
	}

	void playerStateStopped(){
		if (debugStates) {
			Debug.Log ("Parado...");
		}
		anim.SetBool ("stopped", true);
		anim.SetBool ("running", false);
		anim.SetBool ("jumping", false);

	}
		


	void playerStateJumping(){

		if (!anim.GetBool ("jumping")) {
			if (debugStates) {
				Debug.Log ("Pulando...");
			}
			anim.SetBool("stopped", false);
			anim.SetBool("running", false);
			anim.SetBool("jumping", true);
		}
	}
}
