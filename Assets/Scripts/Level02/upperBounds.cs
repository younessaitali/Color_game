using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upperBounds : MonoBehaviour {
	public AudioSource boundSource;
	public AudioClip extreemHit;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		boundSource.clip = extreemHit;
		boundSource.Play ();

	}
}
