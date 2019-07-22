using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	bool showMainMenu; //if whant to see the menu then wil set to true
	public AudioClip btnClickedSound; //audioclip for buttons 	
	public Texture star; //texture of a star showed on screen 
	public GUISkin customSkin = null; //you can use any skin you want, default will be Unity's skin
	Rect menuRect; //menu rectangle	
	private int level = 1; //player score
	float offsetX; //screen percentage from total width
	float offsetY; //screen percentage from total height
	bool oneTimeIncrementOnLevel; //prevent further increments on player score when enLevel condition is fullfil
	public string nextLevelName = ""; //if exist what is the next level name in order to navigate to it?
	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start()
	{
		Initialize();
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update()
	{
		EndLevel();

	}

	/// <summary>
	/// Initialize this instance.
	/// </summary>
	void Initialize()
	{
		oneTimeIncrementOnLevel = true;
		menuRect = new Rect();
		showMainMenu = false;
		level = PlayerPrefs.GetInt("Score"); //Returns the value corresponding to key in the preference file if it exists.
		offsetX = (Screen.width * 18) / 100; //18 percentage from screen width
		offsetY = (Screen.height * 10) / 100; //10 percentage from screen height
		if(nextLevelName=="")
			nextLevelName = Application.loadedLevelName; //if no other level name is provided in the inspector then next level for load will be current level
	}

	/// <summary>
	/// Ends the level.
	/// </summary>
	void EndLevel()
	{
		//search for any object with the tag as "shadow" and if there is none then all the pieces are in their spots (on their shadows)
		//also check if oneTimeIncrementOnLevel is true
		if(GameObject.FindGameObjectWithTag("shadow")==null && oneTimeIncrementOnLevel)
		{
            //level++; //increment de level with one unit
            //PlayerPrefs.SetInt("Score", level); //Sets the value of the preference identified by key
            //showMainMenu = true; //after level is complete we show the menu buttons
            //oneTimeIncrementOnLevel = false; //reset oneTimeIncrementOnLevel to false 
            Application.LoadLevel(nextLevelName);
        }
	}

	/// <summary>
	/// Raises the GU event.
	/// </summary>
	/*void OnGUI() 
	{		
		GUI.skin = customSkin; //you can chose what skin you want
		//Begin a group. Must be matched with a call to EndGroup.When you begin a group, the coordinate system 
		//for GUI controls are set so (0,0) is the top-left corner of the group. All controls are clipped to the group
		GUI.BeginGroup(new Rect(Screen.width - offsetX - 160/2, offsetY - 50/2, 160, 50));
		GUI.DrawTexture(new Rect(5, 5, 40, 40), star); 
		GUI.Label(new Rect(50,5, 60, 40), level.ToString());
		if (GUI.Button(new Rect(115,5, 40, 40), "="))
		{
			PlayAudioButtons();
			showMainMenu = !showMainMenu; //that way every time you click on this ("=") button you'll show or hide the other buttons											
		}			
		GUI.EndGroup();		
		if(showMainMenu)
		{	
			menuRect = new Rect(Screen.width / 2 - 180/2, Screen.height/2 - 180/2, 180, 180);
			menuRect = GUI.Window(0, menuRect, drawWindow, "");		
		}
	}

	/// <summary>
	/// Draws the window.
	/// </summary>
	/// <param name="windowID">Window I.</param>
	void drawWindow(int windowID)
	{ 	
		if (GUI.Button(new Rect(15, 15, 150, 40), "Resume"))
		{
			PlayAudioButtons();		
			showMainMenu = false;
		}
		if (GUI.Button(new Rect(15, 70, 150, 40), "Next Level"))
		{
			PlayAudioButtons();			
			showMainMenu = false;
			NextLevel(nextLevelName);
		}
		if (GUI.Button(new Rect(15, 125, 150, 40), "Quit"))
		{
			PlayAudioButtons();
			showMainMenu = false;
			Application.Quit();
		}
	}

	/// <summary>
	/// Plaies the audio buttons.
	/// </summary>
	void PlayAudioButtons()
	{
		GetComponent<AudioSource>().Stop();
		GetComponent<AudioSource>().clip = btnClickedSound;
		GetComponent<AudioSource>().Play();
	}

	/// <summary>
	/// Nexts the level.
	/// </summary>
	/// <param name="levelName">Level name.</param>
	void NextLevel(string levelName)
	{
		Application.LoadLevel(levelName); 
	}*/
}
