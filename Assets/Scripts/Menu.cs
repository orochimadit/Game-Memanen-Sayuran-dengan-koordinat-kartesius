﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//SceneManager.LoadScene ("game", LoadSceneMode.Additive);

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)){
			Application.LoadLevel("game");
		}

	}
}
