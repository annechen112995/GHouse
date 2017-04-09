using UnityEngine;
using System.Collections;

public class FridgePurge_Fruit : MonoBehaviour
{
	public GameObject left;		//The left prefab of the fruit
	public GameObject right;	//The right prefab of the fruit
	public GameObject splat;	//The splat prefab of the fruit
	public float force;			//The left and right force
	public float torque;		//The rotation speed after we are hit
	
	private bool canBeDead;		//If we can destroy the object
	private Vector3 screen;		//Position on the screen
	private GameObject player;	//The player
	private float rotDir = 50;	//The rotate spped

	void Start ()
	{
		//If we tag is Fruit
		if (gameObject.tag == "Fruit")
		{
			//Find player
			player = GameObject.Find("Player");
		}
		//If random is 1
		if (Random.Range(0,2) > 0)
		{
			//Change rotate speed
			rotDir = -rotDir;
		}
	}
	
	void Update ()
	{
		//Set screen position
		screen = Camera.main.WorldToScreenPoint(transform.position);
		//If we can die and are not on the screen
		if (canBeDead && screen.y < -20)
		{
			//If we tag is Fruit
			if (gameObject.tag == "Fruit")
			{
				//Remove 1 lives from the player
				player.GetComponent<FridgePurge_Player>().lives--;
			}
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
		transform.Rotate(new Vector3(0,0,rotDir) * Time.deltaTime);
	}
	
	public void Hit()
	{
		GameObject go = null;
		//Spawn left prefab of the fruit
		go = Instantiate(left,transform.position,transform.rotation) as GameObject;
		//Add force
		go.GetComponent<Rigidbody>().AddForce(-transform.right * force);
		//Add torque
		go.GetComponent<Rigidbody>().AddTorque(new Vector3(0,0,torque));
		
		//Spawn right prefab of the fruit
		go = Instantiate(right,transform.position,transform.rotation) as GameObject;
		//Add force
		go.GetComponent<Rigidbody>().AddForce(transform.right * force);
		//Add torque
		go.GetComponent<Rigidbody>().AddTorque(new Vector3(0,0,-torque));
		
		//Spawn splat prefab of the fruit
		Instantiate(splat,new Vector3(transform.position.x,transform.position.y,1),transform.rotation);
		
		//Destroy
		Destroy(gameObject);
	}
}
