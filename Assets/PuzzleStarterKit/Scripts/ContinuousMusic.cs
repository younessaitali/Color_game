using UnityEngine;
using System.Collections;

public class ContinuousMusic : MonoBehaviour {

	public AudioClip[] backgroundMusic;	//we can have more than one music for game
	int currentMusic = 0; //initialize the music index

	// Use this for initialization	
	void Start () {
		InitializeBackgroundMusic();
		
	}
	
	// Update is called once per frame
	void Update () {		
		if(!GetComponent<AudioSource>().isPlaying)
		{
			currentMusic++; //increment with one the currentMusic index
			if(currentMusic>=backgroundMusic.Length) //if reaching the end of AudioClips array
			{
				currentMusic = 0;
			}
			GetComponent<AudioSource>().clip = backgroundMusic[currentMusic]; //assign the next music to be played
			GetComponent<AudioSource>().Play();
		}		
	}

	/// <summary>
	/// Initializes the background music.
	/// </summary>
	void InitializeBackgroundMusic()
	{		
		currentMusic = Random.Range(0,backgroundMusic.Length); //chose a random index for music to be played
	}
}
