using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class managerScript : MonoBehaviour {

	// stats to track
	public int numDirtyCloth;  // number of dirty cloth in basket
	public int numHolding;     // total number of cloth on hand
	public int numToWash;      // number of cloth waiting for washer
	public int numToDry;       // number of cloth waiting for dryer
	public int coins;          // coin == score

	float timer = 1f;
	float delay = 1f;

	static bool created = false;

	// initialize the game manager with initial stats
	void Start () {
		if (!created) {
			DontDestroyOnLoad(this.gameObject);
			created = true;
			numDirtyCloth = 10;  // number of dirty cloth in basket
			numHolding = 0;      // total number of cloth on hand
			numToWash = 0;       // number of cloth waiting for washer
			numToDry = 0;        // number of cloth waiting for dryer
			coins = 0;           // coin

		}
		else {
			Destroy(this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		// update number of dirty cloth in basket (time increment)
		timer -= Time.deltaTime;

		// Add dirty cloth
		if (timer <= 0) {
			numDirtyCloth += 1;
			timer = delay;
		}

		// Game over if we have more than 40 in basket
		if (numDirtyCloth > 40) {
			
			Destroy(GameObject.Find("dryerManager"));
			Destroy(GameObject.Find("washerManager"));
			SceneManager.LoadScene ("GameOver");
		}

		if (Input.GetKeyDown(KeyCode.Escape)) {
			Destroy(GameObject.Find("dryerManager"));
			Destroy(GameObject.Find("washerManager"));
			Destroy(this.gameObject);
			SceneManager.LoadScene("Scene1");
		}
	}

}