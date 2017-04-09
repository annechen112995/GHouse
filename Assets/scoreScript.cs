using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour {
	Text currScore;
	private GameObject gameManager;
	managerScript manager;


	// Use this for initialization
	void Start () {
		currScore = GetComponent<UnityEngine.UI.Text>();
		gameManager = GameObject.Find("GameManager"); 
		manager = gameManager.GetComponent<managerScript>();
		
	}
	
	// Update is called once per frame
	void Update () {
		currScore.text = manager.score.ToString();
	}
}
