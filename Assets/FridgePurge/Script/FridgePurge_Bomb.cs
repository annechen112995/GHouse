using UnityEngine;
using System.Collections;

public class FridgePurge_Bomb : MonoBehaviour
{
	private bool canBeDead;		//If we can destroy the object
	private Vector3 screen;		//Position on the screen
	private GameObject player;	//The player
	
	void Start ()
	{
		//Find the player
		player = GameObject.Find("Player");
	}
	
	void Update ()
	{
		//Set screen position
		screen = Camera.main.WorldToScreenPoint(transform.position);
		//If we can die and are not on the screen
		if (canBeDead && screen.y < -20)
		{
			//Destroy
			Destroy(gameObject);
		}
		//If we cant die and are on the screen
		else if (!canBeDead && screen.y > -10)
		{
			//We can die
			canBeDead = true;
		}
		
		//Rotate
		transform.Rotate(new Vector3(0,0,50) * Time.deltaTime);
	}
	
	public void Hit()
	{
		//Set player lives to 0
		player.GetComponent<FridgePurge_Player>().lives = 0;
		//Destroy
		Destroy(gameObject);
	}
}
