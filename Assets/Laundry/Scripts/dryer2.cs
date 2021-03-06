﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dryer2 : MonoBehaviour {
	int maxHold = 12;
	float delayTime = 13f;

	public Sprite notUsed;
	public Sprite inUse;
	public Sprite done;

	// Update image of dryer base on status
	void Update() {
		if (GameObject.Find("dryerManager").GetComponent<dryerScript>().in_use2 &&
			GameObject.Find("dryerManager").GetComponent<dryerScript>().done2) {
			this.gameObject.GetComponent<SpriteRenderer>().sprite = done;
		}
		else if (GameObject.Find("dryerManager").GetComponent<dryerScript>().in_use2) {
			this.gameObject.GetComponent<SpriteRenderer>().sprite = inUse;
		}
		else {
			this.gameObject.GetComponent<SpriteRenderer>().sprite = notUsed;
		}
	}

	// If clicked (either unload, load, or do nothing)
	void OnMouseDown() {
		int hold = GameObject.Find("dryerManager").GetComponent<dryerScript>().hold2;
		bool in_use = GameObject.Find("dryerManager").GetComponent<dryerScript>().in_use2;
		bool done = GameObject.Find("dryerManager").GetComponent<dryerScript>().done2;


		// If the dryer is not in use, then put cloth to dry
		if (!in_use) {
			int toDry = GameObject.Find("GameManager").GetComponent<managerScript>().numToDry;
			if (toDry > 0) {
				if (toDry > maxHold) {
					GameObject.Find("dryerManager").GetComponent<dryerScript>().hold2 = maxHold;
					GameObject.Find("GameManager").GetComponent<managerScript>().numToDry -= maxHold;
					GameObject.Find("GameManager").GetComponent<managerScript>().numHolding -= maxHold;
					GameObject.Find("dryerManager").GetComponent<dryerScript>().in_use2 = true;
					GameObject.Find("dryerManager").GetComponent<dryerScript>().done2 = false;
					GameObject.Find("dryerManager").GetComponent<dryerScript>().timeLeft2 = delayTime;
					this.gameObject.GetComponent<SpriteRenderer>().sprite = inUse;
					return;
				}

				else {
					GameObject.Find("dryerManager").GetComponent<dryerScript>().hold2 = toDry;
					GameObject.Find("GameManager").GetComponent<managerScript>().numToDry -= toDry;
					GameObject.Find("GameManager").GetComponent<managerScript>().numHolding -= toDry;
					GameObject.Find("dryerManager").GetComponent<dryerScript>().in_use2 = true;
					GameObject.Find("dryerManager").GetComponent<dryerScript>().done2 = false;
					GameObject.Find("dryerManager").GetComponent<dryerScript>().timeLeft2 = delayTime;
					this.gameObject.GetComponent<SpriteRenderer>().sprite = inUse;
					return;
				}
			}
		}

		// If the dryer is in use but done, then unload -- Add to score
		else if (in_use && done) {
			GameObject.Find("GameManager").GetComponent<managerScript>().coins += hold;
			GameObject.Find("dryerManager").GetComponent<dryerScript>().hold2 = 0;
			GameObject.Find("dryerManager").GetComponent<dryerScript>().in_use2 = false;
			GameObject.Find("dryerManager").GetComponent<dryerScript>().done2 = false;
			this.gameObject.GetComponent<SpriteRenderer>().sprite = notUsed;
			return;
		
		}
	}
}
