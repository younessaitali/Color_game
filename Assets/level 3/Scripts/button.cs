using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void clickCheck()
    {
        if (FindObjectOfType<manage>().currentTiles.Count != 0 && FindObjectOfType<manage>().isPlaying == false)
        {
            if (this.gameObject.name == FindObjectOfType<manage>().currentTiles[0].tileName)
            {

                Debug.Log("great");
                manage._manage.sauce.clip = manage._manage.currentTiles[0].tileSound;
                manage._manage.sauce.Play();
                StartCoroutine(manage._manage.praise("Great" ,Color.blue));
                FindObjectOfType<manage>().currentTiles.RemoveAt(0);
                manage._manage.hasPlayed = true;

            }
            else
            {
                StartCoroutine(manage._manage.praise("Wrong",Color.red));
                manage._manage.resetTiles();
                manage._manage.startTiles();
            }
        }
        if(manage._manage.currentTiles.Count ==0 && manage._manage.hasPlayed)
        {
            manage._manage.statetext.text = "Start";
            StartCoroutine(manage._manage.praise("Good job",Color.magenta));
            StartCoroutine(manage._manage.goodjob());
            manage._manage.hasPlayed = false;
        }
    }
}
