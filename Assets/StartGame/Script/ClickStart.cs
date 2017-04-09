using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ClickStart : MonoBehaviour {

	public void Click(string levelName) {

		// Going from Start Scene to Apartment Scene when button clicked
		PlayerPrefs.SetInt( "previousLevel", (SceneManager.GetActiveScene()).buildIndex );
		SceneManager.LoadScene(levelName);

	}
}