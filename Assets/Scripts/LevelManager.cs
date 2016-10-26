using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;
	private PlayerController player;
	public GameObject deathParticle;
	public GameObject respawnParticle;

	public int pointPenaltyOnDeath;
	private CameraController camera;
	public float respawnDelay;
	private float gravityStore;
	// Use this for initialization

	void Start () {
		player = FindObjectOfType<PlayerController> ();
		camera = FindObjectOfType<CameraController> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void RespawnPlayer()
	{
		StartCoroutine ("RespawnPlayerCo");
		player.transform.position = currentCheckpoint.transform.position;
		Instantiate (respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);

	}
	public IEnumerator RespawnPlayerCo(){
		Instantiate (deathParticle, player.transform.position, player.transform.rotation);
		player.enabled = false;
		player.GetComponent<Renderer>().enabled = false;
		camera.isFollowing = false;
		//gravityStore = player.GetComponent<Rigidbody2D> ().gravityScale;
		//player.GetComponent<Rigidbody2D> ().gravityScale = 0f;
		//player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero; 
		ScoreManager.addPoints (-pointPenaltyOnDeath);
		//Debug.Log ("Player Respawn");
		yield return new WaitForSeconds(respawnDelay);
		//player.GetComponent<Rigidbody2D> ().gravityScale = gravityStore;

		player.enabled = true;
		player.GetComponent<Renderer>().enabled = true;
		camera.isFollowing = true;
		//jika spikes tabrakan dengan player maka posisi player berada pada awal start
	}
}
