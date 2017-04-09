﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		double half = Screen.width / 2.0;
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Stationary) {
			Vector2 touchPos = Input.GetTouch (0).position;
			if (touchPos.x < half) {
				transform.Translate (Vector3.left * 5f * Time.deltaTime);
			} else {
				transform.Translate (Vector3.right * 5f * Time.deltaTime);
			}
		}
	}
		

}
