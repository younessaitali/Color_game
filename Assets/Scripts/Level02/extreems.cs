using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extreems : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnCollisionEnter2D(Collision2D other)
	{

		if (other.gameObject.CompareTag ("ball")) {

			CapsuleCollider2D ballCollider = other.gameObject.GetComponent<CapsuleCollider2D> ();
			ballCollider.enabled = false;
		}

	}
}
