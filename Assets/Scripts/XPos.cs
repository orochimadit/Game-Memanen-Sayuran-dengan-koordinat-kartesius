using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class XPos : MonoBehaviour {

	string xa;
	Text text;

	void Start(){
		text = GetComponent<Text> ();
		//xa = 0;
	}
	void Update(){
		
		text.text = xa;

	}
	public void addPointsX(string pointsToAdd){
		
		xa = pointsToAdd;
	}

}
