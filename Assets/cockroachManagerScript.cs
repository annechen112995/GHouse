using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cockroachManagerScript : MonoBehaviour {

	public int lives = 3;
	public int score = 0;
	public int spawnRate = 1;
	public float currSpeed = 0.05f;
	public GameObject roach;
	public float radius = 8f;
	private float spawnTime = 2f;
	private float spawnFasterTime = 20f;
	private float speedUpTime = 30f;
	private float speedUpFactor = 1.09f;

	// Use this for initialization
	void Start () {
		score = 0;
		InvokeRepeating ("SpeedUp", speedUpTime, speedUpTime);
		InvokeRepeating ("Spawnfaster", spawnFasterTime,spawnFasterTime);
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}


	void Spawnfaster(){
		spawnTime /= 1.1f;

	}

	void SpeedUp(){
		currSpeed *= speedUpFactor;
		spawnRate += 1;
	}

	// Update is called once per frame
	void Update () {

	}
	void Spawn() {
		for (int i = 0; i < spawnRate; i++){

			float randAngle = Random.Range (0, 360);
			float randAngle2 = Random.Range (70f, 100f);
			float xCord = radius * Mathf.Sin (randAngle);
			float yCord = radius * Mathf.Cos (randAngle);
			Vector3 loc = new Vector3 (xCord, yCord, 1f);
			Vector3 origin = new Vector3 (0f, 0f, 1f);
			float RotateAngle = Mathf.Atan2((origin-loc).y, (origin-loc).x) * Mathf.Rad2Deg;
			GameObject rch = Instantiate (roach, loc, Quaternion.AngleAxis(RotateAngle-randAngle2, Vector3.forward));
			float scale = Random.Range (0f, 0.1f);
			rch.transform.localScale += new Vector3 (scale, scale, 0);
		}
	}
}
