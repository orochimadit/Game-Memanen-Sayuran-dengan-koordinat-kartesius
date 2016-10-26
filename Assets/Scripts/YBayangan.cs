using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class YBayangan : MonoBehaviour {

	string ybayangan;
	Text text;

	void Start(){
		ybayangan = "0";
		text = GetComponent<Text> ();
		//xa = 0;
	}
	void Update(){

		text.text = ybayangan;

	}
	public void addPointsYBayangan(string pointsToAdd){

		ybayangan = pointsToAdd;
	}
}
