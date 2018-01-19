using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;

namespace FirstApp
{
    [Activity(Label = "FirstApp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        private int[] array;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            array = new int[]{
                Resource.Color.bleu_marine,
                Resource.Color.rose,
                Resource.Color.vert,
                Resource.Color.violet
            };

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);

            View background = FindViewById(Resource.Id.background);

            button.Click += delegate { 
                button.Text = $"{count++} clicks!";
                background.SetBackgroundResource(array[(count-1)%array.Length]);
            };
        }
    }
}

