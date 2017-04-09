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

	void Start()
	{
		//Start the spawn update
		StartCoroutine("Spawn");
	}

	IEnumerator Spawn()
	{
		//Wait spawnTime
		yield return new WaitForSeconds(spawnTime);
		//Spawn prefab is apple
		GameObject prefab = Apple;
		//If random is over 30
		if (Random.Range(0,100) < 30)
		{
			//Spawn prefab is bomb
			prefab = AppleCore;
		}
		//Spawn prefab add randomc position
		GameObject go = Instantiate(prefab,new Vector3(Random.Range(minX,maxX + 1),transform.position.y,0),Quaternion.Euler(0,0,Random.Range(-50, 50))) as GameObject;

		//Start the spawn again
		StartCoroutine("Spawn");
	}
}
