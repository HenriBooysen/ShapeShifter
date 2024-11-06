using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAddCheck : MonoBehaviour
{

    void OnEnable()
    {
        ScoreSystem.OnLoose += HandleLooseState;
        ScoreSystem.OnWin += HandleLooseState;
    }

    void OnDisable()
    {
        ScoreSystem.OnLoose -= HandleLooseState;
        ScoreSystem.OnWin -= HandleLooseState;
    }

    void Start()
    {
        // Initialize the IronSource SDK
        IronSource.Agent.init("1af63811d");
        IronSource.Agent.setMetaData("is_test_suite", "enable");

        // Register the SDK initialization completed event
        IronSourceEvents.onSdkInitializationCompletedEvent += SdkInitializationCompletedEvent;

        // Register Interstitial AdInfo events
        IronSourceInterstitialEvents.onAdReadyEvent += InterstitialOnAdReadyEvent;
        IronSourceInterstitialEvents.onAdLoadFailedEvent += InterstitialOnAdLoadFailed;
        IronSourceInterstitialEvents.onAdOpenedEvent += InterstitialOnAdOpenedEvent;
        IronSourceInterstitialEvents.onAdClickedEvent += InterstitialOnAdClickedEvent;
        IronSourceInterstitialEvents.onAdShowSucceededEvent += InterstitialOnAdShowSucceededEvent;
        IronSourceInterstitialEvents.onAdShowFailedEvent += InterstitialOnAdShowFailedEvent;
        IronSourceInterstitialEvents.onAdClosedEvent += InterstitialOnAdClosedEvent;
    }

    void OnApplicationPause(bool isPaused)
    {
        // Handle application pause/resume
        IronSource.Agent.onApplicationPause(isPaused);
    }

    private void SdkInitializationCompletedEvent()
    {
        Debug.Log("IronSource SDK Initialization Completed");
        //IronSource.Agent.launchTestSuite();
        IronSource.Agent.loadInterstitial();
    }

    /************* Interstitial AdInfo Delegates *************/
    void InterstitialOnAdReadyEvent(IronSourceAdInfo adInfo)
    {
        Debug.Log("Interstitial Ad Ready");

    }

    void InterstitialOnAdLoadFailed(IronSourceError ironSourceError)
    {
        Debug.LogError("Interstitial Ad Load Failed: " + ironSourceError.getDescription());
    }

    void InterstitialOnAdOpenedEvent(IronSourceAdInfo adInfo)
    {
        Debug.Log("Interstitial Ad Opened");
    }

    void InterstitialOnAdClickedEvent(IronSourceAdInfo adInfo)
    {
        Debug.Log("Interstitial Ad Clicked");
    }

    void InterstitialOnAdShowFailedEvent(IronSourceError ironSourceError, IronSourceAdInfo adInfo)
    {
        Debug.LogError("Interstitial Ad Show Failed: " + ironSourceError.getDescription());
    }

    void InterstitialOnAdClosedEvent(IronSourceAdInfo adInfo)
    {
        Debug.Log("Interstitial Ad Closed");
    }

    void InterstitialOnAdShowSucceededEvent(IronSourceAdInfo adInfo)
    {
        Debug.Log("Interstitial Ad Show Succeeded");
    }

    void HandleLooseState()
    {
        Debug.Log("Loose state triggered. Handling ads...");

        IronSource.Agent.showInterstitial();
    }
}

