using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

	public static GameControl control;

	public float numCoins;

	private GUIStyle guiStyle = new GUIStyle(); //create a new variable

	void Awake () {
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} else if (control != this) {
			Destroy (gameObject);
		}
	}

	void OnGUI() {
		guiStyle.fontSize = 50; //change the font size

		GUI.Label (new Rect (20, 20, 200, 50), "Coins: " + numCoins, guiStyle);
	}
}