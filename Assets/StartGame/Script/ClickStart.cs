using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickStart : MonoBehaviour {

	public void Click(string levelName) {
		Application.LoadLevel("Scene1");
	}
}