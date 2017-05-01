using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class game_over : MonoBehaviour {

	public Text display;

	int score = 0; 

	void Start() {
		score =  GameObject.Find("GameManager").GetComponent<managerScript>().coins;
		Destroy(GameObject.Find("GameManager"));
		display.text = "You have washed " + score + " dirty clothes. \n\n Score: " + score;
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
}
