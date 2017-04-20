using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitScript : MonoBehaviour {
	/*private GameObject gameManager;
	snakeManagerScript manager;*/

	// Use this for initialization
	void Start () {
		/*gameManager = GameObject.Find("GameManager"); 
		manager = gameManager.GetComponent<snakeManagerScript>();*/
	}

	public void ClickQuit(string sceneName) {
		/*PlayerPrefs.SetInt("coins", manager.score + PlayerPrefs.GetInt("coins"));
		PlayerPrefs.Save();*/
		SceneManager.LoadScene(sceneName);
	}

	// Update is called once per frame
	void Update () {

	}
}
