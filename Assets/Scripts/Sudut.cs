using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Sudut : MonoBehaviour {

	string sudut;
	Text text;

	void Start(){
		sudut = "0";
		text = GetComponent<Text> ();
		//xa = 0;
	}
	void Update(){

		text.text = sudut;

	}
	public void addPointsSudut(string pointsToAdd){

		sudut = pointsToAdd;
	}
}
