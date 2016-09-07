using MPED.StacjaIT.XAIOT.Models.Tasks.InputData;
using MPED.StacjaIT.XAIOT.Models.ViewModels;
using MPED.StacjaIT.XAIOT.Services.Web;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace MPED.StacjaIT.XAIOT.WorkshopApp.WinPhone
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ControlCircuitPage : Page
    {
        private BuildingWebService _buildingWebService = null;
        private SystemTasksWebService _systemTasksWebService = null;
        public ControlCircuitPage()
        {
            this.InitializeComponent();
            _buildingWebService = new BuildingWebService();
            _systemTasksWebService = new SystemTasksWebService();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataContext = e.Parameter;
        }

        private void BackButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

        private async void TurnOnButton_Click(object sender, RoutedEventArgs e)
        {
            ControlCircuitViewModel controlCircuitViewModel = DataContext as ControlCircuitViewModel;
            if (controlCircuitViewModel != null && controlCircuitViewModel.I2CSlaveAddress == "0x40")
            {
                await _systemTasksWebService.PostSystemTask(App.Token.access_token, new Models.Tasks.SystemTask() { CreatedOn = DateTime.Now, Id = Guid.NewGuid(), InputData = JsonConvert.SerializeObject(new DeviceBasicInputData() { ControlCircuit = "0x40", DevicePin = 24, ZoneId = new Guid("835dfb35-479c-49d6-ad06-fd8f083b7f99") }), Name = "TurnOnDevice", Status = 1, Type = 1, UpdatedOn = DateTime.Now });
            }
            else
            {                
                MessageDialog msgbox = new MessageDialog("Sterownik nie posiada tego typu urządzenia.");
                await msgbox.ShowAsync();
            }
        }

        private async void TurnOffButton_Click(object sender, RoutedEventArgs e)
        {
            ControlCircuitViewModel controlCircuitViewModel = DataContext as ControlCircuitViewModel;
            if (controlCircuitViewModel != null && controlCircuitViewModel.I2CSlaveAddress == "0x40")
            {
                await _systemTasksWebService.PostSystemTask(App.Token.access_token, new Models.Tasks.SystemTask() { CreatedOn = DateTime.Now, Id = Guid.NewGuid(), InputData = JsonConvert.SerializeObject(new DeviceBasicInputData() { ControlCircuit = "0x40", DevicePin = 24, ZoneId = new Guid("835dfb35-479c-49d6-ad06-fd8f083b7f99") }), Name = "TurnOffDevice", Status = 1, Type = 2, UpdatedOn = DateTime.Now });
            }
            else
            {
                MessageDialog msgbox = new MessageDialog("Sterownik nie posiada tego typu urządzenia.");
                await msgbox.ShowAsync();
            }
        }

        private async void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            ControlCircuitViewModel controlCircuitViewModel = DataContext as ControlCircuitViewModel;
            if (controlCircuitViewModel != null)
            {
                App.Building = await _buildingWebService.FindBuildingFullData(App.Token.access_token, new Guid("1888561c-950b-41f3-9963-ddbeceb4da22"));
                DataContext = App.Building.Zones.SelectMany(q => q.ControlCircuits).FirstOrDefault(q => q.Id == controlCircuitViewModel.Id);
            }
        }
    }
}
