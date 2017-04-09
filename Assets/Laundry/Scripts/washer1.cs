using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class washer1 : MonoBehaviour {
	int maxHold = 8;
	float delayTime = 12f;

	// If clicked
	void OnMouseDown() {
		int hold = GameObject.Find("washerManager").GetComponent<washerScript>().hold1;
		bool in_use = GameObject.Find("washerManager").GetComponent<washerScript>().in_use1;
		bool done = GameObject.Find("washerManager").GetComponent<washerScript>().done1;


		// If the washer is not in use, then put cloth to wash
		if (!in_use) {
			int toWash = GameObject.Find("GameManager").GetComponent<managerScript>().numToWash;
		
			if (toWash > maxHold) {
				GameObject.Find("washerManager").GetComponent<washerScript>().hold1 = maxHold;
				GameObject.Find("GameManager").GetComponent<managerScript>().numToWash -= maxHold;
				GameObject.Find("GameManager").GetComponent<managerScript>().numHolding -= maxHold;
				GameObject.Find("washerManager").GetComponent<washerScript>().in_use1 = true;
				GameObject.Find("washerManager").GetComponent<washerScript>().done1 = false;					
				GameObject.Find("washerManager").GetComponent<washerScript>().timeLeft1 = delayTime;
				return;
				}

			else {
				GameObject.Find("washerManager").GetComponent<washerScript>().hold1 = toWash;
				GameObject.Find("GameManager").GetComponent<managerScript>().numToWash -= toWash;	
				GameObject.Find("GameManager").GetComponent<managerScript>().numHolding -= toWash;
				GameObject.Find("washerManager").GetComponent<washerScript>().in_use1 = true;
				GameObject.Find("washerManager").GetComponent<washerScript>().done1 = false;
				GameObject.Find("washerManager").GetComponent<washerScript>().timeLeft1 = delayTime;
				return;
			}
			
		}

		// If the washer is in use but done
		else if(in_use && done) {
			int holding = GameObject.Find("GameManager").GetComponent<managerScript>().numHolding;

			// If there is more in the washer than can hold
			if (hold > (10 - holding)) {
				GameObject.Find("GameManager").GetComponent<managerScript>().numHolding += (10 - holding);
				GameObject.Find("GameManager").GetComponent<managerScript>().numToDry += (10 - holding);
				GameObject.Find("washerManager").GetComponent<washerScript>().hold1 -= (10 - holding);
				return;
			}
			else {
				GameObject.Find("GameManager").GetComponent<managerScript>().numHolding += hold;
				GameObject.Find("GameManager").GetComponent<managerScript>().numToDry += hold;
				GameObject.Find("washerManager").GetComponent<washerScript>().hold1 -= hold;
				GameObject.Find("washerManager").GetComponent<washerScript>().in_use1 = false;
				GameObject.Find("washerManager").GetComponent<washerScript>().done1 = false;
				return;
			}
		}
	}
}
