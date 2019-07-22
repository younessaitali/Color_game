using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardLogic : MonoBehaviour {
	public int i ;
	public card currentCard;
	public int take;
    


	// Use this for initialization
	void Start () {
		

		if (take == 0) {
		
			i = Random.Range (0, FindObjectOfType<Gmanager> ().cards.Count);

			currentCard = FindObjectOfType<Gmanager> ().cards [i];
			FindObjectOfType<Gmanager> ().addedCards.Add (currentCard);
			FindObjectOfType<Gmanager> ().cards.Remove (currentCard);
			//currentCard = FindObjectOfType<Gmanager> ().cards [i];


			//Debug.Log (FindObjectOfType<Gmanager> ().cards.Count);
			currentCard.isFlipped = false;
			gameObject.GetComponent<SpriteRenderer> ().sprite = currentCard.backSprite;
			gameObject.name = currentCard.cardName;
		} else if (take == 1) {
			i = Random.Range (0, FindObjectOfType<Gmanager> ().cards2.Count);

			currentCard = FindObjectOfType<Gmanager> ().cards2 [i];
			FindObjectOfType<Gmanager> ().addedCards.Add (currentCard);
			FindObjectOfType<Gmanager> ().cards2.Remove (currentCard);
			//currentCard = FindObjectOfType<Gmanager> ().cards [i];


			//Debug.Log (FindObjectOfType<Gmanager> ().cards.Count);
			currentCard.isFlipped = false;
			gameObject.GetComponent<SpriteRenderer> ().sprite = currentCard.backSprite;
			gameObject.name = currentCard.cardName;


		}

			//FindObjectOfType<Gmanager> ().cards.Remove(currentCard);

	}
	
	// Update is called once per frame
	void Update () {

		
	}

	public IEnumerator flipCard()
	{
		
		if (currentCard.isFlipped == false && FindObjectOfType<Gmanager>().ischecking==false)
		{
            

            if (FindObjectOfType<Gmanager> ().clickCount == 0) {
				FindObjectOfType<Gmanager> ().clickedCards.RemoveRange (0, FindObjectOfType<Gmanager> ().clickedCards.Count);

			}
			FindObjectOfType<Gmanager> ().clickCount++;
            if (FindObjectOfType<Gmanager>().clickCount < 3)
            {
                FindObjectOfType<Gmanager>().clickedCards.Add(gameObject);
                gameObject.GetComponent<SpriteRenderer>().sprite = currentCard.frontSprite;
                currentCard.isFlipped = true;
                Gmanager._gmanager.sauce.clip = Gmanager._gmanager.cardflip;
                Gmanager._gmanager.sauce.Play();
            }
            else
            {
                FindObjectOfType<Gmanager>().ischecking = true;
              
            }
            if(FindObjectOfType<Gmanager>().clickCount ==2)
            {
                yield return new WaitForSeconds(1f);
                FindObjectOfType<Gmanager>().checkTheTwo();
            }




           

			
            FindObjectOfType<Gmanager>().ischecking = false;




        }

	}



		

}
