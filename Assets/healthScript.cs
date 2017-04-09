using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthScript : MonoBehaviour {
	private GameObject gameManager;
	RainManagerScript manager;


	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("RainGameManager"); 
		manager = gameManager.GetComponent<RainManagerScript>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (manager.health > 0) {
			transform.localScale = new Vector3 ((manager.health / 100f) * 10f, 2f, 1f);
		}
		
	}
}
