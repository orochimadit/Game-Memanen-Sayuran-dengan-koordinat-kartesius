using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class YPlayer : MonoBehaviour {

	string yplayer;
	Text text;

	void Start(){
		yplayer = "Posisi Y Petani";
		text = GetComponent<Text> ();
		//xa = 0;
	}
	void Update(){

		text.text = yplayer;

	}
	public void addPointsYPlayer(string pointsToAdd){

		yplayer = pointsToAdd;
	}
}
