using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScroll_hallway : MonoBehaviour {

	public float speed = 0.7F;
	public float x_max = (float) 16;

	//Update is called once per frame
	void FixedUpdate() {
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			transform.Translate (-touchDeltaPosition.x * speed * Time.deltaTime, 
				0, 0);
			transform.position = new Vector3(
				Mathf.Clamp(transform.position.x, 0, x_max),
				Mathf.Clamp(transform.position.y, 0, 0),
				Mathf.Clamp(transform.position.z, -10, -10));
		}

	}
}
