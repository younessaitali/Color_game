using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class AdScript2 : MonoBehaviour
{
    public static int Consent ;
    private static int counter;

    // Use this for initialization
    void Start()
    {
        

        Load();
        Debug.Log("consent :" + Consent);
        //Request Ad
        RequestInterstitialAds();
        counter = 0;
    }

    void Update()
    {

        Debug.Log("counter" + counter);

        if (counter==14)
            {

                showInterstitialAd();
                counter = -13;
                
            }
        
    }

    public void showInterstitialAd()
    {
        //Show Ad
        if (interstitial.IsLoaded())
        {
            interstitial.Show();

            //Stop Sound
            //

            Debug.Log("SHOW AD XXX");
        }
        else {
            RequestInterstitialAds();
            Debug.Log("ad not loaded yet");
                }
        

    }

    InterstitialAd interstitial;
    private void RequestInterstitialAds()
    {
        string adID = "ca-app-pub-1904664762917518/1334017452";

#if UNITY_ANDROID
        string adUnitId = adID;
#elif UNITY_IOS
        string adUnitId = adID;
#else
        string adUnitId = adID;
#endif

        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);

        //***Test***
        // AdRequest request = new AdRequest.Builder()
        //.AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
        //.AddTestDevice("2077ef9a63d2b398840261c8221a0c9b")  // My test device.
        //.Build();

        //***Production***
        AdRequest request;
        if (Consent==1)
        {
            request = new AdRequest.Builder().AddExtra("npa", "1").Build();
           
            interstitial.LoadAd(request);

            Debug.Log("AD LOADED nonpers");
        }
        else {

             request = new AdRequest.Builder().Build();
            interstitial.LoadAd(request);

            Debug.Log("AD LOADED pers ");
        }
       

        // Load the interstitial with the request.
    

    }
    public void Nonperspna()
    {
        Consent = 1;
        PlayerPrefs.SetInt("consent", Consent);

    }
    public void Persona()
    {
        Consent = 0;
        PlayerPrefs.SetInt("consent", Consent);
    }
    public void Load()
    {
        Consent = PlayerPrefs.GetInt("consent", 0);
    }

       public void Incri()
    {
        counter++;
    }
    //Ad Close Event
    private void Interstitial_OnAdClosed(object sender, System.EventArgs e)
    {
        //Resume Play Sound

    }
    public int Getconsent()
    {
        return Consent;
    }
}
