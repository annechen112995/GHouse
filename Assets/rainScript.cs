using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainScript : MonoBehaviour {
	private bool startDie = false;
	public GameObject cat;
	public GameObject umbrella;
	private float health;
	private float rainSpeed;
	private GameObject gameManager;
	RainManagerScript manager;



	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("RainGameManager"); 
		manager = gameManager.GetComponent<RainManagerScript>();
	}

	void hit() {
		Object.Destroy (this.gameObject);
		manager.health -= 1;
		if (manager.health < 1) {
			manager.CancelInvoke ();
			PlayerPrefs.SetInt("coins", manager.score + PlayerPrefs.GetInt("coins"));
			PlayerPrefs.Save();
		}
	}

	void die() {
		Object.Destroy (this.gameObject);
	}

	void OnTriggerEnter(Collider col){
		
		if (col.gameObject.name == "Cat") {
			hit ();
		}
		if (col.gameObject.name == "Umbrella") {
			die ();
		}
	}

	void OnBecameInvisible() {
		Destroy (gameObject);
	}

	// Update is called once per frame
	void Update () {
		
		rainSpeed = manager.rainSpeed;
		if (Mathf.Abs (transform.position.x) < 3f && Mathf.Abs (transform.position.y) < 5f) {
			startDie = true;
		}
		if (startDie) {
			if (Mathf.Abs (transform.position.x) > 3f || Mathf.Abs (transform.position.y) > 5f) {
				die ();
			}
		}

		transform.Translate(Vector3.down * rainSpeed);

	}
		
}
