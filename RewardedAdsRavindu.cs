using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api; ///Admob package
using System.ComponentModel;
using System; ///To avoid EventArgs failures

public class RewardedAdsRavindu : MonoBehaviour
{
    public static BonusAdsOneEon instance; ///To reference the script from outside


    private RewardedAd rewardedAd;
    private string RewardAD = "ca-app-pub-3940256099942544/5224354917"; ///PUT YOUR BONUS AD ID HERE


    /// To Avoid Crashes
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        MobileAds.Initialize(initStatus => { });

        rewardedAd = new RewardedAd(RewardAD);

        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        RequestRewardedAd();
    }

    public void RequestRewardedAd() ///TO LOAD THE AD
    {
        AdRequest request = new AdRequest.Builder().Build();

        rewardedAd.LoadAd(request);
    }

    public void ShowRewardedAd() ///TO SHOW THE AD, IT MUST HAVE BEEN PREVIOUSLY LOADED FIRST
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
        else
        {
            {
                Debug.Log("Ad not Loaded");
            }
        }
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
        ///PUT THE REWARD HERE

    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
        RequestRewardedAd();

    }
}


