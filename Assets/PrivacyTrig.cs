using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrivacyTrig : MonoBehaviour {

    public GameObject privacymenu;
    void Start()
    {

        RPopUp();

    }
    // Update is called once per frame
    void Update () {
		
	}
    public void PopUp()
    {
        privacymenu.SetActive(true);
    }
    public void RPopUp()
    {
        privacymenu.SetActive(false);
    }
}
