using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class xybayangan : MonoBehaviour {

	float xl=0;
	float yl=0;
	string gab;
	Text text;

	void Start(){
		gab = "T' ("+xl+" , "+yl+")";
		text = GetComponent<Text> ();

	}
	void Update(){
		gab = "T' ("+xl+" , "+yl+")";
		text.text = gab;

	}
	public void addPointsXby(float pointsToAdd1){

		xl = pointsToAdd1;
	}
	public void addPointsYby(float pointsToAdd2){

		yl = pointsToAdd2;
	}
}
