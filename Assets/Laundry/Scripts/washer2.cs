﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class washer2 : MonoBehaviour {
	int maxHold = 8;
	float delayTime = 20f;

	// If clicked
	void OnMouseDown() {
		int hold = GameObject.Find("washerManager").GetComponent<washerScript>().hold2;
		bool in_use = GameObject.Find("washerManager").GetComponent<washerScript>().in_use2;
		bool done = GameObject.Find("washerManager").GetComponent<washerScript>().done2;


		// If the washer is not in use, then put cloth to wash
		if (!in_use) {
			int toWash = GameObject.Find("GameManager").GetComponent<managerScript>().numToWash;
			if (toWash > 0) {
				if (toWash > maxHold) {
					GameObject.Find("washerManager").GetComponent<washerScript>().hold2 = maxHold;
					GameObject.Find("GameManager").GetComponent<managerScript>().numToWash -= maxHold;
					GameObject.Find("GameManager").GetComponent<managerScript>().numHolding -= maxHold;
					GameObject.Find("washerManager").GetComponent<washerScript>().in_use2 = true;
					GameObject.Find("washerManager").GetComponent<washerScript>().done2 = false;
					GameObject.Find("washerManager").GetComponent<washerScript>().timeLeft2 = delayTime;
					return;
				}

				else {
					GameObject.Find("washerManager").GetComponent<washerScript>().hold2 = toWash;
					GameObject.Find("GameManager").GetComponent<managerScript>().numToWash -= hold;
					GameObject.Find("GameManager").GetComponent<managerScript>().numHolding -= hold;
					GameObject.Find("washerManager").GetComponent<washerScript>().in_use2 = true;
					GameObject.Find("washerManager").GetComponent<washerScript>().done2 = false;
					GameObject.Find("washerManager").GetComponent<washerScript>().timeLeft2 = delayTime;
					return;
				}
			}
		}

		// If the washer is in use but done
		else if (in_use && done) {
			int holding = GameObject.Find("GameManager").GetComponent<managerScript>().numHolding;

			// If there is more in the washer than can hold
			if (hold > (10 - holding)) {
				GameObject.Find("GameManager").GetComponent<managerScript>().numHolding += (10 - holding);
				GameObject.Find("GameManager").GetComponent<managerScript>().numToDry += (10 - holding);
				GameObject.Find("washerManager").GetComponent<washerScript>().hold2 -= (10 - holding);
				return;
			}

			else {
				GameObject.Find("GameManager").GetComponent<managerScript>().numHolding += hold;
				GameObject.Find("GameManager").GetComponent<managerScript>().numToDry += hold;
				GameObject.Find("washerManager").GetComponent<washerScript>().hold2 = 0;
				GameObject.Find("washerManager").GetComponent<washerScript>().in_use2 = false;
				GameObject.Find("washerManager").GetComponent<washerScript>().done2 = false;
				return;
			}
		}
	}
}
