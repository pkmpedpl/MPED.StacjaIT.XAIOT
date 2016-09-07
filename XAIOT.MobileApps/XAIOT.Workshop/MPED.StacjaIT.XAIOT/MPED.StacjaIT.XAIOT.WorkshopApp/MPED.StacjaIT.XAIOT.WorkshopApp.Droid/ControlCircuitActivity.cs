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
using MPED.StacjaIT.XAIOT.Models.ViewModels;
using MPED.StacjaIT.XAIOT.WorkshopApp.Droid.Utils;
using MPED.StacjaIT.XAIOT.Services.Web;
using Newtonsoft.Json;
using MPED.StacjaIT.XAIOT.Models.Tasks.InputData;

namespace MPED.StacjaIT.XAIOT.WorkshopApp.Droid
{
    [Activity(Label = "ControlCircuitActivity")]
    public class ControlCircuitActivity : Activity
    {        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ControlCircuit);            
        }
    }
}