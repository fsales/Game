using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneController : MonoBehaviour {
	public GameObject[] objs;
	public float frequency;
	float lastTime;
	public GameObject objetoRelativo;
	public int espacamentoEntreObjetos = 20;

	// Use this for initialization
	void Start () {
		lastTime = Time.time;
	}


	GameObject ultimoObjeto = null;

	// Update is called once per frame
	void Update () {




		if (Time.time - lastTime > frequency) {
			lastTime = Time.time;

			int rnd = Random.Range(0, objs.Length);

			if (ultimoObjeto == null) {
				float fimTela = objetoRelativo.transform.position.x + 30;

				Vector3 pos = new Vector3 (Random.Range (fimTela - 10, fimTela), Random.Range (-6.0f, 6.0f), 1);

				GameObject obj = Instantiate(objs [rnd], pos, Quaternion.identity);


				ultimoObjeto = obj;
			} else {
				float fimTela = ultimoObjeto.transform.position.x + 30;

				Vector3 pos = new Vector3 (Random.Range (fimTela - 10, fimTela), espacamentoEntreObjetos, 1);

				GameObject obj = Instantiate(objs [rnd], pos, Quaternion.identity);


				ultimoObjeto = obj;
			}


			//Debug.LogWarning("CRIANDO O OBJETO: " + obj.name);
		}

	}
}
