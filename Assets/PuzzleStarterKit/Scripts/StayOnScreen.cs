using UnityEngine;
using System.Collections;

public class StayOnScreen : MonoBehaviour {

	float screenX, screenY;

	void Start ()
	{
		screenX = (Screen.width * 0.05f); //5 percentage from screen width
		screenY = (Screen.height * 0.05f);//5 percentage from screen height
	}

	void Update ()
	{
		StayWhithin ();
	}

	/// <summary>
	/// Staies the whithin screen boundaries minus screenX and screenY percentages.
	/// </summary>
	public void StayWhithin()
	{
		Vector3 objPositionOnScreen;
		// Check if the object is on screen.        
		objPositionOnScreen = Camera.main.WorldToScreenPoint(transform.position);
		// Vertical on screen
		if (objPositionOnScreen.y < screenY)
		{
			transform.position = Camera.main.ScreenToWorldPoint(new Vector3(objPositionOnScreen.x,
				screenY, objPositionOnScreen.z));
		}
		else if (objPositionOnScreen.y > Screen.height - screenY)
		{
			transform.position = Camera.main.ScreenToWorldPoint(new Vector3(objPositionOnScreen.x,
				Screen.height - screenY, objPositionOnScreen.z));
		}
		
		// Horizontal on screen
		if (objPositionOnScreen.x < screenX)
		{
			transform.position = Camera.main.ScreenToWorldPoint(new Vector3(screenX,
				objPositionOnScreen.y, objPositionOnScreen.z));
		}
		else if (objPositionOnScreen.x > Screen.width - screenX)
		{
			transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - screenX,
				objPositionOnScreen.y, objPositionOnScreen.z));
		}
	}

}
