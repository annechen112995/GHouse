using UnityEngine;
using System.Collections;

public class FridgeClean_Apple : MonoBehaviour
{
	private GameObject player;	//The player
	private Vector3 screen;

	void Start ()
	{
		//Find the player
		player = GameObject.Find("Player");
	}

	void Update ()
	{
		//Set screen position
		screen = Camera.main.WorldToScreenPoint(transform.position);
	}

	public void Hit()
	{
		
		//Set player lives to 0
		player.GetComponent<FridgeClean_Player>().lives--;
	}
}
