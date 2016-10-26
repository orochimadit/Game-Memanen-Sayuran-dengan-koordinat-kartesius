using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public PlayerController player;
	public bool isFollowing;
	public float xoffset;
	public float yoffset;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
		isFollowing = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isFollowing)
			transform.position = new Vector3 (player.transform.position.x + xoffset, player.transform.position.y + yoffset, transform.position.z);
	}
}
