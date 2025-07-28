using System.Collections.Generic;
using Facebook.Unity;
using Playbox.Consent;
using Playbox.SdkConfigurations;
using UnityEngine;

namespace Playbox
{
    public class FacebookSdkInitialization : PlayboxBehaviour
    {
        private void InitParameters()
        {
            FB.Mobile.SetAdvertiserIDCollectionEnabled(true);
            FB.Mobile.SetAutoLogAppEventsEnabled(true);
            FB.Mobile.SetAdvertiserTrackingEnabled(ConsentData.ATE);
        }

        public override void Initialization()
        {
            base.Initialization();
            
            FacebookSdkConfiguration.LoadJsonConfig();
            
            if(!FacebookSdkConfiguration.Active)
                return;
            
            if (FB.IsInitialized)
            {
                FB.ActivateApp();
                InitParameters();
            }
            else
            {
                FB.Init(FacebookSdkConfiguration.AppID,
                    FacebookSdkConfiguration.ClientToken,
                    true,
                    true,
                    true,
                    false,
                    true,
                    null,
                    "en_US",
                    null,
                    OnInitCallback);
            }
            
        }

        private void OnInitCallback()
        {
            if (FB.IsInitialized)
            {
                FB.ActivateApp();
                InitParameters();
                
                ApproveInitialization();
            }
            else
            {
                Analytics.TrackEvent("Facebook", new List<KeyValuePair<string, string>>{
                    new("type","Error of Initializing"),
                    new("app identifier",Application.identifier)
                });
            }
        }

    }
}