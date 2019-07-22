using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScript : MonoBehaviour {
	public bool touched;
	// Use this for initialization
	void Start () {
		
	}
	public RaycastHit2D hitedObject;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Vector2 mousePos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
			Vector2 mousPosWorld = Camera.main.ScreenToWorldPoint (mousePos);
			hitedObject = Physics2D.Raycast (mousPosWorld, transform.forward);
			Debug.DrawRay (mousPosWorld, transform.forward, Color.green);

			if (hitedObject) {
				if (hitedObject.transform.gameObject.tag == "card") {
					touched = true;
					//Debug.Log ("touched");
					//hitedObject.transform.GetComponent<cardLogic> ().flipCard();
					StartCoroutine (hitedObject.transform.GetComponent<cardLogic> ().flipCard ());

				} 
			}

		} else {
			touched = false;
			//Debug.Log ("released");
		}
	}
}
