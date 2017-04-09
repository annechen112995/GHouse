using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehaviourScript : MonoBehaviour {

	public float spawnTime;				//Spawn Time
	public GameObject Apple;			//Apple prefab
	public GameObject AppleCore;		//AppleCore prefab
	public float maxX;					//Max x spawn position
	public float minX;					//Min x spawn position
	private float height;
	private float timeLimit;
	private bool clicked;
	private int numFood = 0;
	public bool spawned = false;

	public void Trigger(float tl)
	{
		clicked = false;
		timeLimit = tl;
	}

	void Start()
	{
		timeLimit = 3.0f;

		if (numFood < 2 && spawned == false) 
		{
			spawned = true; 
			numFood += 1;
			//Start the spawn update
			StartCoroutine("Spawn");
		}
	}

	IEnumerator Spawn()
	{
		//Wait spawnTime
		yield return new WaitForSeconds(spawnTime);
		//Spawn prefab is apple
		GameObject prefab = Apple;
		Apple.SetActive (true);
		//If random is over 30
		if (Random.Range(0,100) < 30)
		{
			//Spawn prefab is apple core
			prefab = AppleCore;
			AppleCore.SetActive (true);
		}
		StartCoroutine (MainLoop (prefab));
		//Spawn prefab add random position
		GameObject go = Instantiate (prefab, new Vector3 (Random.Range (-50, 60), Random.Range (-60, 50), 0),
			Quaternion.Euler (0, 0, Random.Range (-100, 50))) as GameObject;
		spawned = false;
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
