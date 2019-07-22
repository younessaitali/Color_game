using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toucheScript : MonoBehaviour {
	public static bool isPressed = false;
	public Vector2 mousPosWorld;
	// Use this for initialization
	void Start () {
		
	}

	public RaycastHit2D TouchedObject;
	GameObject objSelected = null;
	public float followSpeed = 1f;
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {

			Vector2 mousePos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
			Vector2 mousPosWorld = Camera.main.ScreenToWorldPoint (mousePos);
			Debug.DrawRay (mousPosWorld,transform.forward, Color.green);

			TouchedObject = Physics2D.Raycast (mousPosWorld, transform.forward);


		}
		if (Input.GetMouseButton (0)) {

			Vector2 mousePos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
			Vector2 mousPosWorld = Camera.main.ScreenToWorldPoint (mousePos);
			Debug.DrawRay (mousPosWorld,transform.forward, Color.green);

			//

			if (TouchedObject) {
				objSelected = TouchedObject.transform.gameObject;
				if (objSelected.tag == "bucket") 
				{
					
					//Debug.Log (TouchedObject.collider.name);
					isPressed = true;
					objSelected.transform.position = Vector2.Lerp (objSelected.transform.position,new Vector2( mousPosWorld.x,objSelected.transform.position.y), followSpeed);
					objSelected.transform.GetComponent<SpriteRenderer> ().sprite = objSelected.transform.GetComponent<bucketScript> ().Pressed;
				}
			} 
			else if(objSelected != null && objSelected.tag =="bucket" ) 
			{
				
				objSelected.transform.position = Vector2.Lerp (objSelected.transform.position,new Vector2( mousPosWorld.x,objSelected.transform.position.y), followSpeed);
			}
		 } 
		else if (Input.GetMouseButtonUp (0) && objSelected != null && objSelected.tag=="bucket") {
			objSelected.transform.GetComponent<SpriteRenderer> ().sprite = objSelected.transform.GetComponent<bucketScript> ().NotPressed;
			objSelected = null;

		}
			


	}
}
