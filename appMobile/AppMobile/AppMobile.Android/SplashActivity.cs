using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AppMobile.Droid
{
    [Activity(Label = "Empresa RULO", Theme = "@style/splashscreen", MainLauncher = true, NoHistory = true)]
    //[Activity(Label = "SplashActivity")]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnResume();
            StartActivity(typeof(MainActivity));
            // Create your application here
        }
    }
}