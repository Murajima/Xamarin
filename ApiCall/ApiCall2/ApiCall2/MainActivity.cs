using Android.App;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System;
using System.Json;
using System.Net;
using System.IO;

namespace ApiCall2
{
    [Activity(Label = "ApiCall2", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        private EditText etVille;
        private Button button;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            etVille = FindViewById<EditText>(Resource.Id.editText);
            button = FindViewById<Button>(Resource.Id.myButton);

            button.Click += async (sender, e) => {
                string URL = "http://api.openweathermap.org/data/2.5/weather?q=" + etVille.Text + "&APPID=8754001be4624878ec1c248f4d18e261"; 

                JsonValue json = await FetchWeatherAsync(URL);
                ParseAndDisplay(json);
            };
        }

        private async Task<JsonValue> FetchWeatherAsync(string url)
        {
            // Create an HTTP web request using the URL:
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "GET";

            // Send the request to the server and wait for the response:
            using (WebResponse response = await request.GetResponseAsync())
            {
                // Get a stream representation of the HTTP web response:
                using (Stream stream = response.GetResponseStream())
                {
                    // Use this stream to build a JSON document object:
                    JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));
                    Console.Out.WriteLine("Response: {0}", jsonDoc.ToString());

                    // Return the JSON document:
                    return jsonDoc;
                }
            }
        }

        private void ParseAndDisplay(JsonValue json)
        {
            // Get the weather reporting fields from the layout resource:
            TextView weather = FindViewById<TextView>(Resource.Id.weather);
            TextView temperature = FindViewById<TextView>(Resource.Id.temperature);
            TextView wind = FindViewById<TextView>(Resource.Id.windspeed);

            // Extract the array of name/value results for the field name "weatherObservation". 
            JsonValue weatherResults = json["weather"][0];
            JsonValue temperatureResults = json["main"];
            JsonValue windResults = json["wind"];

            // Extract the "stationName" (location string) and write it to the location TextBox:
            weather.Text = weatherResults["description"].ToString();

            // The temperature is expressed in Celsius:
            double temp = Convert.ToDouble(temperatureResults["temp"].ToString()) - 273.15;

            // Write the temperature (one decimal place) to the temperature TextBox:
            temperature.Text = String.Format("{0:F1}", temp) + "° C";

            // Get the "clouds" and "weatherConditions" strings and 
            // combine them. Ignore strings that are reported as "n/a":
            string cloudy = windResults["speed"].ToString();


            // Write the result to the conditions TextBox:
            wind.Text = cloudy + " km/h ";
        }
    }
}

