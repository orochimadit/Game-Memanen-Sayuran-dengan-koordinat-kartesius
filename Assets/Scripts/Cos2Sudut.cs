using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Cos2Sudut : MonoBehaviour {
	string cosduasudut;
	Text text;

	void Start(){
		cosduasudut = "Cos Sudut";
		text = GetComponent<Text> ();
		//xa = 0;
	}
	void Update(){

		text.text = cosduasudut;

	}
	public void addPointsCosduaSudut(string pointsToAdd){

		cosduasudut = pointsToAdd;
	}
}
