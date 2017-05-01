using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour {

	public Sprite empty;
	public Sprite semiFull;
	public Sprite full;
	public Sprite explode;

	int numClothing;
	int currentHold;
	int currentDirty;
	
	int holdingMax = 10;
	// Update is called once per frame
	void Update () {

		// get number of clothing in basket
		numClothing = GameObject.Find("GameManager").GetComponent<managerScript>().numDirtyCloth;

		if (numClothing < 5) {
			this.gameObject.GetComponent<SpriteRenderer>().sprite = empty;
			return;
		}
		if (numClothing < 15) {
			this.gameObject.GetComponent<SpriteRenderer>().sprite = semiFull;
			return;
		}
		if (numClothing < 40) {
			this.gameObject.GetComponent<SpriteRenderer>().sprite = full;
			return;
		}

		// Game Over
		else {
			this.gameObject.GetComponent<SpriteRenderer>().sprite = explode;
			return;
		}
	}


	void OnMouseDown() {
		
		// Get current number of holding and in basket
		// Get cloth from basket if available
		currentHold = GameObject.Find("GameManager").GetComponent<managerScript>().numHolding;
		currentDirty = GameObject.Find("GameManager").GetComponent<managerScript>().numDirtyCloth;

		// if there is capacity for holding and also dirty cloth in basket
		if (currentHold < holdingMax && currentDirty > 0) {

			// maximum possible number to take from basket
			int toTake = holdingMax - currentHold;

			// if there is more capacity for holding than number of dirty cloth
			if (toTake > currentDirty) {
				GameObject.Find("GameManager").GetComponent<managerScript>().numHolding += currentDirty;
				GameObject.Find("GameManager").GetComponent<managerScript>().numToWash += currentDirty;
				GameObject.Find("GameManager").GetComponent<managerScript>().numDirtyCloth -= currentDirty;
			}

			// if there is more dirty cloth in basket than capacity to hold
			else {
				GameObject.Find("GameManager").GetComponent<managerScript>().numHolding += toTake;
				GameObject.Find("GameManager").GetComponent<managerScript>().numToWash += toTake;
				GameObject.Find("GameManager").GetComponent<managerScript>().numDirtyCloth -= toTake;
			}

		}
	}
}
