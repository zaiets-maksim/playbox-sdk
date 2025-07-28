using System;
using System.Collections.Generic;
using Facebook.Unity;
using Playbox.Consent;
using Playbox.SdkConfigurations;
using UnityEngine;

namespace Playbox
{
    public class FacebookSdkInitialization : PlayboxBehaviour
    {

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
                
                ApproveInitialization();
            }
            else
            {
                FB_Init(() => { OnInitCallback();});
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
                FB_Error_Log();
            }
        }

        private static void FB_Error_Log()
        {
            Analytics.Events.FirebaseEvent("Facebook", $"Firebase initialization failure\n App Id: {Application.identifier}");
        }

        private static void FB_Init(Action callback)
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
                ()=> { callback?.Invoke(); });
        }
        
        private void InitParameters()
        {
            FB.Mobile.SetAdvertiserIDCollectionEnabled(true);
            FB.Mobile.SetAutoLogAppEventsEnabled(true);
            FB.Mobile.SetAdvertiserTrackingEnabled(ConsentData.ATE);
        }
        
        private void OnApplicationPause(bool pauseStatus)
        {
            Debug.Log($"Active {pauseStatus}");
            
            if (!pauseStatus) {
              
                if (FB.IsInitialized) {
                    FB.ActivateApp();
                    
                    InitParameters();
                } else {
                    
                    FB_Init( () => {

                        if (!FB.IsInitialized)
                        {
                            FB_Error_Log();
                            return;
                        }

                        FB.ActivateApp();
                        InitParameters();
                    });
                }
            }
        }
        
        private void OnApplicationFocus(bool Focus)
        {
            Debug.Log($"Focus {Focus}");
            
            if (Focus) {
              
                if (FB.IsInitialized) {
                    FB.ActivateApp();
                    
                    InitParameters();
                } else {
                    
                    FB_Init( () => {

                        if (!FB.IsInitialized)
                        {
                            FB_Error_Log();
                            return;
                        }

                        FB.ActivateApp();
                        InitParameters();
                        
                            
                    });
                }
            }
        }

    }
}