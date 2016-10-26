using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class giftManager : MonoBehaviour {

	// Use this for initialization
	public static int scoregift;
	Text text;
	void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (scoregift < 0)
			scoregift = 0;

		text.text = "" + scoregift;
	}
	public static void addGift(int pointsToAdd){
		scoregift += pointsToAdd;
	}
}
