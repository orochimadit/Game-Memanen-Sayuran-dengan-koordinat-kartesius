using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Cos1Sudut : MonoBehaviour {

	string cossudut;
	Text text;

	void Start(){
		cossudut = "Cos Sudut";
		text = GetComponent<Text> ();
		//xa = 0;
	}
	void Update(){

		text.text = cossudut;

	}
	public void addPointsCosSudut(string pointsToAdd){

		cossudut = pointsToAdd;
	}
}
