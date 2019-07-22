using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdScript : MonoBehaviour
{
    static int i = 0;
   // public AdScript2 coonsent;
    

    private int chekc;
    // Use this for initialization
    void Start()
    {
#if UNITY_ANDROID
        string appId = "ca-app-pub-3940256099942544~3347511713";
#elif UNITY_IPHONE
            string appId = "ca-app-pub-3940256099942544~1458002511";
#else
            string appId = "unexpected_platform";
#endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);

       
       // chekc = coonsent.Getconsent();
      //  Debug.Log("consent adscript" + chekc);
       
            
        if (i == 0)
        {
            this.showBannerAd();
            DontDestroyOnLoad(this.gameObject);
            i++;
        }
        
            

    }

    private void showBannerAd()
    {
       string adID = "ca-app-pub-3940256099942544/6300978111";



        //***For Production When Submit App***
        /* if (chekc == 1)
         {*/
        BannerView bannerView = new BannerView(adID, AdSize.SmartBanner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);
        /* AdRequest request = new AdRequest.Builder().AddExtra("npa", "1").Build();

             BannerView bannerAd = new BannerView(adID, AdSize.SmartBanner, AdPosition.Bottom);
             bannerAd.LoadAd(request);
             Debug.Log("nonper");*/
    /*
        else
        {
            AdRequest request = new AdRequest.Builder().Build();

            BannerView bannerAd = new BannerView(adID, AdSize.SmartBanner, AdPosition.Bottom);
            bannerAd.LoadAd(request);
        }*/
    }

    // Update is called once per frame
    void Update()
    {

    }
}