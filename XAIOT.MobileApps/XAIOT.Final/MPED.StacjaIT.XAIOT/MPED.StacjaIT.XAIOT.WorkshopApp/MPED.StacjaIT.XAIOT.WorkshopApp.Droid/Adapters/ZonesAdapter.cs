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

namespace MPED.StacjaIT.XAIOT.WorkshopApp.Droid.Adapters
{
    public class ZonesAdapter : BaseAdapter<ZoneViewModel>
    {
        List<ZoneViewModel> items;
        Activity context;
        public ZonesAdapter(Activity context, List<ZoneViewModel> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override ZoneViewModel this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.CustomView, null);
            view.FindViewById<TextView>(Resource.Id.textViewName).Text = item.Name;
            return view;
        }
    }
}