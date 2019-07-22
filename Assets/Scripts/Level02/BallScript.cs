using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {
	public string ballColor;
	public Ball[] balls;
	public Ball currentBall;
	public SpriteRenderer ballRender;

	public int j;
	// Use this for initialization
	void Start () {
		ballRender = GetComponent<SpriteRenderer> ();
		j = Random.Range (0, 22);

		ballRender.sprite = balls [j].ballSprite;
		currentBall = balls [j];
		Destroy (gameObject, 6f);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
