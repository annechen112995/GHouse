using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LaunchFridgeGame : MonoBehaviour {

	public void ClickFridge(string levelName) {

		// Going from Start Scene to Apartment Scene when button clicked
		SceneManager.LoadScene("Scene2");
	}
}