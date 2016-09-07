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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.House);            
        }
    }
}