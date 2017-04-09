using UnityEngine;
using System.Collections;

public class FridgeClean_Core : MonoBehaviour
{
	public GameObject splat;	//The splat prefab of the fruit
	private Vector3 screen;
	private GameObject player;	//The player

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
	}

	public void Hit()
	{
		GameObject go = null;
		//Spawn splat prefab of the core
		Instantiate(splat,new Vector3(transform.position.x,transform.position.y,1),Quaternion.identity);
	}
}
