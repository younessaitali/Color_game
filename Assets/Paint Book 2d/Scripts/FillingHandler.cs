using UnityEngine;
using System.Collections;

public class FillingHandler : MonoBehaviour
{
		public AudioSource audioSource;//audio source
		public AudioClip fillAudioClip;//fill audio clip
		public Brush brush;//brush
		private Vector3 Postion;//mouse or touch postion

		void Start ()
		{
				if (audioSource == null) {
						audioSource = Camera.main.GetComponent<AudioSource> ();//get the audio source
				}
		}
	
		// Update is called once per frame
		void Update ()
		{
				Postion = Camera.main.ScreenToWorldPoint (Input.mousePosition);//get click position
				Postion.z = -5;
				if (Input.GetMouseButtonDown (0)) { 
						RayCast2D ();
				} 

				if (brush != null)
						brush.transform.position = Postion;//drag the brush
		}
	
		//2d screen raycast
		private void RayCast2D ()
		{
				RaycastHit2D rayCastHit2D = Physics2D.Raycast (Postion, Vector2.zero);
		
				if (rayCastHit2D.collider == null) {
						return;
				}
		
				if (rayCastHit2D.collider.tag == "BrushColor") {
			  			 //set brush color
						brush.currentColor = rayCastHit2D.collider.GetComponent<BrushColor> ().value;
						brush.transform.GetChild(0).GetComponent<SpriteRenderer>().color = brush.currentColor;
				} else if (rayCastHit2D.collider.tag == "ImagePart") {
			            //full image part
						rayCastHit2D.collider.GetComponent<SpriteRenderer> ().color = brush.currentColor;
						audioSource.clip = fillAudioClip;
						audioSource.Play();
				}
		}
}