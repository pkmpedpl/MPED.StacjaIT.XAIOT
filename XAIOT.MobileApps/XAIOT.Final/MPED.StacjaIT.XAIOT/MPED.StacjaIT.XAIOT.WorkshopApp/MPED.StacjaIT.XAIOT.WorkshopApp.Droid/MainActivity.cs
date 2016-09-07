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
        private AccountWebService _accountWebService = null;
        private BuildingWebService _buildingWebService = null;

        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
            InitCustom();

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button> (Resource.Id.buttonLogin);
            EditText loginText = FindViewById<EditText>(Resource.Id.editTextLogin);
            EditText passwordText = FindViewById<EditText>(Resource.Id.editTextPassword);

            loginText.Text = "stacjait@mped.stacjait.pl";
            passwordText.Text = "StacjaIt.1";

            button.Click += async delegate {
                try
                {
                    GlobalVars.Token = await _accountWebService.GetToken(loginText.Text, passwordText.Text);
                    GlobalVars.Building = await _buildingWebService.FindBuildingFullData(GlobalVars.Token.access_token, new Guid("1888561c-950b-41f3-9963-ddbeceb4da22"));
                    var intent = new Intent(this, typeof(HouseActivity));
                    StartActivity(intent);
                }
                catch
                {
                    Android.Widget.Toast.MakeText(this, "Podane dane są nieprawidłowe.", Android.Widget.ToastLength.Short).Show();
                }
            };
		}

        private void InitCustom()
        {
            _accountWebService = new AccountWebService();
            _buildingWebService = new BuildingWebService();
        }
	}
}


