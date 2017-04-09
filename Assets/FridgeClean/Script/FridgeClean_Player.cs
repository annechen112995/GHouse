using UnityEngine;
using System.Collections;

public class FridgeClean_Player : MonoBehaviour
{
	public FoodBehaviourScript foodBehav;
	public GUISkin skin;	//GUI Skin
	public int score;		//Score
	public int lives = 3;		//Lives
	public int count = 6;

	public GameObject splat;

	private Vector3 pos;	//Position
	private bool dead = false;		//If we are dead

	private float timeLimit = 3.0f;

	void Start ()
	{
		//Set screen orientation to landscape
		Screen.orientation = ScreenOrientation.Portrait;
		//Set sleep timeout to never
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		foodBehav = this.gameObject.GetComponent<FoodBehaviourScript>();
	}

	void Update ()
	{
		WaitForHit();
		//If dead
		if (dead)
		{
			return;
		}
		//If we have 0 lives left
		if (lives < 1)
		{			
			//Kill
			foodBehav.CancelInvoke();
			dead = true;
		}
	}

	void OnMouseDown()
	{
		
		//If we hits an apple core
		if (this.gameObject != null && this.gameObject.tag == "Untagged") {
			//Instantiate (splat, new Vector3 (transform.position.x, transform.position.y, 1), Quaternion.identity);
			//Add score
			score += 1;
			count--;
			Object.Destroy (this.gameObject);
		}
		//If we hits an apple
		else if (this.gameObject != null && this.gameObject.tag == "Respawn") {
			//Removes a life
			lives--;
			count--;
			Object.Destroy (this.gameObject);
		} else {
			score -= 1;
		}
	}

	// Give the player a chance to click the food.
	IEnumerator WaitForHit()
	{
		float time = 0.0f;

		while(Input.touchCount != 1 && time < timeLimit)
		{
			time += Time.deltaTime;
			yield return null;
		}
	}

	void OnGUI()
	{
		GUI.skin = skin;

		//Score
		GUI.Label(new Rect(10,10,300,300),score.ToString());

		//If dead
		if (dead)
		{
			//Show "Lives: 0"
			GUI.Label(new Rect(10,Screen.height - 35,300,300),"Lives: 0");
		}
		else
		{
			//Show lives left
			GUI.Label(new Rect(10,Screen.height - 35,300,300),"Lives: " + lives.ToString());
		}

		//Menu Button
		if(GUI.Button(new Rect(Screen.width - 120,0,120,40),"Menu"))
		{
			//Load Menu scene
			//Application.LoadLevel("Menu");
		}
		//If dead
		if (dead == true)
		{
			//Play Again Button
			if(GUI.Button(new Rect(Screen.width / 2 - 90,Screen.height / 2 - 60,180,50),"Play Again"))
			{
				//SceneManager.LoadScene("FridgeClean");
			}
			//Menu Button
			if(GUI.Button(new Rect(Screen.width / 2 - 90,Screen.height / 2,180,50),"Menu"))
			{
				//Application.LoadLevel("Menu");
			}
		}	
	}
}
