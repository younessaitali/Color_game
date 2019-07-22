using UnityEngine;
using System.Collections;

public class PiecesBehaviour : MonoBehaviour {

	Vector3 offset;
	bool stopDrag; //if we want to stop the piece's drag on screen
	bool dragging; //when the piece is dragged on screen
	public GameObject shadow; //gameObject (the shadow) asociated with the piece
	private SpriteRenderer spriteRenderer;
	public Sprite glowPieceSprite; //the sprite for glow effect
	private Sprite initialSpite;
	bool isMouseReleased = false; //is true if mouse is released or the finger is up
	bool canSnap = false; //is true if piece can snap to it
	Vector3 initialPosition;
	Vector3 initialScale;
	bool correctDrag = false; // added.

	// Use this for initialization
	void Start () {
		Initialize();
	}
	
	// Update is called once per frame
	void Update () {
		if(!GetComponent<AudioSource>().isPlaying)
		{
			spriteRenderer.sprite = initialSpite;
		}
		SnapToPosition();
	}
	
	/// <summary>
	/// Initialize this instance.
	/// </summary>
	void Initialize()
	{
		initialPosition = transform.position;
		initialScale = transform.localScale;
		initialSpite = this.GetComponent<SpriteRenderer>().sprite; //save piece's sprite to an initial variable
		spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
		stopDrag = false;
		dragging = false;
		shadow.GetComponent<SpriteRenderer>().color = Color.black; //initialize color for shadow sprite

	}

	/// <summary>
	/// Raises the mouse down event.
	/// </summary>
	void OnMouseDown() 
	{ 
		isMouseReleased = false;
		canSnap = false;
		dragging = true; //initiate dragging for this piece
		
		//screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position); //Transforms position from world space into screen space	(don't need anymore? it will be 0 because of 2D set-up of the game)	
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 
		         Input.mousePosition.y, 0)); //difference between object world position and mouse (or finger) world position 

		if(shadow!=null) //only took place if there is a shadow
		{             
			transform.localScale = shadow.transform.localScale;  //piece's size (or scale) became the same as their shadow       
		} 

		if(stopDrag) //once the piece is on the right spot (on its shadow)
		{
			PlayAudioClip();
		}
	}
	
	/// <summary>
	/// Raises the mouse drag event.
	/// </summary>
	void OnMouseDrag() 
	{ 
		if(dragging && !stopDrag)
		{
			Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);		
			Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;	//position in world space	
			transform.position = curPosition; //the clicked (or taped down) piece can be "dragged" on screen.
			spriteRenderer.sortingOrder = 1; //force current dragged piece to be drawn on top of other pieces
		}		
	}
	
	/// <summary>
	/// Raises the mouse up event.
	/// </summary>
	void OnMouseUp()
	{
		dragging = false;
		isMouseReleased = true;
	}

	/// <summary>
	/// Raises the trigger exit2 d event.
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerExit2D(Collider2D col)
	{
		if(col.gameObject == shadow)
		{
			canSnap = false;
		}
	}

	/// <summary>
	/// Raises the trigger stay2 d event.
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerStay2D(Collider2D col)
	{
		if(col.gameObject == shadow && isMouseReleased) //if piece is positioned ok on shadow then
		{
			canSnap = true;
			correctDrag = true;  // added
            transform.localScale = shadow.transform.localScale; //maybe this is the problem
        }
		else if(col.gameObject != shadow && isMouseReleased && !correctDrag)  // added. 
		{
			transform.position = initialPosition;
			transform.localScale = initialScale;
		}
	}

	/// <summary>
	/// Snaps to position.
	/// </summary>
	void SnapToPosition()
	{
		if(canSnap && isMouseReleased)
		{
			PlayAudioClip();
			stopDrag = true;
			transform.position = shadow.transform.position; //snap the piece on shadow's position
			spriteRenderer.sortingOrder = 0; //force correct positioned piece to be drawn under the draggable pieces.
			canSnap = false;
			Destroy(shadow); //destroy the shadow as we don't need it anymore.
		}
	}

	/// <summary>
	/// Plaies the audio clip.
	/// </summary>
	void PlayAudioClip()
	{
		if(!GetComponent<AudioSource>().isPlaying) //as long as audio is not played then play the clip
		{
			GetComponent<AudioSource>().Play();
			spriteRenderer.sprite = glowPieceSprite; //here we enable glow effect by assigning glowSprite to piece object
		}
	}
}
