using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class managerScript : MonoBehaviour {
	public int numDirtyCloth;
	public int numHolding;

	public Text numDirty;
	public Text numHold;

	float timer = 1f;
	float delay = 1f;

	// Use this for initialization
	void Start () {
		numDirtyCloth = 10;
		numHolding = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		// update number of dirty cloth in basket (time increment)
		timer -= Time.deltaTime;

		if (timer <= 0) {
			numDirtyCloth += 1;
			timer = delay;
		}

		// update counter display
		numDirty.text = "Dirty Clothes: " + numDirtyCloth;
		numHold.text = "Holding: " + numHolding + "/ 10";
		
	}
}
