using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrower : MonoBehaviour {
	public GameObject ball;
	public Transform throwPoint;
	public float xVel, yVel;
	public float timing;
	// Use this for initialization
	void Start () {
		StartCoroutine (lanceDelay ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void lance()
	{
		xVel = Random.Range (-8f, 8f);
		timing = Random.Range (0.5f, 2f);
		GameObject ballInstance = Instantiate (ball,throwPoint) as GameObject;
		Rigidbody2D myrigid;
		myrigid = ballInstance.GetComponent<Rigidbody2D> ();
		myrigid.velocity = new Vector2 (xVel, yVel);

	}
	public IEnumerator lanceDelay()
	{
		
		lance ();
		yield return new WaitForSeconds (timing);
		StartCoroutine (lanceDelay ());
	}
}
