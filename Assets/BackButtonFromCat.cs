using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonFromCat : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		// From the Apartment Scene
		// If Android's Back Button is pressed, go back to the Previous Scene (Start Scene)
		if (Input.GetKeyUp (KeyCode.Escape)) {
			Destroy(this.gameObject);
			SceneManager.LoadScene ("Scene1");
		}
	}
}