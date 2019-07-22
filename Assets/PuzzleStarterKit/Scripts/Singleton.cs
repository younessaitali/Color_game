using UnityEngine;
using System.Collections;

public class Singleton : MonoBehaviour {

	/// <summary>
	/// The instance.
	/// </summary>
	private static Singleton instance = null;
	
	/// <summary>
	/// Gets the instance.
	/// </summary>
	/// <value>The instance.</value>
	public static Singleton Instance {
		get { return instance; }
	}
	
	/// <summary>
	/// Awake this instance. We need this method to ensure that the gameObject with this script 
	/// will not be destroyed on level load
	/// </summary>
	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}	

}
