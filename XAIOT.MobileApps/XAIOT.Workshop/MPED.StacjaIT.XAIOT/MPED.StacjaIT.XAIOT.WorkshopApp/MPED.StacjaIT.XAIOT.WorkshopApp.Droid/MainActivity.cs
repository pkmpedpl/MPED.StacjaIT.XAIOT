using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MPED.StacjaIT.XAIOT.Services.Web;
using MPED.StacjaIT.XAIOT.WorkshopApp.Droid.Utils;

namespace MPED.StacjaIT.XAIOT.WorkshopApp.Droid
{
	[Activity (Label = "MPED.StacjaIT.XAIOT.WorkshopApp.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
		}
	}
}


