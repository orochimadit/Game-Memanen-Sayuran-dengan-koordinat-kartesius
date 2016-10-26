using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SinSudut : MonoBehaviour {

	string sinsudut;
	Text text;

	void Start(){
		sinsudut = "Sin Sudut";
		text = GetComponent<Text> ();
		//xa = 0;
	}
	void Update(){

		text.text = sinsudut;

	}
	public void addPointsSinSudut(string pointsToAdd){

		sinsudut = pointsToAdd;
	}
}
