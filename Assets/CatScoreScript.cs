using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatScoreScript : MonoBehaviour {
	Text currScore;
	private GameObject gameManager;
	RainManagerScript manager;


	// Use this for initialization
	void Start () {
		currScore = GetComponent<UnityEngine.UI.Text>();
		gameManager = GameObject.Find("RainGameManager"); 
		manager = gameManager.GetComponent<RainManagerScript>();

	}

	// Update is called once per frame
	void Update () {
		currScore.text = manager.score.ToString();
	}
}
