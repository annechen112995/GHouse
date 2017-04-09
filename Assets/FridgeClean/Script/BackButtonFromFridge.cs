﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonFromFridge : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		// From the Apartment Scene
		// If Android's Back Button is pressed, go back to the Previous Scene (Start Scene)
		if (Input.GetKeyUp (KeyCode.Escape)) {
			SceneManager.LoadScene ("Scene1");
		}
	}
}
