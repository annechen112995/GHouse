using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

	public Texture aTexture;

	private int numCoins = -1;

	private GUIStyle guiStyle = new GUIStyle(); //create a new variable

	void Start() {
		numCoins = PlayerPrefs.GetInt("coins");

	}

	void OnGUI() {
		numCoins = PlayerPrefs.GetInt("coins");
		guiStyle.fontSize = 50; //change the font size
		if (SceneManager.GetActiveScene().name == "Scene1") {
			if (!aTexture) {
				return;
			}
			GUI.DrawTexture(new Rect(20, 20, 200, 50), aTexture, ScaleMode.ScaleToFit, true, 10.0F);
			GUI.Label (new Rect(30, 20, 200, 50), numCoins.ToString(), guiStyle);
		}
	}

	void Update() {
		OnGUI();
	}
}