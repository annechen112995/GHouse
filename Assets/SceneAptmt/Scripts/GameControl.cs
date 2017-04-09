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
		if (SceneManager.GetActiveScene().name == "Scene1" || SceneManager.GetActiveScene().name == "ShopScene") {
			if (!aTexture) {
				return;
			}
			GUI.DrawTexture(new Rect(0, 15, 70, 70), aTexture, ScaleMode.ScaleToFit);
			GUI.Label(new Rect(50, 18, 200, 50), numCoins.ToString(), guiStyle);
		}
	}

	void Update() {
		OnGUI();
	}
}