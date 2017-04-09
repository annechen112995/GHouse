using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LaunchGame : MonoBehaviour {

	public void ClickGame(string levelName) {

		// Going from Start Scene to Apartment Scene when button clicked
		SceneManager.LoadScene(levelName);
	}
}