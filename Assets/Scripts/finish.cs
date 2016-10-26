using UnityEngine;
using System.Collections;

public class finish : MonoBehaviour {
	public float finx;
	public float finy;
	public TranslasiA ts;
	public xybayangan xyb;
	public LevelLoader levload1;
	// Use this for initialization
	void Start () {
		ts = FindObjectOfType<TranslasiA> ();
		xyb = FindObjectOfType<xybayangan> ();
		levload1 = FindObjectOfType<LevelLoader> ();
	}

	// Update is called once per frame
	void Update () {
		finx = Mathf.Round (transform.position.x);
		finy = Mathf.Round (transform.position.y);

		if (levload1.levelToLoad == "Level 1" || levload1.levelToLoad == "Level 2") {
			//Debug.Log (""+finx+","+finy);
			ts.addPointsTransX (finx);
			ts.addPointsTransY (finy);
			xyb.addPointsXby (finx);
			xyb.addPointsYby (finy);
		}
	}
}
