using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehaviourScript : MonoBehaviour {

	public float spawnTime;				//Spawn Time
	public float spawnRate = 1;
	public GameObject Apple;			//Apple prefab
	public GameObject AppleCore;		//AppleCore prefab

	public int count = 0;
	public bool spawned = false;

	void Start()
	{
		//Start the spawn update
		//call SpawnEnemy based on spawnRate
		InvokeRepeating("Spawn", 1, spawnRate);  
	}

	void Update()
	{
		
	}

	public void Spawn()
	{
		GameObject prefab = Apple;
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

}
