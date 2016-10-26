using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class XBayangan : MonoBehaviour {

	string xbayangan;
	Text text;

	void Start(){
		xbayangan = "0'";
		text = GetComponent<Text> ();
		//xa = 0;
	}
	void Update(){

		text.text = xbayangan;

	}
	public void addPointsXBayangan(string pointsToAdd){

		xbayangan = pointsToAdd;
	}
}
