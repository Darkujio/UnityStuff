using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

[RequireComponent (typeof (Button))]
public class AdRewarded : MonoBehaviour , IUnityAdsListener 
{
    public string gameId = "3925891";
    public string placementId = "LevelBanner";
    public bool testMode = true;
    public BoxCollider2D BoxRef;
    public SpriteRenderer SpriteRef1;
    //public SpriteRenderer SpriteRef2;
    Button myButton;

    public string myPlacementId = "rewardedVideo";

    void Start () {   
        myButton = GetComponent <Button> ();

        // Set interactivity to be dependent on the Placement’s status:
        myButton.interactable = Advertisement.IsReady (myPlacementId); 

        // Map the ShowRewardedVideo function to the button’s click listener:
        if (myButton) myButton.onClick.AddListener (ShowRewardedVideo);

        // Initialize the Ads listener and service:
        Advertisement.AddListener (this);
        Advertisement.Initialize(gameId, testMode);
        StartCoroutine(ShowBannerWhenInitialized());
    }

    IEnumerator ShowBannerWhenInitialized () {
        while (!Advertisement.isInitialized) {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition (BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show (placementId);
    }

    // Implement a function for showing a rewarded video ad:
    void ShowRewardedVideo () {
        Advertisement.Show (myPlacementId);
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsReady (string placementId) {
        // If the ready Placement is rewarded, activate the button: 
        if (placementId == myPlacementId) {        
            myButton.interactable = true;
        }
    }

    public void OnUnityAdsDidFinish (string placementId, ShowResult showResult) {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished) {
            BoxRef.enabled = true;
            SpriteRef1.color = new Color(255,255,255);
            //SpriteRef2.color = new Color(255,255,255);
            gameObject.SetActive(false);
        } else if (showResult == ShowResult.Skipped) {
            // Do not reward the user for skipping the ad.
        } else if (showResult == ShowResult.Failed) {
            Debug.LogWarning ("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsDidError (string message) {
        // Log the error.
    }

    public void OnUnityAdsDidStart (string placementId) {
        // Optional actions to take when the end-users triggers an ad.
    } 
}
