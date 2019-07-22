using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour {
	public GameObject levelsPanel;
	public AudioSource mainAudioSource;
	public AudioClip buttonClick;
    public GameObject GDPRpanel;
    public GameObject Setingpanel;
   
   
    // Use this for initialization
    void Start () {

       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
	public void starting()
	{
		mainAudioSource.clip = buttonClick;
		mainAudioSource.Play ();
		levelsPanel.SetActive (true);
       



	}
	public void changeScene(int lvlID)
	{
		mainAudioSource.clip = buttonClick;
		mainAudioSource.Play ();
		SceneManager.LoadScene (lvlID);
      
       
       

    }
    public void GDPRpannel()
    {
        GDPRpanel.SetActive(true);
    }
    public void Setpanel()
    {
        Setingpanel.SetActive(true);
    }
}
