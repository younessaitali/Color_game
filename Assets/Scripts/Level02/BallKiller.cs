﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallKiller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnTriggerEnter2D(Collider2D other)
	{
		Destroy (other.gameObject);
	}
}
