using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manage : MonoBehaviour {
    public static manage _manage;
    public List<Tile> allTiles = new List<Tile>();
    public List<Tile> currentTiles = new List<Tile>();
    public List<Image> renders = new List<Image>();
    public AudioSource sauce;
    public AudioClip[] nicejob;
 
    public Text statetext;
    public Text howImDoingText;
    public bool isPlaying;
    public bool hasPlayed;
    // Use this for initialization
    public void Awake()
    {
        if(_manage==null)
        {
            _manage = this;
        }
    }
    void Start () {
        isPlaying = false;
        hasPlayed = false;
        displayTiles();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void displayTiles()
    {
        for (int j = 0; j < allTiles.Count; j++)
        {
            allTiles[j].tileRender = renders[j];
            allTiles[j].tileRender.sprite = allTiles[j].notclicked;
            allTiles[j].tileRender.name = allTiles[j].tileName;
        }
    }
    public void generateTiles()
    {
       
       if(currentTiles.Count ==0)
        {
            resetTiles();
            for (int i = 0; i < 4; i++)
            {
                int t = Random.Range(0, allTiles.Count);
                currentTiles.Add(allTiles[t]);

                //allTiles.RemoveAt(t);
            }
        }
        
    }
    public void resetTiles()
    {
       
           // allTiles.Add(currentTiles[i]);
            currentTiles.Clear();
       
    }
    public IEnumerator tileShow()
    {
        isPlaying = true;
        statetext.text = "...";
       for(int i = 0; i < currentTiles.Count; i++)
        {
            yield return new WaitForSeconds(2);
            sauce.clip = currentTiles[i].tileSound;
            sauce.Play();
           Debug.Log( currentTiles[i].tileName);
            StartCoroutine(flashTile(i));

        }
        isPlaying = false;
        statetext.text = "Hear again";

    }
    public IEnumerator flashTile(int i )
    {
        currentTiles[i].tileRender.sprite = currentTiles[i].clicked;
        yield return new WaitForSeconds(0.5f);
        currentTiles[i].tileRender.sprite = currentTiles[i].notclicked;
    }
    public void startTiles()
    {
        if (isPlaying == false)
        {
            generateTiles();
            StartCoroutine(tileShow());
        }
        
       
    }
    public IEnumerator praise(string phrase , Color color)
    {
        howImDoingText.text = phrase;
        howImDoingText.color = color;
        howImDoingText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        howImDoingText.gameObject.SetActive(false);
    }
    public IEnumerator goodjob()
    {
        yield return new WaitForSeconds(.8f);
        int i = Random.Range(0, 3);
        sauce.clip = nicejob[i];
        sauce.Play();
    }
    

}
