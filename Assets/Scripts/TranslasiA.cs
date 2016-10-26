using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TranslasiA : MonoBehaviour {
	public float transx, transy;
	public float gbx, gby;
	float hasilgbx, hasilgby;
	string hasiltranslasi;
	Text text;

	void Start(){
		hasiltranslasi = "T1 (" + 0 + " , " + 0 + ")";
		text = GetComponent<Text> ();

	}
	void Update(){
		
		hasilgbx = (transx-gbx);
		hasilgby = (transy-gby);
		hasiltranslasi = "T1 (" + hasilgbx + " , " + hasilgby + ")";
		text.text = hasiltranslasi;
		//Debug.Log (""+transx+","+transy);

	}
	public void addPointsTransX(float pointsToAdd){

		transx = pointsToAdd;
	}public void addPointsTransY(float pointsToAdd){

		transy = pointsToAdd;
	}
	public void addPointsgbx(float pointsToAddgbx){

		gbx = pointsToAddgbx;
	}
	public void addPointsgby(float pointsToAddgby){

		gby = pointsToAddgby;
	}
}
