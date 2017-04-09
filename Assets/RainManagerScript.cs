using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainManagerScript : MonoBehaviour {

	public int score = 0;
	public GameObject umbrella;
	public GameObject cat;
	public GameObject rainDrop;
	public float health = 100f;
	public int angle = 0;
	private float angleChangeTime = 10f;
	public float rainSpeed = 0.05f;
	private float rainSpawnTime = .5f;
	private int spawnNumber = 50;
	public float catSpeed = 0.05f;
	public float scoreTime = 1f;


	// Use this for initialization
	void Start () {
		InvokeRepeating ("IncreaseCatSpeed", 10f, 10f);
		InvokeRepeating ("IncreaseScore", scoreTime, scoreTime);
		InvokeRepeating ("SpawnRain",rainSpawnTime, rainSpawnTime);
		InvokeRepeating ("ChangeAngle", angleChangeTime, angleChangeTime);
	}


	void IncreaseCatSpeed(){
		catSpeed *= 1.05f;
	}
	void IncreaseScore(){
		score += 1;
	}

	void ChangeAngle(){
		angle = Random.Range(-40, 40);
		angleChangeTime = Random.Range (4f, 8f);
	}
		

	void SpawnRain(){
		float leftCoord = -8.0f;
		float rightCoord = 8.0f;

		for (float i = leftCoord; i < rightCoord; i += 0.4f) {
			float yOffset = Random.Range (-0.9f, 0.9f);
			Vector3 loc = new Vector3 (i, 6f + yOffset, 0f);

			GameObject drop = Instantiate (rainDrop, loc, Quaternion.AngleAxis (angle, Vector3.forward));
		}
			
	}
	// Update is called once per frame
	void Update () {
		
	}
}
