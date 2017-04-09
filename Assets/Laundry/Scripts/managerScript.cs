using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class managerScript : MonoBehaviour {
	public int numDirtyCloth;  // number of dirty cloth in basket
	public int numHolding; // total number of cloth on hand
	public int numToWash; // number of cloth waiting for washer
	public int numToDry; // number of cloth waiting for dryer
	public int coins; // coin

	float timer = 1f;
	float delay = 1f;


	static bool created = false;

	
	void Start () {
		if (!created) {
			DontDestroyOnLoad(this.gameObject);
			created = true;
			numDirtyCloth = 10;  // number of dirty cloth in basket
			numHolding = 0; // total number of cloth on hand
			numToWash = 0; // number of cloth waiting for washer
			numToDry = 0; // number of cloth waiting for dryer
			coins = 0; // coin

		}
		else {
			Destroy(this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		// update number of dirty cloth in basket (time increment)
		timer -= Time.deltaTime;

		if (timer <= 0) {
			numDirtyCloth += 1;
			timer = delay;
		}

		if (numDirtyCloth >= 80) {
			Destroy(this.gameObject);
			SceneManager.LoadScene ("GameOver");

		}
	}
}
