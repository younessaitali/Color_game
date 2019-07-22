using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bucketScript : MonoBehaviour {
	public GameObject ballThrower;
	public GameObject endLvlPanel;
	//public GameObject[] coloredBuck;
	public AudioSource bucketAudio;
	public AudioClip inbucket;
	public AudioClip scoreSound;
	public AudioClip wrongMoveAudio;
	public Text resultText;
	public GameObject Dust;
	public Transform dustPlace;
	public Text ScoreText;
	public bucket[] buckets;
	public int ScoreCount;
	public int i ;
	public int currentIndice;
	public Sprite NotPressed;
	public Sprite Pressed;
	public SpriteRenderer myRenderer;
	int b = 0;

	public string BucketColor;
	// Use this for initialization
	void Start () {
		ScoreCount = 0;
		i = Random.Range (0,11);
		ScoreText.text = "Score:" + " " + ScoreCount.ToString ();
		currentIndice = i;
		myRenderer = gameObject.GetComponent<SpriteRenderer> ();
		myRenderer.sprite =buckets[i].notPressed;
	}
	
	// Update is called once per frame
	void Update () {
		NotPressed = buckets [i].notPressed;
		Pressed = buckets [i].pressed;
		/*if (toucheScript.isPressed == true) {

			myRenderer.sprite = Pressed;
		} else
			myRenderer.sprite = NotPressed;*/
	}
	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.GetComponent<BallScript> ().currentBall.baColor == buckets [i].bColor)
        {
			/*if (buckets [i].found != true) {
				
				coloredBuck [b].gameObject.SetActive(true);
				buckets [i].found = true;
				b = b + 1;
				if (b == 9) {
					endLvlPanel.gameObject.SetActive (true);
					Destroy (FindObjectsOfType<BallThrower> ()[0].gameObject);
					Destroy (FindObjectsOfType<BallThrower> ()[1].gameObject);
					//gameObject.SetActive (false);
				}
                
			}*/
			ScoreCount++;
			ScoreText.text = "Score:" + " " + ScoreCount.ToString ();
			Debug.Log ("great");
			bucketAudio.clip = scoreSound;
			bucketAudio.Play ();
			StartCoroutine (vanishDelay ());
			
			i = Random.Range (0, 11);
			while (i == currentIndice) {
				i = Random.Range (0, 11);
			}
			currentIndice = i;

		} else if (other.gameObject.GetComponent<BallScript> ().currentBall.baColor != buckets [i].bColor) {

			bucketAudio.clip = wrongMoveAudio;
			bucketAudio.Play ();

		}

		GameObject dustt = Instantiate (Dust, dustPlace) as GameObject;

		//myRenderer.sprite =buckets[i].notPressed;

		/*if (this.BucketColor == other.gameObject.GetComponent<BallScript>().ballColor) {
			Debug.Log ("great");
		}*/
		if(other.gameObject.CompareTag("ball"))
			{
				Destroy(other.gameObject);
			}

	}
	public IEnumerator vanishDelay()
	{
		resultText.text = "Great";
		yield return new WaitForSeconds (1.5f);
		resultText.text = "";
	}

}

