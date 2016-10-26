using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Menjawab90 : MonoBehaviour {

	public Sprite BlackCircle1;
	public Sprite RedCircle1;
	public GameObject textBox1;
	public GameObject textBox21;
	public GameObject textBox31;
	public GameObject gift1;
	public GameObject laser1;
	public Text theText1;
	public Text userjawab1;
	public Text userjawab21;
	public TextAsset textFile1;
	string hitcosSudut, hitminsinSudut, hitposxlaser, hitSudut, hitsinsudut, hitposylaser="0";
	string baris1, baris2, hasilsatu, hasildua;
	public LevelLoader load;
	float playerposx,  playerposy;
	string[] textLines ={
		"Rumus Rotasi :",
		"Sudut",
		"Posisi X Laser",
		"Posisi Y Laser",
		"Baris 1 : (Cos Sudut * posisi X laser) + (-Sin sudut * posisi Y laser) ",
		"Baris 2 :(Sin Sudut * posisi X laser) + (Cos sudut * posisi Y laser)",
		"Jadi :",
		"hasil1",
		"hasil2",
	};

	public float speed = 0.1f;
	int stringindex = 0;
	int characterIndex = 0;

	void Start () {
		textBox1.SetActive (false);
		textBox21.SetActive (false);
		textBox31.SetActive (false);
		gift1.SetActive (false);
		load = FindObjectOfType<LevelLoader> ();

		this.gameObject.GetComponent<SpriteRenderer> ().sprite = BlackCircle1;

	}
	IEnumerator DisplayTimer(){
		while (1 == 1) {
			yield return new WaitForSeconds(speed);
			if (characterIndex > textLines [stringindex].Length) {

				continue;
			}
			theText1.text = textLines [stringindex].Substring(0, characterIndex);
			characterIndex++;
		}
	}
	//public void komponenRumuss(string cosSudut, string posxlaser,string minsinsudut, string posylaser, string sudutt, string sinsudut, string hasil1, string hasil2){



	//}
	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Player" && gift1.active==false) {
			playerposx = 0;
			playerposy = 0;
			stringindex = 0;
			textBox1.SetActive (true);
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = RedCircle1;
			StartCoroutine (DisplayTimer ());
			playerposx = Mathf.Round(laser1.transform.position.x);
			playerposy = Mathf.Round(laser1.transform.position.y);
			float suduttttt=90;

			float cossudut = Mathf.Round (Mathf.Cos ((suduttttt * Mathf.PI) / 180));
			float sinsudut = Mathf.Round (Mathf.Sin ((suduttttt * Mathf.PI) / 180));
			float minsinsudut = Mathf.Round (Mathf.Sin (-(suduttttt * Mathf.PI) / 180));
			float hasilpalyerx = (cossudut * playerposx) + (minsinsudut * playerposy);
			float hasilplayery = (sinsudut * playerposx) + (cossudut * playerposy);

			hitcosSudut = ""+cossudut;
			hitposxlaser = ""+playerposx;
			hitminsinSudut = ""+minsinsudut;
			hitposylaser = ""+playerposy;
			hitSudut = ""+suduttttt;
			hitsinsudut = ""+sinsudut;
			hasilsatu = ""+hasilpalyerx;
			hasildua = ""+hasilplayery;

		}


	}

	void Update () {
		string stringbaris1 = "Baris 1 : (Cos " + hitSudut + " * posisi X laser) + (-Sin " + hitSudut + " * posisi Y laser)";
		string stringbaris2 = "Baris 2 : (Sin " + hitSudut + " * posisi X laser) + (Cos " + hitSudut + " * posisi Y laser)";
		baris1 = "(" + hitcosSudut + " * " + hitposxlaser + ") + (" + hitminsinSudut + " * " + hitposylaser + ")";
		baris2 = "(" + hitsinsudut + " * " + hitposxlaser + ") + (" + hitcosSudut + " * " + hitposylaser + ")";
		textLines.SetValue ("Hasil Baris 1 : " + baris1, 7);
		textLines.SetValue ("Hasil Baris 2 : " + baris2, 8);
		textLines.SetValue ("Sudut :  " + hitSudut, 1);
		textLines.SetValue ("Posisi X Laser : " + hitposxlaser, 2);
		textLines.SetValue ("Posisi Y Laser : " + hitposylaser, 3);

		textLines.SetValue (stringbaris1, 4);
		textLines.SetValue (stringbaris2, 5);
		if (Input.GetKeyDown (KeyCode.L)) {

			if (stringindex < textLines.Length) {
				stringindex++;
				characterIndex = 0;
			}

		}

		if (stringindex == 7) {
			textBox21.SetActive (true);

			string jawaban = userjawab1.text.ToString ();
			if (jawaban == hasilsatu && Input.GetKeyDown (KeyCode.Return)) {

				textBox21.SetActive (false);
				textBox31.SetActive (true);
				userjawab1.text = "jawaban anda";


			} 
		}
		if (stringindex == 8) {
			string jawaban2 = userjawab21.text.ToString ();
			if (jawaban2 == hasildua && Input.GetKeyDown (KeyCode.Return)) {
				textBox31.SetActive (false);
				textBox21.SetActive (false);
				textBox1.SetActive (false);
				if (this.gameObject.GetComponent<SpriteRenderer> ().sprite == RedCircle1) {
					gift1.SetActive (true);
					giftManager.addGift (1);
				}
				theText1.text = " ";	
				stringindex = 9;
				characterIndex = 0;

			}

		}
	}

}
