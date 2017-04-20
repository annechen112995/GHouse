/*
 * Filename: SnakeScript.cs
 * Author: Jocelyn Wei
 * Description: Script that defines Snake/Cat behavior; uses BoxColliders with
 *              isTrigger option selected.
 * Date: April 19, 2017
 * Sources of help: https://noobtuts.com/unity/2d-snake-game
 *                  Followed the above tutorial; altered code, to work
 *                  on Android platform (touch input instead of keys, etc.).
 *                  Also consulted rainScript.cs/RainManagerScript.cs for 
 *                  implementation of OnTriggerEnter function
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; // List functionality
using UnityEngine.SceneManagement;

public class SnakeScript : MonoBehaviour {

	// How fast the Cat moves (300ms)
	public float movementSpeed = 0.4f;
	// Current Movement Direction (by default to the right)
	Vector2 dir = Vector2.right;
	Vector2 moveDir = Vector2.right;
	public string gameOver = "GameOver";

	// Cat's tail
	List<Transform> tail = new List<Transform>();

	// Did the Cat eat?
	bool ate = false;
	bool gameEnd = false;

	// Tail prefab
	public GameObject tailPrefab;

	float delta;


	// Use this for initialization
	void Start() {
		// Move the "Snake" / Cat every 300ms
		InvokeRepeating("Move", movementSpeed, movementSpeed);
		Debug.Log("Started.");
	}

	// Update is called once per frame
	void Update() {



		// Check if Cat should move in a new direction
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			// Get movement of the finger since last frame
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

			delta = Mathf.Max (Mathf.Abs (touchDeltaPosition.x), 
							   Mathf.Abs (touchDeltaPosition.y));
			if (Mathf.Abs(touchDeltaPosition.x) == delta && touchDeltaPosition.x > 0) {
				dir = Vector2.right;
			} else if (Mathf.Abs(touchDeltaPosition.x) == delta && touchDeltaPosition.x < 0) {
				dir = -Vector2.right;
			} else if (Mathf.Abs(touchDeltaPosition.y) == delta && touchDeltaPosition.y > 0) {
				dir = Vector2.up;
			} else if (Mathf.Abs(touchDeltaPosition.y) == delta && touchDeltaPosition.y < 0) {
				dir = -Vector2.up;
			}
		}
	}

	void Move() {
		if (gameEnd) {
			return;
		}

		// Move Cat in new direction

		// If the new direction does not conflict with the old, then update it
		if (dir != moveDir) {
			if (moveDir == -Vector2.right) {
				if (dir != Vector2.right)
					moveDir = dir;
			} else if (moveDir == Vector2.right) {
				if (dir != -Vector2.right)
					moveDir = dir;
			} else if (moveDir == Vector2.up) {
				if (dir != -Vector2.up)
					moveDir = dir;
			} else if (moveDir == -Vector2.up) {
				if (dir != Vector2.up)
					moveDir = dir;
			}
		}

		// Save current position (gap will be here)
		Vector2 v = transform.position;

		// Each time "move" is called, move once forward
		transform.Translate (moveDir);

		// If cat just ate food, add a piece to tail
		if (ate) {

			// Oooox - before move is called
			// Oooo x - move is called, snake has eaten:
			// Oooo0x - new segment 0 is placed in gap

			// Load Prefab into game
			GameObject g = (GameObject)Instantiate (tailPrefab, v, Quaternion.identity);

			// Keep track of it in our tail list
			tail.Insert (0, g.transform);

			// Reset flag; finished eating
			ate = false;

		// If we have a tail and didn't eat, just move forward one
		} else if (tail.Count > 0) {

			// Oooox - before move is called
			// Oooo x - move is called
			//  oooOx - last tail piece moves into gap

			// Move last tail element to where head was
			tail.Last ().position = v;

			// Add to front of list, remove from back
			tail.Insert (0, tail.Last ());
			tail.RemoveAt (tail.Count - 1);

		}

	}

	/*
	 * Function Name: OnTriggerEnter()
	 * Function Prototype: void OnTriggerEnter(Collider coll);
	 * Description: Takes care Cat colliding with food, wall, tail
	 * Parameters: arg1 - Collider coll -- Collider Triggered
	 * Side Effects: May set either "ate" or "gameEnd" to true
	 * Error Conditions: None.
	 * Return Value: None.
	 */
	void OnTriggerEnter(Collider coll) {
		// food?
		Debug.Log("Entered");
		if (coll.name.StartsWith("GreenFishPrefab")) {
			// Get longer in next Move call
			ate = true;

			// Remove the Food
			Destroy (coll.gameObject);

		} else {
			// "Game Over" Scene
			gameEnd = true;
			SceneManager.LoadScene(gameOver);
		}
	}

}