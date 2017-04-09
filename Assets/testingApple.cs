using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testingApple : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		Object.Destroy (this.gameObject);
	}
}
