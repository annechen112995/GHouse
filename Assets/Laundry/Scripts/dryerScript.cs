using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dryerScript : MonoBehaviour {
	public bool in_use1;
	public bool done1;
	public int hold1;
	public float timeLeft1;

	public bool in_use2;
	public bool done2;
	public int hold2;
	public float timeLeft2;

	static bool created = false;

	void Start () {
		if (!created) {
			DontDestroyOnLoad(this.gameObject);
			created = true;
			in_use1 = false;
			done1 = false;
			hold1 = 0;
			timeLeft1 = 15f;

			in_use2 = false;
			done2 = false;
			hold2 = 0;
			timeLeft2 = 15f;
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
