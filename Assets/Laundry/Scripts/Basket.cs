using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour {

	public Sprite empty;
	public Sprite semiFull;
	public Sprite full;
	public Sprite explode;

	int numClothing;

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
		if (numClothing < 25) {
			this.gameObject.GetComponent<SpriteRenderer>().sprite = full;
			return;
		}
		else {
			this.gameObject.GetComponent<SpriteRenderer>().sprite = explode;
			return;
		}
	}
}
