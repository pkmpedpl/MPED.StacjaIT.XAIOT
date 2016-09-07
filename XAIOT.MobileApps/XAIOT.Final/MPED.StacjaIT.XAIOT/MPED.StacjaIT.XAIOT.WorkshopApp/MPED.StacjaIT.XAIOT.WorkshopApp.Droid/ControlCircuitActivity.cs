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
        ControlCircuitViewModel controlCircuit;
        int selectedZoneIndex;
        int selectedControlCircuitIndex;
        TextView textViewName;
        TextView textViewHumidity;
        TextView textViewTemperature;
        TextView textViewLux;
        TextView textViewPIR;
        BuildingWebService _buildingWebService;
        SystemTasksWebService _systemTasksWebService;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ControlCircuit);

            _buildingWebService = new BuildingWebService();
            _systemTasksWebService = new SystemTasksWebService();

            selectedZoneIndex = Intent.Extras.GetInt("selectedZoneIndex");
            selectedControlCircuitIndex = Intent.Extras.GetInt("selectedControlCircuitIndex");
            controlCircuit = GlobalVars.Building.Zones[selectedZoneIndex].ControlCircuits[selectedControlCircuitIndex];

            textViewName = FindViewById<TextView>(Resource.Id.textViewName);
            textViewHumidity = FindViewById<TextView>(Resource.Id.textViewHumidity);
            textViewTemperature = FindViewById<TextView>(Resource.Id.textViewTemperature);
            textViewLux = FindViewById<TextView>(Resource.Id.textViewLux);
            textViewPIR = FindViewById<TextView>(Resource.Id.textViewPIR);

            Button buttonTurnOn = FindViewById<Button>(Resource.Id.buttonTurnOn);
            Button buttonTurnOff = FindViewById<Button>(Resource.Id.buttonTurnOff);
            Button buttonRefresh = FindViewById<Button>(Resource.Id.buttonRefresh);

            SetValues();

            buttonTurnOn.Click += async delegate {               
                if (controlCircuit.I2CSlaveAddress == "0x40")
                {
                    await _systemTasksWebService.PostSystemTask(GlobalVars.Token.access_token, new Models.Tasks.SystemTask() { CreatedOn = DateTime.Now, Id = Guid.NewGuid(), InputData = JsonConvert.SerializeObject(new DeviceBasicInputData() { ControlCircuit = "0x40", DevicePin = 24, ZoneId = new Guid("835dfb35-479c-49d6-ad06-fd8f083b7f99") }), Name = "TurnOnDevice", Status = 1, Type = 1, UpdatedOn = DateTime.Now });
                }
                else
                {                    
                    Android.Widget.Toast.MakeText(this, "Sterownik nie posiada tego typu urz¹dzenia.", Android.Widget.ToastLength.Short).Show();
                }
            };

            buttonTurnOff.Click += async delegate
            {                
                if(controlCircuit.I2CSlaveAddress == "0x40")
                {
                    await _systemTasksWebService.PostSystemTask(GlobalVars.Token.access_token, new Models.Tasks.SystemTask() { CreatedOn = DateTime.Now, Id = Guid.NewGuid(), InputData = JsonConvert.SerializeObject(new DeviceBasicInputData() { ControlCircuit = "0x40", DevicePin = 24, ZoneId = new Guid("835dfb35-479c-49d6-ad06-fd8f083b7f99") }), Name = "TurnOffDevice", Status = 1, Type = 2, UpdatedOn = DateTime.Now });
                }
                else
                {
                    Android.Widget.Toast.MakeText(this, "Sterownik nie posiada tego typu urz¹dzenia.", Android.Widget.ToastLength.Short).Show();
                }
            };

            buttonRefresh.Click += async delegate {
                GlobalVars.Building = await _buildingWebService.FindBuildingFullData(GlobalVars.Token.access_token, new Guid("1888561c-950b-41f3-9963-ddbeceb4da22"));
                controlCircuit = GlobalVars.Building.Zones[selectedZoneIndex].ControlCircuits[selectedControlCircuitIndex];
                SetValues();
                Android.Widget.Toast.MakeText(this, "Dane zosta³y zaktualizowane.", Android.Widget.ToastLength.Short).Show();
            };
        }

        private void SetValues()
        {
            textViewName.Text = controlCircuit.Name;
            textViewHumidity.Text = controlCircuit.SensorHumidity.HasValue ? controlCircuit.SensorHumidity.Value.ToString() : string.Empty;
            textViewTemperature.Text = controlCircuit.SensorTemperature.HasValue ? controlCircuit.SensorTemperature.Value.ToString() : string.Empty;
            textViewLux.Text = controlCircuit.SensorLux.HasValue ? controlCircuit.SensorLux.Value.ToString() : string.Empty;
            textViewPIR.Text = controlCircuit.SensorPIR.HasValue ? controlCircuit.SensorPIR.Value.ToString() : string.Empty;
        }
    }
}