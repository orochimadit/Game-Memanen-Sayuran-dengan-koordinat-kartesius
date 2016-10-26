using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PerhitunganX : MonoBehaviour {

	string  hitungcossudut="0";
	string  hitungplayerposx="0";
	string  hitungminsinsudut="0";
	string  hitungplayerposy="0";
	string  gabung1;
	Text text;

	void Start(){
		
		text = GetComponent<Text> ();
		//xa = 0;
	}
	void Update(){
		gabung1 = "("+hitungcossudut+" * "+hitungplayerposx+") + ("+hitungminsinsudut+" * "+hitungplayerposy+")";
		text.text = gabung1;

	}
	public void addhitungcossudut(string pointsToAdd){

		hitungcossudut = pointsToAdd;
	}
	public void addhitungplayerposx(string pointsToAdd){

		hitungplayerposx = pointsToAdd;
	}
	public void addhitungminsinsudut(string pointsToAdd){

		hitungminsinsudut = pointsToAdd;
	}
	public void addhitungplayerposy(string pointsToAdd){

		hitungplayerposy = pointsToAdd;
	}
}
