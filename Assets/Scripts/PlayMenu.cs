using UnityEngine;
using System.Collections;

public class PlayMenu : MonoBehaviour {

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
	public float rotationSpeed;
	public float shotDelay;
	private float shotDelayCounter;
	private float playerposx;


	void Start () {
		//anim = GetComponent<Animator> ();


	}
	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}
	// Update is called once per frame
	void Update () {
		
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


	}

	public void Jump(){
		GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
	}
}
