using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roachScript : MonoBehaviour {
	private bool startDie = false;
	public float speed;
	private GameObject gameManager;
	cockroachManagerScript manager;


	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("GameManager"); 
		manager = gameManager.GetComponent<cockroachManagerScript>();
		speed = manager.currSpeed;
		
	}
	void die() {
		Object.Destroy (this.gameObject);
		manager.lives -= 1;
		if (manager.lives < 1) {
			manager.CancelInvoke ();
		}
	}

	void OnMouseDown(){
		Object.Destroy (this.gameObject);
		manager.score += 1;
	}
	// Update is called once per frame
	void Update () {
		speed = manager.currSpeed;
		if (Mathf.Abs (transform.position.x) < 3f && Mathf.Abs (transform.position.y) < 5f) {
			startDie = true;
		}
		if (startDie) {
			if (Mathf.Abs (transform.position.x) > 3f || Mathf.Abs (transform.position.y) > 5f) {
				die ();
			}
		}
			
		transform.Translate(Vector3.up * speed);
	}
}
