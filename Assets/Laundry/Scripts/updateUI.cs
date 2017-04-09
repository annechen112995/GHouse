using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateUI : MonoBehaviour {
	int toWash;
	int toDry;
	int holding;
	int dirty;

	public Text numDirty;
	public Text numHold;
	public Text numWash;
	public Text numDry;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        toWash = GameObject.Find("GameManager").GetComponent<managerScript>().numToWash;
	    toDry = GameObject.Find("GameManager").GetComponent<managerScript>().numToDry;
	    holding =  GameObject.Find("GameManager").GetComponent<managerScript>().numHolding;
		dirty =  GameObject.Find("GameManager").GetComponent<managerScript>().numDirtyCloth;

		// update counter display
		numDirty.text = "Dirty Clothes: " + dirty;
		numHold.text = "Holding: " + holding + "/ 10";
		numWash.text = "Need to Wash: " + toWash;
		numDry.text = "Need to Dry: " + toDry;
		
	}
}
