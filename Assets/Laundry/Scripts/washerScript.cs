using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class washerScript : MonoBehaviour {
	public bool in_use1 = false;
	public bool done1 = false;
	public int hold1 = 0;
	public float timeLeft1 = 12f;

	public bool in_use2 = false;
	public bool done2 = false;
	public int hold2 = 0;
	public float timeLeft2 = 12f;

	static bool created = false;

	

	void Start () {
		if (!created) {
			DontDestroyOnLoad(this.gameObject);
			created = true;
		}
		else {
			Destroy(this.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
				// Counting wash cycle
		timeLeft1 -= Time.deltaTime;
        if(timeLeft1 < 0)
        {
             done1 = true;
        }

		// Counting wash cycle
		timeLeft2 -= Time.deltaTime;
        if(timeLeft2 < 0)
        {
             done2 = true;
        }
		
	}
}
