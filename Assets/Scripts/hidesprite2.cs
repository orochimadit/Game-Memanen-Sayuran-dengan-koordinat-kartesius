using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class hidesprite2 : MonoBehaviour {


	public Sprite BlackCircle;
	public Sprite RedCircle;
	public GameObject textBox;
	public GameObject textBox2;
	public GameObject textBox3;
	public GameObject gift;
	public Text theText;
	public Text userjawab;
	public Text userjawab2;
	public TextAsset textFile;
	string hitcosSudut, hitminsinSudut, hitposxlaser, hitSudut, hitsinsudut, hitposylaser="0";
	string baris1, baris2, hasilsatu, hasildua;
	public LevelLoader load;

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
		textBox.SetActive (false);
		textBox2.SetActive (false);
		textBox3.SetActive (false);
		gift.SetActive (false);
		load = FindObjectOfType<LevelLoader> ();

		this.gameObject.GetComponent<SpriteRenderer> ().sprite = BlackCircle;

	}
	IEnumerator DisplayTimer(){
		while (1 == 1) {
			yield return new WaitForSeconds(speed);
			if (characterIndex > textLines [stringindex].Length) {

				continue;
			}
			theText.text = textLines [stringindex].Substring(0, characterIndex);
			characterIndex++;
		}
	}
	//public void komponenRumuss(string cosSudut, string posxlaser,string minsinsudut, string posylaser, string sudutt, string sinsudut, string hasil1, string hasil2){



	//}
	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Player" && gift.active==false) {
			stringindex = 0;
			characterIndex=0;
			textBox.SetActive (true);
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = RedCircle;
			StartCoroutine (DisplayTimer ());
			float playerposx = Mathf.Round(transform.position.x);
			float playerposy = Mathf.Round(transform.position.y);
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
			textBox2.SetActive (true);
		
			string jawaban = userjawab.text.ToString ();
			if (jawaban == hasilsatu && Input.GetKeyDown (KeyCode.Return)) {

				textBox2.SetActive (false);
				textBox3.SetActive (true);
				userjawab.text = "jawaban anda";


			} 
		}
		if (stringindex == 8) {
			string jawaban2 = userjawab2.text.ToString ();
			if (jawaban2 == hasildua && Input.GetKeyDown (KeyCode.Return)) {
				textBox3.SetActive (false);
				textBox2.SetActive (false);
				textBox.SetActive (false);
				gift.SetActive (true);
				giftManager.addGift (1);
				theText.text = " ";
				stringindex = 0;
				characterIndex = 0;

			}

		}
	}

}
