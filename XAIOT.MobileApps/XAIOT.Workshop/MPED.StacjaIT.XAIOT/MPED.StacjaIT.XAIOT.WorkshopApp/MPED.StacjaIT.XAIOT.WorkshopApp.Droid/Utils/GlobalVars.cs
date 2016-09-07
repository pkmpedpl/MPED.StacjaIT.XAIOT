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
using MPED.StacjaIT.XAIOT.Models;
using MPED.StacjaIT.XAIOT.Models.ViewModels;

namespace MPED.StacjaIT.XAIOT.WorkshopApp.Droid.Utils
{
    public static class GlobalVars
    {
        public static UserAccountToken Token { get; set; }
        public static BuildingViewModel Building { get; set; }
    }
}