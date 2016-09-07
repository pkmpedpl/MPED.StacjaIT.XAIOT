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
using MPED.StacjaIT.XAIOT.WorkshopApp.Droid.Utils;
using MPED.StacjaIT.XAIOT.WorkshopApp.Droid.Adapters;
using MPED.StacjaIT.XAIOT.Models.ViewModels;

namespace MPED.StacjaIT.XAIOT.WorkshopApp.Droid
{
    [Activity(Label = "ZoneActivity")]
    public class ZoneActivity : Activity
    {
        ListView listViewZones;
        ZoneViewModel zone;
        int selectedZoneIndex;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.House);

            selectedZoneIndex = Intent.Extras.GetInt("selectedZoneIndex");
            zone = GlobalVars.Building.Zones[selectedZoneIndex];

            // Get our button from the layout resource,
            // and attach an event to it
            TextView textViewName = FindViewById<TextView>(Resource.Id.textViewName);
            textViewName.Text = zone.Name;
            listViewZones = FindViewById<ListView>(Resource.Id.listViewZones);
            listViewZones.Adapter = new ControlCircuitsAdapter(this, zone.ControlCircuits);
            listViewZones.ItemClick += OnListItemClick;  // to be defined
        }

        void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {            
            var intent = new Intent(this, typeof(ControlCircuitActivity));
            intent.PutExtra("selectedZoneIndex", selectedZoneIndex);
            intent.PutExtra("selectedControlCircuitIndex", e.Position);
            StartActivity(intent);
        }
    }
}