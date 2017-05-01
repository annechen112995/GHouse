using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateUI : MonoBehaviour {
	int wash;
	int dry;
	int holding;
	int dirty;
	int score;

	public Text numDirty;
	public Text numHold;
	public Text numWash;
	public Text numDry;
	public Text numScore;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        wash = GameObject.Find("GameManager").GetComponent<managerScript>().numToWash;
	    dry = GameObject.Find("GameManager").GetComponent<managerScript>().numToDry;
	    holding =  GameObject.Find("GameManager").GetComponent<managerScript>().numHolding;
		dirty =  GameObject.Find("GameManager").GetComponent<managerScript>().numDirtyCloth;
		score =  GameObject.Find("GameManager").GetComponent<managerScript>().coins;


		// update counter display
		numDirty.text = "Dirty Clothes in Basket: " + dirty;
		numHold.text = "Holding: " + holding + "/ 10";
		numWash.text = "Waiting to Wash: " + wash;
		numDry.text = "Waitingto Dry: " + dry;
		numScore.text = "Score: " + score;
		
	}
}
