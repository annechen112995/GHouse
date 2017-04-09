using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehaviourScript : MonoBehaviour {

	public float spawnTime;				//Spawn Time
	public GameObject Apple;			//Apple prefab
	public GameObject AppleCore;		//AppleCore prefab
	public float maxX;					//Max x spawn position
	public float minX;		 			//Min x spawn position

	public int count = 0;
	public bool spawned = false;

	void Start()
	{
		spawned = false;
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
		//If random is over 30
		if (Random.Range(0,100) < 30)
		{
			//Spawn prefab is apple core
			prefab = AppleCore;
		}

		if (count < 1 && spawned == false) {
			count += 1;
			spawned = true;
			//Spawn prefab add random position
			GameObject go = Instantiate (prefab, new Vector3 (Random.Range (-50, 60), Random.Range (-60, 50), 0),
				Quaternion.Euler (0, 0, Random.Range (-100, 50))) as GameObject;
		}
	}

}
