using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catScript : MonoBehaviour {

	private GameObject gameManager;
	RainManagerScript manager;
	private float catSpeed;
	private Vector3 currDir = Vector3.right;
	private float changeDirTime = 3f;

	// Use this for initialization
	void Start () {
		this.name = "Cat";
		InvokeRepeating ("ChangeDir", changeDirTime, changeDirTime);
		gameManager = GameObject.Find("RainGameManager"); 
		manager = gameManager.GetComponent<RainManagerScript>();
		catSpeed = manager.catSpeed;
	}

	void ChangeDir(){
		int rand = Random.Range (0, 1);
		if (rand == 0){
			currDir = Vector3.right;
		}
		else{
			currDir = Vector3.left;
		}
		changeDirTime = Random.Range (2f, 5f);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < -2.9) {
			currDir = Vector3.right;
		}
		if (transform.position.x > 2.9) {
			currDir = Vector3.left;
		}
		transform.Translate(currDir * catSpeed);
	}
}
