using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Menerangkan180 : MonoBehaviour {

	public Sprite beforeimage1;
	public Sprite afterimage1;
	public GameObject panelpenjelasan1;
	public GameObject hadiah1;
	public Text textpenjelasan1;
	string hitcosSudut, hitminsinSudut, hitposxlaser, hitSudut, hitsinsudut, hitposylaser="0";
	string baris1, baris2, hasilsatu, hasildua;
	//public LevelLoader load;
	public GameObject posisilaser1;
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
		panelpenjelasan1.SetActive (false);
		hadiah1.SetActive (false);
		//load = FindObjectOfType<LevelLoader> ();

		this.gameObject.GetComponent<SpriteRenderer> ().sprite = beforeimage1;
	}
	IEnumerator DisplayTimer(){
		while (1 == 1) {
			yield return new WaitForSeconds(speed);
			if (characterIndex > textLines [stringindex].Length) {

				continue;
			}
			textpenjelasan1.text = textLines [stringindex].Substring(0, characterIndex);
			characterIndex++;
		}
	}
	//public void komponenRumuss(string cosSudut, string posxlaser,string minsinsudut, string posylaser, string sudutt, string sinsudut, string hasil1, string hasil2){



	//}
	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Player" && hadiah1.active==false ) {
			playerposx = 0;
			playerposy = 0;
			stringindex = 0;
			panelpenjelasan1.SetActive (true);
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = afterimage1;
			StartCoroutine (DisplayTimer ());
			playerposx = Mathf.Round(posisilaser1.transform.position.x);
			playerposy = Mathf.Round(posisilaser1.transform.position.y);
			float suduttttt=180;

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
		baris1 = "(" + hitcosSudut + " * " + hitposxlaser + ") + (" + hitminsinSudut + " * " + hitposylaser + ")"+" = "+hasilsatu;
		baris2 = "(" + hitsinsudut + " * " + hitposxlaser + ") + (" + hitcosSudut + " * " + hitposylaser + ")"+" = "+hasildua;
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

		if (stringindex == 9) {
			panelpenjelasan1.SetActive (false);
			if (this.gameObject.GetComponent<SpriteRenderer> ().sprite == afterimage1) {
				hadiah1.SetActive (true);
				giftManager.addGift (1);
			}
			textpenjelasan1.text = " ";
			stringindex = 10;
		}
	}

}
