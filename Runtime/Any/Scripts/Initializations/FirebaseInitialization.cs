using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Playbox
{
    public class FirebaseInitialization : PlayboxBehaviour
    {
        public override void Initialization()
        {
            base.Initialization();
            
            InitializeCrashlytics();
 
        }

        public void InitializeCrashlytics()
        {
            
        }

        private void Init()
        {
            ApproveInitialization();
        }
    }
}
