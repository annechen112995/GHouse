using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dryer2 : MonoBehaviour {
	int maxHold = 12;
	float delayTime = 15f;


	// If clicked
	void OnMouseDown() {
		int hold = GameObject.Find("dryerManager").GetComponent<dryerScript>().hold2;
		bool in_use = GameObject.Find("dryerManager").GetComponent<dryerScript>().in_use2;
		bool done = GameObject.Find("dryerManager").GetComponent<dryerScript>().done2;


		// If the dryer is not in use, then put cloth to wash
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
					return;
				}

				else {
					GameObject.Find("dryerManager").GetComponent<dryerScript>().hold2 = toDry;
					GameObject.Find("GameManager").GetComponent<managerScript>().numToDry -= hold;
					GameObject.Find("GameManager").GetComponent<managerScript>().numHolding -= hold;
					GameObject.Find("dryerManager").GetComponent<dryerScript>().in_use2 = true;
					GameObject.Find("dryerManager").GetComponent<dryerScript>().done2 = false;
					GameObject.Find("dryerManager").GetComponent<dryerScript>().timeLeft2 = delayTime;
					return;
				}
			}
		}

		// If the dryer is in use but done
		else if (in_use && done) {
			GameObject.Find("GameManager").GetComponent<managerScript>().coins += hold;
			GameObject.Find("dryerManager").GetComponent<dryerScript>().hold2 = 0;
			GameObject.Find("dryerManager").GetComponent<dryerScript>().in_use2 = false;
			GameObject.Find("dryerManager").GetComponent<dryerScript>().done2 = false;
			return;
		
		}
	}
}
