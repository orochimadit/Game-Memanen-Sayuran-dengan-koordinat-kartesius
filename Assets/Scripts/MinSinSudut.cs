using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MinSinSudut : MonoBehaviour {

	 string  minsudut;
	Text text;

	void Start(){
		minsudut = "- Sin Sudut";
		text = GetComponent<Text> ();
		//xa = 0;
	}
	void Update(){

		text.text = minsudut;

	}
	public void addPointsMinSudut(string pointsToAdd){

		minsudut = pointsToAdd;
	}
}
