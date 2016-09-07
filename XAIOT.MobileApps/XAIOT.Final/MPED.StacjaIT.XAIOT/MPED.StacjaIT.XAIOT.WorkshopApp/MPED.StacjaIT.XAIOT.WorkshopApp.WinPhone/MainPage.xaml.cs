using MPED.StacjaIT.XAIOT.Services.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace MPED.StacjaIT.XAIOT.WorkshopApp.WinPhone
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private AccountWebService _accountWebService = null;
        private BuildingWebService _buildingWebService = null;

        public MainPage()
        {
            this.InitializeComponent();
            this.InitializeCustom();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        private void InitializeCustom()
        {
            _accountWebService = new AccountWebService();
            _buildingWebService = new BuildingWebService();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            LoginTextBox.Text = "stacjait@mped.stacjait.pl";
            PasswordBox.Password = "StacjaIt.1";
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.Token = await _accountWebService.GetToken(LoginTextBox.Text, PasswordBox.Password);                
                App.Building = await _buildingWebService.FindBuildingFullData(App.Token.access_token, new Guid("1888561c-950b-41f3-9963-ddbeceb4da22"));
                Frame.Navigate(typeof(HousePage));
            }
            catch (HttpRequestException)
            {
                ErrorTextBlock.Text = "Przesłane dane są niepoprawne."; 
            }
        }
    }
}
