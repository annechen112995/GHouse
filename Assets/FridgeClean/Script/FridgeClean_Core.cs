using UnityEngine;
using System.Collections;

public class FridgeClean_Core : MonoBehaviour
{
	public GameObject splat;	//The splat prefab of the fruit

	private bool canBeDead;		//If we can destroy the object
	private Vector3 screen;		//Position on the screen
	private GameObject player;	//The player

	private float timeLimit = 3.0f;
	private float time;

	void Start ()
	{
		//If we tag is Untagged
		if (gameObject.tag == "Untagged")
		{
			//Find player
			player = GameObject.Find("Player");
		}
	}

	void Update ()
	{
		//Set screen position
		screen = Camera.main.WorldToScreenPoint(transform.position);
		if (canBeDead && time < timeLimit) 
		{
			WaitForHit();
		}
		//If we can die and are not on the screen
		if (canBeDead && time >= timeLimit)
		{
			//If our tag is a core
			if (gameObject.tag == "Untagged")
			{
				//Remove 1 lives from the player
				player.GetComponent<FridgeClean_Player>().lives--;
			}
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
		GameObject go = null;
	
		//Spawn splat prefab of the core
		Instantiate(splat,new Vector3(transform.position.x,transform.position.y,1),Quaternion.identity);

		//Destroy
		Destroy(gameObject);
	}
}
