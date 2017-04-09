using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class liveScript : MonoBehaviour {
	
	private GameObject gameManager;
	managerScript manager;
	public Sprite heart3;
	public Sprite heart2;
	public Sprite heart1;
	public Sprite heart0;
	private Sprite[] heartArray;
	private int hearts;

	// Use this for initialization
	void Start () {
		heartArray = new Sprite[]{heart0,heart1,heart2,heart3};
		gameManager = GameObject.Find("GameManager"); 
		manager = gameManager.GetComponent<managerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		hearts = manager.lives;
		if (hearts < 3 && hearts > -1) {
			GetComponent<SpriteRenderer> ().sprite = heartArray [hearts];
		}

		
	}
}
