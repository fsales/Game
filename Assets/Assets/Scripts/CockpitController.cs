using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CockpitController : MonoBehaviour {

	public Text titulo;
	public Text time;
	public Text resumo;
	public int  numeroFase;

	float timeDown = 0f;

	public Canvas menuRetry;

	private Dictionary<string, Dictionary<string, object>> main = null;
	Dictionary<string, object> faseEscolhida = null;

	public static bool FINALIZOU = false;
	public bool PASSOU = false;

	public static int FASE1_SCENE = 1; //"Scene1 - Bruno";
	public static int FASE2_SCENE = 2; //"Scene2 - Rafael";
	public static int FASE3_SCENE = 3; //"Scene3 - Fabio";
	public static int FASE4_SCENE = 4; //"Scene4 - Final";


	// Use this for initialization
	void Start () {
		Dictionary<string, object> fase1 = new Dictionary<string, object> ();
		fase1.Add ("titulo", "Fase 1 - Saindo de Casa"); 
		fase1.Add ("timeLimite", 30f); // Segundos
		fase1.Add ("timeUsuario", null);

		Dictionary<string, object> fase2 = new Dictionary<string, object> ();
		fase2.Add ("titulo", "Fase 2"); 
		fase2.Add ("timeLimite", 30f); // Segundos
		fase2.Add ("timeUsuario", null);

		Dictionary<string, object> fase3 = new Dictionary<string, object> ();
		fase3.Add ("titulo", "Fase 3"); 
		fase3.Add ("timeLimite", 30f); // Segundos
		fase3.Add ("timeUsuario", null);

		Dictionary<string, object> fase4 = new Dictionary<string, object> ();
		fase4.Add ("titulo", "Fase 4"); 
		fase4.Add ("timeLimite", 30f); // Segundos
		fase4.Add ("timeUsuario", null);

		main = new Dictionary<string, Dictionary<string, object>>();
		main.Add ("fase1", fase1);
		main.Add ("fase2", fase2);
		main.Add ("fase3", fase3);
		main.Add ("fase4", fase4);

		if (numeroFase > 0) {
			faseEscolhida = main["fase" + numeroFase];
		}

		if (faseEscolhida != null) {
			timeDown 	= (float)  faseEscolhida["timeLimite"];
			titulo.text = (string) faseEscolhida["titulo"];
		}

		FINALIZOU = false;
		PASSOU = false;
		hideRetry ();
	}
	
	// Update is called once per frame
	void Update () {
		if (faseEscolhida == null) {
			Debug.Log ("Informe o código da FASE no elemento CockPit");
			return;
		}

		if (PASSOU) {
			return;
		}

		if (FINALIZOU) {
			showRetry ();
			return;
		}

		timeDown -= Time.deltaTime;
		UpdateLevelTimer(timeDown );
	}


	private void hideRetry(){
		if (menuRetry.enabled) {
			menuRetry.enabled = false;
		}
	}

	private void showRetry(){
		if (!menuRetry.enabled) {
			menuRetry.enabled = true;
		}
	}

	public void UpdateLevelTimer(float totalSeconds){
		if (totalSeconds > 0) {
			int minutes = Mathf.FloorToInt (totalSeconds / 60f);
			int seconds = Mathf.RoundToInt (totalSeconds % 60f);

			//string formatedSeconds = seconds.ToString ();

			if (seconds == 60) {
				seconds = 0;
				minutes += 1;
			}
			time.text = minutes.ToString ("00") + ":" + seconds.ToString ("00");
		} else {
			time.text = "00:00";
			FINALIZOU = true;
		}
	}


	public void registrarFimFase(){
		//int fase = numeroFase;

		// TODO
		// REGISTRAR O TEMPO
		PASSOU = true;


	}

	public void trocarFase(){
		int fase = numeroFase + 1;

		if (fase == 2) {
			Application.LoadLevel (FASE2_SCENE);
		} else if (fase == 3) {
			Application.LoadLevel(FASE3_SCENE);
		} else if (fase == 4) {
			Application.LoadLevel(FASE4_SCENE);
		}  else {
			Application.LoadLevel(FASE1_SCENE);
		}

	}

}
