using UnityEngine;
using System.Collections;

public class FridgeClean_Apple : MonoBehaviour
{
	private bool canBeDead;		//If we can destroy the object
	private Vector3 screen;		//Position on the screen
	private GameObject player;	//The player

	private float timeLimit = 3.0f;
	private float time;

	void Start ()
	{
		//Find the player
		player = GameObject.Find("Player");
	}

	void Update ()
	{
		//Set screen position
		screen = Camera.main.WorldToScreenPoint(transform.position);

		WaitForHit();

		//If we can die and are not on the screen
		if (canBeDead && time >= timeLimit)
		{
			//Destroy
			Destroy(gameObject);
		}
		//If we cant die and are on the screen
		else if (!canBeDead && time < timeLimit)
		{
			//We can die
			canBeDead = true;
		}

	}

	// Give the player a chance to click the food.
	private IEnumerator WaitForHit()
	{
		float time = 0.0f;

		while(Input.touchCount != 1 && time < timeLimit)
		{
			time += Time.deltaTime;
			yield return time;
		}	
	}

	public void Hit()
	{
		//Set player lives to 0
		player.GetComponent<FridgeClean_Player>().lives = 0;
		//Destroy
		Destroy(gameObject);
	}
}
