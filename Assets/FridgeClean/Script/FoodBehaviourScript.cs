using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehaviourScript : MonoBehaviour {

	public float spawnTime;				//Spawn Time
	public GameObject Apple;			//Apple prefab
	public GameObject AppleCore;		//AppleCore prefab

	public int count = 0;
	public bool spawned = false;

	void Start()
	{
		//Start the spawn update
		StartCoroutine("Spawn");
	}

	void Update()
	{
		if (count < 5) 
		{
			spawned = false;
			StartCoroutine("Spawn");
		}
	}

	IEnumerator Spawn()
	{
		while (count < 4 && spawned == false) 
		{
			count += 1;
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
			}
				//Spawn prefab add random position
				GameObject go = Instantiate (prefab, new Vector3 (Random.Range (-50, 60), Random.Range (-60, 50), 0),
					Quaternion.Euler (0, 0, Random.Range (-100, 50))) as GameObject;
		}
		spawned = true;
	}

}
