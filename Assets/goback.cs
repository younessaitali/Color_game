using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class goback : MonoBehaviour {
   
    public GameObject backbutt;
   

	// Use this for initialization
	void Awake () {
        
       

    }

    // Update is called once per frame
    void Update () {
		
	}
    public void changeScene(int lvlID)
    {
       
        SceneManager.LoadScene(lvlID);
       // backbutt.SetActive(false);

    }
    public void chnagepaint()
    {

        SceneManager.LoadScene(6);
        // backbutt.SetActive(false);

    }
}
