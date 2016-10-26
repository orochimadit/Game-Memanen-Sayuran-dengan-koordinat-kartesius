using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class xy : MonoBehaviour {

	string xl="0";
	string yl="0";
	string gab;
	Text text;

	void Start(){
		gab = "T ("+xl+" , "+yl+")";
		text = GetComponent<Text> ();

	}
	void Update(){
		gab = "T ("+xl+" , "+yl+")";
		text.text = gab;

	}
	public void addPointsXl(string pointsToAdd1){

		xl = pointsToAdd1;
	}
	public void addPointsYl(string pointsToAdd2){

		yl = pointsToAdd2;
	}
}
