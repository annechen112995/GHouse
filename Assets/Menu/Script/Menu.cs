using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{
	public GUISkin skin;
	private bool loading;
	private Vector2 scrollPosition;
	
	void Start ()
	{
		Screen.orientation = ScreenOrientation.Portrait;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

	void OnGUI()
	{
		GUI.skin = skin;

		if(GUI.Button(new Rect(Screen.width / 2 - 75,70,150,50),"Fridge Purge"))
		{
			loading = true;
			Application.LoadLevel("FridgePurge");
		}
		if (loading)
		{
			GUI.Label(new Rect(Screen.width / 2 - 45,10,100,100), "Loading");
		}
	}
}