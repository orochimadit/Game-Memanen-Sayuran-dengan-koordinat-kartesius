using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class XPlayer : MonoBehaviour {

	string xplayer;
	Text text;

	void Start(){
		xplayer = "Posisi X Petani";
		text = GetComponent<Text> ();
		//xa = 0;
	}
	void Update(){

		text.text = xplayer;

	}
	public void addPointsXPlayer(string pointsToAdd){

		xplayer = pointsToAdd;
	}

}
