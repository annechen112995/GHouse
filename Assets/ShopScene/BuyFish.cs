using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuyFish : MonoBehaviour {

	public Texture aTexture;
	private int numCoins = -1;

	private GUIStyle guiStyle = new GUIStyle(); //create a new variable
	void Start() {
		numCoins = PlayerPrefs.GetInt("coins");
	}

	public void ClickFish() {
		// Clicked fish, decrease number of coins
		if ((PlayerPrefs.GetInt("coins") - 15) > 0) {
			PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt ("coins") - 15);
		}
	}

	public void ClickFish2() {
		// Clicked fish, decrease number of coins
		if ((PlayerPrefs.GetInt("coins") - 25) > 0) {
			PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt ("coins") - 25);
		}
	}

	void OnGUI() {
		numCoins = PlayerPrefs.GetInt("coins");
		guiStyle.fontSize = 50; //change the font size
		if (SceneManager.GetActiveScene().name == "Scene1" || SceneManager.GetActiveScene().name == "ShopScene") {
			if (!aTexture) {
				return;
			}
			GUI.DrawTexture(new Rect(0, 15, 70, 70), aTexture, ScaleMode.ScaleToFit);
			GUI.Label(new Rect(55, 18, 200, 50), numCoins.ToString(), guiStyle);
		}
	}

	void Update() {
		OnGUI();
	}

}
