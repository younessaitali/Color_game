using UnityEngine;
using System.Collections;

namespace HiddenObjectGame
{
	/// <summary>
	/// This script toggles a sound source when clicked on. It also records the sound state (on/off) in a PlayerPrefs. In order to detect clicks you need to attach a collider to this object.
	/// </summary>
	public class HOGToggleSound:MonoBehaviour 
	{
		internal Transform thisTransform;

        // The tag of the sound source
        public string soundObjectTag = "Music";

        //The source of the sound
        internal Transform soundObject;
		
		//The PlayerPrefs name of the sound
		public string playerPref = "MusicVolume";
		
		//The current state of the sound, 1 = on, 0 = off
		public float currentState = 1;
		
		//The sprites of the sound in its various states
		public Sprite[] sprites;
		
		//The sound of the button click and the source of the sound
		public AudioClip soundClick;
		public Transform soundSource;
		
		//Should there be a click effect
		public bool clickEffect = true;

        /// <summary>
        /// This runs before the start function
        /// </summary>
        void Awake()
        {
            thisTransform = transform;

            if (!soundObject && soundObjectTag != string.Empty) soundObject = GameObject.FindGameObjectWithTag(soundObjectTag).transform;

            // Get the current state of the sound from PlayerPrefs
            if (soundObject)
                currentState = PlayerPrefs.GetFloat(playerPref, soundObject.GetComponent<AudioSource>().volume);
            else
                currentState = PlayerPrefs.GetFloat(playerPref, currentState);

            // Set the sound in the sound source
            SetSound();
        }

        /// <summary>
        /// Raises the mouse down event.
        /// </summary>
        void OnMouseDown()
		{
			//Create an effect
			if ( clickEffect == true )    ClickEffect();
			
			//Play a sound from the source
			if ( soundSource )    if ( soundSource.GetComponent<AudioSource>() )    soundSource.GetComponent<AudioSource>().PlayOneShot(soundClick);
			
			//Toggle the sound
			ToggleSound();
		}

		/// <summary>
		/// Sets the sound state
		/// </summary>
		void SetSound()
		{
			//Set the sound in the PlayerPrefs
			PlayerPrefs.SetFloat( playerPref, currentState);
			
			//Update the graphics of the sprite to fit the sound state
			GetComponent<SpriteRenderer>().sprite = sprites[Mathf.RoundToInt(currentState)];
			
			//Set the value of the sound state to the source object
			if ( soundObject )    soundObject.GetComponent<AudioSource>().volume = currentState;
		}
		
		/// <summary>
		/// Toggle the sound. Turn it off if it was on, and turn it on if it was off.
		/// </summary>
		void ToggleSound()
		{
			currentState = 1 - currentState;
			
			SetSound();
		}
		
		/// <summary>
		/// Start playing the sound source
		/// </summary>
		void StartSound()
		{	
			if ( soundObject )    soundObject.GetComponent<AudioSource>().Play();
		}

		/// <summary>
		/// Create an effect, making the object large and then gradually smaller
		/// </summary>
		IEnumerator ClickEffect()
		{
			//Register the original size of the object
			var initScale = thisTransform.localScale;
			
			//Resize it to be larger
			thisTransform.localScale = initScale * 1.1f;
			
			//Gradually reduce its size back to the original size
			while ( thisTransform.localScale.x > initScale.x * 1.01f )
			{
				yield return new WaitForFixedUpdate();

				thisTransform.localScale = new Vector3( thisTransform.localScale.x - 1 * Time.deltaTime, thisTransform.localScale.x - 1 * Time.deltaTime, thisTransform.localScale.z);
			}
			
			//Reset the size to the original
			thisTransform.localScale = thisTransform.localScale = initScale;
		}	
	}
}











