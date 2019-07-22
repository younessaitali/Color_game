using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleMaker : MonoBehaviour {
	public GameObject bubble;
	public Transform makerPlace;
	private float xvec,yvec;
	public float Valuerange;
	[SerializeField]
	private float timing;
	// Use this for initialization
	void Start () {
		StartCoroutine (bdelay ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public IEnumerator bdelay()
	{
		xvec = Random.Range (-Valuerange, Valuerange);
		timing = Random.Range (1f, 3f);
		GameObject bubbleInstance = Instantiate (bubble, makerPlace) as GameObject;
		Rigidbody2D brigid = bubbleInstance.GetComponent<Rigidbody2D> ();

		brigid.velocity = new Vector2 (xvec, yvec);
		yield return new WaitForSeconds (timing);
		StartCoroutine (bdelay ());
	}
}
