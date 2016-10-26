using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PerhitunganY : MonoBehaviour {
	string  hitungsinsudut="0";
	string  hitungplayerposx2="0";
	string  hitungcossudut2="0";
	string  hitungplayerposy2="0";
	string  gabung;
	Text text;

	void Start(){
		text = GetComponent<Text> ();
		//xa = 0;
	}
	void Update(){
		gabung = "("+hitungsinsudut+" * "+hitungplayerposx2+") + ("+hitungcossudut2+" * "+hitungplayerposy2+")";
		text.text = gabung;

	}
	public void addhitungsinsudut(string pointsToAdd){

		hitungsinsudut = pointsToAdd;
	}
	public void addhitungplayerposx2(string pointsToAdd){

		hitungplayerposx2 = pointsToAdd;
	}
	public void addhitungcossudut2(string pointsToAdd){

		hitungcossudut2 = pointsToAdd;
	}
	public void addhitungplayerposy2(string pointsToAdd){

		hitungplayerposy2 = pointsToAdd;
	}
}
