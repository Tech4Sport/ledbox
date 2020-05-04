using System.ComponentModel;
using Xamarin.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LEDboxClientExample
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        APILEDbox APILEDbox;

        public MainPage()
        {
            InitializeComponent();
            //create class to communicate on Wifi to LEDbox
            APILEDbox = new APILEDbox();
        }

        /// <summary>
        /// Run when message received
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        void ProcessMessage(object sender,JObject data)
        {
            lblResponse.Text = JsonConvert.SerializeObject (data);
        }

        async void Handle_connect(object sender, System.EventArgs e)
        {
            if (APILEDbox.connect(ip_ledbox.Text)) // connect to LEDbox
            {
                await DisplayAlert("Connection", "Connection Estabilished", "OK");

                APILEDbox.EventMessageReceived += ProcessMessage; //enable listener of messages


                //create message for get Info
                
                JObject message = new JObject();
                message["cmd"] = "Info";
                message["value"] = "";

                //Send message to LEDbox
                APILEDbox.SendMessage(message);

            }
            else
            {
                await DisplayAlert("Connection", "Error Connection", "OK");
            }
        }
    }
}
