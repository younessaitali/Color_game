using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class Gmanager : MonoBehaviour {
	public GameObject CardGameO;
	public Transform UpperLeft;
	public List<card> cards2 = new List<card>();
	public List<card> cards = new List<card>();
	public List<card> addedCards = new List<card>();
	public List<GameObject> clickedCards = new List<GameObject>();
	public card firstCard;
	public GameObject firstGo;
	public card secondCard;
	public GameObject secondGo;
	public int clickCount;
	public int r;
	public int numFound;
    public bool ischecking;

	public GameObject[] Places;

    public AudioSource sauce;
    public AudioClip cardflip;
    public static Gmanager _gmanager;

    // Use this for initialization
    void Awake()
	{
		if(_gmanager==null)
        {
            _gmanager = this;
        }

	}
	void Start () {
        ischecking = false;
		r =Random.Range (0, 2);
		numFound = 0;

		clickCount = 0;

		for (int m = 0; m < 8; m++) {

			GameObject cardInstance = Instantiate (CardGameO,Places[m].transform) as GameObject;
			cardInstance.GetComponent<cardLogic> ().take =r;

		}
		StartCoroutine (refill ());



	}
	// Update is called once per frame
	void Update () {
		
		
	}
	public IEnumerator refill()
	{
		yield return new WaitForSeconds (0.2f);
		if (r == 0) {
			for (int i = 0; i < addedCards.Capacity; i++) {
				cards.Add (addedCards [i]);

			}
			addedCards.RemoveRange (0, addedCards.Count);
		} else if (r == 1) {

			for (int i = 0; i < addedCards.Count; i++) {
				cards2.Add (addedCards [i]);

			}
			addedCards.RemoveRange (0, addedCards.Count);

		}


	}
	public void checkTheTwo()
	{
            
            if (clickCount > 1)
            {

                if (clickedCards[0].name == clickedCards[1].name)
                {
                    Debug.Log("Great");
                    numFound++;
                    if (numFound == 4)
                    {

                        StartCoroutine(deleteTable());

                    }

                    for (int m = 0; m < clickedCards.Count; m++)
                    {
                        if (m == 0 || m == 1)
                        {
                            clickedCards[m].GetComponent<cardLogic>().currentCard.isFlipped = true;

                        }
                        else
                        {

                            clickedCards[m].GetComponent<cardLogic>().currentCard.isFlipped = false;
                            clickedCards[m].GetComponent<SpriteRenderer>().sprite = clickedCards[m].GetComponent<cardLogic>().currentCard.backSprite;
                        }

                    }

                }
                else
                {
                    Debug.Log("wrong");
                    for (int m = 0; m < clickedCards.Count; m++)
                    {

                        clickedCards[m].GetComponent<cardLogic>().currentCard.isFlipped = false;
                        clickedCards[m].GetComponent<SpriteRenderer>().sprite = clickedCards[m].GetComponent<cardLogic>().currentCard.backSprite;


                    }

                }

                clickCount = 0;
            }

        
		
		
	}

	public IEnumerator deleteTable()
	{
		yield return new WaitForSeconds (1f);
		for (int i = 0; i < FindObjectsOfType<cardLogic> ().Length; i++) {
			Destroy (FindObjectsOfType<cardLogic>()[i].gameObject);

		}

		yield return new WaitForSeconds (1f);
		restart ();

	}
	public void restart()
	{

		r =Random.Range (0, 2);
		numFound = 0;

		clickCount = 0;

		for (int m = 0; m < 8; m++) {

			GameObject cardInstance = Instantiate (CardGameO,Places[m].transform) as GameObject;
			cardInstance.GetComponent<cardLogic> ().take =r;

		}
		StartCoroutine (refill ());


	}
}
