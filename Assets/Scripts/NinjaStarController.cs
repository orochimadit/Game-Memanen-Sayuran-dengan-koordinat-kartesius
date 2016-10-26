using UnityEngine;
using System.Collections;

public class NinjaStarController : MonoBehaviour {
	public float speed;
	public PlayerController player;
	public GameObject enemyDeathEffect;
	public GameObject impactEffect;
	public int pointsForKill;
	//public float rotationSpeed;
	// Use this for initialization
	void Start () {
		//ini beda
		player = FindObjectOfType<PlayerController> ();
		if (player.transform.localScale.x < 0)
			speed = -speed;
		player.rotationSpeed = -player.rotationSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);
		GetComponent<Rigidbody2D> ().angularVelocity = -player.rotationSpeed;
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Enemy") {
			Instantiate(enemyDeathEffect, other.transform.position, other.transform.rotation);//ini beda

			Destroy (other.gameObject);
			ScoreManager.addPoints (pointsForKill);
		}
		Instantiate(impactEffect, transform.position,transform.rotation);//ini beda

		Destroy(gameObject);
	}
}
