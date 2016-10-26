using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private float moveVelocity;
	public float jumpHeight;
	// Use this for initialization
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;
	private bool doubleJumped;
	//private Animator anim;
	public Transform firePoint;
	public GameObject ninjaStar;
	public float rotationSpeed;
	public float shotDelay;
	private float shotDelayCounter;
	private float playerposx;
	float playerposy;
	float hasilpalyerx;
	float hasilplayery;
	float cossudut;
	float sinsudut;
	float minsinsudut;
	float cossudut2;
	public XPos xpos;
	public YPos ypos;
	public YPlayer yplayer;
	public XPlayer xplayer;
	public XBayangan xbayangan;
	public YBayangan ybayangan;
	public Cos1Sudut cos1sudut;
	public Cos2Sudut cos2sudut;
	public SinSudut ss;
	public PerhitunganX hitungx;
	public PerhitunganY hitungy;
	public MinSinSudut mins;
	public TranslasiA trans1;
	public Sudut sd;
	public xy ca;
	public LevelLoader levload;
	public hidesprite hides;
	public hidesprite2 hidess;


	void Start () {
		//anim = GetComponent<Animator> ();
		xpos = FindObjectOfType<XPos> ();
		ypos = FindObjectOfType<YPos> ();
		yplayer = FindObjectOfType<YPlayer> ();
		xplayer = FindObjectOfType<XPlayer> ();
		cos1sudut = FindObjectOfType<Cos1Sudut> ();
		cos2sudut = FindObjectOfType<Cos2Sudut> ();
		xbayangan = FindObjectOfType<XBayangan> ();
		ybayangan = FindObjectOfType<YBayangan> ();
		ss = FindObjectOfType<SinSudut> ();
		mins = FindObjectOfType<MinSinSudut> ();
		sd = FindObjectOfType<Sudut> ();
		hitungx = FindObjectOfType<PerhitunganX> ();
		hitungy = FindObjectOfType<PerhitunganY> ();
		ca = FindObjectOfType<xy> ();
		trans1 = FindObjectOfType<TranslasiA> ();
		levload = FindObjectOfType<LevelLoader> ();
		hides = FindObjectOfType<hidesprite> ();
		hidess = FindObjectOfType<hidesprite2> ();
	}
	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}
	// Update is called once per frame
	void Update () {
		playerposx = Mathf.Round(transform.position.x);
		playerposy = Mathf.Round(transform.position.y);
		string a = "" + playerposx;
		string b = "" + playerposy;
		//Debug.Log ("Activated Checkpoint " + transform.position);
		if (levload.levelToLoad == "Level 1" || levload.levelToLoad == "Level 2") {
			ca.addPointsXl (a);
			ca.addPointsYl (b);
			trans1.addPointsgbx (playerposx);
			trans1.addPointsgby (playerposy);
		}

		if (grounded) {
			doubleJumped = false;
			//anim.SetBool ("Grounded", grounded);
		}
		if (Input.GetKeyDown (KeyCode.Space) && grounded) {
			//GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
			Jump();
		}
		if (Input.GetKeyDown (KeyCode.Space) && !doubleJumped && !grounded) {
			//GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
			Jump();
			doubleJumped = true;
		}
		moveVelocity = 0f;
		if (Input.GetKey (KeyCode.D)) {
			moveVelocity = moveSpeed;
			//GetComponent<Rigidbody2D>().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
		if (Input.GetKey (KeyCode.A)) {
			moveVelocity = -moveSpeed;
			//GetComponent<Rigidbody2D>().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);
		//anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

		if (GetComponent<Rigidbody2D> ().velocity.x > 0) {
			transform.localScale = new Vector3 (1f, 1f, 1f);
		} else if(GetComponent<Rigidbody2D> ().velocity.x < 0) {
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		}
		if (Input.GetKey (KeyCode.T)) {
			shotDelayCounter -= Time.deltaTime;
			if (shotDelayCounter <= 0) {
				shotDelayCounter = shotDelay;
				Instantiate (ninjaStar, firePoint.position, firePoint.rotation);
			}
			rotationSpeed = 360;
			cossudut = Mathf.Round(Mathf.Cos((360 * Mathf.PI)/180));
			cossudut2 = Mathf.Round(Mathf.Cos((360 * Mathf.PI)/180));
			sinsudut = Mathf.Round(Mathf.Sin((360 * Mathf.PI)/180));
			minsinsudut= Mathf.Round(Mathf.Sin((-360 * Mathf.PI)/180));


			hasilpalyerx = (cossudut * playerposx) + (minsinsudut * playerposy);

			hasilplayery = (sinsudut * playerposx) + (cossudut2 * playerposy);

			//Debug.Log ("Activated Checkpoint " + transform.position);
			xplayer.addPointsXPlayer(""+playerposx);
			yplayer.addPointsYPlayer ("" + playerposy);
			xbayangan.addPointsXBayangan (""+hasilpalyerx);
			ybayangan.addPointsYBayangan (""+hasilplayery);
			ss.addPointsSinSudut (""+sinsudut);
			mins.addPointsMinSudut (""+minsinsudut);
			cos1sudut.addPointsCosSudut (""+cossudut);
			cos2sudut.addPointsCosduaSudut (""+cossudut2);
			sd.addPointsSudut (""+rotationSpeed);
			hitungx.addhitungcossudut (""+cossudut);
			hitungx.addhitungminsinsudut (""+minsinsudut);
			hitungx.addhitungplayerposx (""+playerposx);
			hitungx.addhitungplayerposy (""+playerposy);
			hitungy.addhitungcossudut2 (""+cossudut2);
			hitungy.addhitungsinsudut (""+sinsudut);
			hitungy.addhitungplayerposx2 (""+playerposx);
			hitungy.addhitungplayerposy2 (""+playerposy);
			//if (levload.levelToLoad == "Level menerangkan") {
			//	hides.komponenRumus ("" + cossudut, "" + playerposx, "" + minsinsudut, "" + playerposy, "" + 360, "" + sinsudut, "" + hasilpalyerx, "" + hasilplayery);
			//} else {
				//hidess.komponenRumuss ("" + cossudut, "" + playerposx, "" + minsinsudut, "" + playerposy, "" + 360, "" + sinsudut, "" + hasilpalyerx, "" + hasilplayery);
			//}
			//Debug.Log (playerposx);
		}

		if (Input.GetKey (KeyCode.Y)) {
			//Instantiate (ninjaStar, firePoint.position, firePoint.rotation);
			shotDelayCounter -= Time.deltaTime;
			if (shotDelayCounter <= 0) {
				shotDelayCounter = shotDelay;
				Instantiate (ninjaStar, firePoint.position, firePoint.rotation);
			}
			rotationSpeed = 270;
			cossudut = Mathf.Round(Mathf.Cos((270 * Mathf.PI)/180));
			cossudut2 = Mathf.Round(Mathf.Cos((270 * Mathf.PI)/180));
			sinsudut = Mathf.Round(Mathf.Sin((270 * Mathf.PI)/180));
			minsinsudut= Mathf.Round(Mathf.Sin((-270 * Mathf.PI)/180));


			hasilpalyerx = (cossudut * playerposx) + (minsinsudut * playerposy);

			hasilplayery = (sinsudut * playerposx) + (cossudut2 * playerposy);
			xplayer.addPointsXPlayer(""+playerposx);
			yplayer.addPointsYPlayer ("" + playerposy);
			xbayangan.addPointsXBayangan (""+hasilpalyerx);
			ybayangan.addPointsYBayangan (""+hasilplayery);

			ss.addPointsSinSudut (""+sinsudut);
			mins.addPointsMinSudut (""+minsinsudut);
			cos1sudut.addPointsCosSudut (""+cossudut);
			cos2sudut.addPointsCosduaSudut (""+cossudut2);
			sd.addPointsSudut (""+rotationSpeed);
			hitungx.addhitungcossudut (""+cossudut);
			hitungx.addhitungminsinsudut (""+minsinsudut);
			hitungx.addhitungplayerposx (""+playerposx);
			hitungx.addhitungplayerposy (""+playerposy);
			hitungy.addhitungcossudut2 (""+cossudut2);
			hitungy.addhitungsinsudut (""+sinsudut);
			hitungy.addhitungplayerposx2 (""+playerposx);
			hitungy.addhitungplayerposy2 (""+playerposy);
		}
		if (Input.GetKey (KeyCode.U)) {
			//Instantiate (ninjaStar, firePoint.position, firePoint.rotation);
			shotDelayCounter -= Time.deltaTime;
			if (shotDelayCounter <= 0) {
				shotDelayCounter = shotDelay;
				Instantiate (ninjaStar, firePoint.position, firePoint.rotation);
			}
			rotationSpeed = 180;
			cossudut = Mathf.Round(Mathf.Cos((180 * Mathf.PI)/180));
			cossudut2 = Mathf.Round(Mathf.Cos((180 * Mathf.PI)/180));
			sinsudut = Mathf.Round(Mathf.Sin((180 * Mathf.PI)/180));
			minsinsudut= Mathf.Round(Mathf.Sin((-180 * Mathf.PI)/180));


			hasilpalyerx = (cossudut * playerposx) + (minsinsudut * playerposy);

			hasilplayery = (sinsudut * playerposx) + (cossudut2 * playerposy);

			xplayer.addPointsXPlayer(""+playerposx);
			yplayer.addPointsYPlayer ("" + playerposy);
			xbayangan.addPointsXBayangan (""+hasilpalyerx);
			ybayangan.addPointsYBayangan (""+hasilplayery);
			ss.addPointsSinSudut (""+sinsudut);
			mins.addPointsMinSudut (""+minsinsudut);
			cos1sudut.addPointsCosSudut (""+cossudut);
			cos2sudut.addPointsCosduaSudut (""+cossudut2);
			sd.addPointsSudut (""+rotationSpeed);
			hitungx.addhitungcossudut (""+cossudut);
			hitungx.addhitungminsinsudut (""+minsinsudut);
			hitungx.addhitungplayerposx (""+playerposx);
			hitungx.addhitungplayerposy (""+playerposy);
			hitungy.addhitungcossudut2 (""+cossudut2);
			hitungy.addhitungsinsudut (""+sinsudut);
			hitungy.addhitungplayerposx2 (""+playerposx);
			hitungy.addhitungplayerposy2 (""+playerposy);
		}
		if (Input.GetKey (KeyCode.I)) {
			//Instantiate (ninjaStar, firePoint.position, firePoint.rotation);
			shotDelayCounter -= Time.deltaTime;
			if (shotDelayCounter <= 0) {
				shotDelayCounter = shotDelay;
				Instantiate (ninjaStar, firePoint.position, firePoint.rotation);
			}
			rotationSpeed = 90;
			cossudut = Mathf.Round(Mathf.Cos((90 * Mathf.PI)/180));
			cossudut2 = Mathf.Round(Mathf.Cos((90 * Mathf.PI)/180));
			sinsudut = Mathf.Round(Mathf.Sin((90 * Mathf.PI)/180));
			minsinsudut= Mathf.Round(Mathf.Sin((-90 * Mathf.PI)/180));


			hasilpalyerx = (cossudut * playerposx) + (minsinsudut * playerposy);

			hasilplayery = (sinsudut * playerposx) + (cossudut2 * playerposy);

			xplayer.addPointsXPlayer(""+playerposx);
			yplayer.addPointsYPlayer ("" + playerposy);
			xbayangan.addPointsXBayangan (""+hasilpalyerx);
			ybayangan.addPointsYBayangan (""+hasilplayery);
			ss.addPointsSinSudut (""+sinsudut);
			mins.addPointsMinSudut (""+minsinsudut);
			cos1sudut.addPointsCosSudut (""+cossudut);
			cos2sudut.addPointsCosduaSudut (""+cossudut2);
			sd.addPointsSudut (""+rotationSpeed);
			hitungx.addhitungcossudut (""+cossudut);
			hitungx.addhitungminsinsudut (""+minsinsudut);
			hitungx.addhitungplayerposx (""+playerposx);
			hitungx.addhitungplayerposy (""+playerposy);
			hitungy.addhitungcossudut2 (""+cossudut2);
			hitungy.addhitungsinsudut (""+sinsudut);
			hitungy.addhitungplayerposx2 (""+playerposx);
			hitungy.addhitungplayerposy2 (""+playerposy);
		}


	}

	public void Jump(){
		GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
	}
}
