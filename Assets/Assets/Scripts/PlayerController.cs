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

	bool debugStates = true;

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
		if (Input.GetKey (KeyCode.LeftArrow)) {
			Vector3 scala = transform.localScale;
			scala.x = -1;
			transform.localScale = scala;

			Vector3 pos = transform.position;
			pos.x -= escalaRunning;

			transform.position = pos;

			playerStateRunning ();

		}

		// Direita
		if (Input.GetKey (KeyCode.RightArrow)) {
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

				//Debug.Log (pos.y);

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

	bool playerCanJump(){
		bool andandoOuPulando = anim.GetBool ("stopped") || anim.GetBool ("running");

		// Identificar se esta encima de um objeto
		if (andandoOuPulando) {
			cair = false;
		}


		//Debug.Log (cair);

		return andandoOuPulando;
	}

	bool chegouAoSolo(){
		if (transform.position.y < plano) {
			Debug.Log ("Solo");
		} else {
			Debug.Log ("Ar");
		}	
		
		return (transform.position.y < plano);
	}

	bool playerJumping(){
		return anim.GetBool ("jumping");
	}

	void playerStateRunning(){
		chegouAoSolo ();



		if (chegouAoSolo() || !anim.GetBool ("jumping")) {
			if(debugStates){
				Debug.Log ("Correndo...");
			}
			anim.SetBool ("stopped", false);
			anim.SetBool ("running", true);
			anim.SetBool ("jumping", false);

			cair = false;
		}
	}

	void playerStateStopped(){
		if (debugStates) {
			Debug.Log ("Parado...");
		}
		anim.SetBool ("stopped", true);
		anim.SetBool ("running", false);
		anim.SetBool ("jumping", false);

		cair = false;
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

	void OnTriggerEnter2D(Collider2D other) {
		Debug.LogWarning("COLISAO FINAL FASE");
		anim.SetBool ("happy", true);
	}
}
