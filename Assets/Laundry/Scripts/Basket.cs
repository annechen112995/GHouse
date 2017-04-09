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
	
	// Update is called once per frame
	void Update () {
		
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
		else {
			this.gameObject.GetComponent<SpriteRenderer>().sprite = explode;
			return;
		}
	}


	void OnMouseDown() {
		
		currentHold = GameObject.Find("GameManager").GetComponent<managerScript>().numHolding;
		currentDirty = GameObject.Find("GameManager").GetComponent<managerScript>().numDirtyCloth;

		// if there is room and also dirty cloth
		if (currentHold < 10 && currentDirty > 0) {

			// maximum possible take
			int toTake = 10 - currentHold;

			// if there is more room than number of dirty cloth
			if (toTake > currentDirty) {
				GameObject.Find("GameManager").GetComponent<managerScript>().numHolding += currentDirty;
				GameObject.Find("GameManager").GetComponent<managerScript>().numToWash += currentDirty;
				GameObject.Find("GameManager").GetComponent<managerScript>().numDirtyCloth -= currentDirty;
			}

			// if there is more dirty cloth than room
			else {
				GameObject.Find("GameManager").GetComponent<managerScript>().numHolding += toTake;
				GameObject.Find("GameManager").GetComponent<managerScript>().numToWash += toTake;
				GameObject.Find("GameManager").GetComponent<managerScript>().numDirtyCloth -= toTake;
			}

		}
	}
}
