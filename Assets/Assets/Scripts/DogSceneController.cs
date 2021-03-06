﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSceneController : MonoBehaviour {

	public GameObject[] objs;
	public float frequency;
	float lastTime;
	public GameObject objetoRelativo;

	// Use this for initialization
	void Start () {
		lastTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - lastTime > frequency) {
			lastTime = Time.time;

			int rnd = Random.Range(0, objs.Length);
			float fimTela = objetoRelativo.transform.position.x + 40;

			Vector3 pos = new Vector3(Random.Range(fimTela-10, fimTela), -5, 0);
			GameObject obj = Instantiate(objs [rnd], pos, Quaternion.identity);

			Debug.LogWarning("CRIANDO O OBJETO: " + obj.name);
		}
	}
}
