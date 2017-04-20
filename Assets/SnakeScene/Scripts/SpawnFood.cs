/*
 * Filename: SpawnFood.cs
 * Author: Jocelyn Wei
 * Description: Script that makes food spwan in the "Snake"-based minigame
 * Date: April 19, 2017
 * Sources of help: https://noobtuts.com/unity/2d-snake-game
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour {

	// Fish Prefab
	public GameObject fishPrefab;

	// Borders of type Transform (access positions like borderTop.position)
	public Transform borderTop;
	public Transform borderBottom;
	public Transform borderLeft;
	public Transform borderRight;
	private int INTERVAL = 2;
	private int START_TIME = 2;

	/*
	 * Function Name: Start()
	 * Function Prototype: void Start();
	 * Description: Used for initialization
	 * Parameters: None.
	 * Side Effects:
	 * Error Conditions: None.
	 * Return Value: None.
	 */
	void Start () {
		// Spawn food every INTERVAL seconds, starting at START_TIME
		InvokeRepeating ("Spawn", INTERVAL, START_TIME);
	}

	/*
	 * Function Name: Spawn()
	 * Function Prototype: void Spawn();
	 * Description: Spawns one piece of food.
	 * Parameters: None.
	 * Side Effects:
	 * Error Conditions: None.
	 * Return Value: None.
	 */
	void Spawn() {

		// Generate random (x,y) position where x, y are integers
		// left border < x position < right border
		int x = (int)Random.Range (borderLeft.position.x,
			        			   borderRight.position.x);
		
		// top border < y position < bottom border
		int y = (int)Random.Range (borderBottom.position.y,
			       				   borderTop.position.y);

		// Instantiate food at position (x,y)
		Instantiate(fishPrefab, 
			 		new Vector2(x,y), 
					Quaternion.identity); // default rotation
	}
}
