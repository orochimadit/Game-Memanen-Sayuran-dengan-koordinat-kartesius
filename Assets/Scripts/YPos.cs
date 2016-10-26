using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class YPos : MonoBehaviour {

	string ya;
	Text text;

	void Start(){
		text = GetComponent<Text> ();
		//ya = 0;
	}
	void Update(){

		text.text = ya;

	}
	public void addPointsY(string pointsToAdd){

		ya = pointsToAdd;
	}

}
