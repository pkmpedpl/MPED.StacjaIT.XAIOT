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
using MPED.StacjaIT.XAIOT.WorkshopApp.Droid.Adapters;
using MPED.StacjaIT.XAIOT.WorkshopApp.Droid.Utils;

namespace MPED.StacjaIT.XAIOT.WorkshopApp.Droid
{
    [Activity(Label = "HouseActivity")]
    public class HouseActivity : Activity
    {
        ListView listViewZones;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.House);

            // Get our button from the layout resource,
            // and attach an event to it
            TextView textViewName = FindViewById<TextView>(Resource.Id.textViewName);
            textViewName.Text = GlobalVars.Building.Name;
            listViewZones = FindViewById<ListView>(Resource.Id.listViewZones);
            listViewZones.Adapter = new ZonesAdapter(this, GlobalVars.Building.Zones);
            listViewZones.ItemClick += OnListItemClick;  // to be defined
        }

        void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //var listView = sender as ListView;
            //var zone = GlobalVars.Building.Zones[e.Position];
            //Android.Widget.Toast.MakeText(this, zone.Name, Android.Widget.ToastLength.Short).Show();
            var intent = new Intent(this, typeof(ZoneActivity));
            intent.PutExtra("selectedZoneIndex", e.Position);
            StartActivity(intent);
        }
    }
}