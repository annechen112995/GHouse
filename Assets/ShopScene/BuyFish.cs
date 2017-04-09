using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyFish : MonoBehaviour {

	public void ClickFish() {
		// Clicked fish, decrease number of coins
		if ((PlayerPrefs.GetInt("coins") - 15) > 0) {
			PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt ("coins") - 15);
		} else {
			PlayerPrefs.SetInt("coins", 0);
		}
	}

}
