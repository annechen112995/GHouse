﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dryerScript : MonoBehaviour {
	// stats for dryer 1
	public bool in_use1;
	public bool done1;
	public int hold1;
	public float timeLeft1;

	// stats for dryer 2
	public bool in_use2;
	public bool done2;
	public int hold2;
	public float timeLeft2;

	static bool created = false;

	// initializing the dryer manager
	void Start () {
		if (!created) {
			DontDestroyOnLoad(this.gameObject);
			created = true;

			in_use1 = false;
			done1 = false;
			hold1 = 0;
			timeLeft1 = 13f;

			in_use2 = false;
			done2 = false;
			hold2 = 0;
			timeLeft2 = 13f;
		}
		else {
			Destroy(this.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {

		// Counting wash cycle for dryer 1
		timeLeft1 -= Time.deltaTime;
        if(timeLeft1 < 0) {
             done1 = true;
			 GameObject.Find("dryer1").gameObject.GetComponent<SpriteRenderer>().sprite = 
			  			GameObject.Find("dryer1").gameObject.GetComponent<dryer1>().done;
        }

		// Counting wash cycle for dryer 2
		timeLeft2 -= Time.deltaTime;
        if(timeLeft2 < 0) {
             done2 = true;
			 GameObject.Find("dryer2").gameObject.GetComponent<SpriteRenderer>().sprite = 
			  			GameObject.Find("dryer2").gameObject.GetComponent<dryer2>().done;
        }
	}
}
