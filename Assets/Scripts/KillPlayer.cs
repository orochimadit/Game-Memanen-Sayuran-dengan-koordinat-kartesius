﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class KillPlayer : MonoBehaviour {
	public LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();

	}
	
	// Update is called once per frame
	void Update () {
		

	}
	void OnTriggerEnter2D(Collider2D other){
		//jika player dengan spikes bisa tabrakan berarti is trigger centang jika pleyer diatas spikes maka is trigger tidak centang
		if(other.name=="Player"){
			levelManager.RespawnPlayer ();

		}


	}
}
