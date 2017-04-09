using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehaviourScript : MonoBehaviour {

	public float spawnTime;				//Spawn Time
	public GameObject Apple;			//Apple prefab
	public GameObject AppleCore;		//AppleCore prefab
	public float upForce = 750;			//Up force
	public float leftRightForce = 200;	//Left and right force
	public float maxX;					//Max x spawn position
	public float minX;					//Min x spawn position
	private float height;
	private float speed;
	private float timeLimit;
	private bool clicked;

	private Transform colliderTransform;

	public Transform ColliderTransform
	{
		get
		{
			return colliderTransform;
		}
	}

	public void Trigger(float tl)
	{
		clicked = false;
		timeLimit = tl;
	}

	void Start()
	{
		timeLimit = 1.0f;
		speed = 2.0f;

		//Start the spawn update
		StartCoroutine("Spawn");
	}

	IEnumerator Spawn()
	{
		//Wait spawnTime
		yield return new WaitForSeconds(spawnTime);
		//Spawn prefab is apple
		GameObject prefab = Apple;
		Apple.SetActive (true);
		StartCoroutine (MainLoop(Apple));
		//If random is over 30
		if (Random.Range(0,100) < 30)
		{
			//Spawn prefab is apple core
			prefab = AppleCore;
			AppleCore.SetActive (true);
			StartCoroutine (MainLoop(AppleCore));
		}
		//Spawn prefab add randomc position
		GameObject go = Instantiate(prefab,new Vector3(Random.Range(minX,maxX + 1),transform.position.y,0),Quaternion.Euler(0,0,Random.Range(-50, 50))) as GameObject;
		//If x position is over 0 go left
		if (go.transform.position.x > 0)
		{
			go.GetComponent<Rigidbody2D>().AddForce(new Vector3(-leftRightForce,upForce,0));
		}
		//Else go right
		else
		{
			go.GetComponent<Rigidbody2D>().AddForce(new Vector3(leftRightForce,upForce,0));
		}
		//Start the spawn again
		//StartCoroutine("Spawn");
	}

	// Main loop for the sprite.  Move up, then wait, then move down again. Simple.
	private IEnumerator MainLoop(GameObject sprite)
	{
		yield return StartCoroutine(WaitForHit(sprite));
	}

	// Give the player a chance to click the fruit.
	private IEnumerator WaitForHit(GameObject sprite)
	{
		float time = 0.0f;

		while(!clicked && time < timeLimit)
		{
			time += Time.deltaTime;
			yield return null;
		}	
	}

	// Food has been clicked
	public void Click(GameObject sprite)
	{
		clicked = true;
		sprite.SetActive(false);
	}

	public bool Clicked
	{
		get
		{
			return clicked;	
		}
	}
}
